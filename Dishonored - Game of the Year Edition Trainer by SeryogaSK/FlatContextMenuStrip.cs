using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200001A RID: 26
	internal class FlatContextMenuStrip : ContextMenuStrip
	{
		// Token: 0x0600011B RID: 283 RVA: 0x000023ED File Offset: 0x000005ED
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00002938 File Offset: 0x00000B38
		public FlatContextMenuStrip()
		{
			base.Renderer = new ToolStripProfessionalRenderer(new FlatContextMenuStrip.TColorTable());
			base.ShowImageMargin = false;
			base.ForeColor = Color.White;
			this.Font = new Font("Segoe UI", 8f);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00002977 File Offset: 0x00000B77
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		}

		// Token: 0x02000059 RID: 89
		public class TColorTable : ProfessionalColorTable
		{
			// Token: 0x0600068B RID: 1675 RVA: 0x00020790 File Offset: 0x0001E990
			public TColorTable()
			{
				this.BackColor = Color.FromArgb(60, 60, 60);
				this.CheckedColor = Color.FromArgb(0, 170, 220);
				this.BorderColor = Color.FromArgb(0, 170, 220);
			}

			// Token: 0x170001B1 RID: 433
			// (get) Token: 0x0600068C RID: 1676 RVA: 0x000207E0 File Offset: 0x0001E9E0
			// (set) Token: 0x0600068D RID: 1677 RVA: 0x00004AA3 File Offset: 0x00002CA3
			[Category("Colors")]
			public Color _BackColor
			{
				get
				{
					return this.BackColor;
				}
				set
				{
					this.BackColor = value;
				}
			}

			// Token: 0x170001B2 RID: 434
			// (get) Token: 0x0600068E RID: 1678 RVA: 0x000207F8 File Offset: 0x0001E9F8
			// (set) Token: 0x0600068F RID: 1679 RVA: 0x00004AAC File Offset: 0x00002CAC
			[Category("Colors")]
			public Color _CheckedColor
			{
				get
				{
					return this.CheckedColor;
				}
				set
				{
					this.CheckedColor = value;
				}
			}

			// Token: 0x170001B3 RID: 435
			// (get) Token: 0x06000690 RID: 1680 RVA: 0x00020810 File Offset: 0x0001EA10
			// (set) Token: 0x06000691 RID: 1681 RVA: 0x00004AB5 File Offset: 0x00002CB5
			[Category("Colors")]
			public Color _BorderColor
			{
				get
				{
					return this.BorderColor;
				}
				set
				{
					this.BorderColor = value;
				}
			}

			// Token: 0x170001B4 RID: 436
			// (get) Token: 0x06000692 RID: 1682 RVA: 0x000207E0 File Offset: 0x0001E9E0
			public override Color ButtonSelectedBorder
			{
				get
				{
					return this.BackColor;
				}
			}

			// Token: 0x170001B5 RID: 437
			// (get) Token: 0x06000693 RID: 1683 RVA: 0x000207F8 File Offset: 0x0001E9F8
			public override Color CheckBackground
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x170001B6 RID: 438
			// (get) Token: 0x06000694 RID: 1684 RVA: 0x000207F8 File Offset: 0x0001E9F8
			public override Color CheckPressedBackground
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x170001B7 RID: 439
			// (get) Token: 0x06000695 RID: 1685 RVA: 0x000207F8 File Offset: 0x0001E9F8
			public override Color CheckSelectedBackground
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x170001B8 RID: 440
			// (get) Token: 0x06000696 RID: 1686 RVA: 0x000207F8 File Offset: 0x0001E9F8
			public override Color ImageMarginGradientBegin
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x170001B9 RID: 441
			// (get) Token: 0x06000697 RID: 1687 RVA: 0x000207F8 File Offset: 0x0001E9F8
			public override Color ImageMarginGradientEnd
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x170001BA RID: 442
			// (get) Token: 0x06000698 RID: 1688 RVA: 0x000207F8 File Offset: 0x0001E9F8
			public override Color ImageMarginGradientMiddle
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x170001BB RID: 443
			// (get) Token: 0x06000699 RID: 1689 RVA: 0x00020810 File Offset: 0x0001EA10
			public override Color MenuBorder
			{
				get
				{
					return this.BorderColor;
				}
			}

			// Token: 0x170001BC RID: 444
			// (get) Token: 0x0600069A RID: 1690 RVA: 0x00020810 File Offset: 0x0001EA10
			public override Color MenuItemBorder
			{
				get
				{
					return this.BorderColor;
				}
			}

			// Token: 0x170001BD RID: 445
			// (get) Token: 0x0600069B RID: 1691 RVA: 0x000207F8 File Offset: 0x0001E9F8
			public override Color MenuItemSelected
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x170001BE RID: 446
			// (get) Token: 0x0600069C RID: 1692 RVA: 0x00020810 File Offset: 0x0001EA10
			public override Color SeparatorDark
			{
				get
				{
					return this.BorderColor;
				}
			}

			// Token: 0x170001BF RID: 447
			// (get) Token: 0x0600069D RID: 1693 RVA: 0x000207E0 File Offset: 0x0001E9E0
			public override Color ToolStripDropDownBackground
			{
				get
				{
					return this.BackColor;
				}
			}

			// Token: 0x0400030A RID: 778
			private Color BackColor;

			// Token: 0x0400030B RID: 779
			private Color CheckedColor;

			// Token: 0x0400030C RID: 780
			private Color BorderColor;
		}
	}
}
