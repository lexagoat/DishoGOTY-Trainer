using System;
using System.Drawing;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200001D RID: 29
	internal class FlatLabel : Label
	{
		// Token: 0x06000143 RID: 323 RVA: 0x00002A04 File Offset: 0x00000C04
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000A740 File Offset: 0x00008940
		public FlatLabel()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.Font = new Font("Segoe UI", 8f);
			this.ForeColor = Color.White;
			this.BackColor = Color.Transparent;
			this.Text = this.Text;
		}
	}
}
