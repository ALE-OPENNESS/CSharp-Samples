/*
* Copyright 2021 ALE International
*
* Permission is hereby granted, free of charge, to any person obtaining a copy of this 
* software and associated documentation files (the "Software"), to deal in the Software 
* without restriction, including without limitation the rights to use, copy, modify, merge, 
* publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons 
* to whom the Software is furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all copies or 
* substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING 
* BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
* NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
* DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoutingAppTest
{
    internal class LoginFormData
    {
        public string ServerAddress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

	internal class Cipher
    {
		private readonly static string Key = "13459872654241498765243132525525";

		public static string Encrypt(string text)
		{
			var b = Encoding.UTF8.GetBytes(text);
			var encrypted = getAes().CreateEncryptor().TransformFinalBlock(b, 0, b.Length);
			return Convert.ToBase64String(encrypted);
		}

		public static string Decrypt(string encrypted)
		{
			var b = Convert.FromBase64String(encrypted);
			var decrypted = getAes().CreateDecryptor().TransformFinalBlock(b, 0, b.Length);
			return Encoding.UTF8.GetString(decrypted);
		}

		static Aes getAes()
		{
			var keyBytes = new byte[16];
			var skeyBytes = Encoding.UTF8.GetBytes(Key);
			Array.Copy(skeyBytes, keyBytes, Math.Min(keyBytes.Length, skeyBytes.Length));

			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			aes.KeySize = 128;
			aes.Key = keyBytes;
			aes.IV = keyBytes;

			return aes;
		}
	}


	internal class JsonConfigFile
    {
		private static readonly string ConfigFileName = "config.json";

		private static string GetFilename()
        {
			string appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AppTest");
			Directory.CreateDirectory(appPath);

			return Path.Combine(appPath, ConfigFileName);
		}

		protected static JsonSerializerOptions serializeOptions = new JsonSerializerOptions
		{
			WriteIndented = true,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			Converters = {
				new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
			}
		};
		
		public static LoginFormData Load()
        {
			try
			{
				StreamReader stream = new StreamReader(GetFilename());
				string json = stream.ReadToEnd();
				stream.Close();

				LoginFormData data = JsonSerializer.Deserialize<LoginFormData>(json, serializeOptions);
				data.Password = Cipher.Decrypt(data.Password);

				return data;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static void Save(LoginFormData data)
        {
			data.Password = Cipher.Encrypt(data.Password);
			var json = JsonSerializer.Serialize(data, serializeOptions);

			try
			{
				StreamWriter stream = new StreamWriter(GetFilename());
				stream.Write(json);
				stream.Close();
			}
			catch (Exception)
            {
				// Do nothing
            }
		}


	}
}
