using System;
using System.Text;

namespace TI_Lab_2
{
	class Program
	{
		static void Main(string[] args)
		{
			Key key = new Key();
			key.CreateKeys();

			long[] data;
			string plainText;

			plainText = "ALESYA";
			data = FromString(plainText);

			RSA.Encrypt(ref data, key.PublicKey, key.Module);
			string encryptedText = ToString(data);
			RSA.Encrypt(ref data, key.PrivateKey, key.Module);
			string decryptedText = FromArray(data);

			Console.WriteLine("Plain text:     " + plainText);
			Console.WriteLine("Encrypted text: " + encryptedText);
			Console.WriteLine("Decrypted text: " + decryptedText);

			Console.ReadLine();
		}

		public static long[] FromString(string text)
		{
			long[] array = new long[text.Length];

			for (int i = 0; i < text.Length; i++)
			{
				array[i] = text[i];
			}

			return array;
		}

		public static string FromArray(long[] data)
		{
			StringBuilder builder = new StringBuilder(data.Length);

			for (int i = 0; i < data.Length; i++)
			{
				builder.Append((char)data[i]);
			}

			return builder.ToString();
		}

		public static string ToString(long[] data)
		{
			StringBuilder builder = new StringBuilder(data.Length);

			for (int i = 0; i < data.Length; i++)
			{
				builder.Append(data[i] + " ");
			}

			return builder.ToString();
		}
	}
}