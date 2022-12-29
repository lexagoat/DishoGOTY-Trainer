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
	// Token: 0x0200003B RID: 59
	public class LogInListBox : Control
	{
		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x00003A4C File Offset: 0x00001C4C
		// (set) Token: 0x060003E1 RID: 993 RVA: 0x00017A88 File Offset: 0x00015C88
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

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x00017ACC File Offset: 0x00015CCC
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x00003A54 File Offset: 0x00001C54
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

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x00017AE4 File Offset: 0x00015CE4
		// (set) Token: 0x060003E5 RID: 997 RVA: 0x00003A84 File Offset: 0x00001C84
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

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x00017AFC File Offset: 0x00015CFC
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x00003A8D File Offset: 0x00001C8D
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

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x00017B14 File Offset: 0x00015D14
		// (set) Token: 0x060003E9 RID: 1001 RVA: 0x00003A96 File Offset: 0x00001C96
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

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x00017B2C File Offset: 0x00015D2C
		// (set) Token: 0x060003EB RID: 1003 RVA: 0x00003A9F File Offset: 0x00001C9F
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

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x00017B44 File Offset: 0x00015D44
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x00003AA8 File Offset: 0x00001CA8
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

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x00017B5C File Offset: 0x00015D5C
		public string SelectedItem
		{
			get
			{
				return Conversions.ToString(this.ListB.SelectedItem);
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x00017B7C File Offset: 0x00015D7C
		public int SelectedIndex
		{
			get
			{
				return this.ListB.SelectedIndex;
			}
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00003AB1 File Offset: 0x00001CB1
		public void Clear()
		{
			this.ListB.Items.Clear();
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00017B98 File Offset: 0x00015D98
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

		// Token: 0x060003F2 RID: 1010 RVA: 0x00017BEC File Offset: 0x00015DEC
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (!base.Controls.Contains(this.ListB))
			{
				base.Controls.Add(this.ListB);
			}
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00003AC3 File Offset: 0x00001CC3
		public void AddRange(object[] items)
		{
			this.ListB.Items.Remove("");
			this.ListB.Items.AddRange(items);
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00003AEB File Offset: 0x00001CEB
		public void AddItem(object item)
		{
			this.ListB.Items.Remove("");
			this.ListB.Items.Add(RuntimeHelpers.GetObjectValue(item));
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00017C28 File Offset: 0x00015E28
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

		// Token: 0x060003F6 RID: 1014 RVA: 0x00017E1C File Offset: 0x0001601C
		public LogInListBox()
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
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.ListB.DrawMode = DrawMode.OwnerDrawFixed;
			this.ListB.ScrollAlwaysVisible = false;
			this.ListB.HorizontalScrollbar = false;
			this.ListB.BorderStyle = BorderStyle.None;
			this.ListB.BackColor = this._BaseColour;
			this.ListB.Location = new Point(3, 3);
			this.ListB.Font = new Font("Segoe UI", 8f);
			this.ListB.ItemHeight = 20;
			this.ListB.Items.Clear();
			this.ListB.IntegralHeight = false;
			base.Size = new Size(130, 100);
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00017F68 File Offset: 0x00016168
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
				this.ListB.Size = new Size(base.Width - 6, base.Height - 5);
				graphics2.FillRectangle(new SolidBrush(this._BaseColour), rect);
				graphics2.DrawRectangle(new Pen(this._BorderColour, 3f), new Rectangle(0, 0, base.Width, base.Height - 1));
				base.OnPaint(e);
				graphics.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
				bitmap.Dispose();
			}
		}

		// Token: 0x040001F2 RID: 498
		private string[] _Items;

		// Token: 0x040001F3 RID: 499
		private Color _BaseColour;

		// Token: 0x040001F4 RID: 500
		private Color _SelectedColour;

		// Token: 0x040001F5 RID: 501
		private Color _ListBaseColour;

		// Token: 0x040001F6 RID: 502
		private Color _TextColour;

		// Token: 0x040001F7 RID: 503
		private Color _BorderColour;
	}
}
