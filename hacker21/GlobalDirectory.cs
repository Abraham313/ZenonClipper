using System;
using System.IO;

namespace ClipSE
{
	// Token: 0x0200001A RID: 26
	public static class GlobalDirectory
	{
		// Token: 0x06000053 RID: 83 RVA: 0x000041C0 File Offset: 0x000023C0
		public static bool CreateDirectory(string path)
		{
			bool result;
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(path);
				directoryInfo.Create();
				directoryInfo.Refresh();
				directoryInfo.Attributes = (FileAttributes.Hidden | FileAttributes.Directory);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}
