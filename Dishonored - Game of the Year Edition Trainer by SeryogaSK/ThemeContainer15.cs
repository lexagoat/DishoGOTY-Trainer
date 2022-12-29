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
	// Token: 0x02000028 RID: 40
	internal abstract class ThemeContainer15 : ContainerControl
	{
		// Token: 0x06000215 RID: 533 RVA: 0x000121C0 File Offset: 0x000103C0
		public ThemeContainer15()
		{
			this.Messages = new Message[9];
			this._Movable = true;
			this._Sizable = true;
			this._MoveHeight = 24;
			this.Items = new Dictionary<string, Color>();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this._ImageSize = Size.Empty;
			this.MeasureBitmap = new Bitmap(1, 1);
			this.MeasureGraphics = Graphics.FromImage(this.MeasureBitmap);
			this.Font = new Font("Verdana", 8f);
			this.InvalidateCustimization();
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00012254 File Offset: 0x00010454
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

		// Token: 0x06000217 RID: 535 RVA: 0x00012294 File Offset: 0x00010494
		protected sealed override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (this._Movable && !this._ControlMode)
			{
				this.Header = checked(new Rectangle(7, 7, base.Width - 14, this._MoveHeight - 7));
			}
			base.Invalidate();
		}

		// Token: 0x06000218 RID: 536 RVA: 0x000122E4 File Offset: 0x000104E4
		protected sealed override void OnPaint(PaintEventArgs e)
		{
			if (base.Width != 0 && base.Height != 0)
			{
				this.G = e.Graphics;
				this.PaintHook();
			}
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0001231C File Offset: 0x0001051C
		protected sealed override void OnHandleCreated(EventArgs e)
		{
			this.InitializeMessages();
			this.InvalidateCustimization();
			this.ColorHook();
			this._IsParentForm = (base.Parent is Form);
			if (!this._ControlMode)
			{
				this.Dock = DockStyle.Fill;
			}
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
			if (this._IsParentForm && !this._ControlMode)
			{
				base.ParentForm.FormBorderStyle = this._BorderStyle;
				base.ParentForm.TransparencyKey = this._TransparencyKey;
			}
			this.OnCreation();
			base.OnHandleCreated(e);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00002E9E File Offset: 0x0000109E
		protected virtual void OnCreation()
		{
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00002EA0 File Offset: 0x000010A0
		private void SetState(MouseState current)
		{
			this.State = current;
			base.Invalidate();
		}

		// Token: 0x0600021C RID: 540 RVA: 0x000123FC File Offset: 0x000105FC
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (this._Sizable && !this._ControlMode)
			{
				this.InvalidateMouse();
			}
			base.OnMouseMove(e);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0001242C File Offset: 0x0001062C
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

		// Token: 0x0600021E RID: 542 RVA: 0x00002EAF File Offset: 0x000010AF
		protected override void OnMouseEnter(EventArgs e)
		{
			this.SetState(MouseState.Over);
			base.OnMouseEnter(e);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00002EBF File Offset: 0x000010BF
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.SetState(MouseState.Over);
			base.OnMouseUp(e);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00012458 File Offset: 0x00010658
		protected override void OnMouseLeave(EventArgs e)
		{
			this.SetState(MouseState.None);
			if (this._Sizable && !this._ControlMode && base.GetChildAtPoint(base.PointToClient(Control.MousePosition)) != null)
			{
				this.Cursor = Cursors.Default;
				this.Previous = 0;
			}
			base.OnMouseLeave(e);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x000124B0 File Offset: 0x000106B0
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left)
			{
				this.SetState(MouseState.Down);
				bool flag;
				if (this._IsParentForm)
				{
					if (base.ParentForm.WindowState == FormWindowState.Maximized)
					{
						flag = true;
						goto IL_44;
					}
				}
				flag = this._ControlMode;
				IL_44:
				if (!flag)
				{
					if (this._Movable && this.Header.Contains(e.Location))
					{
						base.Capture = false;
						this.DefWndProc(ref this.Messages[0]);
					}
					else if (this._Sizable && this.Previous != 0)
					{
						base.Capture = false;
						this.DefWndProc(ref this.Messages[this.Previous]);
					}
				}
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00012570 File Offset: 0x00010770
		private int GetIndex()
		{
			this.GetIndexPoint = base.PointToClient(Control.MousePosition);
			this.B1 = (this.GetIndexPoint.X < 7);
			checked
			{
				this.B2 = (this.GetIndexPoint.X > base.Width - 7);
				this.B3 = (this.GetIndexPoint.Y < 7);
				this.B4 = (this.GetIndexPoint.Y > base.Height - 7);
				int result;
				if (this.B1 && this.B3)
				{
					result = 4;
				}
				else if (this.B1 && this.B4)
				{
					result = 7;
				}
				else if (this.B2 && this.B3)
				{
					result = 5;
				}
				else if (this.B2 && this.B4)
				{
					result = 8;
				}
				else if (this.B1)
				{
					result = 1;
				}
				else if (this.B2)
				{
					result = 2;
				}
				else if (this.B3)
				{
					result = 3;
				}
				else if (this.B4)
				{
					result = 6;
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0001267C File Offset: 0x0001087C
		private void InvalidateMouse()
		{
			this.Current = this.GetIndex();
			if (this.Current != this.Previous)
			{
				this.Previous = this.Current;
				switch (this.Previous)
				{
				case 0:
					this.Cursor = Cursors.Default;
					break;
				case 1:
				case 2:
					this.Cursor = Cursors.SizeWE;
					break;
				case 3:
				case 6:
					this.Cursor = Cursors.SizeNS;
					break;
				case 4:
				case 8:
					this.Cursor = Cursors.SizeNWSE;
					break;
				case 5:
				case 7:
					this.Cursor = Cursors.SizeNESW;
					break;
				}
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00012724 File Offset: 0x00010924
		private void InitializeMessages()
		{
			this.Messages[0] = Message.Create(base.Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
			int num = 1;
			checked
			{
				do
				{
					this.Messages[num] = Message.Create(base.Parent.Handle, 161, new IntPtr(num + 9), IntPtr.Zero);
					num++;
				}
				while (num <= 8);
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000225 RID: 549 RVA: 0x00012798 File Offset: 0x00010998
		// (set) Token: 0x06000226 RID: 550 RVA: 0x000127B0 File Offset: 0x000109B0
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
					if (!this._ControlMode)
					{
						base.Parent.BackColor = value;
					}
					base.BackColor = value;
				}
				else
				{
					this.BackColorWait = value;
				}
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000227 RID: 551 RVA: 0x000127EC File Offset: 0x000109EC
		// (set) Token: 0x06000228 RID: 552 RVA: 0x00002E9E File Offset: 0x0000109E
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

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00012800 File Offset: 0x00010A00
		// (set) Token: 0x0600022A RID: 554 RVA: 0x00002E9E File Offset: 0x0000109E
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

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600022B RID: 555 RVA: 0x00012810 File Offset: 0x00010A10
		// (set) Token: 0x0600022C RID: 556 RVA: 0x00002E9E File Offset: 0x0000109E
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

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600022D RID: 557 RVA: 0x000073D4 File Offset: 0x000055D4
		// (set) Token: 0x0600022E RID: 558 RVA: 0x00002ECF File Offset: 0x000010CF
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

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600022F RID: 559 RVA: 0x00007418 File Offset: 0x00005618
		// (set) Token: 0x06000230 RID: 560 RVA: 0x00002EDE File Offset: 0x000010DE
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

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000231 RID: 561 RVA: 0x00012820 File Offset: 0x00010A20
		// (set) Token: 0x06000232 RID: 562 RVA: 0x00002EED File Offset: 0x000010ED
		public bool Movable
		{
			get
			{
				return this._Movable;
			}
			set
			{
				this._Movable = value;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000233 RID: 563 RVA: 0x00012834 File Offset: 0x00010A34
		// (set) Token: 0x06000234 RID: 564 RVA: 0x00002EF6 File Offset: 0x000010F6
		public bool Sizable
		{
			get
			{
				return this._Sizable;
			}
			set
			{
				this._Sizable = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000235 RID: 565 RVA: 0x00012848 File Offset: 0x00010A48
		// (set) Token: 0x06000236 RID: 566 RVA: 0x00012860 File Offset: 0x00010A60
		protected int MoveHeight
		{
			get
			{
				return this._MoveHeight;
			}
			set
			{
				if (value >= 8)
				{
					this.Header = checked(new Rectangle(7, 7, base.Width - 14, value - 7));
					this._MoveHeight = value;
					base.Invalidate();
				}
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000237 RID: 567 RVA: 0x0001289C File Offset: 0x00010A9C
		// (set) Token: 0x06000238 RID: 568 RVA: 0x00002EFF File Offset: 0x000010FF
		protected bool ControlMode
		{
			get
			{
				return this._ControlMode;
			}
			set
			{
				this._ControlMode = value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000239 RID: 569 RVA: 0x000128B0 File Offset: 0x00010AB0
		// (set) Token: 0x0600023A RID: 570 RVA: 0x000128EC File Offset: 0x00010AEC
		public Color TransparencyKey
		{
			get
			{
				Color transparencyKey;
				if (this._IsParentForm && !this._ControlMode)
				{
					transparencyKey = base.ParentForm.TransparencyKey;
				}
				else
				{
					transparencyKey = this._TransparencyKey;
				}
				return transparencyKey;
			}
			set
			{
				if (this._IsParentForm && !this._ControlMode)
				{
					base.ParentForm.TransparencyKey = value;
				}
				this._TransparencyKey = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600023B RID: 571 RVA: 0x00012924 File Offset: 0x00010B24
		// (set) Token: 0x0600023C RID: 572 RVA: 0x00012960 File Offset: 0x00010B60
		public FormBorderStyle BorderStyle
		{
			get
			{
				FormBorderStyle result;
				if (this._IsParentForm && !this._ControlMode)
				{
					result = base.ParentForm.FormBorderStyle;
				}
				else
				{
					result = this._BorderStyle;
				}
				return result;
			}
			set
			{
				if (this._IsParentForm && !this._ControlMode)
				{
					base.ParentForm.FormBorderStyle = value;
				}
				this._BorderStyle = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00012998 File Offset: 0x00010B98
		// (set) Token: 0x0600023E RID: 574 RVA: 0x00002F08 File Offset: 0x00001108
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

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600023F RID: 575 RVA: 0x000129AC File Offset: 0x00010BAC
		// (set) Token: 0x06000240 RID: 576 RVA: 0x000129C4 File Offset: 0x00010BC4
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

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000241 RID: 577 RVA: 0x00012A00 File Offset: 0x00010C00
		protected Size ImageSize
		{
			get
			{
				return this._ImageSize;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000242 RID: 578 RVA: 0x00012A18 File Offset: 0x00010C18
		protected bool IsParentForm
		{
			get
			{
				return this._IsParentForm;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000243 RID: 579 RVA: 0x00012A2C File Offset: 0x00010C2C
		// (set) Token: 0x06000244 RID: 580 RVA: 0x00012A44 File Offset: 0x00010C44
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

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000245 RID: 581 RVA: 0x00012A78 File Offset: 0x00010C78
		// (set) Token: 0x06000246 RID: 582 RVA: 0x00012A90 File Offset: 0x00010C90
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

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000247 RID: 583 RVA: 0x00012AC4 File Offset: 0x00010CC4
		// (set) Token: 0x06000248 RID: 584 RVA: 0x00012B20 File Offset: 0x00010D20
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

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000249 RID: 585 RVA: 0x00012B88 File Offset: 0x00010D88
		// (set) Token: 0x0600024A RID: 586 RVA: 0x00012BA0 File Offset: 0x00010DA0
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

		// Token: 0x0600024B RID: 587 RVA: 0x00012C38 File Offset: 0x00010E38
		protected Color GetColor(string name)
		{
			return this.Items[name];
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00012C54 File Offset: 0x00010E54
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

		// Token: 0x0600024D RID: 589 RVA: 0x00002F17 File Offset: 0x00001117
		protected void SetColor(string name, byte r, byte g, byte b)
		{
			this.SetColor(name, Color.FromArgb((int)r, (int)g, (int)b));
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00002F29 File Offset: 0x00001129
		protected void SetColor(string name, byte a, byte r, byte g, byte b)
		{
			this.SetColor(name, Color.FromArgb((int)a, (int)r, (int)g, (int)b));
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00002F3D File Offset: 0x0000113D
		protected void SetColor(string name, byte a, Color color)
		{
			this.SetColor(name, Color.FromArgb((int)a, color));
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00012C8C File Offset: 0x00010E8C
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

		// Token: 0x06000251 RID: 593
		protected abstract void ColorHook();

		// Token: 0x06000252 RID: 594
		protected abstract void PaintHook();

		// Token: 0x06000253 RID: 595 RVA: 0x00012D00 File Offset: 0x00010F00
		protected Point Center(Rectangle r1, Size s1)
		{
			this.CenterReturn = checked(new Point(r1.Width / 2 - s1.Width / 2 + r1.X, r1.Height / 2 - s1.Height / 2 + r1.Y));
			return this.CenterReturn;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00012D58 File Offset: 0x00010F58
		protected Point Center(Rectangle r1, Rectangle r2)
		{
			return this.Center(r1, r2.Size);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00012D78 File Offset: 0x00010F78
		protected Point Center(int w1, int h1, int w2, int h2)
		{
			this.CenterReturn = checked(new Point(w1 / 2 - w2 / 2, h1 / 2 - h2 / 2));
			return this.CenterReturn;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00012DA8 File Offset: 0x00010FA8
		protected Point Center(Size s1, Size s2)
		{
			return this.Center(s1.Width, s1.Height, s2.Width, s2.Height);
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00012DDC File Offset: 0x00010FDC
		protected Point Center(Rectangle r1)
		{
			return this.Center(base.ClientRectangle.Width, base.ClientRectangle.Height, r1.Width, r1.Height);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00012E1C File Offset: 0x0001101C
		protected Point Center(Size s1)
		{
			return this.Center(base.Width, base.Height, s1.Width, s1.Height);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00012E4C File Offset: 0x0001104C
		protected Point Center(int w1, int h1)
		{
			return this.Center(base.Width, base.Height, w1, h1);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00012E70 File Offset: 0x00011070
		protected Size Measure(string text)
		{
			return this.MeasureGraphics.MeasureString(text, this.Font, base.Width).ToSize();
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00012EA0 File Offset: 0x000110A0
		protected Size Measure()
		{
			return this.MeasureGraphics.MeasureString(this.Text, this.Font).ToSize();
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00002F4D File Offset: 0x0000114D
		protected void DrawCorners(Color c1)
		{
			this.DrawCorners(c1, 0, 0, base.Width, base.Height);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00002F64 File Offset: 0x00001164
		protected void DrawCorners(Color c1, Rectangle r1)
		{
			this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00012ED0 File Offset: 0x000110D0
		protected void DrawCorners(Color c1, int x, int y, int width, int height)
		{
			checked
			{
				if (!this._NoRounding)
				{
					this.DrawCornersBrush = new SolidBrush(c1);
					this.G.FillRectangle(this.DrawCornersBrush, x, y, 1, 1);
					this.G.FillRectangle(this.DrawCornersBrush, x + (width - 1), y, 1, 1);
					this.G.FillRectangle(this.DrawCornersBrush, x, y + (height - 1), 1, 1);
					this.G.FillRectangle(this.DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
				}
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00002F89 File Offset: 0x00001189
		protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
		{
			checked
			{
				this.DrawBorders(p1, x + offset, y + offset, width - offset * 2, height - offset * 2);
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00002FA8 File Offset: 0x000011A8
		protected void DrawBorders(Pen p1, int offset)
		{
			this.DrawBorders(p1, 0, 0, base.Width, base.Height, offset);
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00002FC0 File Offset: 0x000011C0
		protected void DrawBorders(Pen p1, Rectangle r, int offset)
		{
			this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00002FE6 File Offset: 0x000011E6
		protected void DrawBorders(Pen p1, int x, int y, int width, int height)
		{
			checked
			{
				this.G.DrawRectangle(p1, x, y, width - 1, height - 1);
			}
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00002FFE File Offset: 0x000011FE
		protected void DrawBorders(Pen p1)
		{
			this.DrawBorders(p1, 0, 0, base.Width, base.Height);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00003015 File Offset: 0x00001215
		protected void DrawBorders(Pen p1, Rectangle r)
		{
			this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000303A File Offset: 0x0000123A
		protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
		{
			this.DrawText(b1, this.Text, a, x, y);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000304D File Offset: 0x0000124D
		protected void DrawText(Brush b1, Point p1)
		{
			this.DrawText(b1, this.Text, p1.X, p1.Y);
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000306A File Offset: 0x0000126A
		protected void DrawText(Brush b1, int x, int y)
		{
			this.DrawText(b1, this.Text, x, y);
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00012F5C File Offset: 0x0001115C
		protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
		{
			checked
			{
				if (text.Length != 0)
				{
					this.DrawTextSize = this.Measure(text);
					this.DrawTextPoint = new Point(base.Width / 2 - this.DrawTextSize.Width / 2, this.MoveHeight / 2 - this.DrawTextSize.Height / 2);
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

		// Token: 0x06000269 RID: 617 RVA: 0x0000307B File Offset: 0x0000127B
		protected void DrawText(Brush b1, string text, Point p1)
		{
			this.DrawText(b1, text, p1.X, p1.Y);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0001303C File Offset: 0x0001123C
		protected void DrawText(Brush b1, string text, int x, int y)
		{
			if (text.Length != 0)
			{
				this.G.DrawString(text, this.Font, b1, (float)x, (float)y);
			}
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00003093 File Offset: 0x00001293
		protected void DrawImage(HorizontalAlignment a, int x, int y)
		{
			this.DrawImage(this._Image, a, x, y);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x000030A4 File Offset: 0x000012A4
		protected void DrawImage(Point p1)
		{
			this.DrawImage(this._Image, p1.X, p1.Y);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x000030C0 File Offset: 0x000012C0
		protected void DrawImage(int x, int y)
		{
			this.DrawImage(this._Image, x, y);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0001306C File Offset: 0x0001126C
		protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
		{
			checked
			{
				if (image != null)
				{
					this.DrawImagePoint = new Point(base.Width / 2 - image.Width / 2, this.MoveHeight / 2 - image.Height / 2);
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

		// Token: 0x0600026F RID: 623 RVA: 0x000030D0 File Offset: 0x000012D0
		protected void DrawImage(Image image, Point p1)
		{
			this.DrawImage(image, p1.X, p1.Y);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00013128 File Offset: 0x00011328
		protected void DrawImage(Image image, int x, int y)
		{
			if (image != null)
			{
				this.G.DrawImage(image, x, y, image.Width, image.Height);
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x000030E7 File Offset: 0x000012E7
		protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
		{
			this.DrawGradient(blend, x, y, width, height, 90f);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x000030FB File Offset: 0x000012FB
		protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
		{
			this.DrawGradient(c1, c2, x, y, width, height, 90f);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00003111 File Offset: 0x00001311
		protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(blend, this.DrawGradientRectangle, angle);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00003133 File Offset: 0x00001333
		protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(c1, c2, this.DrawGradientRectangle, angle);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00003157 File Offset: 0x00001357
		protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
			this.DrawGradientBrush.InterpolationColors = blend;
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000318E File Offset: 0x0000138E
		protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		// Token: 0x0400014A RID: 330
		protected Graphics G;

		// Token: 0x0400014B RID: 331
		private Rectangle Header;

		// Token: 0x0400014C RID: 332
		protected MouseState State;

		// Token: 0x0400014D RID: 333
		private Point GetIndexPoint;

		// Token: 0x0400014E RID: 334
		private bool B1;

		// Token: 0x0400014F RID: 335
		private bool B2;

		// Token: 0x04000150 RID: 336
		private bool B3;

		// Token: 0x04000151 RID: 337
		private bool B4;

		// Token: 0x04000152 RID: 338
		private int Current;

		// Token: 0x04000153 RID: 339
		private int Previous;

		// Token: 0x04000154 RID: 340
		private Message[] Messages;

		// Token: 0x04000155 RID: 341
		private Color BackColorWait;

		// Token: 0x04000156 RID: 342
		private bool _Movable;

		// Token: 0x04000157 RID: 343
		private bool _Sizable;

		// Token: 0x04000158 RID: 344
		private int _MoveHeight;

		// Token: 0x04000159 RID: 345
		private bool _ControlMode;

		// Token: 0x0400015A RID: 346
		private Color _TransparencyKey;

		// Token: 0x0400015B RID: 347
		private FormBorderStyle _BorderStyle;

		// Token: 0x0400015C RID: 348
		private bool _NoRounding;

		// Token: 0x0400015D RID: 349
		private Image _Image;

		// Token: 0x0400015E RID: 350
		private Size _ImageSize;

		// Token: 0x0400015F RID: 351
		private bool _IsParentForm;

		// Token: 0x04000160 RID: 352
		private int _LockWidth;

		// Token: 0x04000161 RID: 353
		private int _LockHeight;

		// Token: 0x04000162 RID: 354
		private Dictionary<string, Color> Items;

		// Token: 0x04000163 RID: 355
		private string _Customization;

		// Token: 0x04000164 RID: 356
		private Point CenterReturn;

		// Token: 0x04000165 RID: 357
		private Bitmap MeasureBitmap;

		// Token: 0x04000166 RID: 358
		private Graphics MeasureGraphics;

		// Token: 0x04000167 RID: 359
		private SolidBrush DrawCornersBrush;

		// Token: 0x04000168 RID: 360
		private Point DrawTextPoint;

		// Token: 0x04000169 RID: 361
		private Size DrawTextSize;

		// Token: 0x0400016A RID: 362
		private Point DrawImagePoint;

		// Token: 0x0400016B RID: 363
		private LinearGradientBrush DrawGradientBrush;

		// Token: 0x0400016C RID: 364
		private Rectangle DrawGradientRectangle;
	}
}
