using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200003A RID: 58
	public class LogInColourTable : ProfessionalColorTable
	{
		// Token: 0x060003CD RID: 973 RVA: 0x000039F6 File Offset: 0x00001BF6
		public LogInColourTable()
		{
			this._BackColour = Color.FromArgb(42, 42, 42);
			this._BorderColour = Color.FromArgb(35, 35, 35);
			this._SelectedColour = Color.FromArgb(47, 47, 47);
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060003CE RID: 974 RVA: 0x00017A40 File Offset: 0x00015C40
		// (set) Token: 0x060003CF RID: 975 RVA: 0x00003A31 File Offset: 0x00001C31
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

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x00017A58 File Offset: 0x00015C58
		// (set) Token: 0x060003D1 RID: 977 RVA: 0x00003A3A File Offset: 0x00001C3A
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

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x00017A70 File Offset: 0x00015C70
		// (set) Token: 0x060003D3 RID: 979 RVA: 0x00003A43 File Offset: 0x00001C43
		[Category("Colours")]
		public Color BackColour
		{
			get
			{
				return this._BackColour;
			}
			set
			{
				this._BackColour = value;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060003D4 RID: 980 RVA: 0x00017A70 File Offset: 0x00015C70
		public override Color ButtonSelectedBorder
		{
			get
			{
				return this._BackColour;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x00017A70 File Offset: 0x00015C70
		public override Color CheckBackground
		{
			get
			{
				return this._BackColour;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x00017A70 File Offset: 0x00015C70
		public override Color CheckPressedBackground
		{
			get
			{
				return this._BackColour;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x00017A70 File Offset: 0x00015C70
		public override Color CheckSelectedBackground
		{
			get
			{
				return this._BackColour;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x00017A70 File Offset: 0x00015C70
		public override Color ImageMarginGradientBegin
		{
			get
			{
				return this._BackColour;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x00017A70 File Offset: 0x00015C70
		public override Color ImageMarginGradientEnd
		{
			get
			{
				return this._BackColour;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060003DA RID: 986 RVA: 0x00017A70 File Offset: 0x00015C70
		public override Color ImageMarginGradientMiddle
		{
			get
			{
				return this._BackColour;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060003DB RID: 987 RVA: 0x00017A58 File Offset: 0x00015C58
		public override Color MenuBorder
		{
			get
			{
				return this._BorderColour;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060003DC RID: 988 RVA: 0x00017A70 File Offset: 0x00015C70
		public override Color MenuItemBorder
		{
			get
			{
				return this._BackColour;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060003DD RID: 989 RVA: 0x00017A40 File Offset: 0x00015C40
		public override Color MenuItemSelected
		{
			get
			{
				return this._SelectedColour;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060003DE RID: 990 RVA: 0x00017A58 File Offset: 0x00015C58
		public override Color SeparatorDark
		{
			get
			{
				return this._BorderColour;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060003DF RID: 991 RVA: 0x00017A70 File Offset: 0x00015C70
		public override Color ToolStripDropDownBackground
		{
			get
			{
				return this._BackColour;
			}
		}

		// Token: 0x040001EE RID: 494
		private Color _BackColour;

		// Token: 0x040001EF RID: 495
		private Color _BorderColour;

		// Token: 0x040001F0 RID: 496
		private Color _SelectedColour;
	}
}
