using System;
using System.Runtime.InteropServices;

namespace ClipSE
{
	// Token: 0x0200000D RID: 13
	internal static class NativeMethods
	{
		// Token: 0x0600001B RID: 27
		[DllImport("user32.dll")]
		internal static extern IntPtr GetClipboardData(uint uFormat);

		// Token: 0x0600001C RID: 28
		[DllImport("user32.dll")]
		public static extern bool IsClipboardFormatAvailable(uint format);

		// Token: 0x0600001D RID: 29
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool OpenClipboard(IntPtr hWndNewOwner);

		// Token: 0x0600001E RID: 30
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool CloseClipboard();

		// Token: 0x0600001F RID: 31
		[DllImport("user32.dll")]
		internal static extern bool EmptyClipboard();

		// Token: 0x06000020 RID: 32
		[DllImport("kernel32.dll")]
		internal static extern IntPtr GlobalLock(IntPtr hMem);

		// Token: 0x06000021 RID: 33
		[DllImport("kernel32.dll")]
		public static extern bool GlobalUnlock(IntPtr hMem);

		// Token: 0x06000022 RID: 34
		[DllImport("user32.dll")]
		internal static extern IntPtr GetOpenClipboardWindow();

		// Token: 0x06000023 RID: 35
		[DllImport("user32.dll")]
		internal static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

		// Token: 0x06000024 RID: 36
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

		// Token: 0x06000025 RID: 37
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

		// Token: 0x06000026 RID: 38
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

		// Token: 0x06000027 RID: 39
		[DllImport("user32")]
		public static extern int PostMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x06000028 RID: 40
		[DllImport("user32", CharSet = CharSet.Unicode)]
		internal static extern IntPtr FindWindow(string className, string caption);

		// Token: 0x06000029 RID: 41
		[DllImport("user32", CharSet = CharSet.Unicode)]
		internal static extern IntPtr FindWindowEx(IntPtr parent, IntPtr startChild, string className, string caption);

		// Token: 0x0600002A RID: 42
		[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode)]
		internal static extern IntPtr GetModuleHandle(string lpModuleName);
	}
}
