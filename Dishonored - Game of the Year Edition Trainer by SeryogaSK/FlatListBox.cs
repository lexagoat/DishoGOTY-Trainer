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
	// Token: 0x02000019 RID: 25
	internal class FlatListBox : Control
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600010D RID: 269 RVA: 0x000028A1 File Offset: 0x00000AA1
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00009924 File Offset: 0x00007B24
		private virtual ListBox ListBx
		{
			[CompilerGenerated]
			get
			{
				return this._ListBx;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DrawItemEventHandler value2 = new DrawItemEventHandler(this.Drawitem);
				ListBox listBx = this._ListBx;
				if (listBx != null)
				{
					listBx.DrawItem -= value2;
				}
				this._ListBx = value;
				listBx = this._ListBx;
				if (listBx != null)
				{
					listBx.DrawItem += value2;
				}
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00009968 File Offset: 0x00007B68
		// (set) Token: 0x06000110 RID: 272 RVA: 0x000028A9 File Offset: 0x00000AA9
		[Category("Options")]
		public string[] items
		{
			get
			{
				return this._items;
			}
			set
			{
				this._items = value;
				this.ListBx.Items.Clear();
				this.ListBx.Items.AddRange(value);
				base.Invalidate();
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00009980 File Offset: 0x00007B80
		// (set) Token: 0x06000112 RID: 274 RVA: 0x000028D9 File Offset: 0x00000AD9
		[Category("Colors")]
		public Color SelectedColor
		{
			get
			{
				return this._SelectedColor;
			}
			set
			{
				this._SelectedColor = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00009998 File Offset: 0x00007B98
		public string SelectedItem
		{
			get
			{
				return Conversions.ToString(this.ListBx.SelectedItem);
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000114 RID: 276 RVA: 0x000099B8 File Offset: 0x00007BB8
		public int SelectedIndex
		{
			get
			{
				return this.ListBx.SelectedIndex;
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000099D4 File Offset: 0x00007BD4
		public void Drawitem(object sender, DrawItemEventArgs e)
		{
			checked
			{
				if (e.Index >= 0)
				{
					e.DrawBackground();
					e.DrawFocusRectangle();
					e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
					e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
					e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
					if (Strings.InStr(e.State.ToString(), "Selected,", CompareMethod.Binary) > 0)
					{
						e.Graphics.FillRectangle(new SolidBrush(this._SelectedColor), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
						e.Graphics.DrawString(" " + this.ListBx.Items[e.Index].ToString(), new Font("Segoe UI", 8f), Brushes.White, (float)e.Bounds.X, (float)(e.Bounds.Y + 2));
					}
					else
					{
						e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
						e.Graphics.DrawString(" " + this.ListBx.Items[e.Index].ToString(), new Font("Segoe UI", 8f), Brushes.White, (float)e.Bounds.X, (float)(e.Bounds.Y + 2));
					}
					e.Graphics.Dispose();
				}
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00009BD8 File Offset: 0x00007DD8
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (!base.Controls.Contains(this.ListBx))
			{
				base.Controls.Add(this.ListBx);
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000028E2 File Offset: 0x00000AE2
		public void AddRange(object[] items)
		{
			this.ListBx.Items.Remove("");
			this.ListBx.Items.AddRange(items);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000290A File Offset: 0x00000B0A
		public void AddItem(object item)
		{
			this.ListBx.Items.Remove("");
			this.ListBx.Items.Add(RuntimeHelpers.GetObjectValue(item));
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00009C14 File Offset: 0x00007E14
		public FlatListBox()
		{
			this.ListBx = new ListBox();
			this._items = new string[]
			{
				""
			};
			this.BaseColor = Color.FromArgb(60, 60, 60);
			this._SelectedColor = Color.FromArgb(0, 170, 220);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.ListBx.DrawMode = DrawMode.OwnerDrawFixed;
			this.ListBx.ScrollAlwaysVisible = false;
			this.ListBx.HorizontalScrollbar = false;
			this.ListBx.BorderStyle = BorderStyle.None;
			this.ListBx.BackColor = this.BaseColor;
			this.ListBx.ForeColor = Color.White;
			this.ListBx.Location = new Point(3, 3);
			this.ListBx.Font = new Font("Segoe UI", 8f);
			this.ListBx.ItemHeight = 20;
			this.ListBx.Items.Clear();
			this.ListBx.IntegralHeight = false;
			base.Size = new Size(131, 101);
			this.BackColor = this.BaseColor;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00009D44 File Offset: 0x00007F44
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(base.Width, base.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
			Graphics g = Helpers.G;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			g.Clear(this.BackColor);
			this.ListBx.Size = checked(new Size(base.Width - 6, base.Height - 2));
			g.FillRectangle(new SolidBrush(this.BaseColor), rect);
			base.OnPaint(e);
			Helpers.G.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
			Helpers.B.Dispose();
		}

		// Token: 0x04000090 RID: 144
		private string[] _items;

		// Token: 0x04000091 RID: 145
		private Color BaseColor;

		// Token: 0x04000092 RID: 146
		private Color _SelectedColor;
	}
}
