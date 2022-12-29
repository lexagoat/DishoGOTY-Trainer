using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x02000035 RID: 53
	public class LogInLabel : Label
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000389 RID: 905 RVA: 0x000167DC File Offset: 0x000149DC
		// (set) Token: 0x0600038A RID: 906 RVA: 0x000038D2 File Offset: 0x00001AD2
		[Category("Colours")]
		public Color FontColour
		{
			get
			{
				return this._FontColour;
			}
			set
			{
				this._FontColour = value;
			}
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00002A04 File Offset: 0x00000C04
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x0600038C RID: 908 RVA: 0x000167F4 File Offset: 0x000149F4
		public LogInLabel()
		{
			this._FontColour = Color.FromArgb(255, 255, 255);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.Font = new Font("Segoe UI", 9f);
			this.ForeColor = this._FontColour;
			this.BackColor = Color.Transparent;
			this.Text = this.Text;
		}

		// Token: 0x040001D0 RID: 464
		private Color _FontColour;
	}
}
