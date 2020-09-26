using System;

namespace ClipSE
{
	// Token: 0x0200000F RID: 15
	public static class ExpSetting
	{
		// Token: 0x06000030 RID: 48 RVA: 0x0000301C File Offset: 0x0000121C
		public static void RefreshExplorer()
		{
			IntPtr intPtr = NativeMethods.FindWindow("Progman", "Program Manager");
			intPtr = NativeMethods.FindWindowEx(intPtr, IntPtr.Zero, "SHELLDLL_DefView", null);
			intPtr = NativeMethods.FindWindowEx(intPtr, IntPtr.Zero, "SysListView32", null);
			NativeMethods.PostMessage(intPtr, 256, new IntPtr(116), IntPtr.Zero);
			NativeMethods.PostMessage(intPtr, 257, new IntPtr(116), new IntPtr(int.MinValue));
		}
	}
}
