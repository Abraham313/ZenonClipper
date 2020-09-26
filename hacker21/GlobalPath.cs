using System;
using System.IO;
using System.Reflection;

namespace ClipSE
{
	// Token: 0x02000007 RID: 7
	public static class GlobalPath
	{
		// Token: 0x0400000C RID: 12
		public static string MessageErrorTextForUser = "Test";

		// Token: 0x0400000D RID: 13
		public static readonly string DefaultTemp = Environment.GetEnvironmentVariable("temp") + '\\';

		// Token: 0x0400000E RID: 14
		public static readonly string GetFileName = Path.GetFileName(AppDomain.CurrentDomain.FriendlyName);

		// Token: 0x0400000F RID: 15
		public static readonly string GenRunNameWithoutExtension = Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName);

		// Token: 0x04000010 RID: 16
		public static readonly string AssemblyPath = Assembly.GetExecutingAssembly().Location;

		// Token: 0x04000011 RID: 17
		public static readonly string StartupPath = Path.GetDirectoryName(GlobalPath.AssemblyPath);

		// Token: 0x04000012 RID: 18
		public static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

		// Token: 0x04000013 RID: 19
		public static readonly string DesktopDir = Path.Combine(new string[]
		{
			Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
		});

		// Token: 0x04000014 RID: 20
		public static readonly string LocalAppDir = Path.Combine(new string[]
		{
			Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
		});

		// Token: 0x04000015 RID: 21
		public static readonly string BatchFile = Path.Combine(Environment.CurrentDirectory, "Self.bat");

		// Token: 0x04000016 RID: 22
		public static readonly string Microsoft = Path.Combine(GlobalPath.AppData, "Microsoft");

		// Token: 0x04000017 RID: 23
		public static readonly string StartUpFromAppDataReserv = Path.Combine(GlobalPath.AppData, "Microsoft\\SecureData");
	}
}
