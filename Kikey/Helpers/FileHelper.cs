using Kikey.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Documents;

namespace Kikey.Helpers
{
    public static class FileHelper
    {
        public static bool SetEnvironment()
        {
			try
			{
				CreateRootDirectory();

				return true;
			}
			catch (Exception)
			{
				return false;
			}
        }

		public static bool SavePassword(Password password)
		{
			try
			{
				if(ExistsPassword(password))
				{
					return false;
				}

				var passwords = GetPasswords();

				if(passwords is null)
				{
					passwords = new List<Password>()
					{
						password
					};
                }
				else
				{
					passwords.Add(password);
                }

                File.WriteAllText(ConstantsHelper.PasswordFileName, JsonConvert.SerializeObject(passwords, Formatting.Indented));

                return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static List<Password> GetPasswords()
		{
			try
			{
				var passwords = File.ReadAllText(ConstantsHelper.PasswordFileName);

				if(string.IsNullOrEmpty(passwords))
				{
					return null;
				}

				return JsonConvert.DeserializeObject<List<Password>>(passwords);
			}
			catch (Exception)
			{
				return null;
			}
		}

		private static void CreateRootDirectory()
		{
            Directory.CreateDirectory(ConstantsHelper.RootPath);
        }

		public static bool ExistsPassword(Password password)
		{
			try
			{
				var passwords = GetPasswords();

				return passwords.Any(a => a.Hash.SequenceEqual(password.Hash));
			}
			catch (Exception)
			{
				return false;
			}
		}
    }
}