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
	// Token: 0x02000047 RID: 71
	internal abstract class ThemeContainer154 : ContainerControl
	{
		// Token: 0x060004F0 RID: 1264 RVA: 0x0001C220 File Offset: 0x0001A420
		public ThemeContainer154()
		{
			this.Messages = new Message[9];
			this._SmartBounds = true;
			this._Movable = true;
			this._Sizable = true;
			this.Items = new Dictionary<string, Color>();
			this._Header = 24;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this._ImageSize = Size.Empty;
			this.Font = new Font("Verdana", 8f);
			this.MeasureBitmap = new Bitmap(1, 1);
			this.MeasureGraphics = Graphics.FromImage(this.MeasureBitmap);
			this.DrawRadialPath = new GraphicsPath();
			this.InvalidateCustimization();
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0001C2C4 File Offset: 0x0001A4C4
		protected sealed override void OnHandleCreated(EventArgs e)
		{
			if (this.DoneCreation)
			{
				this.InitializeMessages();
			}
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
			if (!this._ControlMode)
			{
				base.Dock = DockStyle.Fill;
			}
			this.Transparent = this._Transparent;
			if (this._Transparent && this._BackColor)
			{
				this.BackColor = Color.Transparent;
			}
			base.OnHandleCreated(e);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0001C35C File Offset: 0x0001A55C
		protected sealed override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (base.Parent != null)
			{
				this._IsParentForm = (base.Parent is Form);
				if (!this._ControlMode)
				{
					this.InitializeMessages();
					if (this._IsParentForm)
					{
						base.ParentForm.FormBorderStyle = this._BorderStyle;
						base.ParentForm.TransparencyKey = this._TransparencyKey;
						if (!base.DesignMode)
						{
							base.ParentForm.Shown += this.FormShown;
						}
					}
					base.Parent.BackColor = this.BackColor;
				}
				this.OnCreation();
				this.DoneCreation = true;
				this.InvalidateTimer();
			}
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0001C414 File Offset: 0x0001A614
		private void DoAnimation(bool i)
		{
			this.OnAnimation();
			if (i)
			{
				base.Invalidate();
			}
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0001C430 File Offset: 0x0001A630
		protected sealed override void OnPaint(PaintEventArgs e)
		{
			if (base.Width != 0 && base.Height != 0)
			{
				if (this._Transparent && this._ControlMode)
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

		// Token: 0x060004F5 RID: 1269 RVA: 0x00003FC2 File Offset: 0x000021C2
		protected override void OnHandleDestroyed(EventArgs e)
		{
			ThemeShare.RemoveAnimationCallback(new ThemeShare.AnimationDelegate(this.DoAnimation));
			base.OnHandleDestroyed(e);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0001C494 File Offset: 0x0001A694
		private void FormShown(object sender, EventArgs e)
		{
			if (!this._ControlMode && !this.HasShown)
			{
				if (this._StartPosition == FormStartPosition.CenterParent || this._StartPosition == FormStartPosition.CenterScreen)
				{
					Rectangle bounds = Screen.PrimaryScreen.Bounds;
					Rectangle bounds2 = base.ParentForm.Bounds;
					base.ParentForm.Location = checked(new Point(bounds.Width / 2 - bounds2.Width / 2, bounds.Height / 2 - bounds2.Width / 2));
				}
				this.HasShown = true;
			}
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0001C520 File Offset: 0x0001A720
		protected sealed override void OnSizeChanged(EventArgs e)
		{
			if (this._Movable && !this._ControlMode)
			{
				this.Frame = checked(new Rectangle(7, 7, base.Width - 14, this._Header - 7));
			}
			this.InvalidateBitmap();
			base.Invalidate();
			base.OnSizeChanged(e);
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0001C574 File Offset: 0x0001A774
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

		// Token: 0x060004F9 RID: 1273 RVA: 0x00003FDC File Offset: 0x000021DC
		private void SetState(MouseState current)
		{
			this.State = current;
			base.Invalidate();
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0001C5B4 File Offset: 0x0001A7B4
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if ((!this._IsParentForm || base.ParentForm.WindowState != FormWindowState.Maximized) && (this._Sizable && !this._ControlMode))
			{
				this.InvalidateMouse();
			}
			base.OnMouseMove(e);
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0001C604 File Offset: 0x0001A804
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

		// Token: 0x060004FC RID: 1276 RVA: 0x00003FEB File Offset: 0x000021EB
		protected override void OnMouseEnter(EventArgs e)
		{
			this.SetState(MouseState.Over);
			base.OnMouseEnter(e);
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00003FFB File Offset: 0x000021FB
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.SetState(MouseState.Over);
			base.OnMouseUp(e);
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x0001C630 File Offset: 0x0001A830
		protected override void OnMouseLeave(EventArgs e)
		{
			this.SetState(MouseState.None);
			if (base.GetChildAtPoint(base.PointToClient(Control.MousePosition)) != null && (this._Sizable && !this._ControlMode))
			{
				this.Cursor = Cursors.Default;
				this.Previous = 0;
			}
			base.OnMouseLeave(e);
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0001C68C File Offset: 0x0001A88C
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.SetState(MouseState.Down);
			}
			bool flag;
			if (this._IsParentForm)
			{
				if (base.ParentForm.WindowState == FormWindowState.Maximized)
				{
					flag = false;
					goto IL_3A;
				}
			}
			flag = !this._ControlMode;
			IL_3A:
			if (flag)
			{
				if (this._Movable && this.Frame.Contains(e.Location))
				{
					base.Capture = false;
					this.WM_LMBUTTONDOWN = true;
					this.DefWndProc(ref this.Messages[0]);
				}
				else if (this._Sizable && this.Previous != 0)
				{
					base.Capture = false;
					this.WM_LMBUTTONDOWN = true;
					this.DefWndProc(ref this.Messages[this.Previous]);
				}
			}
			base.OnMouseDown(e);
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0001C758 File Offset: 0x0001A958
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (this.WM_LMBUTTONDOWN && m.Msg == 513)
			{
				this.WM_LMBUTTONDOWN = false;
				this.SetState(MouseState.Over);
				if (this._SmartBounds)
				{
					if (this.IsParentMdi)
					{
						this.CorrectBounds(new Rectangle(Point.Empty, base.Parent.Parent.Size));
					}
					else
					{
						this.CorrectBounds(Screen.FromControl(base.Parent).WorkingArea);
					}
				}
			}
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0001C7E0 File Offset: 0x0001A9E0
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

		// Token: 0x06000502 RID: 1282 RVA: 0x0001C8EC File Offset: 0x0001AAEC
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

		// Token: 0x06000503 RID: 1283 RVA: 0x0001C994 File Offset: 0x0001AB94
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

		// Token: 0x06000504 RID: 1284 RVA: 0x0001CA08 File Offset: 0x0001AC08
		private void CorrectBounds(Rectangle bounds)
		{
			if (base.Parent.Width > bounds.Width)
			{
				base.Parent.Width = bounds.Width;
			}
			if (base.Parent.Height > bounds.Height)
			{
				base.Parent.Height = bounds.Height;
			}
			int num = base.Parent.Location.X;
			int num2 = base.Parent.Location.Y;
			if (num < bounds.X)
			{
				num = bounds.X;
			}
			if (num2 < bounds.Y)
			{
				num2 = bounds.Y;
			}
			checked
			{
				int num3 = bounds.X + bounds.Width;
				int num4 = bounds.Y + bounds.Height;
				if (num + base.Parent.Width > num3)
				{
					num = num3 - base.Parent.Width;
				}
				if (num2 + base.Parent.Height > num4)
				{
					num2 = num4 - base.Parent.Height;
				}
				base.Parent.Location = new Point(num, num2);
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x0001CB2C File Offset: 0x0001AD2C
		// (set) Token: 0x06000506 RID: 1286 RVA: 0x0001CB44 File Offset: 0x0001AD44
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				if (this._ControlMode)
				{
					base.Dock = value;
				}
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x00012798 File Offset: 0x00010998
		// (set) Token: 0x06000508 RID: 1288 RVA: 0x0001CB64 File Offset: 0x0001AD64
		[Category("Misc")]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				if (!(value == base.BackColor))
				{
					if (!base.IsHandleCreated && this._ControlMode && value == Color.Transparent)
					{
						this._BackColor = true;
					}
					else
					{
						base.BackColor = value;
						if (base.Parent != null)
						{
							if (!this._ControlMode)
							{
								base.Parent.BackColor = value;
							}
							this.ColorHook();
						}
					}
				}
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x0001CBD8 File Offset: 0x0001ADD8
		// (set) Token: 0x0600050A RID: 1290 RVA: 0x0001CBF0 File Offset: 0x0001ADF0
		public override Size MinimumSize
		{
			get
			{
				return base.MinimumSize;
			}
			set
			{
				base.MinimumSize = value;
				if (base.Parent != null)
				{
					base.Parent.MinimumSize = value;
				}
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x0001CC1C File Offset: 0x0001AE1C
		// (set) Token: 0x0600050C RID: 1292 RVA: 0x0001CC34 File Offset: 0x0001AE34
		public override Size MaximumSize
		{
			get
			{
				return base.MaximumSize;
			}
			set
			{
				base.MaximumSize = value;
				if (base.Parent != null)
				{
					base.Parent.MaximumSize = value;
				}
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600050D RID: 1293 RVA: 0x000073D4 File Offset: 0x000055D4
		// (set) Token: 0x0600050E RID: 1294 RVA: 0x00002ECF File Offset: 0x000010CF
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

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x0600050F RID: 1295 RVA: 0x00007418 File Offset: 0x00005618
		// (set) Token: 0x06000510 RID: 1296 RVA: 0x00002EDE File Offset: 0x000010DE
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

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x000127EC File Offset: 0x000109EC
		// (set) Token: 0x06000512 RID: 1298 RVA: 0x00002E9E File Offset: 0x0000109E
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

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000513 RID: 1299 RVA: 0x00012800 File Offset: 0x00010A00
		// (set) Token: 0x06000514 RID: 1300 RVA: 0x00002E9E File Offset: 0x0000109E
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

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000515 RID: 1301 RVA: 0x00012810 File Offset: 0x00010A10
		// (set) Token: 0x06000516 RID: 1302 RVA: 0x00002E9E File Offset: 0x0000109E
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

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x0001CC60 File Offset: 0x0001AE60
		// (set) Token: 0x06000518 RID: 1304 RVA: 0x0000400B File Offset: 0x0000220B
		public bool SmartBounds
		{
			get
			{
				return this._SmartBounds;
			}
			set
			{
				this._SmartBounds = value;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x0001CC74 File Offset: 0x0001AE74
		// (set) Token: 0x0600051A RID: 1306 RVA: 0x00004014 File Offset: 0x00002214
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

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0001CC88 File Offset: 0x0001AE88
		// (set) Token: 0x0600051C RID: 1308 RVA: 0x0000401D File Offset: 0x0000221D
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

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x0001CC9C File Offset: 0x0001AE9C
		// (set) Token: 0x0600051E RID: 1310 RVA: 0x0001CCD8 File Offset: 0x0001AED8
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
				if (!(value == this._TransparencyKey))
				{
					this._TransparencyKey = value;
					if (this._IsParentForm && !this._ControlMode)
					{
						base.ParentForm.TransparencyKey = value;
						this.ColorHook();
					}
				}
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x0001CD24 File Offset: 0x0001AF24
		// (set) Token: 0x06000520 RID: 1312 RVA: 0x0001CD60 File Offset: 0x0001AF60
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
				this._BorderStyle = value;
				if (this._IsParentForm && !this._ControlMode)
				{
					base.ParentForm.FormBorderStyle = value;
					if (value > FormBorderStyle.None)
					{
						this.Movable = false;
						this.Sizable = false;
					}
				}
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000521 RID: 1313 RVA: 0x0001CDAC File Offset: 0x0001AFAC
		// (set) Token: 0x06000522 RID: 1314 RVA: 0x0001CDE8 File Offset: 0x0001AFE8
		public FormStartPosition StartPosition
		{
			get
			{
				FormStartPosition startPosition;
				if (this._IsParentForm && !this._ControlMode)
				{
					startPosition = base.ParentForm.StartPosition;
				}
				else
				{
					startPosition = this._StartPosition;
				}
				return startPosition;
			}
			set
			{
				this._StartPosition = value;
				if (this._IsParentForm && !this._ControlMode)
				{
					base.ParentForm.StartPosition = value;
				}
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000523 RID: 1315 RVA: 0x0001CE20 File Offset: 0x0001B020
		// (set) Token: 0x06000524 RID: 1316 RVA: 0x00004026 File Offset: 0x00002226
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

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000525 RID: 1317 RVA: 0x0001CE34 File Offset: 0x0001B034
		// (set) Token: 0x06000526 RID: 1318 RVA: 0x0001CE4C File Offset: 0x0001B04C
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

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x0001CE88 File Offset: 0x0001B088
		// (set) Token: 0x06000528 RID: 1320 RVA: 0x0001CEE4 File Offset: 0x0001B0E4
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

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x0001CF4C File Offset: 0x0001B14C
		// (set) Token: 0x0600052A RID: 1322 RVA: 0x0001CF64 File Offset: 0x0001B164
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

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x0001CFFC File Offset: 0x0001B1FC
		// (set) Token: 0x0600052C RID: 1324 RVA: 0x0001D010 File Offset: 0x0001B210
		public bool Transparent
		{
			get
			{
				return this._Transparent;
			}
			set
			{
				this._Transparent = value;
				if (base.IsHandleCreated || this._ControlMode)
				{
					if (!value && this.BackColor.A != 255)
					{
						throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
					}
					base.SetStyle(ControlStyles.Opaque, !value);
					base.SetStyle(ControlStyles.SupportsTransparentBackColor, value);
					this.InvalidateBitmap();
					base.Invalidate();
				}
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x0001D088 File Offset: 0x0001B288
		protected Size ImageSize
		{
			get
			{
				return this._ImageSize;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x0600052E RID: 1326 RVA: 0x0001D0A0 File Offset: 0x0001B2A0
		protected bool IsParentForm
		{
			get
			{
				return this._IsParentForm;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x0001D0B4 File Offset: 0x0001B2B4
		protected bool IsParentMdi
		{
			get
			{
				return base.Parent != null && base.Parent.Parent != null;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000530 RID: 1328 RVA: 0x0001D0E0 File Offset: 0x0001B2E0
		// (set) Token: 0x06000531 RID: 1329 RVA: 0x0001D0F8 File Offset: 0x0001B2F8
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

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000532 RID: 1330 RVA: 0x0001D12C File Offset: 0x0001B32C
		// (set) Token: 0x06000533 RID: 1331 RVA: 0x0001D144 File Offset: 0x0001B344
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

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x0001D178 File Offset: 0x0001B378
		// (set) Token: 0x06000535 RID: 1333 RVA: 0x0001D190 File Offset: 0x0001B390
		protected int Header
		{
			get
			{
				return this._Header;
			}
			set
			{
				this._Header = value;
				if (!this._ControlMode)
				{
					this.Frame = checked(new Rectangle(7, 7, base.Width - 14, value - 7));
					base.Invalidate();
				}
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x0001D1D0 File Offset: 0x0001B3D0
		// (set) Token: 0x06000537 RID: 1335 RVA: 0x0001D1E4 File Offset: 0x0001B3E4
		protected bool ControlMode
		{
			get
			{
				return this._ControlMode;
			}
			set
			{
				this._ControlMode = value;
				this.Transparent = this._Transparent;
				if (this._Transparent && this._BackColor)
				{
					this.BackColor = Color.Transparent;
				}
				this.InvalidateBitmap();
				base.Invalidate();
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x0001D230 File Offset: 0x0001B430
		// (set) Token: 0x06000539 RID: 1337 RVA: 0x00004035 File Offset: 0x00002235
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

		// Token: 0x0600053A RID: 1338 RVA: 0x0001D244 File Offset: 0x0001B444
		protected Pen GetPen(string name)
		{
			return new Pen(this.Items[name]);
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0001D264 File Offset: 0x0001B464
		protected Pen GetPen(string name, float width)
		{
			return new Pen(this.Items[name], width);
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0001D288 File Offset: 0x0001B488
		protected SolidBrush GetBrush(string name)
		{
			return new SolidBrush(this.Items[name]);
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0001D2A8 File Offset: 0x0001B4A8
		protected Color GetColor(string name)
		{
			return this.Items[name];
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0001D2C4 File Offset: 0x0001B4C4
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

		// Token: 0x0600053F RID: 1343 RVA: 0x00004044 File Offset: 0x00002244
		protected void SetColor(string name, byte r, byte g, byte b)
		{
			this.SetColor(name, Color.FromArgb((int)r, (int)g, (int)b));
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00004056 File Offset: 0x00002256
		protected void SetColor(string name, byte a, byte r, byte g, byte b)
		{
			this.SetColor(name, Color.FromArgb((int)a, (int)r, (int)g, (int)b));
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0000406A File Offset: 0x0000226A
		protected void SetColor(string name, byte a, Color value)
		{
			this.SetColor(name, Color.FromArgb((int)a, value));
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0001D2FC File Offset: 0x0001B4FC
		private void InvalidateBitmap()
		{
			if (this._Transparent && this._ControlMode)
			{
				if (base.Width != 0 && base.Height != 0)
				{
					this.B = new Bitmap(base.Width, base.Height, PixelFormat.Format32bppPArgb);
					this.G = Graphics.FromImage(this.B);
				}
			}
			else
			{
				this.G = null;
				this.B = null;
			}
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0001D370 File Offset: 0x0001B570
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

		// Token: 0x06000544 RID: 1348 RVA: 0x0001D3E4 File Offset: 0x0001B5E4
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

		// Token: 0x06000545 RID: 1349
		protected abstract void ColorHook();

		// Token: 0x06000546 RID: 1350
		protected abstract void PaintHook();

		// Token: 0x06000547 RID: 1351 RVA: 0x00002E9E File Offset: 0x0000109E
		protected virtual void OnCreation()
		{
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00002E9E File Offset: 0x0000109E
		protected virtual void OnAnimation()
		{
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0001D434 File Offset: 0x0001B634
		protected Rectangle Offset(Rectangle r, int amount)
		{
			this.OffsetReturnRectangle = checked(new Rectangle(r.X + amount, r.Y + amount, r.Width - amount * 2, r.Height - amount * 2));
			return this.OffsetReturnRectangle;
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0001D47C File Offset: 0x0001B67C
		protected Size Offset(Size s, int amount)
		{
			this.OffsetReturnSize = checked(new Size(s.Width + amount, s.Height + amount));
			return this.OffsetReturnSize;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0001D4B0 File Offset: 0x0001B6B0
		protected Point Offset(Point p, int amount)
		{
			this.OffsetReturnPoint = checked(new Point(p.X + amount, p.Y + amount));
			return this.OffsetReturnPoint;
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0001D4E4 File Offset: 0x0001B6E4
		protected Point Center(Rectangle p, Rectangle c)
		{
			this.CenterReturn = checked(new Point(p.Width / 2 - c.Width / 2 + p.X + c.X, p.Height / 2 - c.Height / 2 + p.Y + c.Y));
			return this.CenterReturn;
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0001D54C File Offset: 0x0001B74C
		protected Point Center(Rectangle p, Size c)
		{
			this.CenterReturn = checked(new Point(p.Width / 2 - c.Width / 2 + p.X, p.Height / 2 - c.Height / 2 + p.Y));
			return this.CenterReturn;
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0001D5A4 File Offset: 0x0001B7A4
		protected Point Center(Rectangle child)
		{
			return this.Center(base.Width, base.Height, child.Width, child.Height);
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0001D5D4 File Offset: 0x0001B7D4
		protected Point Center(Size child)
		{
			return this.Center(base.Width, base.Height, child.Width, child.Height);
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0001D604 File Offset: 0x0001B804
		protected Point Center(int childWidth, int childHeight)
		{
			return this.Center(base.Width, base.Height, childWidth, childHeight);
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0001D628 File Offset: 0x0001B828
		protected Point Center(Size p, Size c)
		{
			return this.Center(p.Width, p.Height, c.Width, c.Height);
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0001D65C File Offset: 0x0001B85C
		protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
		{
			this.CenterReturn = checked(new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2));
			return this.CenterReturn;
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0001D68C File Offset: 0x0001B88C
		protected Size Measure()
		{
			object measureGraphics = this.MeasureGraphics;
			Size result;
			lock (measureGraphics)
			{
				result = this.MeasureGraphics.MeasureString(this.Text, this.Font, base.Width).ToSize();
			}
			return result;
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0001D6F0 File Offset: 0x0001B8F0
		protected Size Measure(string text)
		{
			object measureGraphics = this.MeasureGraphics;
			Size result;
			lock (measureGraphics)
			{
				result = this.MeasureGraphics.MeasureString(text, this.Font, base.Width).ToSize();
			}
			return result;
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0001D74C File Offset: 0x0001B94C
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

		// Token: 0x06000556 RID: 1366 RVA: 0x0000407A File Offset: 0x0000227A
		protected void DrawCorners(Color c1, int offset)
		{
			this.DrawCorners(c1, 0, 0, base.Width, base.Height, offset);
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x00004092 File Offset: 0x00002292
		protected void DrawCorners(Color c1, Rectangle r1, int offset)
		{
			this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x000040B8 File Offset: 0x000022B8
		protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
		{
			checked
			{
				this.DrawCorners(c1, x + offset, y + offset, width - offset * 2, height - offset * 2);
			}
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x000040D7 File Offset: 0x000022D7
		protected void DrawCorners(Color c1)
		{
			this.DrawCorners(c1, 0, 0, base.Width, base.Height);
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x000040EE File Offset: 0x000022EE
		protected void DrawCorners(Color c1, Rectangle r1)
		{
			this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0001D794 File Offset: 0x0001B994
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

		// Token: 0x0600055C RID: 1372 RVA: 0x00004113 File Offset: 0x00002313
		protected void DrawBorders(Pen p1, int offset)
		{
			this.DrawBorders(p1, 0, 0, base.Width, base.Height, offset);
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0000412B File Offset: 0x0000232B
		protected void DrawBorders(Pen p1, Rectangle r, int offset)
		{
			this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00004151 File Offset: 0x00002351
		protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
		{
			checked
			{
				this.DrawBorders(p1, x + offset, y + offset, width - offset * 2, height - offset * 2);
			}
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00004170 File Offset: 0x00002370
		protected void DrawBorders(Pen p1)
		{
			this.DrawBorders(p1, 0, 0, base.Width, base.Height);
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x00004187 File Offset: 0x00002387
		protected void DrawBorders(Pen p1, Rectangle r)
		{
			this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x000041AC File Offset: 0x000023AC
		protected void DrawBorders(Pen p1, int x, int y, int width, int height)
		{
			checked
			{
				this.G.DrawRectangle(p1, x, y, width - 1, height - 1);
			}
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x000041C4 File Offset: 0x000023C4
		protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
		{
			this.DrawText(b1, this.Text, a, x, y);
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0001D878 File Offset: 0x0001BA78
		protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
		{
			checked
			{
				if (text.Length != 0)
				{
					this.DrawTextSize = this.Measure(text);
					this.DrawTextPoint = new Point(base.Width / 2 - this.DrawTextSize.Width / 2, this.Header / 2 - this.DrawTextSize.Height / 2);
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

		// Token: 0x06000564 RID: 1380 RVA: 0x0001D984 File Offset: 0x0001BB84
		protected void DrawText(Brush b1, Point p1)
		{
			if (this.Text.Length != 0)
			{
				this.G.DrawString(this.Text, this.Font, b1, p1);
			}
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x0001D9C0 File Offset: 0x0001BBC0
		protected void DrawText(Brush b1, int x, int y)
		{
			if (this.Text.Length != 0)
			{
				this.G.DrawString(this.Text, this.Font, b1, (float)x, (float)y);
			}
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x000041D7 File Offset: 0x000023D7
		protected void DrawImage(HorizontalAlignment a, int x, int y)
		{
			this.DrawImage(this._Image, a, x, y);
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0001D9FC File Offset: 0x0001BBFC
		protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
		{
			checked
			{
				if (image != null)
				{
					this.DrawImagePoint = new Point(base.Width / 2 - image.Width / 2, this.Header / 2 - image.Height / 2);
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

		// Token: 0x06000568 RID: 1384 RVA: 0x000041E8 File Offset: 0x000023E8
		protected void DrawImage(Point p1)
		{
			this.DrawImage(this._Image, p1.X, p1.Y);
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00004204 File Offset: 0x00002404
		protected void DrawImage(int x, int y)
		{
			this.DrawImage(this._Image, x, y);
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x00004214 File Offset: 0x00002414
		protected void DrawImage(Image image, Point p1)
		{
			this.DrawImage(image, p1.X, p1.Y);
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0001DAEC File Offset: 0x0001BCEC
		protected void DrawImage(Image image, int x, int y)
		{
			if (image != null)
			{
				this.G.DrawImage(image, x, y, image.Width, image.Height);
			}
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0000422B File Offset: 0x0000242B
		protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(blend, this.DrawGradientRectangle);
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0000424B File Offset: 0x0000244B
		protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(blend, this.DrawGradientRectangle, angle);
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0000426D File Offset: 0x0000246D
		protected void DrawGradient(ColorBlend blend, Rectangle r)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
			this.DrawGradientBrush.InterpolationColors = blend;
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x000042A8 File Offset: 0x000024A8
		protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
			this.DrawGradientBrush.InterpolationColors = blend;
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x000042DF File Offset: 0x000024DF
		protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(c1, c2, this.DrawGradientRectangle);
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x00004301 File Offset: 0x00002501
		protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(c1, c2, this.DrawGradientRectangle, angle);
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00004325 File Offset: 0x00002525
		protected void DrawGradient(Color c1, Color c2, Rectangle r)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0000434C File Offset: 0x0000254C
		protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x00004370 File Offset: 0x00002570
		public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(blend, this.DrawRadialRectangle, width / 2, height / 2);
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x00004398 File Offset: 0x00002598
		public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(blend, this.DrawRadialRectangle, center.X, center.Y);
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x000043C6 File Offset: 0x000025C6
		public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(blend, this.DrawRadialRectangle, cx, cy);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x000043EA File Offset: 0x000025EA
		public void DrawRadial(ColorBlend blend, Rectangle r)
		{
			this.DrawRadial(blend, r, r.Width / 2, r.Height / 2);
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x00004406 File Offset: 0x00002606
		public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
		{
			this.DrawRadial(blend, r, center.X, center.Y);
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0001DB1C File Offset: 0x0001BD1C
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

		// Token: 0x0600057A RID: 1402 RVA: 0x0000441E File Offset: 0x0000261E
		protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(c1, c2, this.DrawGradientRectangle);
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x00004440 File Offset: 0x00002640
		protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(c1, c2, this.DrawGradientRectangle, angle);
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x00004464 File Offset: 0x00002664
		protected void DrawRadial(Color c1, Color c2, Rectangle r)
		{
			this.DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0000448B File Offset: 0x0000268B
		protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
		{
			this.DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
			this.G.FillEllipse(this.DrawGradientBrush, r);
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0001DC00 File Offset: 0x0001BE00
		public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
		{
			this.CreateRoundRectangle = new Rectangle(x, y, width, height);
			return this.CreateRound(this.CreateRoundRectangle, slope);
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0001DC30 File Offset: 0x0001BE30
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

		// Token: 0x04000269 RID: 617
		protected Graphics G;

		// Token: 0x0400026A RID: 618
		protected Bitmap B;

		// Token: 0x0400026B RID: 619
		private bool DoneCreation;

		// Token: 0x0400026C RID: 620
		private bool HasShown;

		// Token: 0x0400026D RID: 621
		private Rectangle Frame;

		// Token: 0x0400026E RID: 622
		protected MouseState State;

		// Token: 0x0400026F RID: 623
		private bool WM_LMBUTTONDOWN;

		// Token: 0x04000270 RID: 624
		private Point GetIndexPoint;

		// Token: 0x04000271 RID: 625
		private bool B1;

		// Token: 0x04000272 RID: 626
		private bool B2;

		// Token: 0x04000273 RID: 627
		private bool B3;

		// Token: 0x04000274 RID: 628
		private bool B4;

		// Token: 0x04000275 RID: 629
		private int Current;

		// Token: 0x04000276 RID: 630
		private int Previous;

		// Token: 0x04000277 RID: 631
		private Message[] Messages;

		// Token: 0x04000278 RID: 632
		private bool _BackColor;

		// Token: 0x04000279 RID: 633
		private bool _SmartBounds;

		// Token: 0x0400027A RID: 634
		private bool _Movable;

		// Token: 0x0400027B RID: 635
		private bool _Sizable;

		// Token: 0x0400027C RID: 636
		private Color _TransparencyKey;

		// Token: 0x0400027D RID: 637
		private FormBorderStyle _BorderStyle;

		// Token: 0x0400027E RID: 638
		private FormStartPosition _StartPosition;

		// Token: 0x0400027F RID: 639
		private bool _NoRounding;

		// Token: 0x04000280 RID: 640
		private Image _Image;

		// Token: 0x04000281 RID: 641
		private Dictionary<string, Color> Items;

		// Token: 0x04000282 RID: 642
		private string _Customization;

		// Token: 0x04000283 RID: 643
		private bool _Transparent;

		// Token: 0x04000284 RID: 644
		private Size _ImageSize;

		// Token: 0x04000285 RID: 645
		private bool _IsParentForm;

		// Token: 0x04000286 RID: 646
		private int _LockWidth;

		// Token: 0x04000287 RID: 647
		private int _LockHeight;

		// Token: 0x04000288 RID: 648
		private int _Header;

		// Token: 0x04000289 RID: 649
		private bool _ControlMode;

		// Token: 0x0400028A RID: 650
		private bool _IsAnimated;

		// Token: 0x0400028B RID: 651
		private Rectangle OffsetReturnRectangle;

		// Token: 0x0400028C RID: 652
		private Size OffsetReturnSize;

		// Token: 0x0400028D RID: 653
		private Point OffsetReturnPoint;

		// Token: 0x0400028E RID: 654
		private Point CenterReturn;

		// Token: 0x0400028F RID: 655
		private Bitmap MeasureBitmap;

		// Token: 0x04000290 RID: 656
		private Graphics MeasureGraphics;

		// Token: 0x04000291 RID: 657
		private SolidBrush DrawPixelBrush;

		// Token: 0x04000292 RID: 658
		private SolidBrush DrawCornersBrush;

		// Token: 0x04000293 RID: 659
		private Point DrawTextPoint;

		// Token: 0x04000294 RID: 660
		private Size DrawTextSize;

		// Token: 0x04000295 RID: 661
		private Point DrawImagePoint;

		// Token: 0x04000296 RID: 662
		private LinearGradientBrush DrawGradientBrush;

		// Token: 0x04000297 RID: 663
		private Rectangle DrawGradientRectangle;

		// Token: 0x04000298 RID: 664
		private GraphicsPath DrawRadialPath;

		// Token: 0x04000299 RID: 665
		private PathGradientBrush DrawRadialBrush1;

		// Token: 0x0400029A RID: 666
		private LinearGradientBrush DrawRadialBrush2;

		// Token: 0x0400029B RID: 667
		private Rectangle DrawRadialRectangle;

		// Token: 0x0400029C RID: 668
		private GraphicsPath CreateRoundPath;

		// Token: 0x0400029D RID: 669
		private Rectangle CreateRoundRectangle;
	}
}
