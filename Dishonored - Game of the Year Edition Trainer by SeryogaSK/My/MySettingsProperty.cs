using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template.My
{
	// Token: 0x02000007 RID: 7
	[StandardModule]
	[HideModuleName]
	[CompilerGenerated]
	[DebuggerNonUserCode]
	internal sealed class MySettingsProperty
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00004C78 File Offset: 0x00002E78
		[HelpKeyword("My.Settings")]
		internal static MySettings Settings
		{
			get
			{
				return MySettings.Default;
			}
		}
	}
}
