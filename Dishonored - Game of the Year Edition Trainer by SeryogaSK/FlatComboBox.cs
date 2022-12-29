using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000016 RID: 22
	internal class FlatComboBox : ComboBox
	{
		// Token: 0x060000DD RID: 221 RVA: 0x00002779 File Offset: 0x00000979
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000278F File Offset: 0x0000098F
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000027A5 File Offset: 0x000009A5
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000027BB File Offset: 0x000009BB
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00008974 File Offset: 0x00006B74
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.Location.X;
			this.y = e.Location.Y;
			base.Invalidate();
			if (e.X < checked(base.Width - 41))
			{
				this.Cursor = Cursors.IBeam;
			}
			else
			{
				this.Cursor = Cursors.Hand;
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000089E4 File Offset: 0x00006BE4
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			base.OnDrawItem(e);
			base.Invalidate();
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				base.Invalidate();
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000027D1 File Offset: 0x000009D1
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			base.Invalidate();
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00008A14 File Offset: 0x00006C14
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x000027E0 File Offset: 0x000009E0
		[Category("Colors")]
		public Color HoverColor
		{
			get
			{
				return this._HoverColor;
			}
			set
			{
				this._HoverColor = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00008A2C File Offset: 0x00006C2C
		// (set) Token: 0x060000E7 RID: 231 RVA: 0x00008A44 File Offset: 0x00006C44
		private int StartIndex
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

		// Token: 0x060000E8 RID: 232 RVA: 0x00008A84 File Offset: 0x00006C84
		public void DrawItem_(object sender, DrawItemEventArgs e)
		{
			if (e.Index >= 0)
			{
				e.DrawBackground();
				e.DrawFocusRectangle();
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				{
					e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 170, 220)), e.Bounds);
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(this._BaseColor), e.Bounds);
				}
				e.Graphics.DrawString(base.GetItemText(RuntimeHelpers.GetObjectValue(base.Items[e.Index])), new Font("Segoe UI", 8f), Brushes.White, checked(new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height)));
				e.Graphics.Dispose();
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000027E9 File Offset: 0x000009E9
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 18;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00008BB8 File Offset: 0x00006DB8
		public FlatComboBox()
		{
			base.DrawItem += this.DrawItem_;
			this._StartIndex = 0;
			this.State = MouseState.None;
			this._BaseColor = Color.FromArgb(60, 60, 60);
			this._BGColor = Color.FromArgb(60, 60, 60);
			this._HoverColor = Color.FromArgb(0, 170, 220);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.DrawMode = DrawMode.OwnerDrawFixed;
			this.BackColor = Color.FromArgb(50, 50, 50);
			this.ForeColor = Color.White;
			base.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Cursor = Cursors.Hand;
			this.StartIndex = 0;
			base.ItemHeight = 18;
			this.Font = new Font("Segoe UI", 8f, FontStyle.Regular);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00008C90 File Offset: 0x00006E90
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			this.W = base.Width;
			this.H = base.Height;
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			checked
			{
				Rectangle rect2 = new Rectangle(this.W - 40, 0, this.W, this.H);
				GraphicsPath graphicsPath = new GraphicsPath();
				new GraphicsPath();
				Graphics g = Helpers.G;
				g.Clear(Color.FromArgb(0, 170, 220));
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.FillRectangle(new SolidBrush(this._BGColor), rect);
				graphicsPath.Reset();
				graphicsPath.AddRectangle(rect2);
				g.SetClip(graphicsPath);
				g.FillRectangle(new SolidBrush(this._BaseColor), rect2);
				g.ResetClip();
				g.DrawLine(Pens.White, this.W - 10, 6, this.W - 30, 6);
				g.DrawLine(Pens.White, this.W - 10, 12, this.W - 30, 12);
				g.DrawLine(Pens.White, this.W - 10, 18, this.W - 30, 18);
				g.DrawString(this.Text, this.Font, Brushes.White, new Point(4, 6), Helpers.NearSF);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}

		// Token: 0x04000075 RID: 117
		private int W;

		// Token: 0x04000076 RID: 118
		private int H;

		// Token: 0x04000077 RID: 119
		private int _StartIndex;

		// Token: 0x04000078 RID: 120
		private int x;

		// Token: 0x04000079 RID: 121
		private int y;

		// Token: 0x0400007A RID: 122
		private MouseState State;

		// Token: 0x0400007B RID: 123
		private Color _BaseColor;

		// Token: 0x0400007C RID: 124
		private Color _BGColor;

		// Token: 0x0400007D RID: 125
		private Color _HoverColor;
	}
}
