using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace trainer_template.My
{
	// Token: 0x02000002 RID: 2
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal class MyApplication : WindowsFormsApplicationBase
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00004AC0 File Offset: 0x00002CC0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DebuggerHidden]
		[STAThread]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		internal static void Main(string[] args)
		{
			try
			{
				Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
			}
			finally
			{
			}
			MyProject.Application.Run(args);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020BC File Offset: 0x000002BC
		[DebuggerStepThrough]
		public MyApplication() : base(AuthenticationMode.Windows)
		{
			base.IsSingleInstance = false;
			base.EnableVisualStyles = true;
			base.SaveMySettingsOnExit = true;
			base.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020E1 File Offset: 0x000002E1
		[DebuggerStepThrough]
		protected override void OnCreateMainForm()
		{
			base.MainForm = MyProject.Forms.Form1;
		}
	}
}
