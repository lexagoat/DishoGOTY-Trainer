using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x02000048 RID: 72
	internal abstract class ThemeControl154 : Control
	{
		// Token: 0x06000580 RID: 1408 RVA: 0x0001DCF8 File Offset: 0x0001BEF8
		public ThemeControl154()
		{
			this.Items = new Dictionary<string, Color>();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this._ImageSize = Size.Empty;
			this.Font = new Font("Verdana", 8f);
			this.MeasureBitmap = new Bitmap(1, 1);
			this.MeasureGraphics = Graphics.FromImage(this.MeasureBitmap);
			this.DrawRadialPath = new GraphicsPath();
			this.InvalidateCustimization();
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0001DD74 File Offset: 0x0001BF74
		protected sealed override void OnHandleCreated(EventArgs e)
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
			this.Transparent = this._Transparent;
			if (this._Transparent && this._BackColor)
			{
				this.BackColor = Color.Transparent;
			}
			base.OnHandleCreated(e);
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0001DDEC File Offset: 0x0001BFEC
		protected sealed override void OnParentChanged(EventArgs e)
		{
			if (base.Parent != null)
			{
				this.OnCreation();
				this.DoneCreation = true;
				this.InvalidateTimer();
			}
			base.OnParentChanged(e);
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0001DE20 File Offset: 0x0001C020
		private void DoAnimation(bool i)
		{
			this.OnAnimation();
			if (i)
			{
				base.Invalidate();
			}
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0001DE3C File Offset: 0x0001C03C
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

		// Token: 0x06000585 RID: 1413 RVA: 0x000044AF File Offset: 0x000026AF
		protected override void OnHandleDestroyed(EventArgs e)
		{
			ThemeShare.RemoveAnimationCallback(new ThemeShare.AnimationDelegate(this.DoAnimation));
			base.OnHandleDestroyed(e);
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0001DE94 File Offset: 0x0001C094
		protected sealed override void OnSizeChanged(EventArgs e)
		{
			if (this._Transparent)
			{
				this.InvalidateBitmap();
			}
			base.Invalidate();
			base.OnSizeChanged(e);
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x0001DEBC File Offset: 0x0001C0BC
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

		// Token: 0x06000588 RID: 1416 RVA: 0x000044C9 File Offset: 0x000026C9
		protected override void OnMouseEnter(EventArgs e)
		{
			this.InPosition = true;
			this.SetState(MouseState.Over);
			base.OnMouseEnter(e);
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x0001DEFC File Offset: 0x0001C0FC
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (this.InPosition)
			{
				this.SetState(MouseState.Over);
			}
			base.OnMouseUp(e);
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x0001DF20 File Offset: 0x0001C120
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.SetState(MouseState.Down);
			}
			base.OnMouseDown(e);
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x000044E0 File Offset: 0x000026E0
		protected override void OnMouseLeave(EventArgs e)
		{
			this.InPosition = false;
			this.SetState(MouseState.None);
			base.OnMouseLeave(e);
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x0001DF4C File Offset: 0x0001C14C
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

		// Token: 0x0600058D RID: 1421 RVA: 0x000044F7 File Offset: 0x000026F7
		private void SetState(MouseState current)
		{
			this.State = current;
			base.Invalidate();
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x000127EC File Offset: 0x000109EC
		// (set) Token: 0x0600058F RID: 1423 RVA: 0x00002E9E File Offset: 0x0000109E
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

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x00012800 File Offset: 0x00010A00
		// (set) Token: 0x06000591 RID: 1425 RVA: 0x00002E9E File Offset: 0x0000109E
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x00012810 File Offset: 0x00010A10
		// (set) Token: 0x06000593 RID: 1427 RVA: 0x00002E9E File Offset: 0x0000109E
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x000073D4 File Offset: 0x000055D4
		// (set) Token: 0x06000595 RID: 1429 RVA: 0x00002ECF File Offset: 0x000010CF
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

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x00007418 File Offset: 0x00005618
		// (set) Token: 0x06000597 RID: 1431 RVA: 0x00002EDE File Offset: 0x000010DE
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

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000598 RID: 1432 RVA: 0x00012798 File Offset: 0x00010998
		// (set) Token: 0x06000599 RID: 1433 RVA: 0x0001DF78 File Offset: 0x0001C178
		[Category("Misc")]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				if (!base.IsHandleCreated && value == Color.Transparent)
				{
					this._BackColor = true;
				}
				else
				{
					base.BackColor = value;
					if (base.Parent != null)
					{
						this.ColorHook();
					}
				}
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x0001DFC0 File Offset: 0x0001C1C0
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x00004506 File Offset: 0x00002706
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

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x0001DFD4 File Offset: 0x0001C1D4
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x0001DFEC File Offset: 0x0001C1EC
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

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x0001E028 File Offset: 0x0001C228
		// (set) Token: 0x0600059F RID: 1439 RVA: 0x0001E03C File Offset: 0x0001C23C
		public bool Transparent
		{
			get
			{
				return this._Transparent;
			}
			set
			{
				this._Transparent = value;
				if (base.IsHandleCreated)
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
					base.Invalidate();
				}
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x0001E0B8 File Offset: 0x0001C2B8
		// (set) Token: 0x060005A1 RID: 1441 RVA: 0x0001E114 File Offset: 0x0001C314
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

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x0001E17C File Offset: 0x0001C37C
		// (set) Token: 0x060005A3 RID: 1443 RVA: 0x0001E194 File Offset: 0x0001C394
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

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x060005A4 RID: 1444 RVA: 0x0001E22C File Offset: 0x0001C42C
		protected Size ImageSize
		{
			get
			{
				return this._ImageSize;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x0001E244 File Offset: 0x0001C444
		// (set) Token: 0x060005A6 RID: 1446 RVA: 0x0001E25C File Offset: 0x0001C45C
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

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x0001E290 File Offset: 0x0001C490
		// (set) Token: 0x060005A8 RID: 1448 RVA: 0x0001E2A8 File Offset: 0x0001C4A8
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

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x060005A9 RID: 1449 RVA: 0x0001E2DC File Offset: 0x0001C4DC
		// (set) Token: 0x060005AA RID: 1450 RVA: 0x00004515 File Offset: 0x00002715
		protected bool IsAnimated
		{
			get
			{
				return this._IsAnimated;
			}
			set
			{
				this._IsAnimated = value;
				this.InvalidateTimer();
			}
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x0001E2F0 File Offset: 0x0001C4F0
		protected Pen GetPen(string name)
		{
			return new Pen(this.Items[name]);
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0001E310 File Offset: 0x0001C510
		protected Pen GetPen(string name, float width)
		{
			return new Pen(this.Items[name], width);
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0001E334 File Offset: 0x0001C534
		protected SolidBrush GetBrush(string name)
		{
			return new SolidBrush(this.Items[name]);
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0001E354 File Offset: 0x0001C554
		protected Color GetColor(string name)
		{
			return this.Items[name];
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x0001E370 File Offset: 0x0001C570
		protected void SetColor(string name, Color value)
		{
			if (this.Items.ContainsKey(name))
			{
				this.Items[name] = value;
			}
			else
			{
				this.Items.Add(name, value);
			}
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00004524 File Offset: 0x00002724
		protected void SetColor(string name, byte r, byte g, byte b)
		{
			this.SetColor(name, Color.FromArgb((int)r, (int)g, (int)b));
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00004536 File Offset: 0x00002736
		protected void SetColor(string name, byte a, byte r, byte g, byte b)
		{
			this.SetColor(name, Color.FromArgb((int)a, (int)r, (int)g, (int)b));
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0000454A File Offset: 0x0000274A
		protected void SetColor(string name, byte a, Color value)
		{
			this.SetColor(name, Color.FromArgb((int)a, value));
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0001E3A8 File Offset: 0x0001C5A8
		private void InvalidateBitmap()
		{
			if (base.Width != 0 && base.Height != 0)
			{
				this.B = new Bitmap(base.Width, base.Height, PixelFormat.Format32bppPArgb);
				this.G = Graphics.FromImage(this.B);
			}
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0001E3F8 File Offset: 0x0001C5F8
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

		// Token: 0x060005B5 RID: 1461 RVA: 0x0001E46C File Offset: 0x0001C66C
		private void InvalidateTimer()
		{
			if (!base.DesignMode && this.DoneCreation)
			{
				if (this._IsAnimated)
				{
					ThemeShare.AddAnimationCallback(new ThemeShare.AnimationDelegate(this.DoAnimation));
				}
				else
				{
					ThemeShare.RemoveAnimationCallback(new ThemeShare.AnimationDelegate(this.DoAnimation));
				}
			}
		}

		// Token: 0x060005B6 RID: 1462
		protected abstract void ColorHook();

		// Token: 0x060005B7 RID: 1463
		protected abstract void PaintHook();

		// Token: 0x060005B8 RID: 1464 RVA: 0x00002E9E File Offset: 0x0000109E
		protected virtual void OnCreation()
		{
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x00002E9E File Offset: 0x0000109E
		protected virtual void OnAnimation()
		{
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0001E4BC File Offset: 0x0001C6BC
		protected Rectangle Offset(Rectangle r, int amount)
		{
			this.OffsetReturnRectangle = checked(new Rectangle(r.X + amount, r.Y + amount, r.Width - amount * 2, r.Height - amount * 2));
			return this.OffsetReturnRectangle;
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x0001E504 File Offset: 0x0001C704
		protected Size Offset(Size s, int amount)
		{
			this.OffsetReturnSize = checked(new Size(s.Width + amount, s.Height + amount));
			return this.OffsetReturnSize;
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0001E538 File Offset: 0x0001C738
		protected Point Offset(Point p, int amount)
		{
			this.OffsetReturnPoint = checked(new Point(p.X + amount, p.Y + amount));
			return this.OffsetReturnPoint;
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0001E56C File Offset: 0x0001C76C
		protected Point Center(Rectangle p, Rectangle c)
		{
			this.CenterReturn = checked(new Point(p.Width / 2 - c.Width / 2 + p.X + c.X, p.Height / 2 - c.Height / 2 + p.Y + c.Y));
			return this.CenterReturn;
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0001E5D4 File Offset: 0x0001C7D4
		protected Point Center(Rectangle p, Size c)
		{
			this.CenterReturn = checked(new Point(p.Width / 2 - c.Width / 2 + p.X, p.Height / 2 - c.Height / 2 + p.Y));
			return this.CenterReturn;
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0001E62C File Offset: 0x0001C82C
		protected Point Center(Rectangle child)
		{
			return this.Center(base.Width, base.Height, child.Width, child.Height);
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0001E65C File Offset: 0x0001C85C
		protected Point Center(Size child)
		{
			return this.Center(base.Width, base.Height, child.Width, child.Height);
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0001E68C File Offset: 0x0001C88C
		protected Point Center(int childWidth, int childHeight)
		{
			return this.Center(base.Width, base.Height, childWidth, childHeight);
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0001E6B0 File Offset: 0x0001C8B0
		protected Point Center(Size p, Size c)
		{
			return this.Center(p.Width, p.Height, c.Width, c.Height);
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0001E6E4 File Offset: 0x0001C8E4
		protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
		{
			this.CenterReturn = checked(new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2));
			return this.CenterReturn;
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0001E714 File Offset: 0x0001C914
		protected Size Measure()
		{
			return this.MeasureGraphics.MeasureString(this.Text, this.Font, base.Width).ToSize();
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0001E748 File Offset: 0x0001C948
		protected Size Measure(string text)
		{
			return this.MeasureGraphics.MeasureString(text, this.Font, base.Width).ToSize();
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0001E778 File Offset: 0x0001C978
		protected void DrawPixel(Color c1, int x, int y)
		{
			if (this._Transparent)
			{
				this.B.SetPixel(x, y, c1);
			}
			else
			{
				this.DrawPixelBrush = new SolidBrush(c1);
				this.G.FillRectangle(this.DrawPixelBrush, x, y, 1, 1);
			}
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0000455A File Offset: 0x0000275A
		protected void DrawCorners(Color c1, int offset)
		{
			this.DrawCorners(c1, 0, 0, base.Width, base.Height, offset);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00004572 File Offset: 0x00002772
		protected void DrawCorners(Color c1, Rectangle r1, int offset)
		{
			this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00004598 File Offset: 0x00002798
		protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
		{
			checked
			{
				this.DrawCorners(c1, x + offset, y + offset, width - offset * 2, height - offset * 2);
			}
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x000045B7 File Offset: 0x000027B7
		protected void DrawCorners(Color c1)
		{
			this.DrawCorners(c1, 0, 0, base.Width, base.Height);
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x000045CE File Offset: 0x000027CE
		protected void DrawCorners(Color c1, Rectangle r1)
		{
			this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0001E7C0 File Offset: 0x0001C9C0
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

		// Token: 0x060005CD RID: 1485 RVA: 0x000045F3 File Offset: 0x000027F3
		protected void DrawBorders(Pen p1, int offset)
		{
			this.DrawBorders(p1, 0, 0, base.Width, base.Height, offset);
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0000460B File Offset: 0x0000280B
		protected void DrawBorders(Pen p1, Rectangle r, int offset)
		{
			this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x00004631 File Offset: 0x00002831
		protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
		{
			checked
			{
				this.DrawBorders(p1, x + offset, y + offset, width - offset * 2, height - offset * 2);
			}
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x00004650 File Offset: 0x00002850
		protected void DrawBorders(Pen p1)
		{
			this.DrawBorders(p1, 0, 0, base.Width, base.Height);
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x00004667 File Offset: 0x00002867
		protected void DrawBorders(Pen p1, Rectangle r)
		{
			this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0000468C File Offset: 0x0000288C
		protected void DrawBorders(Pen p1, int x, int y, int width, int height)
		{
			checked
			{
				this.G.DrawRectangle(p1, x, y, width - 1, height - 1);
			}
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x000046A4 File Offset: 0x000028A4
		protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
		{
			this.DrawText(b1, this.Text, a, x, y);
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x0001E8A4 File Offset: 0x0001CAA4
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
						this.G.DrawString(text, this.Font, b1, (float)x, (float)(this.DrawTextPoint.Y + y));
						break;
					case HorizontalAlignment.Right:
						this.G.DrawString(text, this.Font, b1, (float)(base.Width - this.DrawTextSize.Width - x), (float)(this.DrawTextPoint.Y + y));
						break;
					case HorizontalAlignment.Center:
						this.G.DrawString(text, this.Font, b1, (float)(this.DrawTextPoint.X + x), (float)(this.DrawTextPoint.Y + y));
						break;
					}
				}
			}
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0001E98C File Offset: 0x0001CB8C
		protected void DrawText(Brush b1, Point p1)
		{
			if (this.Text.Length != 0)
			{
				this.G.DrawString(this.Text, this.Font, b1, p1);
			}
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0001E9C8 File Offset: 0x0001CBC8
		protected void DrawText(Brush b1, int x, int y)
		{
			if (this.Text.Length != 0)
			{
				this.G.DrawString(this.Text, this.Font, b1, (float)x, (float)y);
			}
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x000046B7 File Offset: 0x000028B7
		protected void DrawImage(HorizontalAlignment a, int x, int y)
		{
			this.DrawImage(this._Image, a, x, y);
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0001EA04 File Offset: 0x0001CC04
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
						this.G.DrawImage(image, x, this.DrawImagePoint.Y + y, image.Width, image.Height);
						break;
					case HorizontalAlignment.Right:
						this.G.DrawImage(image, base.Width - image.Width - x, this.DrawImagePoint.Y + y, image.Width, image.Height);
						break;
					case HorizontalAlignment.Center:
						this.G.DrawImage(image, this.DrawImagePoint.X + x, this.DrawImagePoint.Y + y, image.Width, image.Height);
						break;
					}
				}
			}
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x000046C8 File Offset: 0x000028C8
		protected void DrawImage(Point p1)
		{
			this.DrawImage(this._Image, p1.X, p1.Y);
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x000046E4 File Offset: 0x000028E4
		protected void DrawImage(int x, int y)
		{
			this.DrawImage(this._Image, x, y);
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x000046F4 File Offset: 0x000028F4
		protected void DrawImage(Image image, Point p1)
		{
			this.DrawImage(image, p1.X, p1.Y);
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0001EAD8 File Offset: 0x0001CCD8
		protected void DrawImage(Image image, int x, int y)
		{
			if (image != null)
			{
				this.G.DrawImage(image, x, y, image.Width, image.Height);
			}
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0000470B File Offset: 0x0000290B
		protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(blend, this.DrawGradientRectangle);
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0000472B File Offset: 0x0000292B
		protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(blend, this.DrawGradientRectangle, angle);
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0000474D File Offset: 0x0000294D
		protected void DrawGradient(ColorBlend blend, Rectangle r)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
			this.DrawGradientBrush.InterpolationColors = blend;
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x00004788 File Offset: 0x00002988
		protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
			this.DrawGradientBrush.InterpolationColors = blend;
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x000047BF File Offset: 0x000029BF
		protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(c1, c2, this.DrawGradientRectangle);
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x000047E1 File Offset: 0x000029E1
		protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(c1, c2, this.DrawGradientRectangle, angle);
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x00004805 File Offset: 0x00002A05
		protected void DrawGradient(Color c1, Color c2, Rectangle r)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0000482C File Offset: 0x00002A2C
		protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00004850 File Offset: 0x00002A50
		public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(blend, this.DrawRadialRectangle, width / 2, height / 2);
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x00004878 File Offset: 0x00002A78
		public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(blend, this.DrawRadialRectangle, center.X, center.Y);
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x000048A6 File Offset: 0x00002AA6
		public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(blend, this.DrawRadialRectangle, cx, cy);
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x000048CA File Offset: 0x00002ACA
		public void DrawRadial(ColorBlend blend, Rectangle r)
		{
			this.DrawRadial(blend, r, r.Width / 2, r.Height / 2);
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x000048E6 File Offset: 0x00002AE6
		public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
		{
			this.DrawRadial(blend, r, center.X, center.Y);
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0001EB08 File Offset: 0x0001CD08
		public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
		{
			this.DrawRadialPath.Reset();
			checked
			{
				this.DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);
				this.DrawRadialBrush1 = new PathGradientBrush(this.DrawRadialPath);
				this.DrawRadialBrush1.CenterPoint = new Point(r.X + cx, r.Y + cy);
				this.DrawRadialBrush1.InterpolationColors = blend;
				if (this.G.SmoothingMode == SmoothingMode.AntiAlias)
				{
					this.G.FillEllipse(this.DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
				}
				else
				{
					this.G.FillEllipse(this.DrawRadialBrush1, r);
				}
			}
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x000048FE File Offset: 0x00002AFE
		protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(c1, c2, this.DrawRadialRectangle);
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x00004920 File Offset: 0x00002B20
		protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(c1, c2, this.DrawRadialRectangle, angle);
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x00004944 File Offset: 0x00002B44
		protected void DrawRadial(Color c1, Color c2, Rectangle r)
		{
			this.DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
			this.G.FillEllipse(this.DrawRadialBrush2, r);
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0000496B File Offset: 0x00002B6B
		protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
		{
			this.DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
			this.G.FillEllipse(this.DrawRadialBrush2, r);
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x0001EBEC File Offset: 0x0001CDEC
		public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
		{
			this.CreateRoundRectangle = new Rectangle(x, y, width, height);
			return this.CreateRound(this.CreateRoundRectangle, slope);
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x0001EC1C File Offset: 0x0001CE1C
		public GraphicsPath CreateRound(Rectangle r, int slope)
		{
			this.CreateRoundPath = new GraphicsPath(FillMode.Winding);
			this.CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
			checked
			{
				this.CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
				this.CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
				this.CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
				this.CreateRoundPath.CloseFigure();
				return this.CreateRoundPath;
			}
		}

		// Token: 0x0400029E RID: 670
		protected Graphics G;

		// Token: 0x0400029F RID: 671
		protected Bitmap B;

		// Token: 0x040002A0 RID: 672
		private bool DoneCreation;

		// Token: 0x040002A1 RID: 673
		private bool InPosition;

		// Token: 0x040002A2 RID: 674
		protected MouseState State;

		// Token: 0x040002A3 RID: 675
		private bool _BackColor;

		// Token: 0x040002A4 RID: 676
		private bool _NoRounding;

		// Token: 0x040002A5 RID: 677
		private Image _Image;

		// Token: 0x040002A6 RID: 678
		private bool _Transparent;

		// Token: 0x040002A7 RID: 679
		private Dictionary<string, Color> Items;

		// Token: 0x040002A8 RID: 680
		private string _Customization;

		// Token: 0x040002A9 RID: 681
		private Size _ImageSize;

		// Token: 0x040002AA RID: 682
		private int _LockWidth;

		// Token: 0x040002AB RID: 683
		private int _LockHeight;

		// Token: 0x040002AC RID: 684
		private bool _IsAnimated;

		// Token: 0x040002AD RID: 685
		private Rectangle OffsetReturnRectangle;

		// Token: 0x040002AE RID: 686
		private Size OffsetReturnSize;

		// Token: 0x040002AF RID: 687
		private Point OffsetReturnPoint;

		// Token: 0x040002B0 RID: 688
		private Point CenterReturn;

		// Token: 0x040002B1 RID: 689
		private Bitmap MeasureBitmap;

		// Token: 0x040002B2 RID: 690
		private Graphics MeasureGraphics;

		// Token: 0x040002B3 RID: 691
		private SolidBrush DrawPixelBrush;

		// Token: 0x040002B4 RID: 692
		private SolidBrush DrawCornersBrush;

		// Token: 0x040002B5 RID: 693
		private Point DrawTextPoint;

		// Token: 0x040002B6 RID: 694
		private Size DrawTextSize;

		// Token: 0x040002B7 RID: 695
		private Point DrawImagePoint;

		// Token: 0x040002B8 RID: 696
		private LinearGradientBrush DrawGradientBrush;

		// Token: 0x040002B9 RID: 697
		private Rectangle DrawGradientRectangle;

		// Token: 0x040002BA RID: 698
		private GraphicsPath DrawRadialPath;

		// Token: 0x040002BB RID: 699
		private PathGradientBrush DrawRadialBrush1;

		// Token: 0x040002BC RID: 700
		private LinearGradientBrush DrawRadialBrush2;

		// Token: 0x040002BD RID: 701
		private Rectangle DrawRadialRectangle;

		// Token: 0x040002BE RID: 702
		private GraphicsPath CreateRoundPath;

		// Token: 0x040002BF RID: 703
		private Rectangle CreateRoundRectangle;
	}
}
