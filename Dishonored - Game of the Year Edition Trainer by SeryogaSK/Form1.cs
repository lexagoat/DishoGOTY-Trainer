using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x0200001E RID: 30
	[DesignerGenerated]
	public partial class Form1 : Form
	{
		// Token: 0x06000145 RID: 325 RVA: 0x0000A798 File Offset: 0x00008998
		public Form1()
		{
			base.Load += this.Form1_Load;
			this.Insert = false;
			this.Numpad1 = false;
			this.Numpad2 = false;
			this.Numpad3 = false;
			this.Numpad4 = false;
			this.Numpad5 = false;
			this.Numpad6 = false;
			this.Numpad7 = false;
			this.Numpad8 = false;
			this.health = false;
			this.blinkdis = false;
			this.ammo = false;
			this.reload = false;
			this.health_bytes = new byte[]
			{
				199,
				129,
				172,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				15,
				182,
				129,
				172,
				0,
				0,
				0,
				233,
				1,
				129,
				109,
				254
			};
			this.health_org_bytes = new byte[]
			{
				15,
				182,
				129,
				172,
				0,
				0,
				0
			};
			this.offset_health = 7635216L;
			this.blinkdis_bytes = new byte[]
			{
				186,
				byte.MaxValue,
				201,
				154,
				59,
				137,
				86,
				4,
				91,
				133,
				210,
				233,
				50,
				245,
				183,
				254
			};
			this.blinkdis_org_bytes = new byte[]
			{
				137,
				86,
				4,
				91,
				133,
				210
			};
			this.offset_blinkdis = 8451388L;
			this.ammo_bytes = new byte[]
			{
				199,
				4,
				240,
				231,
				3,
				0,
				0,
				139,
				20,
				240,
				49,
				201,
				233,
				134,
				78,
				203,
				254
			};
			this.ammo_org_bytes = new byte[]
			{
				139,
				20,
				240,
				51,
				201
			};
			this.offset_ammo = 8408722L;
			this.reload_bytes = new byte[]
			{
				199,
				129,
				36,
				1,
				0,
				0,
				3,
				0,
				0,
				0,
				139,
				129,
				36,
				1,
				0,
				0,
				233,
				193,
				195,
				219,
				224
			};
			this.reload_org_bytes = new byte[]
			{
				139,
				129,
				36,
				1,
				0,
				0
			};
			this.offset_reload = 8504272L;
			this.InitializeComponent();
		}

		// Token: 0x06000146 RID: 326
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int GetAsyncKeyState(int key);

		// Token: 0x06000147 RID: 327 RVA: 0x0000A918 File Offset: 0x00008B18
		private void Form1_Load(object sender, EventArgs e)
		{
			this.numpad1_toggle.Options = FlatToggle._Options.Style3;
			this.numpad2_toggle.Options = FlatToggle._Options.Style3;
			this.numpad3_toggle.Options = FlatToggle._Options.Style3;
			this.numpad4_toggle.Options = FlatToggle._Options.Style3;
			this.numpad8_toggle.Options = FlatToggle._Options.Style3;
			this.numpad5_toggle.Options = FlatToggle._Options.Style3;
			this.numpad6_toggle.Options = FlatToggle._Options.Style3;
			this.numpad7_toggle.Options = FlatToggle._Options.Style3;
			this.game_checker.Start();
			this.game_hash_txt.Text = "5CC5686E596F7B49581C6221975BAB8";
			this.your_hash_txt.Text = "";
			this.english_lang.Enabled = false;
			this.md5_alter_box.Visible = true;
			Process[] processesByName = Process.GetProcessesByName("Dishonored");
			processesByName = Process.GetProcessesByName("Dishonored");
			if (processesByName.Length > 0)
			{
				this.getGameID_lbl.Text = Conversions.ToString(Operators.ConcatenateObject("Game ID:", TrainerModul2_3.GetProcessId("Dishonored")));
				this.game_status_bar.Text = "Game Status: Game Found.";
				this.game_status_bar.RectColor = Color.Green;
				this.game_status_bar.UseWaitCursor = false;
				this.BaseAddress_EXE = Conversions.ToInteger(TrainerModul2_3.GetModuleBase("Dishonored", "Dishonored.exe"));
				TrainerModul2_3.GetProcessId("Dishonored");
				this.game_checker.Stop();
			}
			else
			{
				this.getGameID_lbl.Text = "Game ID: 000000";
				this.game_status_bar.Text = "Game Status: Game not Found. Run Dishonored.exe";
				this.game_status_bar.RectColor = Color.Red;
				this.game_status_bar.UseWaitCursor = true;
				this.trainer_sts_lbl.Text = "Trainer is OFF";
				this.trainer_sts_lbl.ForeColor = Color.Red;
				this.numpad1_toggle.Enabled = false;
				this.numpad2_toggle.Enabled = false;
				this.numpad3_toggle.Enabled = false;
				this.numpad4_toggle.Enabled = false;
				this.numpad8_toggle.Enabled = false;
				this.numpad5_toggle.Enabled = false;
				this.numpad6_toggle.Enabled = false;
				this.numpad7_toggle.Enabled = false;
				this.Hotkey_timer.Stop();
			}
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000AB38 File Offset: 0x00008D38
		private void cheats_timer_Tick(object sender, EventArgs e)
		{
			TrainerModul2_3.Write_Pointer_4Bytes_32Bit(99, checked(this.BaseAddress_EXE + 17116648), new int[]
			{
				836
			});
			if (this.numpad1_toggle.Checked)
			{
				this.numpad1_toggle.Checked = true;
				this.numpad1_toggle.Refresh();
			}
			else
			{
				this.numpad1_toggle.Checked = false;
				this.health_timer.Stop();
				this.numpad1_toggle.Refresh();
			}
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000ABB0 File Offset: 0x00008DB0
		private void mana_timer_Tick(object sender, EventArgs e)
		{
			TrainerModul2_3.Write_Pointer_4Bytes_32Bit(999, checked(this.BaseAddress_EXE + 17116648), new int[]
			{
				2656
			});
			if (this.numpad2_toggle.Checked)
			{
				this.numpad2_toggle.Checked = true;
				this.numpad2_toggle.Refresh();
			}
			else
			{
				this.numpad2_toggle.Checked = false;
				this.mana_timer.Stop();
				this.numpad2_toggle.Refresh();
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000AC2C File Offset: 0x00008E2C
		private void oxygen_timer_Tick(object sender, EventArgs e)
		{
			TrainerModul2_3.Write_Pointer_float_32Bit(Conversions.ToInteger(TrainerModul2_3.Float2Long(999f)), checked(this.BaseAddress_EXE + 17116648), new int[]
			{
				2744
			});
			if (this.numpad3_toggle.Checked)
			{
				this.numpad3_toggle.Checked = true;
				this.numpad3_toggle.Refresh();
			}
			else
			{
				this.numpad3_toggle.Checked = false;
				this.oxygen_timer.Stop();
				this.numpad3_toggle.Refresh();
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000ACB0 File Offset: 0x00008EB0
		private void FlatToggle1_CheckedChanged(object sender)
		{
			if (this.numpad1_toggle.Checked)
			{
				this.health_timer.Start();
			}
			else
			{
				this.health_timer.Stop();
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000ACE4 File Offset: 0x00008EE4
		private void mana_btn_CheckedChanged(object sender)
		{
			if (this.numpad2_toggle.Checked)
			{
				this.mana_timer.Start();
			}
			else
			{
				this.mana_timer.Stop();
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000AD18 File Offset: 0x00008F18
		private void oxygen_btn_CheckedChanged(object sender)
		{
			if (this.numpad3_toggle.Checked)
			{
				this.oxygen_timer.Start();
			}
			else
			{
				this.oxygen_timer.Stop();
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000AD4C File Offset: 0x00008F4C
		private void speed_timer_Tick(object sender, EventArgs e)
		{
			checked
			{
				TrainerModul2_3.Write_Pointer_4Bytes_32Bit(1091567616, this.BaseAddress_EXE + 17116648, new int[]
				{
					1420
				});
				if (this.numpad8_toggle.Checked)
				{
					this.numpad8_toggle.Checked = true;
					this.numpad8_toggle.Refresh();
				}
				else
				{
					TrainerModul2_3.Write_Pointer_4Bytes_32Bit(1063675494, this.BaseAddress_EXE + 17116648, new int[]
					{
						1420
					});
					this.numpad8_toggle.Checked = false;
					this.speed_timer.Stop();
					this.numpad8_toggle.Refresh();
				}
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00002A13 File Offset: 0x00000C13
		private void speed_btn_CheckedChanged(object sender)
		{
			this.speed_timer.Start();
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000ADEC File Offset: 0x00008FEC
		private void stealth_btn_CheckedChanged(object sender)
		{
			checked
			{
				if (this.health)
				{
					TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_health, this.health_org_bytes);
					this.health = false;
				}
				else
				{
					TrainerModul2_3.GetProcessId("Dishonored");
					this.baseaddr = Conversions.ToInteger(TrainerModul2_3.GetModuleBase("Dishonored", "Dishonored.exe"));
					this.alloc = TrainerModul2_3.AllocMem("Dishonored", "Dishonored.exe");
					TrainerModul2_3.Write_CodeInjection(this.alloc, this.health_bytes);
					int num = Conversions.ToInteger(TrainerModul2_3.GetJmpBytes(unchecked((long)this.baseaddr) + this.offset_health + 5L, this.alloc + unchecked((long)this.health_bytes.Length) - 5L));
					TrainerModul2_3.Write_4_Bytes(this.alloc + unchecked((long)this.health_bytes.Length) - 4L, unchecked((long)num));
					TrainerModul2_3.JmpToCave(this.alloc, unchecked((long)this.baseaddr) + this.offset_health, this.health_org_bytes.Length - 5);
					this.health = true;
				}
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000AEFC File Offset: 0x000090FC
		private void FlatToggle1_CheckedChanged_1(object sender)
		{
			checked
			{
				if (this.blinkdis)
				{
					TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_blinkdis, this.blinkdis_org_bytes);
					this.blinkdis = false;
				}
				else
				{
					this.addtinc = unchecked((long)(checked(this.health_bytes.Length + 32)));
					TrainerModul2_3.GetProcessId("Dishonored");
					this.baseaddr = Conversions.ToInteger(TrainerModul2_3.GetModuleBase("Dishonored", "Dishonored.exe"));
					this.alloc = TrainerModul2_3.AllocMem("Dishonored", "Dishonored.exe");
					TrainerModul2_3.Write_CodeInjection(this.alloc + this.addtinc, this.blinkdis_bytes);
					int num = Conversions.ToInteger(TrainerModul2_3.GetJmpBytes(unchecked((long)this.baseaddr) + this.offset_blinkdis + 5L, this.alloc + this.addtinc + unchecked((long)this.blinkdis_bytes.Length) - 5L));
					TrainerModul2_3.Write_4_Bytes(this.alloc + this.addtinc + unchecked((long)this.blinkdis_bytes.Length) - 4L, unchecked((long)num));
					TrainerModul2_3.JmpToCave(this.alloc + this.addtinc, unchecked((long)this.baseaddr) + this.offset_blinkdis, this.blinkdis_org_bytes.Length - 5);
					this.blinkdis = true;
				}
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000B038 File Offset: 0x00009238
		private void FlatToggle2_CheckedChanged(object sender)
		{
			checked
			{
				if (this.ammo)
				{
					TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_ammo, this.ammo_org_bytes);
					this.ammo = false;
				}
				else
				{
					this.addtinc = unchecked((long)(checked(this.health_bytes.Length + this.blinkdis_bytes.Length + 32)));
					TrainerModul2_3.GetProcessId("Dishonored");
					this.baseaddr = Conversions.ToInteger(TrainerModul2_3.GetModuleBase("Dishonored", "Dishonored.exe"));
					this.alloc = TrainerModul2_3.AllocMem("Dishonored", "Dishonored.exe");
					TrainerModul2_3.Write_CodeInjection(this.alloc + this.addtinc, this.ammo_bytes);
					int num = Conversions.ToInteger(TrainerModul2_3.GetJmpBytes(unchecked((long)this.baseaddr) + this.offset_ammo + 5L, this.alloc + this.addtinc + unchecked((long)this.ammo_bytes.Length) - 5L));
					TrainerModul2_3.Write_4_Bytes(this.alloc + this.addtinc + unchecked((long)this.ammo_bytes.Length) - 4L, unchecked((long)num));
					TrainerModul2_3.JmpToCave(this.alloc + this.addtinc, unchecked((long)this.baseaddr) + this.offset_ammo, this.ammo_org_bytes.Length - 5);
					this.ammo = true;
				}
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000B17C File Offset: 0x0000937C
		private void FlatToggle3_CheckedChanged(object sender)
		{
			checked
			{
				if (this.reload)
				{
					TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_reload, this.reload_org_bytes);
					this.reload = false;
				}
				else
				{
					this.addtinc = unchecked((long)(checked(this.health_bytes.Length + this.blinkdis_bytes.Length + this.ammo_bytes.Length + 32)));
					TrainerModul2_3.GetProcessId("Dishonored");
					this.baseaddr = Conversions.ToInteger(TrainerModul2_3.GetModuleBase("Dishonored", "Dishonored.exe"));
					this.alloc = TrainerModul2_3.AllocMem("Dishonored", "Dishonored.exe");
					TrainerModul2_3.Write_CodeInjection(this.alloc + this.addtinc, this.reload_bytes);
					int num = Conversions.ToInteger(TrainerModul2_3.GetJmpBytes(unchecked((long)this.baseaddr) + this.offset_reload + 5L, this.alloc + this.addtinc + unchecked((long)this.reload_bytes.Length) - 5L));
					TrainerModul2_3.Write_4_Bytes(this.alloc + this.addtinc + unchecked((long)this.reload_bytes.Length) - 4L, unchecked((long)num));
					TrainerModul2_3.JmpToCave(this.alloc + this.addtinc, unchecked((long)this.baseaddr) + this.offset_reload, this.reload_org_bytes.Length - 5);
					this.reload = true;
				}
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000B2CC File Offset: 0x000094CC
		private void Hotkey_timer_Tick(object sender, EventArgs e)
		{
			checked
			{
				if ((Form1.GetAsyncKeyState(45) & 1) > 0)
				{
					this.Insert = !this.Insert;
					if (this.Insert)
					{
						this.trainer_status_btn.Checked = true;
						this.trainer_status_btn.Refresh();
						this.trainer_sts_lbl.Refresh();
					}
					else
					{
						this.trainer_status_btn.Checked = false;
						this.trainer_status_btn.Refresh();
						this.trainer_sts_lbl.Refresh();
						this.numpad1_toggle.Enabled = false;
						this.numpad2_toggle.Enabled = false;
						this.numpad3_toggle.Enabled = false;
						this.numpad4_toggle.Enabled = false;
						this.numpad8_toggle.Enabled = false;
						this.numpad5_toggle.Enabled = false;
						this.numpad6_toggle.Enabled = false;
						this.numpad7_toggle.Enabled = false;
						this.Hotkey_timer.Stop();
						this.trainer_sts_lbl.Text = "Trainer is Off";
						this.trainer_sts_lbl.ForeColor = Color.Red;
						this.Hotkey_toggle.Checked = false;
						this.Hotkey_toggle.Refresh();
						this.toggle_btn.Checked = false;
						this.toggle_btn.Refresh();
						TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_reload, this.reload_org_bytes);
						this.reload = false;
						TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_ammo, this.ammo_org_bytes);
						this.ammo = false;
						TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_blinkdis, this.blinkdis_org_bytes);
						this.blinkdis = false;
						TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_health, this.health_org_bytes);
						this.health = false;
						TrainerModul2_3.Write_Pointer_4Bytes_32Bit(1063675494, this.BaseAddress_EXE + 17116648, new int[]
						{
							1420
						});
						this.speed_timer.Stop();
						this.oxygen_timer.Stop();
						this.mana_timer.Stop();
						this.health_timer.Stop();
						this.numpad1_toggle.Checked = false;
						this.numpad1_toggle.Refresh();
						this.numpad2_toggle.Checked = false;
						this.numpad2_toggle.Refresh();
						this.numpad3_toggle.Checked = false;
						this.numpad3_toggle.Refresh();
						this.numpad4_toggle.Checked = false;
						this.numpad4_toggle.Refresh();
						this.numpad5_toggle.Checked = false;
						this.numpad5_toggle.Refresh();
						this.numpad6_toggle.Checked = false;
						this.numpad6_toggle.Refresh();
						this.numpad7_toggle.Checked = false;
						this.numpad7_toggle.Refresh();
						this.numpad8_toggle.Checked = false;
						this.numpad8_toggle.Refresh();
					}
				}
				if ((Form1.GetAsyncKeyState(97) & 1) > 0)
				{
					this.Numpad1 = !this.Numpad1;
					if (this.Numpad1)
					{
						this.numpad1_toggle.Checked = true;
						this.numpad1_toggle.Refresh();
						this.health_timer.Start();
					}
					else
					{
						this.numpad1_toggle.Checked = false;
						this.numpad1_toggle.Refresh();
						this.health_timer.Stop();
					}
				}
				if ((Form1.GetAsyncKeyState(98) & 1) > 0)
				{
					this.Numpad2 = !this.Numpad2;
					if (this.Numpad2)
					{
						this.numpad2_toggle.Checked = true;
						this.numpad2_toggle.Refresh();
						this.mana_timer.Start();
					}
					else
					{
						this.numpad2_toggle.Checked = false;
						this.numpad2_toggle.Refresh();
						this.mana_timer.Stop();
					}
				}
				if ((Form1.GetAsyncKeyState(99) & 1) > 0)
				{
					this.Numpad3 = !this.Numpad3;
					if (this.Numpad3)
					{
						this.numpad3_toggle.Checked = true;
						this.numpad3_toggle.Refresh();
						this.oxygen_timer.Start();
					}
					else
					{
						this.numpad3_toggle.Checked = false;
						this.numpad3_toggle.Refresh();
						this.oxygen_timer.Stop();
					}
				}
				if ((Form1.GetAsyncKeyState(100) & 1) > 0)
				{
					this.Numpad4 = !this.Numpad4;
					if (this.Numpad4)
					{
						this.numpad4_toggle.Checked = true;
						this.numpad4_toggle.Refresh();
						this.health = true;
						TrainerModul2_3.GetProcessId("Dishonored");
						this.baseaddr = Conversions.ToInteger(TrainerModul2_3.GetModuleBase("Dishonored", "Dishonored.exe"));
						this.alloc = TrainerModul2_3.AllocMem("Dishonored", "Dishonored.exe");
						TrainerModul2_3.Write_CodeInjection(this.alloc, this.health_bytes);
						int num = Conversions.ToInteger(TrainerModul2_3.GetJmpBytes(unchecked((long)this.baseaddr) + this.offset_health + 5L, this.alloc + unchecked((long)this.health_bytes.Length) - 5L));
						TrainerModul2_3.Write_4_Bytes(this.alloc + unchecked((long)this.health_bytes.Length) - 4L, unchecked((long)num));
						TrainerModul2_3.JmpToCave(this.alloc, unchecked((long)this.baseaddr) + this.offset_health, this.health_org_bytes.Length - 5);
					}
					else
					{
						this.health = false;
						this.numpad4_toggle.Checked = false;
						this.numpad4_toggle.Refresh();
						TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_health, this.health_org_bytes);
					}
				}
				if ((Form1.GetAsyncKeyState(101) & 1) > 0)
				{
					this.Numpad5 = !this.Numpad5;
					if (this.Numpad5)
					{
						this.numpad5_toggle.Checked = true;
						this.numpad5_toggle.Refresh();
						this.addtinc = unchecked((long)(checked(this.health_bytes.Length + 32)));
						TrainerModul2_3.GetProcessId("Dishonored");
						this.baseaddr = Conversions.ToInteger(TrainerModul2_3.GetModuleBase("Dishonored", "Dishonored.exe"));
						this.alloc = TrainerModul2_3.AllocMem("Dishonored", "Dishonored.exe");
						TrainerModul2_3.Write_CodeInjection(this.alloc + this.addtinc, this.blinkdis_bytes);
						int num2 = Conversions.ToInteger(TrainerModul2_3.GetJmpBytes(unchecked((long)this.baseaddr) + this.offset_blinkdis + 5L, this.alloc + this.addtinc + unchecked((long)this.blinkdis_bytes.Length) - 5L));
						TrainerModul2_3.Write_4_Bytes(this.alloc + this.addtinc + unchecked((long)this.blinkdis_bytes.Length) - 4L, unchecked((long)num2));
						TrainerModul2_3.JmpToCave(this.alloc + this.addtinc, unchecked((long)this.baseaddr) + this.offset_blinkdis, this.blinkdis_org_bytes.Length - 5);
						this.blinkdis = true;
					}
					else
					{
						this.numpad5_toggle.Checked = false;
						this.numpad5_toggle.Refresh();
						TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_blinkdis, this.blinkdis_org_bytes);
						this.blinkdis = false;
					}
				}
				if ((Form1.GetAsyncKeyState(102) & 1) > 0)
				{
					this.Numpad6 = !this.Numpad6;
					if (this.Numpad6)
					{
						this.numpad6_toggle.Checked = true;
						this.numpad6_toggle.Refresh();
						this.addtinc = unchecked((long)(checked(this.health_bytes.Length + this.blinkdis_bytes.Length + 32)));
						TrainerModul2_3.GetProcessId("Dishonored");
						this.baseaddr = Conversions.ToInteger(TrainerModul2_3.GetModuleBase("Dishonored", "Dishonored.exe"));
						this.alloc = TrainerModul2_3.AllocMem("Dishonored", "Dishonored.exe");
						TrainerModul2_3.Write_CodeInjection(this.alloc + this.addtinc, this.ammo_bytes);
						int num3 = Conversions.ToInteger(TrainerModul2_3.GetJmpBytes(unchecked((long)this.baseaddr) + this.offset_ammo + 5L, this.alloc + this.addtinc + unchecked((long)this.ammo_bytes.Length) - 5L));
						TrainerModul2_3.Write_4_Bytes(this.alloc + this.addtinc + unchecked((long)this.ammo_bytes.Length) - 4L, unchecked((long)num3));
						TrainerModul2_3.JmpToCave(this.alloc + this.addtinc, unchecked((long)this.baseaddr) + this.offset_ammo, this.ammo_org_bytes.Length - 5);
						this.ammo = true;
					}
					else
					{
						this.numpad6_toggle.Checked = false;
						this.numpad6_toggle.Refresh();
						TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_ammo, this.ammo_org_bytes);
						this.ammo = false;
					}
				}
				if ((Form1.GetAsyncKeyState(103) & 1) > 0)
				{
					this.Numpad7 = !this.Numpad7;
					if (this.Numpad7)
					{
						this.numpad7_toggle.Checked = true;
						this.numpad7_toggle.Refresh();
						this.addtinc = unchecked((long)(checked(this.health_bytes.Length + this.blinkdis_bytes.Length + this.ammo_bytes.Length + 32)));
						TrainerModul2_3.GetProcessId("Dishonored");
						this.baseaddr = Conversions.ToInteger(TrainerModul2_3.GetModuleBase("Dishonored", "Dishonored.exe"));
						this.alloc = TrainerModul2_3.AllocMem("Dishonored", "Dishonored.exe");
						TrainerModul2_3.Write_CodeInjection(this.alloc + this.addtinc, this.reload_bytes);
						int num4 = Conversions.ToInteger(TrainerModul2_3.GetJmpBytes(unchecked((long)this.baseaddr) + this.offset_reload + 5L, this.alloc + this.addtinc + unchecked((long)this.reload_bytes.Length) - 5L));
						TrainerModul2_3.Write_4_Bytes(this.alloc + this.addtinc + unchecked((long)this.reload_bytes.Length) - 4L, unchecked((long)num4));
						TrainerModul2_3.JmpToCave(this.alloc + this.addtinc, unchecked((long)this.baseaddr) + this.offset_reload, this.reload_org_bytes.Length - 5);
						this.reload = true;
					}
					else
					{
						this.numpad7_toggle.Checked = false;
						this.numpad7_toggle.Refresh();
						TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_reload, this.reload_org_bytes);
						this.reload = false;
					}
				}
				if ((Form1.GetAsyncKeyState(104) & 1) > 0)
				{
					this.Numpad8 = !this.Numpad8;
					if (this.Numpad8)
					{
						this.numpad8_toggle.Checked = true;
						this.numpad8_toggle.Refresh();
						this.speed_timer.Start();
					}
					else
					{
						this.numpad8_toggle.Checked = false;
						this.numpad8_toggle.Refresh();
						this.speed_timer.Stop();
					}
				}
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000BD1C File Offset: 0x00009F1C
		private void PictureBox4_Click(object sender, EventArgs e)
		{
			this.health_lbl.Text = "Беск. Здоровье";
			this.FlatLabel4.Text = "Беск. Мана";
			this.FlatLabel5.Text = "Беск. Воздух";
			this.stealth_lbl.Text = "Невидимость";
			this.FlatLabel8.Text = "Беск. Монеты/Руны";
			this.FlatLabel9.Text = "Беск. Патроны";
			this.FlatLabel10.Text = "Без Перезарядки";
			this.speed_lbl.Text = "Быстрый Бег";
			this.enable_trainer_lbl.Text = "Включить трейнер";
			this.enb_hotkey_lbl.Text = "Вкл. горячие клавиши";
			this.toggle_btn_lbl.Text = "Вкл. кнопки переключения";
			this.language_sel_lbl.Text = "Язык трейнера:";
			this.game_hash_lbl.Text = "Трейнер EXE Хэш:";
			this.your_hash_lbl.Text = "Твой EXE-хеш:";
			this.russian_lang.Enabled = false;
			this.german_lang.Enabled = true;
			this.english_lang.Enabled = true;
			this.your_hash_txt.Text = "";
			this.md5_alter_box.Text = "Сначала выберите EXE-файл игры.";
			this.md5_alter_box.kind = FlatAlertBox._Kind.Info;
			this.md5_alter_box.Visible = true;
			if (this.trainer_status_btn.Checked)
			{
				this.trainer_sts_lbl.Text = "Трейнер Вкл.";
				this.trainer_sts_lbl.ForeColor = Color.Green;
			}
			else
			{
				this.trainer_sts_lbl.Text = "Трейнер вык.";
				this.trainer_sts_lbl.ForeColor = Color.Red;
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		private void PictureBox3_Click(object sender, EventArgs e)
		{
			this.health_lbl.Text = "Unl. Health";
			this.FlatLabel4.Text = "Unl. Mana";
			this.FlatLabel5.Text = "Unl. Oxygen";
			this.stealth_lbl.Text = "Stealth";
			this.FlatLabel8.Text = "Unl. Coins/Runs";
			this.FlatLabel9.Text = "Unl. Ammo";
			this.FlatLabel10.Text = "No Reload";
			this.speed_lbl.Text = "Super Speed";
			this.enable_trainer_lbl.Text = "Enable Trainer";
			this.enb_hotkey_lbl.Text = "Enable Hotkey";
			this.toggle_btn_lbl.Text = "Enable Toggle Buttons";
			this.language_sel_lbl.Text = "Trainer Language:";
			this.game_hash_lbl.Text = "Trainer EXE Hash";
			this.your_hash_lbl.Text = "Your EXE Hash:";
			this.russian_lang.Enabled = true;
			this.german_lang.Enabled = true;
			this.english_lang.Enabled = false;
			this.your_hash_txt.Text = "";
			this.md5_alter_box.Text = "Please Select your Game EXE first.";
			this.md5_alter_box.kind = FlatAlertBox._Kind.Info;
			this.md5_alter_box.Visible = true;
			if (this.trainer_status_btn.Checked)
			{
				this.trainer_sts_lbl.Text = "Trainer is ON";
				this.trainer_sts_lbl.ForeColor = Color.Green;
			}
			else
			{
				this.trainer_sts_lbl.Text = "Trainer is OFF";
				this.trainer_sts_lbl.ForeColor = Color.Red;
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000C04C File Offset: 0x0000A24C
		private void PictureBox5_Click(object sender, EventArgs e)
		{
			this.health_lbl.Text = "Un. Leben";
			this.FlatLabel4.Text = "Un. Mana";
			this.FlatLabel5.Text = "Un. Sauerstoff";
			this.stealth_lbl.Text = "Unsichtbar";
			this.FlatLabel8.Text = "Un. Geld/Runen";
			this.FlatLabel9.Text = "Un. Munition";
			this.FlatLabel10.Text = "Kein Nachladen";
			this.speed_lbl.Text = "Supergeschwindigkeit";
			this.enable_trainer_lbl.Text = "Trainer aktivieren";
			this.enb_hotkey_lbl.Text = "Hotkeys aktivieren";
			this.toggle_btn_lbl.Text = "Schaltknöpfe aktivieren";
			this.language_sel_lbl.Text = "Trainersprache:";
			this.game_hash_lbl.Text = "Trainer EXE Hash";
			this.your_hash_lbl.Text = "Deine EXE Hash:";
			this.russian_lang.Enabled = true;
			this.german_lang.Enabled = false;
			this.english_lang.Enabled = true;
			this.your_hash_txt.Text = "";
			this.md5_alter_box.Text = "Bitte wählen Sie zuerst Ihre Spiel-EXE aus";
			this.md5_alter_box.kind = FlatAlertBox._Kind.Info;
			this.md5_alter_box.Visible = true;
			if (this.trainer_status_btn.Checked)
			{
				this.trainer_sts_lbl.Text = "Trainer ist AN";
				this.trainer_sts_lbl.ForeColor = Color.Green;
			}
			else
			{
				this.trainer_sts_lbl.Text = "Trainer ist AUS";
				this.trainer_sts_lbl.ForeColor = Color.Red;
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00002A20 File Offset: 0x00000C20
		private void PictureBox3_MouseLeave(object sender, EventArgs e)
		{
			this.english_lang.BackColor = Color.Transparent;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00002A32 File Offset: 0x00000C32
		private void PictureBox4_MouseLeave(object sender, EventArgs e)
		{
			this.russian_lang.BackColor = Color.Transparent;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00002A44 File Offset: 0x00000C44
		private void PictureBox4_MouseHover(object sender, EventArgs e)
		{
			this.russian_lang.BackColor = Color.Gray;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00002A56 File Offset: 0x00000C56
		private void PictureBox5_MouseHover(object sender, EventArgs e)
		{
			this.german_lang.BackColor = Color.Gray;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00002A68 File Offset: 0x00000C68
		private void PictureBox5_MouseLeave(object sender, EventArgs e)
		{
			this.german_lang.BackColor = Color.Transparent;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00002A7A File Offset: 0x00000C7A
		private void PictureBox3_MouseHover(object sender, EventArgs e)
		{
			this.english_lang.BackColor = Color.Gray;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000C1E4 File Offset: 0x0000A3E4
		private void trainer_status_btn_CheckedChanged(object sender)
		{
			checked
			{
				if (this.trainer_status_btn.Checked)
				{
					if (this.game_status_bar.RectColor == Color.Green)
					{
						this.numpad1_toggle.Enabled = true;
						this.numpad2_toggle.Enabled = true;
						this.numpad3_toggle.Enabled = true;
						this.numpad4_toggle.Enabled = true;
						this.numpad8_toggle.Enabled = true;
						this.numpad5_toggle.Enabled = true;
						this.numpad6_toggle.Enabled = true;
						this.numpad7_toggle.Enabled = true;
						this.Hotkey_timer.Start();
						if (!this.english_lang.Enabled)
						{
							this.trainer_sts_lbl.Text = "Trainer is ON";
							this.trainer_sts_lbl.ForeColor = Color.Green;
						}
						else if (!this.german_lang.Enabled)
						{
							this.trainer_sts_lbl.Text = "Trainer ist AN";
							this.trainer_sts_lbl.ForeColor = Color.Green;
						}
						else if (!this.russian_lang.Enabled)
						{
							this.trainer_sts_lbl.Text = "Трейнер Вкл.";
							this.trainer_sts_lbl.ForeColor = Color.Green;
						}
						this.Hotkey_toggle.Checked = true;
						this.Hotkey_toggle.Refresh();
						this.toggle_btn.Checked = true;
						this.toggle_btn.Refresh();
					}
				}
				else if (!this.trainer_status_btn.Checked)
				{
					this.numpad1_toggle.Enabled = false;
					this.numpad2_toggle.Enabled = false;
					this.numpad3_toggle.Enabled = false;
					this.numpad4_toggle.Enabled = false;
					this.numpad8_toggle.Enabled = false;
					this.numpad5_toggle.Enabled = false;
					this.numpad6_toggle.Enabled = false;
					this.numpad7_toggle.Enabled = false;
					this.Hotkey_timer.Stop();
					if (!this.english_lang.Enabled)
					{
						this.trainer_sts_lbl.Text = "Trainer is OFF";
						this.trainer_sts_lbl.ForeColor = Color.Red;
					}
					else if (!this.german_lang.Enabled)
					{
						this.trainer_sts_lbl.Text = "Trainer ist AUS";
						this.trainer_sts_lbl.ForeColor = Color.Red;
					}
					else if (!this.russian_lang.Enabled)
					{
						this.trainer_sts_lbl.Text = "Трейнер вык.";
						this.trainer_sts_lbl.ForeColor = Color.Red;
					}
					this.Hotkey_toggle.Checked = false;
					this.Hotkey_toggle.Refresh();
					this.toggle_btn.Checked = false;
					this.toggle_btn.Refresh();
					TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_reload, this.reload_org_bytes);
					this.reload = false;
					TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_ammo, this.ammo_org_bytes);
					this.ammo = false;
					TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_blinkdis, this.blinkdis_org_bytes);
					this.blinkdis = false;
					TrainerModul2_3.Write_CodeInjection(unchecked((long)this.baseaddr) + this.offset_health, this.health_org_bytes);
					this.health = false;
					TrainerModul2_3.Write_Pointer_4Bytes_32Bit(1063675494, this.BaseAddress_EXE + 17116648, new int[]
					{
						1420
					});
					this.speed_timer.Stop();
					this.oxygen_timer.Stop();
					this.mana_timer.Stop();
					this.health_timer.Stop();
					this.numpad1_toggle.Checked = false;
					this.numpad1_toggle.Refresh();
					this.numpad2_toggle.Checked = false;
					this.numpad2_toggle.Refresh();
					this.numpad3_toggle.Checked = false;
					this.numpad3_toggle.Refresh();
					this.numpad4_toggle.Checked = false;
					this.numpad4_toggle.Refresh();
					this.numpad5_toggle.Checked = false;
					this.numpad5_toggle.Refresh();
					this.numpad6_toggle.Checked = false;
					this.numpad6_toggle.Refresh();
					this.numpad7_toggle.Checked = false;
					this.numpad7_toggle.Refresh();
					this.numpad8_toggle.Checked = false;
					this.numpad8_toggle.Refresh();
				}
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000C618 File Offset: 0x0000A818
		private void game_checker_Tick(object sender, EventArgs e)
		{
			if (this.game_status_bar.RectColor == Color.Green)
			{
				this.numpad1_toggle.Enabled = true;
				this.numpad2_toggle.Enabled = true;
				this.numpad3_toggle.Enabled = true;
				this.numpad4_toggle.Enabled = true;
				this.numpad8_toggle.Enabled = true;
				this.numpad5_toggle.Enabled = true;
				this.numpad6_toggle.Enabled = true;
				this.numpad7_toggle.Enabled = true;
				this.Hotkey_timer.Start();
				this.trainer_status_btn.Enabled = true;
				this.trainer_status_btn.Refresh();
				this.Hotkey_toggle.Enabled = true;
				this.Hotkey_toggle.Refresh();
				this.toggle_btn.Enabled = true;
				this.Hotkey_toggle.Refresh();
			}
			else
			{
				this.trainer_status_btn.Enabled = false;
				this.numpad1_toggle.Enabled = false;
				this.numpad2_toggle.Enabled = false;
				this.numpad3_toggle.Enabled = false;
				this.numpad4_toggle.Enabled = false;
				this.numpad8_toggle.Enabled = false;
				this.numpad5_toggle.Enabled = false;
				this.numpad6_toggle.Enabled = false;
				this.numpad7_toggle.Enabled = false;
				this.Hotkey_timer.Stop();
				this.Hotkey_toggle.Enabled = false;
				this.toggle_btn.Enabled = false;
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000C784 File Offset: 0x0000A984
		private void Hotkey_toggle_CheckedChanged(object sender)
		{
			if (this.Hotkey_timer.Enabled)
			{
				this.Hotkey_timer.Enabled = false;
			}
			else
			{
				this.Hotkey_timer.Enabled = true;
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000C7B8 File Offset: 0x0000A9B8
		private void toggle_btn_CheckedChanged(object sender)
		{
			if (this.toggle_btn.Checked)
			{
				this.numpad1_toggle.Enabled = true;
				this.numpad2_toggle.Enabled = true;
				this.numpad3_toggle.Enabled = true;
				this.numpad4_toggle.Enabled = true;
				this.numpad8_toggle.Enabled = true;
				this.numpad5_toggle.Enabled = true;
				this.numpad6_toggle.Enabled = true;
				this.numpad7_toggle.Enabled = true;
				this.numpad8_toggle.Enabled = true;
			}
			else
			{
				this.numpad1_toggle.Enabled = false;
				this.numpad2_toggle.Enabled = false;
				this.numpad3_toggle.Enabled = false;
				this.numpad4_toggle.Enabled = false;
				this.numpad8_toggle.Enabled = false;
				this.numpad5_toggle.Enabled = false;
				this.numpad6_toggle.Enabled = false;
				this.numpad7_toggle.Enabled = false;
				this.numpad8_toggle.Enabled = false;
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000C8AC File Offset: 0x0000AAAC
		private void Check_btn_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "All Files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.filepath_txt.Text = openFileDialog.FileName;
			}
			if (Operators.CompareString(openFileDialog.FileName, "", false) != 0)
			{
				FileStream fileStream = new FileStream(this.filepath_txt.Text, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);
				fileStream = new FileStream(this.filepath_txt.Text, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);
				MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
				md5CryptoServiceProvider.ComputeHash(fileStream);
				fileStream.Close();
				byte[] hash = md5CryptoServiceProvider.Hash;
				StringBuilder stringBuilder = new StringBuilder();
				foreach (byte b in hash)
				{
					stringBuilder.Append(string.Format("{0:X1}", b));
				}
				this.your_hash_txt.Text = stringBuilder.ToString();
				if (Operators.CompareString(this.game_hash_txt.Text, this.your_hash_txt.Text, false) == 0 & !this.russian_lang.Enabled)
				{
					this.md5_alter_box.Text = "Правильный MD5! Трейнер работает";
					this.md5_alter_box.kind = FlatAlertBox._Kind.Success;
					this.md5_alter_box.Visible = true;
				}
				else if (Operators.CompareString(this.game_hash_txt.Text, this.your_hash_txt.Text, false) == 0 & !this.english_lang.Enabled)
				{
					this.md5_alter_box.Text = "Right MD5! Trainer Work";
					this.md5_alter_box.kind = FlatAlertBox._Kind.Success;
					this.md5_alter_box.Visible = true;
				}
				else if (Operators.CompareString(this.game_hash_txt.Text, this.your_hash_txt.Text, false) == 0 & !this.german_lang.Enabled)
				{
					this.md5_alter_box.Text = "Richtiger MD5! Trainer funktioniert";
					this.md5_alter_box.kind = FlatAlertBox._Kind.Success;
					this.md5_alter_box.Visible = true;
				}
				else if (this.game_hash_txt.Text != this.your_hash_txt.Text & !this.german_lang.Enabled)
				{
					this.md5_alter_box.Text = "Falscher MD5! Trainer funktieoniert nicht";
					this.md5_alter_box.kind = FlatAlertBox._Kind.Error;
					this.md5_alter_box.Visible = true;
				}
				else if (this.game_hash_txt.Text != this.your_hash_txt.Text & !this.english_lang.Enabled)
				{
					this.md5_alter_box.Text = "Wrong MD5! Trainer not Work";
					this.md5_alter_box.kind = FlatAlertBox._Kind.Error;
					this.md5_alter_box.Visible = true;
				}
				else if (this.game_hash_txt.Text != this.your_hash_txt.Text & !this.russian_lang.Enabled)
				{
					this.md5_alter_box.Text = "Неправильный  MD5! Трейнер Не работает";
					this.md5_alter_box.kind = FlatAlertBox._Kind.Error;
					this.md5_alter_box.Visible = true;
				}
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00002A8C File Offset: 0x00000C8C
		// (set) Token: 0x06000166 RID: 358 RVA: 0x00002A94 File Offset: 0x00000C94
		internal virtual FormSkin FormSkin1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00002A9D File Offset: 0x00000C9D
		// (set) Token: 0x06000168 RID: 360 RVA: 0x00002AA5 File Offset: 0x00000CA5
		internal virtual FlatClose FlatClose1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00002AAE File Offset: 0x00000CAE
		// (set) Token: 0x0600016A RID: 362 RVA: 0x00002AB6 File Offset: 0x00000CB6
		internal virtual FlatMini FlatMini1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00002ABF File Offset: 0x00000CBF
		// (set) Token: 0x0600016C RID: 364 RVA: 0x00002AC7 File Offset: 0x00000CC7
		internal virtual PictureBox PictureBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00002AD0 File Offset: 0x00000CD0
		// (set) Token: 0x0600016E RID: 366 RVA: 0x0000FA84 File Offset: 0x0000DC84
		internal virtual Timer health_timer
		{
			[CompilerGenerated]
			get
			{
				return this._health_timer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cheats_timer_Tick);
				Timer health_timer = this._health_timer;
				if (health_timer != null)
				{
					health_timer.Tick -= value2;
				}
				this._health_timer = value;
				health_timer = this._health_timer;
				if (health_timer != null)
				{
					health_timer.Tick += value2;
				}
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600016F RID: 367 RVA: 0x00002AD8 File Offset: 0x00000CD8
		// (set) Token: 0x06000170 RID: 368 RVA: 0x0000FAC8 File Offset: 0x0000DCC8
		internal virtual Timer Hotkey_timer
		{
			[CompilerGenerated]
			get
			{
				return this._Hotkey_timer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Hotkey_timer_Tick);
				Timer hotkey_timer = this._Hotkey_timer;
				if (hotkey_timer != null)
				{
					hotkey_timer.Tick -= value2;
				}
				this._Hotkey_timer = value;
				hotkey_timer = this._Hotkey_timer;
				if (hotkey_timer != null)
				{
					hotkey_timer.Tick += value2;
				}
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000171 RID: 369 RVA: 0x00002AE0 File Offset: 0x00000CE0
		// (set) Token: 0x06000172 RID: 370 RVA: 0x00002AE8 File Offset: 0x00000CE8
		internal virtual LogInLabel getGameID_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000173 RID: 371 RVA: 0x00002AF1 File Offset: 0x00000CF1
		// (set) Token: 0x06000174 RID: 372 RVA: 0x0000FB0C File Offset: 0x0000DD0C
		internal virtual Timer mana_timer
		{
			[CompilerGenerated]
			get
			{
				return this._mana_timer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.mana_timer_Tick);
				Timer mana_timer = this._mana_timer;
				if (mana_timer != null)
				{
					mana_timer.Tick -= value2;
				}
				this._mana_timer = value;
				mana_timer = this._mana_timer;
				if (mana_timer != null)
				{
					mana_timer.Tick += value2;
				}
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000175 RID: 373 RVA: 0x00002AF9 File Offset: 0x00000CF9
		// (set) Token: 0x06000176 RID: 374 RVA: 0x0000FB50 File Offset: 0x0000DD50
		internal virtual Timer oxygen_timer
		{
			[CompilerGenerated]
			get
			{
				return this._oxygen_timer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.oxygen_timer_Tick);
				Timer oxygen_timer = this._oxygen_timer;
				if (oxygen_timer != null)
				{
					oxygen_timer.Tick -= value2;
				}
				this._oxygen_timer = value;
				oxygen_timer = this._oxygen_timer;
				if (oxygen_timer != null)
				{
					oxygen_timer.Tick += value2;
				}
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000177 RID: 375 RVA: 0x00002B01 File Offset: 0x00000D01
		// (set) Token: 0x06000178 RID: 376 RVA: 0x0000FB94 File Offset: 0x0000DD94
		internal virtual FlatToggle numpad1_toggle
		{
			[CompilerGenerated]
			get
			{
				return this._numpad1_toggle;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				FlatToggle.CheckedChangedEventHandler value2 = new FlatToggle.CheckedChangedEventHandler(this.FlatToggle1_CheckedChanged);
				FlatToggle numpad1_toggle = this._numpad1_toggle;
				if (numpad1_toggle != null)
				{
					numpad1_toggle.CheckedChanged -= value2;
				}
				this._numpad1_toggle = value;
				numpad1_toggle = this._numpad1_toggle;
				if (numpad1_toggle != null)
				{
					numpad1_toggle.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000179 RID: 377 RVA: 0x00002B09 File Offset: 0x00000D09
		// (set) Token: 0x0600017A RID: 378 RVA: 0x00002B11 File Offset: 0x00000D11
		internal virtual FlatLabel health_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600017B RID: 379 RVA: 0x00002B1A File Offset: 0x00000D1A
		// (set) Token: 0x0600017C RID: 380 RVA: 0x0000FBD8 File Offset: 0x0000DDD8
		internal virtual FlatToggle numpad3_toggle
		{
			[CompilerGenerated]
			get
			{
				return this._numpad3_toggle;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				FlatToggle.CheckedChangedEventHandler value2 = new FlatToggle.CheckedChangedEventHandler(this.oxygen_btn_CheckedChanged);
				FlatToggle numpad3_toggle = this._numpad3_toggle;
				if (numpad3_toggle != null)
				{
					numpad3_toggle.CheckedChanged -= value2;
				}
				this._numpad3_toggle = value;
				numpad3_toggle = this._numpad3_toggle;
				if (numpad3_toggle != null)
				{
					numpad3_toggle.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600017D RID: 381 RVA: 0x00002B22 File Offset: 0x00000D22
		// (set) Token: 0x0600017E RID: 382 RVA: 0x0000FC1C File Offset: 0x0000DE1C
		internal virtual FlatToggle numpad2_toggle
		{
			[CompilerGenerated]
			get
			{
				return this._numpad2_toggle;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				FlatToggle.CheckedChangedEventHandler value2 = new FlatToggle.CheckedChangedEventHandler(this.mana_btn_CheckedChanged);
				FlatToggle numpad2_toggle = this._numpad2_toggle;
				if (numpad2_toggle != null)
				{
					numpad2_toggle.CheckedChanged -= value2;
				}
				this._numpad2_toggle = value;
				numpad2_toggle = this._numpad2_toggle;
				if (numpad2_toggle != null)
				{
					numpad2_toggle.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600017F RID: 383 RVA: 0x00002B2A File Offset: 0x00000D2A
		// (set) Token: 0x06000180 RID: 384 RVA: 0x00002B32 File Offset: 0x00000D32
		internal virtual FlatLabel FlatLabel5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000181 RID: 385 RVA: 0x00002B3B File Offset: 0x00000D3B
		// (set) Token: 0x06000182 RID: 386 RVA: 0x00002B43 File Offset: 0x00000D43
		internal virtual FlatLabel FlatLabel4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000183 RID: 387 RVA: 0x00002B4C File Offset: 0x00000D4C
		// (set) Token: 0x06000184 RID: 388 RVA: 0x00002B54 File Offset: 0x00000D54
		internal virtual FlatLabel speed_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00002B5D File Offset: 0x00000D5D
		// (set) Token: 0x06000186 RID: 390 RVA: 0x0000FC60 File Offset: 0x0000DE60
		internal virtual FlatToggle numpad8_toggle
		{
			[CompilerGenerated]
			get
			{
				return this._numpad8_toggle;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				FlatToggle.CheckedChangedEventHandler value2 = new FlatToggle.CheckedChangedEventHandler(this.speed_btn_CheckedChanged);
				FlatToggle numpad8_toggle = this._numpad8_toggle;
				if (numpad8_toggle != null)
				{
					numpad8_toggle.CheckedChanged -= value2;
				}
				this._numpad8_toggle = value;
				numpad8_toggle = this._numpad8_toggle;
				if (numpad8_toggle != null)
				{
					numpad8_toggle.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00002B65 File Offset: 0x00000D65
		// (set) Token: 0x06000188 RID: 392 RVA: 0x0000FCA4 File Offset: 0x0000DEA4
		internal virtual Timer speed_timer
		{
			[CompilerGenerated]
			get
			{
				return this._speed_timer;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.speed_timer_Tick);
				Timer speed_timer = this._speed_timer;
				if (speed_timer != null)
				{
					speed_timer.Tick -= value2;
				}
				this._speed_timer = value;
				speed_timer = this._speed_timer;
				if (speed_timer != null)
				{
					speed_timer.Tick += value2;
				}
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00002B6D File Offset: 0x00000D6D
		// (set) Token: 0x0600018A RID: 394 RVA: 0x00002B75 File Offset: 0x00000D75
		internal virtual FlatLabel stealth_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600018B RID: 395 RVA: 0x00002B7E File Offset: 0x00000D7E
		// (set) Token: 0x0600018C RID: 396 RVA: 0x0000FCE8 File Offset: 0x0000DEE8
		internal virtual FlatToggle numpad4_toggle
		{
			[CompilerGenerated]
			get
			{
				return this._numpad4_toggle;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				FlatToggle.CheckedChangedEventHandler value2 = new FlatToggle.CheckedChangedEventHandler(this.stealth_btn_CheckedChanged);
				FlatToggle numpad4_toggle = this._numpad4_toggle;
				if (numpad4_toggle != null)
				{
					numpad4_toggle.CheckedChanged -= value2;
				}
				this._numpad4_toggle = value;
				numpad4_toggle = this._numpad4_toggle;
				if (numpad4_toggle != null)
				{
					numpad4_toggle.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600018D RID: 397 RVA: 0x00002B86 File Offset: 0x00000D86
		// (set) Token: 0x0600018E RID: 398 RVA: 0x0000FD2C File Offset: 0x0000DF2C
		internal virtual FlatToggle numpad5_toggle
		{
			[CompilerGenerated]
			get
			{
				return this._numpad5_toggle;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				FlatToggle.CheckedChangedEventHandler value2 = new FlatToggle.CheckedChangedEventHandler(this.FlatToggle1_CheckedChanged_1);
				FlatToggle numpad5_toggle = this._numpad5_toggle;
				if (numpad5_toggle != null)
				{
					numpad5_toggle.CheckedChanged -= value2;
				}
				this._numpad5_toggle = value;
				numpad5_toggle = this._numpad5_toggle;
				if (numpad5_toggle != null)
				{
					numpad5_toggle.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600018F RID: 399 RVA: 0x00002B8E File Offset: 0x00000D8E
		// (set) Token: 0x06000190 RID: 400 RVA: 0x00002B96 File Offset: 0x00000D96
		internal virtual FlatLabel FlatLabel8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000191 RID: 401 RVA: 0x00002B9F File Offset: 0x00000D9F
		// (set) Token: 0x06000192 RID: 402 RVA: 0x00002BA7 File Offset: 0x00000DA7
		internal virtual FlatLabel FlatLabel9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000193 RID: 403 RVA: 0x00002BB0 File Offset: 0x00000DB0
		// (set) Token: 0x06000194 RID: 404 RVA: 0x0000FD70 File Offset: 0x0000DF70
		internal virtual FlatToggle numpad6_toggle
		{
			[CompilerGenerated]
			get
			{
				return this._numpad6_toggle;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				FlatToggle.CheckedChangedEventHandler value2 = new FlatToggle.CheckedChangedEventHandler(this.FlatToggle2_CheckedChanged);
				FlatToggle numpad6_toggle = this._numpad6_toggle;
				if (numpad6_toggle != null)
				{
					numpad6_toggle.CheckedChanged -= value2;
				}
				this._numpad6_toggle = value;
				numpad6_toggle = this._numpad6_toggle;
				if (numpad6_toggle != null)
				{
					numpad6_toggle.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000195 RID: 405 RVA: 0x00002BB8 File Offset: 0x00000DB8
		// (set) Token: 0x06000196 RID: 406 RVA: 0x00002BC0 File Offset: 0x00000DC0
		internal virtual FlatLabel FlatLabel10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000197 RID: 407 RVA: 0x00002BC9 File Offset: 0x00000DC9
		// (set) Token: 0x06000198 RID: 408 RVA: 0x0000FDB4 File Offset: 0x0000DFB4
		internal virtual FlatToggle numpad7_toggle
		{
			[CompilerGenerated]
			get
			{
				return this._numpad7_toggle;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				FlatToggle.CheckedChangedEventHandler value2 = new FlatToggle.CheckedChangedEventHandler(this.FlatToggle3_CheckedChanged);
				FlatToggle numpad7_toggle = this._numpad7_toggle;
				if (numpad7_toggle != null)
				{
					numpad7_toggle.CheckedChanged -= value2;
				}
				this._numpad7_toggle = value;
				numpad7_toggle = this._numpad7_toggle;
				if (numpad7_toggle != null)
				{
					numpad7_toggle.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000199 RID: 409 RVA: 0x00002BD1 File Offset: 0x00000DD1
		// (set) Token: 0x0600019A RID: 410 RVA: 0x00002BD9 File Offset: 0x00000DD9
		internal virtual LogInLabel trainer_sts_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00002BE2 File Offset: 0x00000DE2
		// (set) Token: 0x0600019C RID: 412 RVA: 0x0000FDF8 File Offset: 0x0000DFF8
		internal virtual Timer game_checker
		{
			[CompilerGenerated]
			get
			{
				return this._game_checker;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.game_checker_Tick);
				Timer game_checker = this._game_checker;
				if (game_checker != null)
				{
					game_checker.Tick -= value2;
				}
				this._game_checker = value;
				game_checker = this._game_checker;
				if (game_checker != null)
				{
					game_checker.Tick += value2;
				}
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00002BEA File Offset: 0x00000DEA
		// (set) Token: 0x0600019E RID: 414 RVA: 0x00002BF2 File Offset: 0x00000DF2
		internal virtual PictureBox PictureBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00002BFB File Offset: 0x00000DFB
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x0000FE3C File Offset: 0x0000E03C
		internal virtual PictureBox russian_lang
		{
			[CompilerGenerated]
			get
			{
				return this._russian_lang;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.PictureBox4_Click);
				EventHandler value3 = new EventHandler(this.PictureBox4_MouseLeave);
				EventHandler value4 = new EventHandler(this.PictureBox4_MouseHover);
				PictureBox russian_lang = this._russian_lang;
				if (russian_lang != null)
				{
					russian_lang.Click -= value2;
					russian_lang.MouseLeave -= value3;
					russian_lang.MouseHover -= value4;
				}
				this._russian_lang = value;
				russian_lang = this._russian_lang;
				if (russian_lang != null)
				{
					russian_lang.Click += value2;
					russian_lang.MouseLeave += value3;
					russian_lang.MouseHover += value4;
				}
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00002C03 File Offset: 0x00000E03
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x0000FEB8 File Offset: 0x0000E0B8
		internal virtual PictureBox english_lang
		{
			[CompilerGenerated]
			get
			{
				return this._english_lang;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.PictureBox3_Click);
				EventHandler value3 = new EventHandler(this.PictureBox3_MouseLeave);
				EventHandler value4 = new EventHandler(this.PictureBox3_MouseHover);
				PictureBox english_lang = this._english_lang;
				if (english_lang != null)
				{
					english_lang.Click -= value2;
					english_lang.MouseLeave -= value3;
					english_lang.MouseHover -= value4;
				}
				this._english_lang = value;
				english_lang = this._english_lang;
				if (english_lang != null)
				{
					english_lang.Click += value2;
					english_lang.MouseLeave += value3;
					english_lang.MouseHover += value4;
				}
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00002C0B File Offset: 0x00000E0B
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x0000FF34 File Offset: 0x0000E134
		internal virtual PictureBox german_lang
		{
			[CompilerGenerated]
			get
			{
				return this._german_lang;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.PictureBox5_Click);
				EventHandler value3 = new EventHandler(this.PictureBox5_MouseHover);
				EventHandler value4 = new EventHandler(this.PictureBox5_MouseLeave);
				PictureBox german_lang = this._german_lang;
				if (german_lang != null)
				{
					german_lang.Click -= value2;
					german_lang.MouseHover -= value3;
					german_lang.MouseLeave -= value4;
				}
				this._german_lang = value;
				german_lang = this._german_lang;
				if (german_lang != null)
				{
					german_lang.Click += value2;
					german_lang.MouseHover += value3;
					german_lang.MouseLeave += value4;
				}
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00002C13 File Offset: 0x00000E13
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x00002C1B File Offset: 0x00000E1B
		internal virtual FlatStatusBar game_status_bar { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00002C24 File Offset: 0x00000E24
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x00002C2C File Offset: 0x00000E2C
		internal virtual LogInSeperator LogInSeperator1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x00002C35 File Offset: 0x00000E35
		// (set) Token: 0x060001AA RID: 426 RVA: 0x00002C3D File Offset: 0x00000E3D
		internal virtual FlatLabel enable_trainer_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001AB RID: 427 RVA: 0x00002C46 File Offset: 0x00000E46
		// (set) Token: 0x060001AC RID: 428 RVA: 0x00002C4E File Offset: 0x00000E4E
		internal virtual FlatLabel trainer_st_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001AD RID: 429 RVA: 0x00002C57 File Offset: 0x00000E57
		// (set) Token: 0x060001AE RID: 430 RVA: 0x0000FFB0 File Offset: 0x0000E1B0
		internal virtual FlatToggle trainer_status_btn
		{
			[CompilerGenerated]
			get
			{
				return this._trainer_status_btn;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				FlatToggle.CheckedChangedEventHandler value2 = new FlatToggle.CheckedChangedEventHandler(this.trainer_status_btn_CheckedChanged);
				FlatToggle trainer_status_btn = this._trainer_status_btn;
				if (trainer_status_btn != null)
				{
					trainer_status_btn.CheckedChanged -= value2;
				}
				this._trainer_status_btn = value;
				trainer_status_btn = this._trainer_status_btn;
				if (trainer_status_btn != null)
				{
					trainer_status_btn.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001AF RID: 431 RVA: 0x00002C5F File Offset: 0x00000E5F
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x00002C67 File Offset: 0x00000E67
		internal virtual FlatLabel numpad1_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00002C70 File Offset: 0x00000E70
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x00002C78 File Offset: 0x00000E78
		internal virtual FlatLabel numpad7_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00002C81 File Offset: 0x00000E81
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x00002C89 File Offset: 0x00000E89
		internal virtual FlatLabel numpad6_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x00002C92 File Offset: 0x00000E92
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x00002C9A File Offset: 0x00000E9A
		internal virtual FlatLabel numpad5_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00002CA3 File Offset: 0x00000EA3
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x00002CAB File Offset: 0x00000EAB
		internal virtual FlatLabel numpad4_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00002CB4 File Offset: 0x00000EB4
		// (set) Token: 0x060001BA RID: 442 RVA: 0x00002CBC File Offset: 0x00000EBC
		internal virtual FlatLabel numpad3_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00002CC5 File Offset: 0x00000EC5
		// (set) Token: 0x060001BC RID: 444 RVA: 0x00002CCD File Offset: 0x00000ECD
		internal virtual FlatLabel numpad2_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00002CD6 File Offset: 0x00000ED6
		// (set) Token: 0x060001BE RID: 446 RVA: 0x00002CDE File Offset: 0x00000EDE
		internal virtual FlatLabel numpad8_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00002CE7 File Offset: 0x00000EE7
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x00002CEF File Offset: 0x00000EEF
		internal virtual FlatTabControl FlatTabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00002CF8 File Offset: 0x00000EF8
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x00002D00 File Offset: 0x00000F00
		internal virtual TabPage trainer_tab { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00002D09 File Offset: 0x00000F09
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00002D11 File Offset: 0x00000F11
		internal virtual TabPage md5_tab { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00002D1A File Offset: 0x00000F1A
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x00002D22 File Offset: 0x00000F22
		internal virtual TabPage trn_settings_tab { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00002D2B File Offset: 0x00000F2B
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x00002D33 File Offset: 0x00000F33
		internal virtual FlatLabel toggle_btn_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00002D3C File Offset: 0x00000F3C
		// (set) Token: 0x060001CA RID: 458 RVA: 0x0000FFF4 File Offset: 0x0000E1F4
		internal virtual FlatToggle toggle_btn
		{
			[CompilerGenerated]
			get
			{
				return this._toggle_btn;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				FlatToggle.CheckedChangedEventHandler value2 = new FlatToggle.CheckedChangedEventHandler(this.toggle_btn_CheckedChanged);
				FlatToggle toggle_btn = this._toggle_btn;
				if (toggle_btn != null)
				{
					toggle_btn.CheckedChanged -= value2;
				}
				this._toggle_btn = value;
				toggle_btn = this._toggle_btn;
				if (toggle_btn != null)
				{
					toggle_btn.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001CB RID: 459 RVA: 0x00002D44 File Offset: 0x00000F44
		// (set) Token: 0x060001CC RID: 460 RVA: 0x00002D4C File Offset: 0x00000F4C
		internal virtual FlatLabel enb_hotkey_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00002D55 File Offset: 0x00000F55
		// (set) Token: 0x060001CE RID: 462 RVA: 0x00010038 File Offset: 0x0000E238
		internal virtual FlatToggle Hotkey_toggle
		{
			[CompilerGenerated]
			get
			{
				return this._Hotkey_toggle;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				FlatToggle.CheckedChangedEventHandler value2 = new FlatToggle.CheckedChangedEventHandler(this.Hotkey_toggle_CheckedChanged);
				FlatToggle hotkey_toggle = this._Hotkey_toggle;
				if (hotkey_toggle != null)
				{
					hotkey_toggle.CheckedChanged -= value2;
				}
				this._Hotkey_toggle = value;
				hotkey_toggle = this._Hotkey_toggle;
				if (hotkey_toggle != null)
				{
					hotkey_toggle.CheckedChanged += value2;
				}
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00002D5D File Offset: 0x00000F5D
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x00002D65 File Offset: 0x00000F65
		internal virtual FlatAlertBox md5_alter_box { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x00002D6E File Offset: 0x00000F6E
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x00002D76 File Offset: 0x00000F76
		internal virtual FlatLabel language_sel_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00002D7F File Offset: 0x00000F7F
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x00002D87 File Offset: 0x00000F87
		internal virtual LogInSeperator LogInSeperator3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00002D90 File Offset: 0x00000F90
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x0001007C File Offset: 0x0000E27C
		internal virtual FlatButton Check_btn
		{
			[CompilerGenerated]
			get
			{
				return this._Check_btn;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Check_btn_Click);
				FlatButton check_btn = this._Check_btn;
				if (check_btn != null)
				{
					check_btn.Click -= value2;
				}
				this._Check_btn = value;
				check_btn = this._Check_btn;
				if (check_btn != null)
				{
					check_btn.Click += value2;
				}
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00002D98 File Offset: 0x00000F98
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x00002DA0 File Offset: 0x00000FA0
		internal virtual FlatLabel your_hash_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00002DA9 File Offset: 0x00000FA9
		// (set) Token: 0x060001DA RID: 474 RVA: 0x00002DB1 File Offset: 0x00000FB1
		internal virtual FlatLabel game_hash_lbl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00002DBA File Offset: 0x00000FBA
		// (set) Token: 0x060001DC RID: 476 RVA: 0x00002DC2 File Offset: 0x00000FC2
		internal virtual FlatTextBox your_hash_txt { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00002DCB File Offset: 0x00000FCB
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00002DD3 File Offset: 0x00000FD3
		internal virtual FlatTextBox game_hash_txt { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00002DDC File Offset: 0x00000FDC
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x00002DE4 File Offset: 0x00000FE4
		internal virtual OpenFileDialog OpenFileDialog1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00002DED File Offset: 0x00000FED
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x00002DF5 File Offset: 0x00000FF5
		internal virtual FlatTextBox filepath_txt { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x040000A9 RID: 169
		private const string ProcName = "Dishonored";

		// Token: 0x040000AA RID: 170
		private int BaseAddress_EXE;

		// Token: 0x040000AB RID: 171
		private bool Insert;

		// Token: 0x040000AC RID: 172
		private bool Numpad1;

		// Token: 0x040000AD RID: 173
		private bool Numpad2;

		// Token: 0x040000AE RID: 174
		private bool Numpad3;

		// Token: 0x040000AF RID: 175
		private bool Numpad4;

		// Token: 0x040000B0 RID: 176
		private bool Numpad5;

		// Token: 0x040000B1 RID: 177
		private bool Numpad6;

		// Token: 0x040000B2 RID: 178
		private bool Numpad7;

		// Token: 0x040000B3 RID: 179
		private bool Numpad8;

		// Token: 0x040000B4 RID: 180
		public int baseaddr;

		// Token: 0x040000B5 RID: 181
		public const string ModuleName = "Dishonored.exe";

		// Token: 0x040000B6 RID: 182
		private long alloc;

		// Token: 0x040000B7 RID: 183
		private bool health;

		// Token: 0x040000B8 RID: 184
		private bool blinkdis;

		// Token: 0x040000B9 RID: 185
		private bool ammo;

		// Token: 0x040000BA RID: 186
		private bool reload;

		// Token: 0x040000BB RID: 187
		public long procid;

		// Token: 0x040000BC RID: 188
		public int caveaddr;

		// Token: 0x040000BD RID: 189
		public int jmpbytes;

		// Token: 0x040000BE RID: 190
		private long addtinc;

		// Token: 0x040000BF RID: 191
		private byte[] health_bytes;

		// Token: 0x040000C0 RID: 192
		private byte[] health_org_bytes;

		// Token: 0x040000C1 RID: 193
		private long offset_health;

		// Token: 0x040000C2 RID: 194
		private byte[] blinkdis_bytes;

		// Token: 0x040000C3 RID: 195
		private byte[] blinkdis_org_bytes;

		// Token: 0x040000C4 RID: 196
		private long offset_blinkdis;

		// Token: 0x040000C5 RID: 197
		private byte[] ammo_bytes;

		// Token: 0x040000C6 RID: 198
		private byte[] ammo_org_bytes;

		// Token: 0x040000C7 RID: 199
		private long offset_ammo;

		// Token: 0x040000C8 RID: 200
		private byte[] reload_bytes;

		// Token: 0x040000C9 RID: 201
		private byte[] reload_org_bytes;

		// Token: 0x040000CA RID: 202
		private long offset_reload;
	}
}
