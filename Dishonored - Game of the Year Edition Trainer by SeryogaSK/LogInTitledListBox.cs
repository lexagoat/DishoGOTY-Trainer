using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x0200003C RID: 60
	public class LogInTitledListBox : Control
	{
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060003F8 RID: 1016 RVA: 0x00003B19 File Offset: 0x00001D19
		// (set) Token: 0x060003F9 RID: 1017 RVA: 0x00018054 File Offset: 0x00016254
		private virtual ListBox ListB
		{
			[CompilerGenerated]
			get
			{
				return this._ListB;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DrawItemEventHandler value2 = new DrawItemEventHandler(this.Drawitem);
				ListBox listB = this._ListB;
				if (listB != null)
				{
					listB.DrawItem -= value2;
				}
				this._ListB = value;
				listB = this._ListB;
				if (listB != null)
				{
					listB.DrawItem += value2;
				}
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x00018098 File Offset: 0x00016298
		// (set) Token: 0x060003FB RID: 1019 RVA: 0x00003B21 File Offset: 0x00001D21
		[Category("Control")]
		public Font TitleFont
		{
			get
			{
				return this._TitleFont;
			}
			set
			{
				this._TitleFont = value;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x000180B0 File Offset: 0x000162B0
		// (set) Token: 0x060003FD RID: 1021 RVA: 0x00003B2A File Offset: 0x00001D2A
		[Category("Control")]
		public string[] Items
		{
			get
			{
				return this._Items;
			}
			set
			{
				this._Items = value;
				this.ListB.Items.Clear();
				this.ListB.Items.AddRange(value);
				base.Invalidate();
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060003FE RID: 1022 RVA: 0x000180C8 File Offset: 0x000162C8
		// (set) Token: 0x060003FF RID: 1023 RVA: 0x00003B5A File Offset: 0x00001D5A
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

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000400 RID: 1024 RVA: 0x000180E0 File Offset: 0x000162E0
		// (set) Token: 0x06000401 RID: 1025 RVA: 0x00003B63 File Offset: 0x00001D63
		[Category("Colours")]
		public Color SelectedColour
		{
			get
			{
				return this._SelectedColour;
			}
			set
			{
				this._SelectedColour = value;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x000180F8 File Offset: 0x000162F8
		// (set) Token: 0x06000403 RID: 1027 RVA: 0x00003B6C File Offset: 0x00001D6C
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

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x00018110 File Offset: 0x00016310
		// (set) Token: 0x06000405 RID: 1029 RVA: 0x00003B75 File Offset: 0x00001D75
		[Category("Colours")]
		public Color ListBaseColour
		{
			get
			{
				return this._ListBaseColour;
			}
			set
			{
				this._ListBaseColour = value;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x00018128 File Offset: 0x00016328
		// (set) Token: 0x06000407 RID: 1031 RVA: 0x00003B7E File Offset: 0x00001D7E
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

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x00018140 File Offset: 0x00016340
		public string SelectedItem
		{
			get
			{
				return Conversions.ToString(this.ListB.SelectedItem);
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x00018160 File Offset: 0x00016360
		public int SelectedIndex
		{
			get
			{
				return this.ListB.SelectedIndex;
			}
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x00003B87 File Offset: 0x00001D87
		public void Clear()
		{
			this.ListB.Items.Clear();
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0001817C File Offset: 0x0001637C
		public void ClearSelected()
		{
			checked
			{
				int num = this.ListB.SelectedItems.Count - 1;
				for (int i = num; i >= 0; i += -1)
				{
					this.ListB.Items.Remove(RuntimeHelpers.GetObjectValue(this.ListB.SelectedItems[i]));
				}
			}
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x000181D0 File Offset: 0x000163D0
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (!base.Controls.Contains(this.ListB))
			{
				base.Controls.Add(this.ListB);
			}
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00003B99 File Offset: 0x00001D99
		public void AddRange(object[] items)
		{
			this.ListB.Items.Remove("");
			this.ListB.Items.AddRange(items);
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00003BC1 File Offset: 0x00001DC1
		public void AddItem(object item)
		{
			this.ListB.Items.Remove("");
			this.ListB.Items.Add(RuntimeHelpers.GetObjectValue(item));
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0001820C File Offset: 0x0001640C
		public void Drawitem(object sender, DrawItemEventArgs e)
		{
			checked
			{
				if (e.Index >= 0)
				{
					e.DrawBackground();
					e.DrawFocusRectangle();
					Graphics graphics = e.Graphics;
					graphics.SmoothingMode = SmoothingMode.HighQuality;
					graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
					if (Strings.InStr(e.State.ToString(), "Selected,", CompareMethod.Binary) > 0)
					{
						graphics.FillRectangle(new SolidBrush(this._SelectedColour), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - 1));
						graphics.DrawString(" " + this.ListB.Items[e.Index].ToString(), new Font("Segoe UI", 9f, FontStyle.Bold), new SolidBrush(this._TextColour), (float)e.Bounds.X, (float)(e.Bounds.Y + 2));
					}
					else
					{
						graphics.FillRectangle(new SolidBrush(this._ListBaseColour), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
						graphics.DrawString(" " + this.ListB.Items[e.Index].ToString(), new Font("Segoe UI", 8f), new SolidBrush(this._TextColour), (float)e.Bounds.X, (float)(e.Bounds.Y + 2));
					}
					graphics.Dispose();
				}
			}
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00018400 File Offset: 0x00016600
		public LogInTitledListBox()
		{
			this.ListB = new ListBox();
			this._Items = new string[]
			{
				""
			};
			this._BaseColour = Color.FromArgb(42, 42, 42);
			this._SelectedColour = Color.FromArgb(55, 55, 55);
			this._ListBaseColour = Color.FromArgb(47, 47, 47);
			this._TextColour = Color.FromArgb(255, 255, 255);
			this._BorderColour = Color.FromArgb(35, 35, 35);
			this._TitleFont = new Font("Segeo UI", 10f, FontStyle.Bold);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.ListB.DrawMode = DrawMode.OwnerDrawFixed;
			this.ListB.ScrollAlwaysVisible = false;
			this.ListB.HorizontalScrollbar = false;
			this.ListB.BorderStyle = BorderStyle.None;
			this.ListB.BackColor = this.BaseColour;
			this.ListB.Location = new Point(3, 28);
			this.ListB.Font = new Font("Segoe UI", 8f);
			this.ListB.ItemHeight = 20;
			this.ListB.Items.Clear();
			this.ListB.IntegralHeight = false;
			base.Size = new Size(130, 100);
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00018564 File Offset: 0x00016764
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			checked
			{
				this.ListB.Size = new Size(base.Width - 6, base.Height - 30);
				graphics2.FillRectangle(new SolidBrush(this.BaseColour), rect);
				graphics2.DrawRectangle(new Pen(this._BorderColour, 3f), new Rectangle(0, 0, base.Width, base.Height - 1));
				graphics2.DrawLine(new Pen(this._BorderColour, 2f), new Point(0, 27), new Point(base.Width - 1, 27));
				graphics2.DrawString(this.Text, this._TitleFont, new SolidBrush(this._TextColour), new Rectangle(2, 5, base.Width - 5, 20), new StringFormat
				{
					Alignment = StringAlignment.Center,
					LineAlignment = StringAlignment.Center
				});
				base.OnPaint(e);
				graphics.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x040001F9 RID: 505
		private string[] _Items;

		// Token: 0x040001FA RID: 506
		private Color _BaseColour;

		// Token: 0x040001FB RID: 507
		private Color _SelectedColour;

		// Token: 0x040001FC RID: 508
		private Color _ListBaseColour;

		// Token: 0x040001FD RID: 509
		private Color _TextColour;

		// Token: 0x040001FE RID: 510
		private Color _BorderColour;

		// Token: 0x040001FF RID: 511
		private Font _TitleFont;
	}
}
