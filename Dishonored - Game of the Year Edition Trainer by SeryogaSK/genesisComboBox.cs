using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000026 RID: 38
	internal class genesisComboBox : ComboBox
	{
		// Token: 0x0600020C RID: 524 RVA: 0x00011AEC File Offset: 0x0000FCEC
		public genesisComboBox()
		{
			base.DrawItem += this.ReplaceItem;
			this._StartIndex = 0;
			this.LightBlack = Color.FromArgb(37, 37, 37);
			this.LighterBlack = Color.FromArgb(60, 60, 60);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.DrawMode = DrawMode.OwnerDrawFixed;
			this.BackColor = Color.FromArgb(45, 45, 45);
			this.ForeColor = Color.White;
			base.DropDownStyle = ComboBoxStyle.DropDownList;
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00011B70 File Offset: 0x0000FD70
		// (set) Token: 0x0600020E RID: 526 RVA: 0x00011B88 File Offset: 0x0000FD88
		public int StartIndex
		{
			get
			{
				return this._StartIndex;
			}
			set
			{
				this._StartIndex = value;
				try
				{
					base.SelectedIndex = value;
				}
				catch (Exception ex)
				{
				}
				base.Invalidate();
			}
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00011BC8 File Offset: 0x0000FDC8
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, base.Width, 10), Color.FromArgb(62, Color.White), Color.FromArgb(30, Color.White), 90f);
			new SolidBrush(Color.FromArgb(37, 37, 37));
			checked
			{
				try
				{
					Graphics graphics2 = graphics;
					graphics.SmoothingMode = SmoothingMode.HighQuality;
					graphics2.Clear(Color.FromArgb(37, 37, 37));
					graphics2.FillRectangle(brush, new Rectangle(0, 0, base.Width, 9));
					graphics2.DrawString(base.Items[this.SelectedIndex].ToString(), this.Font, Brushes.White, new Point(3, 3));
					graphics2.DrawLine(new Pen(new SolidBrush(Color.FromArgb(37, 37, 37))), 0, 0, 0, 0);
					graphics2.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(0, 0, 0))), new Rectangle(1, 1, base.Width - 3, base.Height - 3));
					graphics2.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, base.Width, 0);
					graphics2.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, base.Height);
					graphics2.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), base.Width - 1, 0, base.Width - 1, base.Height);
					graphics2.DrawLine(new Pen(new SolidBrush(Color.FromArgb(70, 70, 70))), 0, base.Height - 1, base.Width, base.Height - 1);
					this.DrawTriangle(Color.White, new Point(base.Width - 15, 8), new Point(base.Width - 7, 8), new Point(base.Width - 11, 13), graphics);
				}
				catch (Exception ex)
				{
				}
			}
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00011DE8 File Offset: 0x0000FFE8
		public void ReplaceItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			try
			{
				if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				{
					e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(37, 37, 37)), e.Bounds);
				}
				using (SolidBrush solidBrush = new SolidBrush(e.ForeColor))
				{
					e.Graphics.DrawString(base.GetItemText(RuntimeHelpers.GetObjectValue(base.Items[e.Index])), e.Font, solidBrush, e.Bounds);
				}
			}
			catch (Exception ex)
			{
			}
			e.DrawFocusRectangle();
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00011EAC File Offset: 0x000100AC
		protected void DrawTriangle(Color Clr, Point FirstPoint, Point SecondPoint, Point ThirdPoint, Graphics G)
		{
			List<Point> list = new List<Point>();
			list.Add(FirstPoint);
			list.Add(SecondPoint);
			list.Add(ThirdPoint);
			G.FillPolygon(new SolidBrush(Clr), list.ToArray());
		}

		// Token: 0x04000141 RID: 321
		private int _StartIndex;

		// Token: 0x04000142 RID: 322
		private Color LightBlack;

		// Token: 0x04000143 RID: 323
		private Color LighterBlack;
	}
}
