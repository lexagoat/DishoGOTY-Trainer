using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x02000009 RID: 9
	internal class FormSkin : ContainerControl
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00004F28 File Offset: 0x00003128
		// (set) Token: 0x06000018 RID: 24 RVA: 0x00002164 File Offset: 0x00000364
		[Category("Colors")]
		public Color HeaderColor
		{
			get
			{
				return this._HeaderColor;
			}
			set
			{
				this._HeaderColor = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00004F40 File Offset: 0x00003140
		// (set) Token: 0x0600001A RID: 26 RVA: 0x0000216D File Offset: 0x0000036D
		[Category("Colors")]
		public Color BaseColor
		{
			get
			{
				return this._BaseColor;
			}
			set
			{
				this._BaseColor = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00004F58 File Offset: 0x00003158
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002176 File Offset: 0x00000376
		[Category("Colors")]
		public Color BorderColor
		{
			get
			{
				return this._BorderColor;
			}
			set
			{
				this._BorderColor = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00004F70 File Offset: 0x00003170
		// (set) Token: 0x0600001E RID: 30 RVA: 0x0000217F File Offset: 0x0000037F
		[Category("Colors")]
		public Color FlatColor
		{
			get
			{
				return Helpers._FlatColor;
			}
			set
			{
				Helpers._FlatColor = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00004F84 File Offset: 0x00003184
		// (set) Token: 0x06000020 RID: 32 RVA: 0x00002187 File Offset: 0x00000387
		[Category("Options")]
		public bool HeaderMaximize
		{
			get
			{
				return this._HeaderMaximize;
			}
			set
			{
				this._HeaderMaximize = value;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00004F98 File Offset: 0x00003198
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left & new Rectangle(0, 0, base.Width, Conversions.ToInteger(this.MoveHeight)).Contains(e.Location))
			{
				this.Cap = true;
				this.MousePoint = e.Location;
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00004FF8 File Offset: 0x000031F8
		private void FormSkin_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.HeaderMaximize && (e.Button == MouseButtons.Left & new Rectangle(0, 0, base.Width, Conversions.ToInteger(this.MoveHeight)).Contains(e.Location)))
			{
				if (base.FindForm().WindowState == FormWindowState.Normal)
				{
					base.FindForm().WindowState = FormWindowState.Maximized;
					base.FindForm().Refresh();
				}
				else if (base.FindForm().WindowState == FormWindowState.Maximized)
				{
					base.FindForm().WindowState = FormWindowState.Normal;
					base.FindForm().Refresh();
				}
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002190 File Offset: 0x00000390
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.Cap = false;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00005098 File Offset: 0x00003298
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (this.Cap)
			{
				base.Parent.Location = Control.MousePosition - (Size)this.MousePoint;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000050D4 File Offset: 0x000032D4
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			base.ParentForm.FormBorderStyle = FormBorderStyle.None;
			base.ParentForm.AllowTransparency = false;
			base.ParentForm.TransparencyKey = Color.Fuchsia;
			base.ParentForm.FindForm().StartPosition = FormStartPosition.CenterScreen;
			this.Dock = DockStyle.Fill;
			base.Invalidate();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00005130 File Offset: 0x00003330
		public FormSkin()
		{
			base.MouseDoubleClick += this.FormSkin_MouseDoubleClick;
			this.Cap = false;
			this._HeaderMaximize = false;
			this.MousePoint = new Point(0, 0);
			this.MoveHeight = 50;
			this._HeaderColor = Color.FromArgb(50, 50, 50);
			this._BaseColor = Color.FromArgb(50, 50, 50);
			this._BorderColor = Color.FromArgb(0, 170, 220);
			this.TextColor = Color.FromArgb(212, 198, 209);
			this._HeaderLight = Color.FromArgb(171, 171, 172);
			this._BaseLight = Color.FromArgb(196, 199, 200);
			this.TextLight = Color.FromArgb(45, 47, 49);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.White;
			this.Font = new Font("Segoe UI", 12f);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00005248 File Offset: 0x00003448
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			this.W = base.Width;
			this.H = base.Height;
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			Rectangle rect2 = new Rectangle(0, 0, this.W, 50);
			Graphics g = Helpers.G;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			g.Clear(this.BackColor);
			g.FillRectangle(new SolidBrush(this._BaseColor), rect);
			g.FillRectangle(new SolidBrush(this._HeaderColor), rect2);
			g.FillRectangle(new SolidBrush(Color.FromArgb(243, 243, 243)), new Rectangle(8, 16, 4, 18));
			g.FillRectangle(new SolidBrush(Color.FromArgb(0, 170, 220)), 16, 16, 4, 18);
			g.DrawString(this.Text, this.Font, new SolidBrush(this.TextColor), new Rectangle(26, 15, this.W, this.H), Helpers.NearSF);
			g.DrawRectangle(new Pen(this._BorderColor), rect);
			base.OnPaint(e);
			Helpers.G.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
			Helpers.B.Dispose();
		}

		// Token: 0x04000010 RID: 16
		private int W;

		// Token: 0x04000011 RID: 17
		private int H;

		// Token: 0x04000012 RID: 18
		private bool Cap;

		// Token: 0x04000013 RID: 19
		private bool _HeaderMaximize;

		// Token: 0x04000014 RID: 20
		private Point MousePoint;

		// Token: 0x04000015 RID: 21
		private object MoveHeight;

		// Token: 0x04000016 RID: 22
		private Color _HeaderColor;

		// Token: 0x04000017 RID: 23
		private Color _BaseColor;

		// Token: 0x04000018 RID: 24
		private Color _BorderColor;

		// Token: 0x04000019 RID: 25
		private Color TextColor;

		// Token: 0x0400001A RID: 26
		private Color _HeaderLight;

		// Token: 0x0400001B RID: 27
		private Color _BaseLight;

		// Token: 0x0400001C RID: 28
		public Color TextLight;
	}
}
