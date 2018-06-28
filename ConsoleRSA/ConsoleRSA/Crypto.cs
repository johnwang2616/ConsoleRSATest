using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleRSA
{
	// chain of Convert
	// byte[] >> Base64(Value) >> string
	// byte[] << Base64(Value) << string

	public class Base64
	{
		public string Value { get; }
		public byte[] Bytes { get { return Convert.FromBase64String(this.Value); } }
		public string String { get { return Encoding.UTF8.GetString(this.Bytes); } }

		public Base64(string inputText)
		{
			byte[] inputBytes = Encoding.UTF8.GetBytes(inputText);
			this.Value = Convert.ToBase64String(inputBytes);
		}
		public Base64(byte[] inputBytes)
		{
			this.Value = Convert.ToBase64String(inputBytes);
		}
	}


	public static class Crypto
	{

		public static Base64 EncryptRSAToBase64(string plain)
		{
			Base64 plainBase64 = new Base64(plain);
			return new Base64(EncryptRSA(plainBase64.Bytes));
		}

		public static byte[] EncryptRSA(byte[] OriginalData)
		{
			if (OriginalData == null || OriginalData.Length <= 0)
			{
				throw new NotSupportedException();
			}
			RSACryptoServiceProvider rsaEncrypt = new RSACryptoServiceProvider();
			rsaEncrypt.FromXmlString(Config.GetPublicKey());

			int bufferSize = (rsaEncrypt.KeySize / 8) - 11;
			byte[] buffer = new byte[bufferSize];
			using (MemoryStream input = new MemoryStream(OriginalData))
			{
				using (MemoryStream ouput = new MemoryStream())
				{
					while (true)
					{
						int readLine = input.Read(buffer, 0, bufferSize);
						if (readLine <= 0)
						{
							break;
						}
						byte[] temp = new byte[readLine];
						Array.Copy(buffer, 0, temp, 0, readLine);
						byte[] encrypt = rsaEncrypt.Encrypt(temp, false);
						ouput.Write(encrypt, 0, encrypt.Length);
					}
					return ouput.ToArray();
				}
			}
		}

		public static string DecryptRSAFromBase64(Base64 encryptedBase64)
		{
			new Base64( DecryptRSA(encryptedBase64.Bytes));

			return new Base64(DecryptRSA(encryptedBase64.Bytes)).String;
		}

		public static byte[] DecryptRSA(byte[] EncryptDada)
		{
			if (EncryptDada == null || EncryptDada.Length <= 0)
			{
				throw new NotSupportedException();
			}

			RSACryptoServiceProvider rsaDecrypt = new RSACryptoServiceProvider();
			rsaDecrypt.FromXmlString(Config.GetPrivateKey());
			int keySize = rsaDecrypt.KeySize / 8; byte[] buffer = new byte[keySize];

			using (MemoryStream input = new MemoryStream(EncryptDada))
			{
				using (MemoryStream output = new MemoryStream())
				{
					while (true)
					{
						int readLine = input.Read(buffer, 0, keySize);
						if (readLine <= 0)
						{
							break;
						}
						byte[] temp = new byte[readLine];
						Array.Copy(buffer, 0, temp, 0, readLine);
						byte[] decrypt = rsaDecrypt.Decrypt(temp, false);
						output.Write(decrypt, 0, decrypt.Length);
					}
					return output.ToArray();
				}
			}
		}
	}
}