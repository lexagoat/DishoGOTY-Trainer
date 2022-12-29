using System;
using System.Drawing;

namespace trainer_template
{
	// Token: 0x0200004B RID: 75
	internal struct Bloom
	{
		// Token: 0x170001AA RID: 426
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x0001EE74 File Offset: 0x0001D074
		public string Name
		{
			get
			{
				return this._Name;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x0001EE8C File Offset: 0x0001D08C
		// (set) Token: 0x060005F8 RID: 1528 RVA: 0x000049A5 File Offset: 0x00002BA5
		public Color Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				this._Value = value;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x0001EEA4 File Offset: 0x0001D0A4
		// (set) Token: 0x060005FA RID: 1530 RVA: 0x0001EF08 File Offset: 0x0001D108
		public string ValueHex
		{
			get
			{
				return "#" + this._Value.R.ToString("X2", null) + this._Value.G.ToString("X2", null) + this._Value.B.ToString("X2", null);
			}
			set
			{
				try
				{
					this._Value = ColorTranslator.FromHtml(value);
				}
				catch (Exception ex)
				{
				}
			}
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x000049AE File Offset: 0x00002BAE
		public Bloom(string name, Color value)
		{
			this = default(Bloom);
			this._Name = name;
			this._Value = value;
		}

		// Token: 0x040002CB RID: 715
		public string _Name;

		// Token: 0x040002CC RID: 716
		private Color _Value;
	}
}
