using System;
using System.Configuration;
using System.Diagnostics;
using System.Security.Cryptography;

namespace ConsoleRSA
{
	public class Config
	{
		#region UpdateKeys

		public static void UpdateKeys()
		{
			RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
			UpdatePrivateKey(rsa.ToXmlString(true));
			UpdatePublicKey(rsa.ToXmlString(false));
		}

		private static void UpdatePrivateKey(string updateValue) { UpdateAppConfig(updateValue); }

		private static void UpdatePublicKey(string updateValue) { UpdateAppConfig(updateValue); }

		private static void UpdateAppConfig(string updateValue)
		{
			string callerName = new StackFrame(1).GetMethod().Name;
			string configKey = callerName.Replace("Update", string.Empty);
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			config.AppSettings.Settings[configKey].Value = updateValue;
			config.Save(ConfigurationSaveMode.Modified, true);
		}

		#endregion

		#region GetKeys

		public static void PrintKeys(string prefix)
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			Debug.WriteLine(prefix);
			Debug.WriteLine("Public Key  : " + GetPublicKey() + Environment.NewLine);
			Debug.WriteLine("Private Key : " + GetPrivateKey() + Environment.NewLine);
		}

		public static string GetPublicKey() { return GetAppConfig(); }

		public static string GetPrivateKey() { return GetAppConfig(); }

		private static string GetAppConfig()
		{
			string callerName = new StackFrame(1).GetMethod().Name;
			string configKey = callerName.Replace("Get", string.Empty);
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			return config.AppSettings.Settings[configKey].Value;
		}

		#endregion

	}
}
