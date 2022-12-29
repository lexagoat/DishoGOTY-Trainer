using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template.My
{
	// Token: 0x02000004 RID: 4
	[HideModuleName]
	[StandardModule]
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	internal sealed class MyProject
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00004AF8 File Offset: 0x00002CF8
		[HelpKeyword("My.Computer")]
		internal static MyComputer Computer
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_ComputerObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00004B14 File Offset: 0x00002D14
		[HelpKeyword("My.Application")]
		internal static MyApplication Application
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_AppObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00004B30 File Offset: 0x00002D30
		[HelpKeyword("My.User")]
		internal static User User
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_UserObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00004B4C File Offset: 0x00002D4C
		[HelpKeyword("My.Forms")]
		internal static MyProject.MyForms Forms
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyFormsObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00004B68 File Offset: 0x00002D68
		[HelpKeyword("My.WebServices")]
		internal static MyProject.MyWebServices WebServices
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyWebServicesObjectProvider.GetInstance;
			}
		}

		// Token: 0x04000001 RID: 1
		private static readonly MyProject.ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new MyProject.ThreadSafeObjectProvider<MyComputer>();

		// Token: 0x04000002 RID: 2
		private static readonly MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();

		// Token: 0x04000003 RID: 3
		private static readonly MyProject.ThreadSafeObjectProvider<User> m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<User>();

		// Token: 0x04000004 RID: 4
		private static MyProject.ThreadSafeObjectProvider<MyProject.MyForms> m_MyFormsObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyForms>();

		// Token: 0x04000005 RID: 5
		private static readonly MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();

		// Token: 0x0200004F RID: 79
		[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal sealed class MyForms
		{
			// Token: 0x0600066B RID: 1643 RVA: 0x000205A8 File Offset: 0x0001E7A8
			[DebuggerHidden]
			private static T Create__Instance__<T>(T Instance) where T : Form, new()
			{
				if (Instance == null || Instance.IsDisposed)
				{
					if (MyProject.MyForms.m_FormBeingCreated != null)
					{
						if (MyProject.MyForms.m_FormBeingCreated.ContainsKey(typeof(T)))
						{
							throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
						}
					}
					else
					{
						MyProject.MyForms.m_FormBeingCreated = new Hashtable();
					}
					MyProject.MyForms.m_FormBeingCreated.Add(typeof(T), null);
					try
					{
						return Activator.CreateInstance<T>();
					}
					catch (TargetInvocationException ex) when (ex.InnerException != null)
					{
						string resourceString = Utils.GetResourceString("WinForms_SeeInnerException", new string[]
						{
							ex.InnerException.Message
						});
						throw new InvalidOperationException(resourceString, ex.InnerException);
					}
					finally
					{
						MyProject.MyForms.m_FormBeingCreated.Remove(typeof(T));
					}
				}
				return Instance;
			}

			// Token: 0x0600066C RID: 1644 RVA: 0x000049FF File Offset: 0x00002BFF
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance) where T : Form
			{
				instance.Dispose();
				instance = default(T);
			}

			// Token: 0x0600066D RID: 1645 RVA: 0x000049C5 File Offset: 0x00002BC5
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public MyForms()
			{
			}

			// Token: 0x0600066E RID: 1646 RVA: 0x000206B8 File Offset: 0x0001E8B8
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x0600066F RID: 1647 RVA: 0x000206D4 File Offset: 0x0001E8D4
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x06000670 RID: 1648 RVA: 0x000206EC File Offset: 0x0001E8EC
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyProject.MyForms);
			}

			// Token: 0x06000671 RID: 1649 RVA: 0x00020708 File Offset: 0x0001E908
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x170001AE RID: 430
			// (get) Token: 0x06000672 RID: 1650 RVA: 0x00004A14 File Offset: 0x00002C14
			// (set) Token: 0x06000674 RID: 1652 RVA: 0x00004A46 File Offset: 0x00002C46
			public Form1 Form1
			{
				[DebuggerHidden]
				get
				{
					this.m_Form1 = MyProject.MyForms.Create__Instance__<Form1>(this.m_Form1);
					return this.m_Form1;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_Form1)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<Form1>(ref this.m_Form1);
					}
				}
			}

			// Token: 0x170001AF RID: 431
			// (get) Token: 0x06000673 RID: 1651 RVA: 0x00004A2D File Offset: 0x00002C2D
			// (set) Token: 0x06000675 RID: 1653 RVA: 0x00004A70 File Offset: 0x00002C70
			public Form2 Form2
			{
				[DebuggerHidden]
				get
				{
					this.m_Form2 = MyProject.MyForms.Create__Instance__<Form2>(this.m_Form2);
					return this.m_Form2;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_Form2)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<Form2>(ref this.m_Form2);
					}
				}
			}

			// Token: 0x040002F6 RID: 758
			[ThreadStatic]
			private static Hashtable m_FormBeingCreated;

			// Token: 0x040002F7 RID: 759
			[EditorBrowsable(EditorBrowsableState.Never)]
			public Form1 m_Form1;

			// Token: 0x040002F8 RID: 760
			[EditorBrowsable(EditorBrowsableState.Never)]
			public Form2 m_Form2;
		}

		// Token: 0x02000050 RID: 80
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
		internal sealed class MyWebServices
		{
			// Token: 0x06000676 RID: 1654 RVA: 0x000206B8 File Offset: 0x0001E8B8
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x06000677 RID: 1655 RVA: 0x000206D4 File Offset: 0x0001E8D4
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x06000678 RID: 1656 RVA: 0x00020720 File Offset: 0x0001E920
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyProject.MyWebServices);
			}

			// Token: 0x06000679 RID: 1657 RVA: 0x00020708 File Offset: 0x0001E908
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x0600067A RID: 1658 RVA: 0x0002073C File Offset: 0x0001E93C
			[DebuggerHidden]
			private static T Create__Instance__<T>(T instance) where T : new()
			{
				T result;
				if (instance == null)
				{
					result = Activator.CreateInstance<T>();
				}
				else
				{
					result = instance;
				}
				return result;
			}

			// Token: 0x0600067B RID: 1659 RVA: 0x00004A9A File Offset: 0x00002C9A
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance)
			{
				instance = default(T);
			}

			// Token: 0x0600067C RID: 1660 RVA: 0x000049C5 File Offset: 0x00002BC5
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyWebServices()
			{
			}
		}

		// Token: 0x02000051 RID: 81
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		internal sealed class ThreadSafeObjectProvider<T> where T : new()
		{
			// Token: 0x170001B0 RID: 432
			// (get) Token: 0x0600067D RID: 1661 RVA: 0x00020760 File Offset: 0x0001E960
			internal T GetInstance
			{
				[DebuggerHidden]
				get
				{
					if (MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null)
					{
						MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = Activator.CreateInstance<T>();
					}
					return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;
				}
			}

			// Token: 0x0600067E RID: 1662 RVA: 0x000049C5 File Offset: 0x00002BC5
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public ThreadSafeObjectProvider()
			{
			}

			// Token: 0x040002F9 RID: 761
			[CompilerGenerated]
			[ThreadStatic]
			private static T m_ThreadStaticValue;
		}
	}
}
