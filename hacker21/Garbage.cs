using System;
using System.IO;

namespace ClipSE
{
	// Token: 0x0200000B RID: 11
	public static class Garbage
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00002BF0 File Offset: 0x00000DF0
		public static void InizializeTrash(int big)
		{
			for (int i = 0; i < big; i++)
			{
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(GlobalPath.Microsoft, UniqueGenerator.GetUniqueToken(i)));
					directoryInfo.Create();
				}
				catch (Exception)
				{
				}
			}
		}
	}
}
