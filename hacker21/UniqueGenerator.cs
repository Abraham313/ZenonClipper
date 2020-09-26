using System;
using System.Security.Cryptography;

namespace ClipSE
{
	// Token: 0x0200000A RID: 10
	public static class UniqueGenerator
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002B20 File Offset: 0x00000D20
		public static string GetUniqueToken(int length)
		{
			string result;
			try
			{
				using (RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider())
				{
					byte[] array = null;
					byte[] array2 = new byte[length];
					int num = 255 - 256 % "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_".Length;
					rngcryptoServiceProvider.GetBytes(array2);
					char[] array3 = new char[length];
					for (int i = 0; i < length; i++)
					{
						byte b = array2[i];
						while ((int)b > num)
						{
							if (array == null)
							{
								array = new byte[1];
							}
							rngcryptoServiceProvider.GetBytes(array);
							b = array[0];
						}
						array3[i] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_"[(int)b % "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_".Length];
					}
					result = new string(array3);
				}
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x0400001B RID: 27
		private const string Key = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_";
	}
}
