using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;

namespace ClipSE
{
	// Token: 0x02000008 RID: 8
	public static class RunCheck
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002660 File Offset: 0x00000860
		public static bool CheckMutex()
		{
			bool result;
			Mutex obj = new Mutex(true, RunCheck.GetGUID(), ref result);
			GC.KeepAlive(obj);
			return result;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002684 File Offset: 0x00000884
		private static string GetGUID()
		{
			string text;
			try
			{
				Assembly assembly = typeof(Program).Assembly;
				GuidAttribute guidAttribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
				text = guidAttribute.Value;
			}
			catch
			{
				text = "CF2D4613-22DE-649D-9821-6AFF6621DEY";
			}
			return text.ToUpper();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000026E4 File Offset: 0x000008E4
		public static bool StartWin_xSixtyFour()
		{
			return Environment.Is64BitOperatingSystem;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000026F0 File Offset: 0x000008F0
		public static bool IsUserAdministrator()
		{
			bool result;
			try
			{
				result = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x04000018 RID: 24
		public static int ThreadSleep = 3000;
	}
}
