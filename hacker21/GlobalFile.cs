using System;
using System.IO;

namespace ClipSE
{
	// Token: 0x0200001B RID: 27
	public static class GlobalFile
	{
		// Token: 0x06000054 RID: 84 RVA: 0x00004204 File Offset: 0x00002404
		public static bool IsHideOrNo()
		{
			bool result;
			try
			{
				if (File.GetAttributes(GlobalPath.AssemblyPath).HasFlag(FileAttributes.Hidden))
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000424C File Offset: 0x0000244C
		public static void HideFile(string path, FileAttributes attributes)
		{
			try
			{
				File.SetAttributes(path, attributes);
			}
			catch (Exception)
			{
			}
		}
	}
}
