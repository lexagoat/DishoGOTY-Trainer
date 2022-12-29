using System;
using System.Runtime.InteropServices;

namespace trainer_template
{
	// Token: 0x0200004C RID: 76
	internal class PrecisionTimer : IDisposable
	{
		// Token: 0x170001AD RID: 429
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x0001EF40 File Offset: 0x0001D140
		public bool Enabled
		{
			get
			{
				return this._Enabled;
			}
		}

		// Token: 0x060005FE RID: 1534
		[DllImport("kernel32.dll")]
		private static extern bool CreateTimerQueueTimer(ref IntPtr handle, IntPtr queue, PrecisionTimer.TimerDelegate callback, IntPtr state, uint dueTime, uint period, uint flags);

		// Token: 0x060005FF RID: 1535
		[DllImport("kernel32.dll")]
		private static extern bool DeleteTimerQueueTimer(IntPtr queue, IntPtr handle, IntPtr callback);

		// Token: 0x06000600 RID: 1536 RVA: 0x0001EF54 File Offset: 0x0001D154
		public void Create(uint dueTime, uint period, PrecisionTimer.TimerDelegate callback)
		{
			if (!this._Enabled)
			{
				this.TimerCallback = callback;
				bool enabled;
				if (!(enabled = PrecisionTimer.CreateTimerQueueTimer(ref this.Handle, IntPtr.Zero, this.TimerCallback, IntPtr.Zero, dueTime, period, 0U)))
				{
					this.ThrowNewException("CreateTimerQueueTimer");
				}
				this._Enabled = enabled;
			}
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0001EFA8 File Offset: 0x0001D1A8
		public void Delete()
		{
			if (this._Enabled)
			{
				bool flag;
				if (!(flag = PrecisionTimer.DeleteTimerQueueTimer(IntPtr.Zero, this.Handle, IntPtr.Zero)) && Marshal.GetLastWin32Error() != 997)
				{
					this.ThrowNewException("DeleteTimerQueueTimer");
				}
				this._Enabled = !flag;
			}
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x000049CD File Offset: 0x00002BCD
		private void ThrowNewException(string name)
		{
			throw new Exception(string.Format("{0} failed. Win32Error: {1}", name, Marshal.GetLastWin32Error()));
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x000049E9 File Offset: 0x00002BE9
		public void Dispose()
		{
			this.Delete();
		}

		// Token: 0x040002CD RID: 717
		private bool _Enabled;

		// Token: 0x040002CE RID: 718
		private IntPtr Handle;

		// Token: 0x040002CF RID: 719
		private PrecisionTimer.TimerDelegate TimerCallback;

		// Token: 0x0200006A RID: 106
		// (Invoke) Token: 0x060006C5 RID: 1733
		public delegate void TimerDelegate(IntPtr r1, bool r2);
	}
}
