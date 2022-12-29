using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace trainer_template
{
	// Token: 0x02000049 RID: 73
	[StandardModule]
	internal sealed class ThemeShare
	{
		// Token: 0x060005F2 RID: 1522 RVA: 0x0001ECE4 File Offset: 0x0001CEE4
		private static void HandleCallbacks(IntPtr state, bool reserve)
		{
			ThemeShare.Invalidate = (ThemeShare.Frames >= 50);
			if (ThemeShare.Invalidate)
			{
				ThemeShare.Frames = 0;
			}
			object callbacks = ThemeShare.Callbacks;
			checked
			{
				lock (callbacks)
				{
					int num = ThemeShare.Callbacks.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						ThemeShare.Callbacks[i](ThemeShare.Invalidate);
					}
				}
				ThemeShare.Frames += 10;
			}
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		private static void InvalidateThemeTimer()
		{
			if (ThemeShare.Callbacks.Count == 0)
			{
				ThemeShare.ThemeTimer.Delete();
			}
			else
			{
				ThemeShare.ThemeTimer.Create(0U, 10U, new PrecisionTimer.TimerDelegate(ThemeShare.HandleCallbacks));
			}
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0001EDC0 File Offset: 0x0001CFC0
		public static void AddAnimationCallback(ThemeShare.AnimationDelegate callback)
		{
			object callbacks = ThemeShare.Callbacks;
			lock (callbacks)
			{
				if (!ThemeShare.Callbacks.Contains(callback))
				{
					ThemeShare.Callbacks.Add(callback);
					ThemeShare.InvalidateThemeTimer();
				}
			}
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x0001EE18 File Offset: 0x0001D018
		public static void RemoveAnimationCallback(ThemeShare.AnimationDelegate callback)
		{
			object callbacks = ThemeShare.Callbacks;
			lock (callbacks)
			{
				if (ThemeShare.Callbacks.Contains(callback))
				{
					ThemeShare.Callbacks.Remove(callback);
					ThemeShare.InvalidateThemeTimer();
				}
			}
		}

		// Token: 0x040002C0 RID: 704
		private static int Frames;

		// Token: 0x040002C1 RID: 705
		private static bool Invalidate;

		// Token: 0x040002C2 RID: 706
		public static PrecisionTimer ThemeTimer = new PrecisionTimer();

		// Token: 0x040002C3 RID: 707
		private const int FPS = 50;

		// Token: 0x040002C4 RID: 708
		private const int Rate = 10;

		// Token: 0x040002C5 RID: 709
		private static List<ThemeShare.AnimationDelegate> Callbacks = new List<ThemeShare.AnimationDelegate>();

		// Token: 0x02000069 RID: 105
		// (Invoke) Token: 0x060006C1 RID: 1729
		public delegate void AnimationDelegate(bool invalidate);
	}
}
