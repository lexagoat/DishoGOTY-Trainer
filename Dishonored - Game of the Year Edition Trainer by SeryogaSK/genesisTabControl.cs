using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000025 RID: 37
	internal class genesisTabControl : TabControl
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000208 RID: 520 RVA: 0x000116C8 File Offset: 0x0000F8C8
		// (set) Token: 0x06000209 RID: 521 RVA: 0x00002E8F File Offset: 0x0000108F
		public Color TabTextColor
		{
			get
			{
				return this._ControlBColor;
			}
			set
			{
				this._ControlBColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x0600020A RID: 522 RVA: 0x000116E0 File Offset: 0x0000F8E0
		public genesisTabControl()
		{
			this.LightBlack = Color.FromArgb(37, 37, 37);
			this.LighterBlack = Color.FromArgb(44, 44, 44);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			this.TabTextColor = Color.White;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0001172C File Offset: 0x0000F92C
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			checked
			{
				Rectangle rect = new Rectangle(2, 0, base.Width - 1, 11);
				Rectangle rect2 = new Rectangle(2, 0, base.Width - 1, 11);
				e.Graphics.Clear(Color.FromArgb(37, 37, 37));
				SolidBrush solidBrush = new SolidBrush(Color.Empty);
				SolidBrush solidBrush2 = new SolidBrush(Color.DimGray);
				e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(33, 33, 33)), new Rectangle(1, 1, base.Width - 2, base.Height - 2));
				this.DrawGradientBrush2 = new LinearGradientBrush(rect2, Color.FromArgb(62, Color.White), Color.FromArgb(30, Color.White), 90f);
				e.Graphics.FillRectangle(this.DrawGradientBrush2, rect);
				int num = base.TabCount - 1;
				for (int i = 0; i <= num; i++)
				{
					Rectangle tabRect = base.GetTabRect(i);
					if ((i & 1) != 0)
					{
						solidBrush2.Color = Color.Transparent;
					}
					else
					{
						solidBrush2.Color = Color.Transparent;
					}
					e.Graphics.FillRectangle(solidBrush2, tabRect);
					Pen pen;
					if (i == base.SelectedIndex)
					{
						pen = new Pen(Color.Transparent, 1f);
					}
					else
					{
						pen = new Pen(Color.Transparent, 1f);
					}
					e.Graphics.DrawRectangle(pen, new Rectangle(tabRect.Location.X + 3, tabRect.Location.Y + 1, tabRect.Width - 8, tabRect.Height - 4));
					pen.Dispose();
					StringFormat stringFormat = new StringFormat();
					stringFormat.LineAlignment = StringAlignment.Center;
					stringFormat.Alignment = StringAlignment.Center;
					if (base.SelectedIndex == i)
					{
						solidBrush.Color = this.TabTextColor;
					}
					else
					{
						solidBrush.Color = Color.DimGray;
					}
					e.Graphics.DrawString(base.TabPages[i].Text, this.Font, solidBrush, base.GetTabRect(i), stringFormat);
					try
					{
						base.TabPages[i].BackColor = Color.FromArgb(35, 35, 35);
					}
					catch (Exception ex)
					{
					}
				}
				try
				{
					try
					{
						foreach (object obj in base.TabPages)
						{
							TabPage tabPage = (TabPage)obj;
							tabPage.BorderStyle = BorderStyle.None;
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				catch (Exception ex2)
				{
				}
				e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(255, Color.Black))), 2, 0, base.Width - 3, base.Height - 3);
				e.Graphics.DrawRectangle(new Pen(new SolidBrush(this.LighterBlack)), new Rectangle(3, 24, base.Width - 5, base.Height - 28));
				e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(255, Color.Black))), 2, 23, base.Width - 2, 23);
				e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(35, 35, 35))), 0, 0, 1, 1);
				e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(70, 70, 70))), 2, base.Height - 2, base.Width + 1, base.Height - 2);
			}
		}

		// Token: 0x0400013C RID: 316
		private Color LightBlack;

		// Token: 0x0400013D RID: 317
		private Color LighterBlack;

		// Token: 0x0400013E RID: 318
		private LinearGradientBrush DrawGradientBrush;

		// Token: 0x0400013F RID: 319
		private LinearGradientBrush DrawGradientBrush2;

		// Token: 0x04000140 RID: 320
		private Color _ControlBColor;
	}
}
