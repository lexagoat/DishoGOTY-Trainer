using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace trainer_template
{
	// Token: 0x0200003D RID: 61
	public class LogInContextMenu : ContextMenuStrip
	{
		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x000186C4 File Offset: 0x000168C4
		// (set) Token: 0x06000413 RID: 1043 RVA: 0x00003BEF File Offset: 0x00001DEF
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

		// Token: 0x06000414 RID: 1044 RVA: 0x000186DC File Offset: 0x000168DC
		public LogInContextMenu()
		{
			this._FontColour = Color.FromArgb(255, 255, 255);
			base.Renderer = new ToolStripProfessionalRenderer(new LogInColourTable());
			base.ShowCheckMargin = false;
			base.ShowImageMargin = false;
			base.ForeColor = Color.FromArgb(255, 255, 255);
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00003BF8 File Offset: 0x00001DF8
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			base.OnPaint(e);
		}

		// Token: 0x04000200 RID: 512
		private Color _FontColour;
	}
}
