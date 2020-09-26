using System;
using System.Threading;
using System.Windows.Forms;

namespace ClipSE
{
	// Token: 0x02000015 RID: 21
	public static class ClipboardMonitor
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000035 RID: 53 RVA: 0x00003338 File Offset: 0x00001538
		// (remove) Token: 0x06000036 RID: 54 RVA: 0x0000336C File Offset: 0x0000156C
		internal static event ClipboardMonitor.OnClipboardChangeEventHandler OnClipboardChange;

		// Token: 0x06000037 RID: 55 RVA: 0x000033AD File Offset: 0x000015AD
		public static void Start()
		{
			ClipboardMonitor.ClipboardWatcher.Start();
			ClipboardMonitor.ClipboardWatcher.OnClipboardChange += delegate(Enums.ClipboardFormat clipboardFormat, object data)
			{
				ClipboardMonitor.OnClipboardChange(clipboardFormat, data);
			};
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000033D6 File Offset: 0x000015D6
		public static void Stop()
		{
			ClipboardMonitor.OnClipboardChange = null;
			ClipboardMonitor.ClipboardWatcher.Stop();
		}

		// Token: 0x02000016 RID: 22
		private class ClipboardWatcher : Form
		{
			// Token: 0x14000002 RID: 2
			// (add) Token: 0x0600003A RID: 58 RVA: 0x000033E4 File Offset: 0x000015E4
			// (remove) Token: 0x0600003B RID: 59 RVA: 0x00003418 File Offset: 0x00001618
			public static event ClipboardMonitor.ClipboardWatcher.OnClipboardChangeEventHandler OnClipboardChange;

			// Token: 0x0600003C RID: 60 RVA: 0x00003458 File Offset: 0x00001658
			public static void Start()
			{
				if (ClipboardMonitor.ClipboardWatcher.mInstance == null)
				{
					Thread thread = new Thread(delegate(object x)
					{
						Application.Run(new ClipboardMonitor.ClipboardWatcher());
					});
					thread.SetApartmentState(ApartmentState.STA);
					thread.Start();
				}
			}

			// Token: 0x0600003D RID: 61 RVA: 0x000034B4 File Offset: 0x000016B4
			public static void Stop()
			{
				try
				{
					ClipboardMonitor.ClipboardWatcher.mInstance.Invoke(new MethodInvoker(delegate()
					{
						NativeMethods.ChangeClipboardChain(ClipboardMonitor.ClipboardWatcher.mInstance.Handle, ClipboardMonitor.ClipboardWatcher.nextClipboardViewer);
					}));
					ClipboardMonitor.ClipboardWatcher.mInstance.Invoke(new MethodInvoker(ClipboardMonitor.ClipboardWatcher.mInstance.Close));
					ClipboardMonitor.ClipboardWatcher.mInstance.Dispose();
					ClipboardMonitor.ClipboardWatcher.mInstance = null;
				}
				catch (Exception)
				{
				}
			}

			// Token: 0x0600003E RID: 62 RVA: 0x0000352C File Offset: 0x0000172C
			protected override void SetVisibleCore(bool value)
			{
				this.CreateHandle();
				ClipboardMonitor.ClipboardWatcher.mInstance = this;
				ClipboardMonitor.ClipboardWatcher.nextClipboardViewer = NativeMethods.SetClipboardViewer(ClipboardMonitor.ClipboardWatcher.mInstance.Handle);
				base.SetVisibleCore(false);
			}

			// Token: 0x0600003F RID: 63 RVA: 0x00003558 File Offset: 0x00001758
			protected override void WndProc(ref Message m)
			{
				int msg = m.Msg;
				if (msg == 776)
				{
					this.ClipChanged();
					NativeMethods.SendMessage(ClipboardMonitor.ClipboardWatcher.nextClipboardViewer, m.Msg, m.WParam, m.LParam);
					return;
				}
				int msg2 = m.Msg;
				if (msg2 != 781)
				{
					base.WndProc(ref m);
					return;
				}
				if (m.WParam != ClipboardMonitor.ClipboardWatcher.nextClipboardViewer)
				{
					NativeMethods.SendMessage(ClipboardMonitor.ClipboardWatcher.nextClipboardViewer, m.Msg, m.WParam, m.LParam);
					return;
				}
				ClipboardMonitor.ClipboardWatcher.nextClipboardViewer = m.LParam;
			}

			// Token: 0x06000040 RID: 64 RVA: 0x000035EC File Offset: 0x000017EC
			private void ClipChanged()
			{
				IDataObject dataObject = Clipboard.GetDataObject();
				Enums.ClipboardFormat? clipboardFormat = null;
				foreach (string text in Enum.GetNames(typeof(Enums.ClipboardFormat)))
				{
					if (dataObject.GetDataPresent(text))
					{
						clipboardFormat = new Enums.ClipboardFormat?((Enums.ClipboardFormat)Enum.Parse(typeof(Enums.ClipboardFormat), text));
						break;
					}
				}
				object data = dataObject.GetData(clipboardFormat.ToString());
				if (data == null || clipboardFormat == null)
				{
					return;
				}
				ClipboardMonitor.ClipboardWatcher.OnClipboardChange(clipboardFormat.Value, data);
			}

			// Token: 0x04000054 RID: 84
			private const int WM_DRAWCLIPBOARD = 776;

			// Token: 0x04000055 RID: 85
			private const int WM_CHANGECBCHAIN = 781;

			// Token: 0x04000057 RID: 87
			protected static ClipboardMonitor.ClipboardWatcher mInstance;

			// Token: 0x04000058 RID: 88
			private static IntPtr nextClipboardViewer;

			// Token: 0x02000017 RID: 23
			// (Invoke) Token: 0x06000045 RID: 69
			internal delegate void OnClipboardChangeEventHandler(Enums.ClipboardFormat format, object data);
		}

		// Token: 0x02000018 RID: 24
		// (Invoke) Token: 0x06000049 RID: 73
		internal delegate void OnClipboardChangeEventHandler(Enums.ClipboardFormat clipboardFormat, object data);
	}
}
