using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x02000029 RID: 41
	internal abstract class ThemeControl151 : Control
	{
		// Token: 0x06000277 RID: 631 RVA: 0x00013158 File Offset: 0x00011358
		public ThemeControl151()
		{
			this.Items = new Dictionary<string, Color>();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this._ImageSize = Size.Empty;
			this.MeasureBitmap = new Bitmap(1, 1);
			this.MeasureGraphics = Graphics.FromImage(this.MeasureBitmap);
			this.Font = new Font("Verdana", 8f);
			this.InvalidateCustimization();
		}

		// Token: 0x06000278 RID: 632 RVA: 0x000131C8 File Offset: 0x000113C8
		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			if (this._LockWidth != 0)
			{
				width = this._LockWidth;
			}
			if (this._LockHeight != 0)
			{
				height = this._LockHeight;
			}
			base.SetBoundsCore(x, y, width, height, specified);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00013208 File Offset: 0x00011408
		protected sealed override void OnSizeChanged(EventArgs e)
		{
			if (this._Transparent && base.Width != 0 && base.Height != 0)
			{
				this.B = new Bitmap(base.Width, base.Height);
				this.G = Graphics.FromImage(this.B);
			}
			base.Invalidate();
			base.OnSizeChanged(e);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0001326C File Offset: 0x0001146C
		protected sealed override void OnPaint(PaintEventArgs e)
		{
			if (base.Width != 0 && base.Height != 0)
			{
				if (this._Transparent)
				{
					this.PaintHook();
					e.Graphics.DrawImage(this.B, 0, 0);
				}
				else
				{
					this.G = e.Graphics;
					this.PaintHook();
				}
			}
		}

		// Token: 0x0600027B RID: 635 RVA: 0x000132C4 File Offset: 0x000114C4
		protected override void OnHandleCreated(EventArgs e)
		{
			this.InvalidateCustimization();
			this.ColorHook();
			if (this._LockWidth != 0)
			{
				base.Width = this._LockWidth;
			}
			if (this._LockHeight != 0)
			{
				base.Height = this._LockHeight;
			}
			if (!(this.BackColorWait == default(Color)))
			{
				this.BackColor = this.BackColorWait;
			}
			this.OnCreation();
			base.OnHandleCreated(e);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00002E9E File Offset: 0x0000109E
		protected virtual void OnCreation()
		{
		}

		// Token: 0x0600027D RID: 637 RVA: 0x000031B2 File Offset: 0x000013B2
		protected override void OnMouseEnter(EventArgs e)
		{
			this.SetState(MouseState.Over);
			base.OnMouseEnter(e);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x000031C2 File Offset: 0x000013C2
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.SetState(MouseState.Over);
			base.OnMouseUp(e);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00013340 File Offset: 0x00011540
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.SetState(MouseState.Down);
			}
			base.OnMouseDown(e);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x000031D2 File Offset: 0x000013D2
		protected override void OnMouseLeave(EventArgs e)
		{
			this.SetState(MouseState.None);
			base.OnMouseLeave(e);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0001336C File Offset: 0x0001156C
		protected override void OnEnabledChanged(EventArgs e)
		{
			if (base.Enabled)
			{
				this.SetState(MouseState.None);
			}
			else
			{
				this.SetState(MouseState.Block);
			}
			base.OnEnabledChanged(e);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x000031E2 File Offset: 0x000013E2
		private void SetState(MouseState current)
		{
			this.State = current;
			base.Invalidate();
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000283 RID: 643 RVA: 0x00012798 File Offset: 0x00010998
		// (set) Token: 0x06000284 RID: 644 RVA: 0x00013398 File Offset: 0x00011598
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				if (base.IsHandleCreated)
				{
					base.BackColor = value;
				}
				else
				{
					this.BackColorWait = value;
				}
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000285 RID: 645 RVA: 0x000127EC File Offset: 0x000109EC
		// (set) Token: 0x06000286 RID: 646 RVA: 0x00002E9E File Offset: 0x0000109E
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override Color ForeColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00012800 File Offset: 0x00010A00
		// (set) Token: 0x06000288 RID: 648 RVA: 0x00002E9E File Offset: 0x0000109E
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override Image BackgroundImage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000289 RID: 649 RVA: 0x00012810 File Offset: 0x00010A10
		// (set) Token: 0x0600028A RID: 650 RVA: 0x00002E9E File Offset: 0x0000109E
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override ImageLayout BackgroundImageLayout
		{
			get
			{
				return ImageLayout.None;
			}
			set
			{
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600028B RID: 651 RVA: 0x000073D4 File Offset: 0x000055D4
		// (set) Token: 0x0600028C RID: 652 RVA: 0x00002ECF File Offset: 0x000010CF
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				base.Invalidate();
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600028D RID: 653 RVA: 0x00007418 File Offset: 0x00005618
		// (set) Token: 0x0600028E RID: 654 RVA: 0x00002EDE File Offset: 0x000010DE
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				base.Invalidate();
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600028F RID: 655 RVA: 0x000133C0 File Offset: 0x000115C0
		// (set) Token: 0x06000290 RID: 656 RVA: 0x000031F1 File Offset: 0x000013F1
		public bool NoRounding
		{
			get
			{
				return this._NoRounding;
			}
			set
			{
				this._NoRounding = value;
				base.Invalidate();
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000291 RID: 657 RVA: 0x000133D4 File Offset: 0x000115D4
		// (set) Token: 0x06000292 RID: 658 RVA: 0x000133EC File Offset: 0x000115EC
		public Image Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if (value == null)
				{
					this._ImageSize = Size.Empty;
				}
				else
				{
					this._ImageSize = value.Size;
				}
				this._Image = value;
				base.Invalidate();
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000293 RID: 659 RVA: 0x00013428 File Offset: 0x00011628
		protected Size ImageSize
		{
			get
			{
				return this._ImageSize;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000294 RID: 660 RVA: 0x00013440 File Offset: 0x00011640
		// (set) Token: 0x06000295 RID: 661 RVA: 0x00013458 File Offset: 0x00011658
		protected int LockWidth
		{
			get
			{
				return this._LockWidth;
			}
			set
			{
				this._LockWidth = value;
				if (this.LockWidth != 0 && base.IsHandleCreated)
				{
					base.Width = this.LockWidth;
				}
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000296 RID: 662 RVA: 0x0001348C File Offset: 0x0001168C
		// (set) Token: 0x06000297 RID: 663 RVA: 0x000134A4 File Offset: 0x000116A4
		protected int LockHeight
		{
			get
			{
				return this._LockHeight;
			}
			set
			{
				this._LockHeight = value;
				if (this.LockHeight != 0 && base.IsHandleCreated)
				{
					base.Height = this.LockHeight;
				}
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000298 RID: 664 RVA: 0x000134D8 File Offset: 0x000116D8
		// (set) Token: 0x06000299 RID: 665 RVA: 0x000134EC File Offset: 0x000116EC
		public bool Transparent
		{
			get
			{
				return this._Transparent;
			}
			set
			{
				if (!value && this.BackColor.A != 255)
				{
					throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
				}
				base.SetStyle(ControlStyles.Opaque, !value);
				base.SetStyle(ControlStyles.SupportsTransparentBackColor, value);
				if (value)
				{
					this.InvalidateBitmap();
				}
				else
				{
					this.B = null;
				}
				this._Transparent = value;
				base.Invalidate();
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600029A RID: 666 RVA: 0x0001355C File Offset: 0x0001175C
		// (set) Token: 0x0600029B RID: 667 RVA: 0x000135B8 File Offset: 0x000117B8
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public Bloom[] Colors
		{
			get
			{
				List<Bloom> list = new List<Bloom>();
				Dictionary<string, Color>.Enumerator enumerator = this.Items.GetEnumerator();
				while (enumerator.MoveNext())
				{
					List<Bloom> list2 = list;
					KeyValuePair<string, Color> keyValuePair = enumerator.Current;
					string key = keyValuePair.Key;
					keyValuePair = enumerator.Current;
					list2.Add(new Bloom(key, keyValuePair.Value));
				}
				return list.ToArray();
			}
			set
			{
				checked
				{
					for (int i = 0; i < value.Length; i++)
					{
						Bloom bloom = value[i];
						if (this.Items.ContainsKey(bloom.Name))
						{
							this.Items[bloom.Name] = bloom.Value;
						}
					}
					this.InvalidateCustimization();
					this.ColorHook();
					base.Invalidate();
				}
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600029C RID: 668 RVA: 0x00013620 File Offset: 0x00011820
		// (set) Token: 0x0600029D RID: 669 RVA: 0x00013638 File Offset: 0x00011838
		public string Customization
		{
			get
			{
				return this._Customization;
			}
			set
			{
				checked
				{
					if (Operators.CompareString(value, this._Customization, false) != 0)
					{
						Bloom[] colors = this.Colors;
						try
						{
							byte[] value2 = Convert.FromBase64String(value);
							int num = colors.Length - 1;
							for (int i = 0; i <= num; i++)
							{
								colors[i].Value = Color.FromArgb(BitConverter.ToInt32(value2, i * 4));
							}
						}
						catch (Exception ex)
						{
							return;
						}
						this._Customization = value;
						this.Colors = colors;
						this.ColorHook();
						base.Invalidate();
					}
				}
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x000136D0 File Offset: 0x000118D0
		private void InvalidateBitmap()
		{
			if (base.Width != 0 && base.Height != 0)
			{
				this.B = new Bitmap(base.Width, base.Height);
				this.G = Graphics.FromImage(this.B);
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0001371C File Offset: 0x0001191C
		protected Color GetColor(string name)
		{
			return this.Items[name];
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00013738 File Offset: 0x00011938
		protected void SetColor(string name, Color color)
		{
			if (this.Items.ContainsKey(name))
			{
				this.Items[name] = color;
			}
			else
			{
				this.Items.Add(name, color);
			}
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00003200 File Offset: 0x00001400
		protected void SetColor(string name, byte r, byte g, byte b)
		{
			this.SetColor(name, Color.FromArgb((int)r, (int)g, (int)b));
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00003212 File Offset: 0x00001412
		protected void SetColor(string name, byte a, byte r, byte g, byte b)
		{
			this.SetColor(name, Color.FromArgb((int)a, (int)r, (int)g, (int)b));
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00003226 File Offset: 0x00001426
		protected void SetColor(string name, byte a, Color color)
		{
			this.SetColor(name, Color.FromArgb((int)a, color));
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00013770 File Offset: 0x00011970
		private void InvalidateCustimization()
		{
			MemoryStream memoryStream = new MemoryStream(checked(this.Items.Count * 4));
			foreach (Bloom bloom in this.Colors)
			{
				memoryStream.Write(BitConverter.GetBytes(bloom.Value.ToArgb()), 0, 4);
			}
			memoryStream.Close();
			this._Customization = Convert.ToBase64String(memoryStream.ToArray());
		}

		// Token: 0x060002A5 RID: 677
		protected abstract void ColorHook();

		// Token: 0x060002A6 RID: 678
		protected abstract void PaintHook();

		// Token: 0x060002A7 RID: 679 RVA: 0x000137E4 File Offset: 0x000119E4
		protected Point Center(Rectangle r1, Size s1)
		{
			this.CenterReturn = checked(new Point(r1.Width / 2 - s1.Width / 2 + r1.X, r1.Height / 2 - s1.Height / 2 + r1.Y));
			return this.CenterReturn;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0001383C File Offset: 0x00011A3C
		protected Point Center(Rectangle r1, Rectangle r2)
		{
			return this.Center(r1, r2.Size);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0001385C File Offset: 0x00011A5C
		protected Point Center(int w1, int h1, int w2, int h2)
		{
			this.CenterReturn = checked(new Point(w1 / 2 - w2 / 2, h1 / 2 - h2 / 2));
			return this.CenterReturn;
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0001388C File Offset: 0x00011A8C
		protected Point Center(Size s1, Size s2)
		{
			return this.Center(s1.Width, s1.Height, s2.Width, s2.Height);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x000138C0 File Offset: 0x00011AC0
		protected Point Center(Rectangle r1)
		{
			return this.Center(base.ClientRectangle.Width, base.ClientRectangle.Height, r1.Width, r1.Height);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00013900 File Offset: 0x00011B00
		protected Point Center(Size s1)
		{
			return this.Center(base.Width, base.Height, s1.Width, s1.Height);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00013930 File Offset: 0x00011B30
		protected Point Center(int w1, int h1)
		{
			return this.Center(base.Width, base.Height, w1, h1);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00013954 File Offset: 0x00011B54
		protected Size Measure(string text)
		{
			return this.MeasureGraphics.MeasureString(text, this.Font, base.Width).ToSize();
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00013984 File Offset: 0x00011B84
		protected Size Measure()
		{
			return this.MeasureGraphics.MeasureString(this.Text, this.Font, base.Width).ToSize();
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00003236 File Offset: 0x00001436
		protected void DrawCorners(Color c1)
		{
			this.DrawCorners(c1, 0, 0, base.Width, base.Height);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000324D File Offset: 0x0000144D
		protected void DrawCorners(Color c1, Rectangle r1)
		{
			this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x000139B8 File Offset: 0x00011BB8
		protected void DrawCorners(Color c1, int x, int y, int width, int height)
		{
			checked
			{
				if (!this._NoRounding)
				{
					if (this._Transparent)
					{
						this.B.SetPixel(x, y, c1);
						this.B.SetPixel(x + (width - 1), y, c1);
						this.B.SetPixel(x, y + (height - 1), c1);
						this.B.SetPixel(x + (width - 1), y + (height - 1), c1);
					}
					else
					{
						this.DrawCornersBrush = new SolidBrush(c1);
						this.G.FillRectangle(this.DrawCornersBrush, x, y, 1, 1);
						this.G.FillRectangle(this.DrawCornersBrush, x + (width - 1), y, 1, 1);
						this.G.FillRectangle(this.DrawCornersBrush, x, y + (height - 1), 1, 1);
						this.G.FillRectangle(this.DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
					}
				}
			}
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00003272 File Offset: 0x00001472
		protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
		{
			checked
			{
				this.DrawBorders(p1, x + offset, y + offset, width - offset * 2, height - offset * 2);
			}
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00003291 File Offset: 0x00001491
		protected void DrawBorders(Pen p1, int offset)
		{
			this.DrawBorders(p1, 0, 0, base.Width, base.Height, offset);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x000032A9 File Offset: 0x000014A9
		protected void DrawBorders(Pen p1, Rectangle r, int offset)
		{
			this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x000032CF File Offset: 0x000014CF
		protected void DrawBorders(Pen p1, int x, int y, int width, int height)
		{
			checked
			{
				this.G.DrawRectangle(p1, x, y, width - 1, height - 1);
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x000032E7 File Offset: 0x000014E7
		protected void DrawBorders(Pen p1)
		{
			this.DrawBorders(p1, 0, 0, base.Width, base.Height);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x000032FE File Offset: 0x000014FE
		protected void DrawBorders(Pen p1, Rectangle r)
		{
			this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00003323 File Offset: 0x00001523
		protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
		{
			this.DrawText(b1, this.Text, a, x, y);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00003336 File Offset: 0x00001536
		protected void DrawText(Brush b1, Point p1)
		{
			this.DrawText(b1, this.Text, p1.X, p1.Y);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00003353 File Offset: 0x00001553
		protected void DrawText(Brush b1, int x, int y)
		{
			this.DrawText(b1, this.Text, x, y);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00013A9C File Offset: 0x00011C9C
		protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
		{
			checked
			{
				if (text.Length != 0)
				{
					this.DrawTextSize = this.Measure(text);
					this.DrawTextPoint = this.Center(this.DrawTextSize);
					switch (a)
					{
					case HorizontalAlignment.Left:
						this.DrawText(b1, text, x, this.DrawTextPoint.Y + y);
						break;
					case HorizontalAlignment.Right:
						this.DrawText(b1, text, base.Width - this.DrawTextSize.Width - x, this.DrawTextPoint.Y + y);
						break;
					case HorizontalAlignment.Center:
						this.DrawText(b1, text, this.DrawTextPoint.X + x, this.DrawTextPoint.Y + y);
						break;
					}
				}
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00003364 File Offset: 0x00001564
		protected void DrawText(Brush b1, string text, Point p1)
		{
			this.DrawText(b1, text, p1.X, p1.Y);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00013B58 File Offset: 0x00011D58
		protected void DrawText(Brush b1, string text, int x, int y)
		{
			if (text.Length != 0)
			{
				this.G.DrawString(text, this.Font, b1, (float)x, (float)y);
			}
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000337C File Offset: 0x0000157C
		protected void DrawImage(HorizontalAlignment a, int x, int y)
		{
			this.DrawImage(this._Image, a, x, y);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000338D File Offset: 0x0000158D
		protected void DrawImage(Point p1)
		{
			this.DrawImage(this._Image, p1.X, p1.Y);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x000033A9 File Offset: 0x000015A9
		protected void DrawImage(int x, int y)
		{
			this.DrawImage(this._Image, x, y);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00013B88 File Offset: 0x00011D88
		protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
		{
			checked
			{
				if (image != null)
				{
					this.DrawImagePoint = this.Center(image.Size);
					switch (a)
					{
					case HorizontalAlignment.Left:
						this.DrawImage(image, x, this.DrawImagePoint.Y + y);
						break;
					case HorizontalAlignment.Right:
						this.DrawImage(image, base.Width - image.Width - x, this.DrawImagePoint.Y + y);
						break;
					case HorizontalAlignment.Center:
						this.DrawImage(image, this.DrawImagePoint.X + x, this.DrawImagePoint.Y + y);
						break;
					}
				}
			}
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x000033B9 File Offset: 0x000015B9
		protected void DrawImage(Image image, Point p1)
		{
			this.DrawImage(image, p1.X, p1.Y);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00013C28 File Offset: 0x00011E28
		protected void DrawImage(Image image, int x, int y)
		{
			if (image != null)
			{
				this.G.DrawImage(image, x, y, image.Width, image.Height);
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x000033D0 File Offset: 0x000015D0
		protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
		{
			this.DrawGradient(blend, x, y, width, height, 90f);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x000033E4 File Offset: 0x000015E4
		protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
		{
			this.DrawGradient(c1, c2, x, y, width, height, 90f);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x000033FA File Offset: 0x000015FA
		protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(blend, this.DrawGradientRectangle, angle);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000341C File Offset: 0x0000161C
		protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(c1, c2, this.DrawGradientRectangle, angle);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00003440 File Offset: 0x00001640
		protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
			this.DrawGradientBrush.InterpolationColors = blend;
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00003477 File Offset: 0x00001677
		protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		// Token: 0x0400016D RID: 365
		protected Graphics G;

		// Token: 0x0400016E RID: 366
		protected Bitmap B;

		// Token: 0x0400016F RID: 367
		protected MouseState State;

		// Token: 0x04000170 RID: 368
		private Color BackColorWait;

		// Token: 0x04000171 RID: 369
		private bool _NoRounding;

		// Token: 0x04000172 RID: 370
		private Image _Image;

		// Token: 0x04000173 RID: 371
		private Size _ImageSize;

		// Token: 0x04000174 RID: 372
		private int _LockWidth;

		// Token: 0x04000175 RID: 373
		private int _LockHeight;

		// Token: 0x04000176 RID: 374
		private bool _Transparent;

		// Token: 0x04000177 RID: 375
		private Dictionary<string, Color> Items;

		// Token: 0x04000178 RID: 376
		private string _Customization;

		// Token: 0x04000179 RID: 377
		private Point CenterReturn;

		// Token: 0x0400017A RID: 378
		private Bitmap MeasureBitmap;

		// Token: 0x0400017B RID: 379
		private Graphics MeasureGraphics;

		// Token: 0x0400017C RID: 380
		private SolidBrush DrawCornersBrush;

		// Token: 0x0400017D RID: 381
		private Point DrawTextPoint;

		// Token: 0x0400017E RID: 382
		private Size DrawTextSize;

		// Token: 0x0400017F RID: 383
		private Point DrawImagePoint;

		// Token: 0x04000180 RID: 384
		private LinearGradientBrush DrawGradientBrush;

		// Token: 0x04000181 RID: 385
		private Rectangle DrawGradientRectangle;
	}
}
