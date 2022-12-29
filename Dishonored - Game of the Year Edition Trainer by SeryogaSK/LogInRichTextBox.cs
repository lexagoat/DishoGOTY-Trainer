using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200003F RID: 63
	public class LogInRichTextBox : Control
	{
		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x00003C74 File Offset: 0x00001E74
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x00003C7C File Offset: 0x00001E7C
		private virtual RichTextBox TB { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x00018C60 File Offset: 0x00016E60
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x00003C85 File Offset: 0x00001E85
		[Category("Colours")]
		public Color BaseColour
		{
			get
			{
				return this._BaseColour;
			}
			set
			{
				this._BaseColour = value;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x00018C78 File Offset: 0x00016E78
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x00003C8E File Offset: 0x00001E8E
		[Category("Colours")]
		public Color BorderColour
		{
			get
			{
				return this._BorderColour;
			}
			set
			{
				this._BorderColour = value;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x00018C90 File Offset: 0x00016E90
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x00003C97 File Offset: 0x00001E97
		[Category("Colours")]
		public Color TextColour
		{
			get
			{
				return this._TextColour;
			}
			set
			{
				this._TextColour = value;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x00018CA8 File Offset: 0x00016EA8
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x00003CA0 File Offset: 0x00001EA0
		public override string Text
		{
			get
			{
				return this.TB.Text;
			}
			set
			{
				this.TB.Text = value;
				base.Invalidate();
			}
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00003CB4 File Offset: 0x00001EB4
		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged(e);
			this.TB.BackColor = this.BackColor;
			base.Invalidate();
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00003CD4 File Offset: 0x00001ED4
		protected override void OnForeColorChanged(EventArgs e)
		{
			base.OnForeColorChanged(e);
			this.TB.ForeColor = this.ForeColor;
			base.Invalidate();
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00003CF4 File Offset: 0x00001EF4
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			this.TB.Size = checked(new Size(base.Width - 10, base.Height - 11));
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00003D1F File Offset: 0x00001F1F
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			this.TB.Font = this.Font;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00003D39 File Offset: 0x00001F39
		public void TextChanges()
		{
			this.TB.Text = this.Text;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00018CC4 File Offset: 0x00016EC4
		public LogInRichTextBox()
		{
			base.TextChanged += delegate(object sender, EventArgs e)
			{
				this.TextChanges();
			};
			this.TB = new RichTextBox();
			this._BaseColour = Color.FromArgb(42, 42, 42);
			this._TextColour = Color.FromArgb(255, 255, 255);
			this._BorderColour = Color.FromArgb(35, 35, 35);
			RichTextBox tb = this.TB;
			tb.Multiline = true;
			tb.BackColor = this._BaseColour;
			tb.ForeColor = this._TextColour;
			tb.Text = string.Empty;
			tb.BorderStyle = BorderStyle.None;
			tb.Location = new Point(5, 5);
			tb.Font = new Font("Segeo UI", 9f);
			tb.Size = checked(new Size(base.Width - 10, base.Height - 10));
			base.Controls.Add(this.TB);
			base.Size = new Size(135, 35);
			this.DoubleBuffered = true;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00018DD4 File Offset: 0x00016FD4
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rectangle = checked(new Rectangle(0, 0, base.Width - 1, base.Height - 1));
			Graphics graphics2 = graphics;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.Clear(this._BaseColour);
			graphics2.DrawRectangle(new Pen(this._BorderColour, 2f), base.ClientRectangle);
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x0400020A RID: 522
		private Color _BaseColour;

		// Token: 0x0400020B RID: 523
		private Color _TextColour;

		// Token: 0x0400020C RID: 524
		private Color _BorderColour;
	}
}
