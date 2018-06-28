using System;
using System.Configuration;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleRSA
{
	enum WorkEnum
	{
		UpdateKeys,
		PrintStatus
	}

	class Program
	{
		static void Main(string[] args)
		{

			Config.UpdateKeys();
			//Config.PrintKeys("**************************");
			string a = 
				@"Everipedia, Inc. (ev-ree-PEE-dee-a) is a technology company​ located in the Westwood Village​ neighborhood of Los Angeles, California​​.​ It is best known for its online encyclopedia, Everipedia,​ which aims to use blockchain technology to reward users with cryptocurrency​. These users curate and submit content to its database (the Everipedia Network) and get rewarded in the form of IQ tokens.
Everipedia's encyclopedia is recognized as the largest English online encyclopedia, with over 6 million articles, including all articles from the English Wikipedia​. It has been labeled as an 'fork' and 'expansion pack​' to Wikipedia, as it provides a significantly larger range of articles than the English Wikipedia​. This is due to Everipedia's lower threshold for notability and emphasis on inclusive criteria.[98]​[101]​
Everipedia's name is a portmanteau​ of the English words 'everything' and 'encyclopedia.'[98]​
The concept of Everipedia originated in December 2014 and launched in 2015. It was founded by Sam Kazemian​, Theodor Forselius, Mahbod Moghadam​, and Travis Moore​. Kazemian serves as President​, Forselius serves as CEO​, Moghadam serves as CCO​, and Moore serves as CTO. Larry Sanger​, the co-founder of Wikipedia, joined the company as CIO​ in December 2017.[90]";
			
			//Base64 base64 = new Base64(a);
			//Base64 base64_2 = new Base64(base64.Bytes);
			//Base64 base64_3 = new Base64(base64.String);
			////Base64 base64A1 = Crypto.EncryptRSAToBase64(a);
			////string a2 = Crypto.DecryptRSAFromBase64(new Base64( base64A1.Value));

			//Base64 base64_A1 = new Base64(Crypto.EncryptRSA(base64.Bytes));
			//Debug.WriteLine(base64_A1.Value);
			//Base64 base64_A2 = new Base64(Crypto.DecryptRSA(base64_A1.Bytes));
			//Debug.WriteLine(base64_A2.String);

			Base64 base64_A4_1 = Crypto.EncryptRSAToBase64(a);
			string base64_A4_2 = Crypto.DecryptRSAFromBase64(base64_A4_1);
			Debug.WriteLine(base64_A4_2);
		}
	}
}