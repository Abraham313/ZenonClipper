using System;
using System.Runtime.InteropServices;

namespace ClipSE
{
	// Token: 0x02000014 RID: 20
	internal static class ClipboardEx
	{
		// Token: 0x06000033 RID: 51 RVA: 0x00003240 File Offset: 0x00001440
		public static string GetText()
		{
			if (NativeMethods.IsClipboardFormatAvailable(13U) && NativeMethods.OpenClipboard(IntPtr.Zero))
			{
				string result = null;
				IntPtr clipboardData = NativeMethods.GetClipboardData(13U);
				if (!clipboardData.Equals(IntPtr.Zero))
				{
					IntPtr intPtr = NativeMethods.GlobalLock(clipboardData);
					if (!intPtr.Equals(IntPtr.Zero))
					{
						try
						{
							result = Marshal.PtrToStringUni(intPtr);
							NativeMethods.GlobalUnlock(intPtr);
						}
						catch
						{
						}
					}
				}
				NativeMethods.CloseClipboard();
				return result;
			}
			return null;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000032D4 File Offset: 0x000014D4
		public static bool SetClipboardText(string Text)
		{
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(Text);
			if (!intPtr.Equals(IntPtr.Zero) && NativeMethods.OpenClipboard(IntPtr.Zero))
			{
				NativeMethods.EmptyClipboard();
				if (!(NativeMethods.SetClipboardData(1U, intPtr) != IntPtr.Zero))
				{
					Marshal.FreeHGlobal(intPtr);
				}
				NativeMethods.CloseClipboard();
				return true;
			}
			return false;
		}

		// Token: 0x04000050 RID: 80
		private const uint CF_UNICODETEXT = 13U;

		// Token: 0x04000051 RID: 81
		private const int UF = 1;
	}
}
