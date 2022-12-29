using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using trainer_template.My;

namespace trainer_template
{
	// Token: 0x0200004D RID: 77
	[StandardModule]
	internal sealed class TrainerModul2_3
	{
		// Token: 0x06000605 RID: 1541 RVA: 0x0001F004 File Offset: 0x0001D204
		public static void Add<T>(this T[] arr, T item)
		{
			checked
			{
				if (arr != null)
				{
					Array.Resize<T>(ref arr, arr.Length + 1);
					arr[arr.Length - 1] = item;
				}
				else
				{
					arr = new T[1];
					arr[0] = item;
				}
			}
		}

		// Token: 0x06000606 RID: 1542
		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int OpenProcess(int dwDesiredAccess, int bInerhitHandle, int dwProcessId);

		// Token: 0x06000607 RID: 1543
		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int CloseHandle(int hObject);

		// Token: 0x06000608 RID: 1544
		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern sbyte WriteProcessMemory(int hProcess, int lpBaseAddress, ref sbyte lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000609 RID: 1545
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "WriteProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern byte WriteProcessMemory_1(int hProcess, int lpBaseAddress, ref byte lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x0600060A RID: 1546
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "WriteProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern short WriteProcessMemory_2(int hProcess, int lpBaseAddress, ref short lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x0600060B RID: 1547
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "WriteProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern ushort WriteProcessMemory_3(int hProcess, int lpBaseAddress, ref ushort lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x0600060C RID: 1548
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "WriteProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern int WriteProcessMemory_4(int hProcess, int lpBaseAddress, ref int lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x0600060D RID: 1549
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "WriteProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern uint WriteProcessMemory_5(int hProcess, int lpBaseAddress, ref uint lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x0600060E RID: 1550
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "WriteProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern long WriteProcessMemory_6(int hProcess, int lpBaseAddress, ref long lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x0600060F RID: 1551
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "WriteProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern ulong WriteProcessMemory_7(int hProcess, int lpBaseAddress, ref ulong lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000610 RID: 1552
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "ReadProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern sbyte ReadProcessMemory_1(int hProcess, int lpBaseAddress, ref sbyte lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000611 RID: 1553
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "ReadProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern byte ReadProcessMemory_2(int hProcess, int lpBaseAddress, ref byte lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000612 RID: 1554
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "ReadProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern short ReadProcessMemory_3(int hProcess, int lpBaseAddress, ref short lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000613 RID: 1555
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "ReadProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern ushort ReadProcessMemory_4(int hProcess, int lpBaseAddress, ref ushort lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000614 RID: 1556
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "ReadProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern int ReadProcessMemory_5(int hProcess, int lpBaseAddress, ref int lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000615 RID: 1557
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "ReadProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern uint ReadProcessMemory_6(int hProcess, int lpBaseAddress, ref uint lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000616 RID: 1558
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "ReadProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern ulong ReadProcessMemory_7(int hProcess, int lpBaseAddress, ref ulong lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000617 RID: 1559
		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, int newProtect, ref int oldProtect);

		// Token: 0x06000618 RID: 1560
		[DllImport("KERNEL32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool IsDebuggerPresent();

		// Token: 0x06000619 RID: 1561
		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int iSize, ref int lpNumberOfBytesRead);

		// Token: 0x0600061A RID: 1562
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "WriteProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern byte WriteProcessMemory_8(int hProcess, long lpBaseAddress, ref byte lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x0600061B RID: 1563
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "WriteProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern int WriteProcessMemory_9(int hProcess, long lpBaseAddress, ref int lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x0600061C RID: 1564
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "WriteProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern long WriteProcessMemory_10(int hProcess, long lpBaseAddress, ref long lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x0600061D RID: 1565
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "WriteProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern long WriteProcessMemory_11(int hProcess, long lpBaseAddress, ref List<byte> lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x0600061E RID: 1566
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "ReadProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern byte ReadProcessMemory_8(int hProcess, long lpBaseAddress, ref byte lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x0600061F RID: 1567
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "ReadProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern int ReadProcessMemory_9(int hProcess, long lpBaseAddress, ref long lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000620 RID: 1568
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "ReadProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern long ReadProcessMemory_10(int hProcess, int lpBaseAddress, ref long lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000621 RID: 1569
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "ReadProcessMemory", ExactSpelling = true, SetLastError = true)]
		private static extern byte ReadProcessMemory_11(int hProcess, int lpBaseAddress, ref List<byte> lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000622 RID: 1570
		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr VirtualAllocEx(IntPtr hProcess, long lpAddress, IntPtr dwSize, int flAllocationType, int flProtect);

		// Token: 0x06000623 RID: 1571
		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr VirtualFreeEx(IntPtr hProcess, long lpAddress, IntPtr dwSize, IntPtr dwFreeType);

		// Token: 0x06000624 RID: 1572
		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern IntPtr VirtualQueryEx(int hProcess, IntPtr lpAddress, ref TrainerModul2_3.MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

		// Token: 0x06000625 RID: 1573
		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern void GetSystemInfo(ref TrainerModul2_3.SYSTEM_INFO lpSystemInfo);

		// Token: 0x06000626 RID: 1574
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int GetAsyncKeyState(long vkey);

		// Token: 0x06000627 RID: 1575 RVA: 0x0001F048 File Offset: 0x0001D248
		public static void Write_1Byte_32Bit(int address, int value)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 1;
				int num2 = 0;
				TrainerModul2_3.WriteProcessMemory_4(hProcess, address, ref value, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0001F084 File Offset: 0x0001D284
		public static void Write_1Byte_64Bit(int address, uint value)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 1;
				int num2 = 0;
				TrainerModul2_3.WriteProcessMemory_5(hProcess, address, ref value, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0001F0C0 File Offset: 0x0001D2C0
		public static void Write_2Bytes_32Bit(int address, int value)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 2;
				int num2 = 0;
				TrainerModul2_3.WriteProcessMemory_4(hProcess, address, ref value, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x0001F0FC File Offset: 0x0001D2FC
		public static void Write_2Bytes_64Bit(int address, uint value)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 2;
				int num2 = 0;
				TrainerModul2_3.WriteProcessMemory_5(hProcess, address, ref value, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x0001F138 File Offset: 0x0001D338
		public static void Write_3Bytes_32Bit(int address, int value)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 3;
				int num2 = 0;
				TrainerModul2_3.WriteProcessMemory_4(hProcess, address, ref value, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0001F174 File Offset: 0x0001D374
		public static void Write_3Bytes_64Bit(int address, uint value)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 3;
				int num2 = 0;
				TrainerModul2_3.WriteProcessMemory_5(hProcess, address, ref value, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0001F1B0 File Offset: 0x0001D3B0
		public static void Write_4Bytes_32Bit(int address, int value)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 4;
				int num2 = 0;
				TrainerModul2_3.WriteProcessMemory_4(hProcess, address, ref value, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0001F1EC File Offset: 0x0001D3EC
		public static void Write_4Bytes_64Bit(int address, uint value)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 4;
				int num2 = 0;
				TrainerModul2_3.WriteProcessMemory_5(hProcess, address, ref value, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0001F228 File Offset: 0x0001D428
		public static void Write_8Bytes_32Bit(int address, long value)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 8;
				int num2 = 0;
				TrainerModul2_3.WriteProcessMemory_6(hProcess, address, ref value, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0001F264 File Offset: 0x0001D464
		public static void Write_8Bytes_64Bit(int address, ulong value)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 8;
				int num2 = 0;
				TrainerModul2_3.WriteProcessMemory_7(hProcess, address, ref value, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0001F2A0 File Offset: 0x0001D4A0
		public static void Write_String(int address, string value)
		{
			byte[] array = new byte[1];
			int num = 0;
			array = Encoding.ASCII.GetBytes(value);
			checked
			{
				foreach (byte value2 in array)
				{
					TrainerModul2_3.Write_1Byte_64Bit(address + num, (uint)value2);
					num++;
				}
				int num2 = num;
				for (int j = num2; j <= 64; j++)
				{
					TrainerModul2_3.Write_1Byte_64Bit(address + j, 0U);
				}
			}
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0001F308 File Offset: 0x0001D508
		public static void autopatcher(int address, byte[] value)
		{
			byte b;
			byte b2;
			checked
			{
				b = (byte)Information.LBound(value, 1);
				b2 = (byte)Information.UBound(value, 1);
			}
			for (byte b3 = b; b3 <= b2; b3 += 1)
			{
				TrainerModul2_3.Write_1Byte_64Bit(checked(address + (int)b3), (uint)value[(int)b3]);
			}
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0001F340 File Offset: 0x0001D540
		public static sbyte Read_1Byte_32Bit(int address)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			sbyte result;
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 1;
				int num2 = 0;
				TrainerModul2_3.ReadProcessMemory_1(hProcess, address, ref result, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
			return result;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0001F380 File Offset: 0x0001D580
		public static byte Read_1Byte_64Bit(int address)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			byte result;
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 1;
				int num2 = 0;
				TrainerModul2_3.ReadProcessMemory_2(hProcess, address, ref result, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
			return result;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0001F3C0 File Offset: 0x0001D5C0
		public static short Read_2Bytes_32Bit(int address)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			short result;
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 2;
				int num2 = 0;
				TrainerModul2_3.ReadProcessMemory_3(hProcess, address, ref result, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
			return result;
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0001F400 File Offset: 0x0001D600
		public static ushort Read_2Bytes_64Bit(int address)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			ushort result;
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 2;
				int num2 = 0;
				TrainerModul2_3.ReadProcessMemory_4(hProcess, address, ref result, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
			return result;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0001F440 File Offset: 0x0001D640
		public static uint Read_3Bytes_32Bit(int address)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			int num3;
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 3;
				int num2 = 0;
				TrainerModul2_3.ReadProcessMemory_5(hProcess, address, ref num3, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
			return checked((uint)num3);
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0001F480 File Offset: 0x0001D680
		public static uint Read_3Bytes_64Bit(int address)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			uint result;
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 3;
				int num2 = 0;
				TrainerModul2_3.ReadProcessMemory_6(hProcess, address, ref result, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
			return result;
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0001F4C0 File Offset: 0x0001D6C0
		public static uint Read_4Bytes_32Bit(int address)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			int num3;
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 4;
				int num2 = 0;
				TrainerModul2_3.ReadProcessMemory_5(hProcess, address, ref num3, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
			return checked((uint)num3);
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0001F500 File Offset: 0x0001D700
		public static uint Read_4Bytes_64Bit(int address)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			uint result;
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 4;
				int num2 = 0;
				TrainerModul2_3.ReadProcessMemory_6(hProcess, address, ref result, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
			return result;
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x0001F540 File Offset: 0x0001D740
		public static long Read_8Bytes_32Bit(int address)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			long result;
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 8;
				int num2 = 0;
				TrainerModul2_3.ReadProcessMemory_10(hProcess, address, ref result, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
			return result;
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x0001F580 File Offset: 0x0001D780
		public static ulong Read_8Bytes_64Bit(int address)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			ulong result;
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 8;
				int num2 = 0;
				TrainerModul2_3.ReadProcessMemory_7(hProcess, address, ref result, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
			return result;
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x0001F5C0 File Offset: 0x0001D7C0
		public static object Read_String(int length, int address)
		{
			string text = "";
			checked
			{
				int num = length - 1;
				for (int i = 0; i <= num; i++)
				{
					int value = (int)TrainerModul2_3.Read_1Byte_32Bit(address + i);
					text += Conversions.ToString(Convert.ToChar(value));
				}
				return text;
			}
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x0001F608 File Offset: 0x0001D808
		public static long AllocMem(string ProcessName, string ModuleName)
		{
			TrainerModul2_3.process_handle = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			Process[] processesByName = Process.GetProcessesByName(ProcessName);
			long result;
			if (0 < processesByName.Length)
			{
				long num = (long)TrainerModul2_3.VirtualAllocEx((IntPtr)TrainerModul2_3.process_handle, Conversions.ToLong(TrainerModul2_3.FindFreeBlockForAllocMem(Conversions.ToLong(TrainerModul2_3.GetModuleBase(ProcessName, ModuleName)))), new IntPtr(2048), 12288, 64);
				if ((IntPtr)num == IntPtr.Zero)
				{
					TrainerModul2_3.RemoveProtectionx64(ProcessName, Conversions.ToLong(Operators.AddObject(TrainerModul2_3.GetModuleBase(ProcessName, ModuleName), 1536)), 3071L);
					result = Conversions.ToLong(Operators.AddObject(TrainerModul2_3.GetModuleBase(ProcessName, ModuleName), 1536));
				}
				else
				{
					result = num;
				}
			}
			return result;
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x0001F6D8 File Offset: 0x0001D8D8
		private static object FindFreeBlockForAllocMem(long @base)
		{
			checked
			{
				long num = @base - 1610612735L;
				long num2 = @base + 1610612735L;
				TrainerModul2_3.SYSTEM_INFO system_INFO;
				TrainerModul2_3.GetSystemInfo(ref system_INFO);
				(IntPtr)system_INFO.lpMinimumApplicationAddress;
				int num3 = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
				TrainerModul2_3.MEMORY_BASIC_INFORMATION memory_BASIC_INFORMATION;
				long num4 = unchecked((long)Marshal.SizeOf<TrainerModul2_3.MEMORY_BASIC_INFORMATION>(memory_BASIC_INFORMATION));
				for (;;)
				{
					TrainerModul2_3.VirtualQueryEx(num3, (IntPtr)num, ref memory_BASIC_INFORMATION, (uint)num4);
					if (unchecked((ulong)memory_BASIC_INFORMATION.State) == 65536UL & memory_BASIC_INFORMATION.RegionSize >= 2048L)
					{
						break;
					}
					num = memory_BASIC_INFORMATION.BaseAddress + memory_BASIC_INFORMATION.RegionSize;
					if (num >= num2)
					{
						goto IL_B9;
					}
				}
				return memory_BASIC_INFORMATION.BaseAddress + memory_BASIC_INFORMATION.RegionSize - 2048L;
				IL_B9:
				TrainerModul2_3.CloseHandle(num3);
				object result;
				return result;
			}
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x0001F7A8 File Offset: 0x0001D9A8
		public static void DeAlloc(string ProcessName, long AddressOfStart)
		{
			TrainerModul2_3.process_handle = TrainerModul2_3.OpenProcess(2035711, 0, checked((int)MyProject.Forms.Form1.procid));
			TrainerModul2_3.VirtualFreeEx((IntPtr)TrainerModul2_3.process_handle, AddressOfStart, (IntPtr)0, (IntPtr)32768);
			TrainerModul2_3.CloseHandle(TrainerModul2_3.process_handle);
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x0001F804 File Offset: 0x0001DA04
		public static void RemoveProtectionx64(string ProcessName, long AddressOfStart, long SizeToRemoveProtectionInBytes)
		{
			foreach (Process process in Process.GetProcessesByName(ProcessName))
			{
				int num;
				if (!TrainerModul2_3.VirtualProtectEx(process.Handle, new IntPtr(AddressOfStart), new IntPtr(SizeToRemoveProtectionInBytes), 64, ref num))
				{
					throw new Exception();
				}
				process.Dispose();
			}
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0001F85C File Offset: 0x0001DA5C
		public static void RemoveProtection(string ProcessName, int AddressOfStart, int SizeToRemoveProtectionInBytes)
		{
			foreach (Process process in Process.GetProcessesByName(ProcessName))
			{
				int num;
				if (!TrainerModul2_3.VirtualProtectEx(process.Handle, new IntPtr(AddressOfStart), new IntPtr(SizeToRemoveProtectionInBytes), 64, ref num))
				{
					throw new Exception();
				}
				process.Dispose();
			}
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0001F8B4 File Offset: 0x0001DAB4
		public static void JmpToCave(long DestinationAddi, long sourceaddi, int NumberOfNops = 0)
		{
			checked
			{
				long value = DestinationAddi - sourceaddi - 5L;
				byte[] bytes = BitConverter.GetBytes(value);
				byte[] bytes_to_inject = new byte[]
				{
					233,
					bytes[0],
					bytes[1],
					bytes[2],
					bytes[3]
				};
				int num = NumberOfNops - 1;
				for (int i = 0; i <= num; i++)
				{
					ref bytes_to_inject.Add(144);
				}
				TrainerModul2_3.Write_CodeInjection(sourceaddi, bytes_to_inject);
			}
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0001F924 File Offset: 0x0001DB24
		public static object GetJmpBytes(long DestinationAddi, long SourceAddi)
		{
			long num = checked(DestinationAddi - SourceAddi - 5L);
			return num;
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0001F948 File Offset: 0x0001DB48
		public static object GetModuleInformation(string ProcName, ref string ModuleName, ref long ModuleBase, ref long ModuleSize)
		{
			try
			{
				foreach (object obj in Process.GetProcessesByName(ProcName)[0].Modules)
				{
					ProcessModule processModule = (ProcessModule)obj;
					if (Operators.CompareString(ModuleName.ToLower(), processModule.ModuleName.ToLower(), false) == 0)
					{
						long num = (long)processModule.BaseAddress;
						ModuleBase = num;
						ModuleName = processModule.ModuleName;
						ModuleSize = checked(num + unchecked((long)processModule.ModuleMemorySize));
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			object result;
			return result;
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0001F9E8 File Offset: 0x0001DBE8
		public static object GetModuleSize(string ProcName, string ModuleName)
		{
			long num;
			try
			{
				foreach (object obj in Process.GetProcessesByName(ProcName)[0].Modules)
				{
					ProcessModule processModule = (ProcessModule)obj;
					if (Operators.CompareString(ModuleName.ToLower(), processModule.ModuleName.ToLower(), false) == 0)
					{
						(long)processModule.BaseAddress;
						num = (long)processModule.ModuleMemorySize;
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			return num;
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x0001FA84 File Offset: 0x0001DC84
		public static object Long2Float(int Value)
		{
			byte[] bytes = BitConverter.GetBytes(Value);
			float num = BitConverter.ToSingle(bytes, 0);
			return num;
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x0001FAA8 File Offset: 0x0001DCA8
		public static object Float2Long(float Value)
		{
			byte[] bytes = BitConverter.GetBytes(Value);
			int num = BitConverter.ToInt32(bytes, 0);
			return num;
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0001FACC File Offset: 0x0001DCCC
		public static object Read_Pointer_float_32Bit(int address, int[] Offset = null)
		{
			checked
			{
				address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
				if (!Information.IsNothing(Offset))
				{
					int num = Offset.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address + Offset[i]);
					}
				}
				return TrainerModul2_3.Long2Float(address);
			}
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0001FB14 File Offset: 0x0001DD14
		public static void Write_Pointer_float_32Bit(int WhatToWrite, int address, int[] Offset = null)
		{
			checked
			{
				if (!Information.IsNothing(Offset))
				{
					address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
					int num = Offset.Length - 2;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address + Offset[i]);
					}
					TrainerModul2_3.Write_4Bytes_32Bit(address + Offset[Offset.Length - 1], WhatToWrite);
				}
				else
				{
					TrainerModul2_3.Write_4Bytes_32Bit(address, WhatToWrite);
				}
			}
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x0001FB6C File Offset: 0x0001DD6C
		public static void Write_CodeInjection(long address, byte[] bytes_to_inject)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			if (num != 0)
			{
				int hProcess = num;
				int num2 = 0;
				int nSize = bytes_to_inject.Length;
				int num3 = 0;
				TrainerModul2_3.WriteProcessMemory_8(hProcess, address, ref bytes_to_inject[num2], nSize, ref num3);
			}
			TrainerModul2_3.CloseHandle(num);
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x0001FBB0 File Offset: 0x0001DDB0
		public static void Write_4_Bytes(long address, long value)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 4;
				int num2 = 0;
				TrainerModul2_3.WriteProcessMemory_10(hProcess, address, ref value, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0001FBEC File Offset: 0x0001DDEC
		public static void autopatcher(long address, byte[] value)
		{
			checked
			{
				int num = value.Count<byte>() - 1;
				for (int i = 0; i <= num; i++)
				{
					TrainerModul2_3.Write_Byte(address + unchecked((long)i), value[i]);
				}
			}
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x0001FC1C File Offset: 0x0001DE1C
		public static void Write_Byte(long address, byte value)
		{
			int num = TrainerModul2_3.OpenProcess(2035711, 0, TrainerModul2_3.process_id);
			if (num != 0)
			{
				int hProcess = num;
				int nSize = 1;
				int num2 = 0;
				TrainerModul2_3.WriteProcessMemory_8(hProcess, address, ref value, nSize, ref num2);
			}
			TrainerModul2_3.CloseHandle(num);
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0001FC58 File Offset: 0x0001DE58
		public static object GetProcessId(string ProcName)
		{
			Process[] processes = Process.GetProcesses();
			int num = Information.LBound(processes, 1);
			int num2 = Information.UBound(processes, 1);
			checked
			{
				object result;
				for (int i = num; i <= num2; i++)
				{
					string processName = processes[i].ProcessName;
					if (Operators.CompareString(processName.ToLower(), ProcName.ToLower(), false) == 0)
					{
						TrainerModul2_3.process_id = processes[i].Id;
						result = TrainerModul2_3.process_id;
						return result;
					}
				}
				return result;
			}
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0001FCC8 File Offset: 0x0001DEC8
		public static object GetModuleBase(string ProcName, string GameModuleName)
		{
			long num;
			try
			{
				foreach (object obj in Process.GetProcessesByName(ProcName)[0].Modules)
				{
					ProcessModule processModule = (ProcessModule)obj;
					if (Operators.CompareString(GameModuleName.ToLower(), processModule.ModuleName.ToLower(), false) == 0)
					{
						num = (long)processModule.BaseAddress;
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			return num;
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0001FD58 File Offset: 0x0001DF58
		public static TrainerModul2_3.Teleporter Read_Koord_32Bit(int address, int Offset, bool SMA)
		{
			TrainerModul2_3.Teleporter teleporter = new TrainerModul2_3.Teleporter();
			int num;
			if (!(-(SMA > false)))
			{
				num = checked((int)TrainerModul2_3.Read_4Bytes_32Bit(address));
			}
			else if (-(SMA > false))
			{
				num = address;
			}
			checked
			{
				teleporter.XKoord = (int)TrainerModul2_3.Read_4Bytes_32Bit(num + Offset);
				teleporter.YKoord = (int)TrainerModul2_3.Read_4Bytes_32Bit(num + Offset + 4);
				teleporter.ZKoord = (int)TrainerModul2_3.Read_4Bytes_32Bit(num + Offset + 8);
				return teleporter;
			}
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0001FDC0 File Offset: 0x0001DFC0
		public static TrainerModul2_3.Teleporter Read_Koord_64Bit(int address, int Offset, bool SMA)
		{
			TrainerModul2_3.Teleporter teleporter = new TrainerModul2_3.Teleporter();
			int num;
			if (!(-(SMA > false)))
			{
				num = checked((int)TrainerModul2_3.Read_4Bytes_32Bit(address));
			}
			else if (-(SMA > false))
			{
				num = address;
			}
			checked
			{
				teleporter.XKoord = (int)TrainerModul2_3.Read_4Bytes_64Bit(num + Offset);
				teleporter.YKoord = (int)TrainerModul2_3.Read_4Bytes_64Bit(num + Offset + 4);
				teleporter.ZKoord = (int)TrainerModul2_3.Read_4Bytes_64Bit(num + Offset + 8);
				return teleporter;
			}
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0001FE28 File Offset: 0x0001E028
		public static void Write_Koord_32Bit(int address, int Offset, bool SMA, TrainerModul2_3.Teleporter Position)
		{
			int num;
			if (!(-(SMA > false)))
			{
				num = checked((int)TrainerModul2_3.Read_4Bytes_32Bit(address));
			}
			else if (-(SMA > false))
			{
				num = address;
			}
			checked
			{
				TrainerModul2_3.Write_4Bytes_32Bit(num + Offset, Position.XKoord);
				TrainerModul2_3.Write_4Bytes_32Bit(num + Offset + 4, Position.YKoord);
				TrainerModul2_3.Write_4Bytes_32Bit(num + Offset + 8, Position.ZKoord);
			}
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0001FE84 File Offset: 0x0001E084
		public static void Write_Koord_64Bit(int address, int Offset, bool SMA, TrainerModul2_3.Teleporter Position)
		{
			int num;
			if (!(-(SMA > false)))
			{
				num = checked((int)TrainerModul2_3.Read_4Bytes_32Bit(address));
			}
			else if (-(SMA > false))
			{
				num = address;
			}
			checked
			{
				TrainerModul2_3.Write_4Bytes_64Bit(num + Offset, (uint)Position.XKoord);
				TrainerModul2_3.Write_4Bytes_64Bit(num + Offset + 4, (uint)Position.YKoord);
				TrainerModul2_3.Write_4Bytes_64Bit(num + Offset + 8, (uint)Position.ZKoord);
			}
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0001FEE4 File Offset: 0x0001E0E4
		public static void Write_Pointer_1Byte_32Bit(sbyte WhatToWrite, int address, int[] Offset = null)
		{
			checked
			{
				if (!Information.IsNothing(Offset))
				{
					address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
					int num = Offset.Length - 2;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address + Offset[i]);
					}
					TrainerModul2_3.Write_4Bytes_32Bit(address + Offset[Offset.Length - 1], (int)WhatToWrite);
				}
				else
				{
					TrainerModul2_3.Write_1Byte_32Bit(address, (int)WhatToWrite);
				}
			}
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0001FF3C File Offset: 0x0001E13C
		public static void Write_Pointer_1Byte_64Bit(byte WhatToWrite, int address, int[] Offset = null)
		{
			checked
			{
				if (!Information.IsNothing(Offset))
				{
					address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
					int num = Offset.Length - 2;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address + Offset[i]);
					}
					TrainerModul2_3.Write_4Bytes_32Bit(address + Offset[Offset.Length - 1], (int)WhatToWrite);
				}
				else
				{
					TrainerModul2_3.Write_1Byte_64Bit(address, (uint)WhatToWrite);
				}
			}
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x0001FF94 File Offset: 0x0001E194
		public static void Write_Pointer_2Bytes_32Bit(short WhatToWrite, int address, int[] Offset = null)
		{
			checked
			{
				if (!Information.IsNothing(Offset))
				{
					address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
					int num = Offset.Length - 2;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address + Offset[i]);
					}
					TrainerModul2_3.Write_4Bytes_32Bit(address + Offset[Offset.Length - 1], (int)WhatToWrite);
				}
				else
				{
					TrainerModul2_3.Write_2Bytes_32Bit(address, (int)WhatToWrite);
				}
			}
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0001FFEC File Offset: 0x0001E1EC
		public static void Write_Pointer_2Bytes_64Bit(ushort WhatToWrite, int address, int[] Offset = null)
		{
			checked
			{
				if (!Information.IsNothing(Offset))
				{
					address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
					int num = Offset.Length - 2;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address + Offset[i]);
					}
					TrainerModul2_3.Write_4Bytes_32Bit(address + Offset[Offset.Length - 1], (int)WhatToWrite);
				}
				else
				{
					TrainerModul2_3.Write_2Bytes_64Bit(address, (uint)WhatToWrite);
				}
			}
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x00020044 File Offset: 0x0001E244
		public static void Write_Pointer_3Bytes_32Bit(int WhatToWrite, int address, int[] Offset = null)
		{
			checked
			{
				if (!Information.IsNothing(Offset))
				{
					address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
					int num = Offset.Length - 2;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_2Bytes_32Bit(address + Offset[i]);
					}
					TrainerModul2_3.Write_4Bytes_32Bit(address + Offset[Offset.Length - 1], WhatToWrite);
				}
				else
				{
					TrainerModul2_3.Write_3Bytes_32Bit(address, WhatToWrite);
				}
			}
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0002009C File Offset: 0x0001E29C
		public static void Write_Pointer_3Bytes_64Bit(uint WhatToWrite, int address, int[] Offset = null)
		{
			checked
			{
				if (!Information.IsNothing(Offset))
				{
					address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
					int num = Offset.Length - 2;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address + Offset[i]);
					}
					TrainerModul2_3.Write_4Bytes_32Bit(address + Offset[Offset.Length - 1], (int)WhatToWrite);
				}
				else
				{
					TrainerModul2_3.Write_3Bytes_64Bit(address, WhatToWrite);
				}
			}
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0001FB14 File Offset: 0x0001DD14
		public static void Write_Pointer_4Bytes_32Bit(int WhatToWrite, int address, int[] Offset = null)
		{
			checked
			{
				if (!Information.IsNothing(Offset))
				{
					address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
					int num = Offset.Length - 2;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address + Offset[i]);
					}
					TrainerModul2_3.Write_4Bytes_32Bit(address + Offset[Offset.Length - 1], WhatToWrite);
				}
				else
				{
					TrainerModul2_3.Write_4Bytes_32Bit(address, WhatToWrite);
				}
			}
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x000200F8 File Offset: 0x0001E2F8
		public static void Write_Pointer_4Bytes_64Bit(uint WhatToWrite, int address, int[] Offset = null)
		{
			checked
			{
				if (!Information.IsNothing(Offset))
				{
					address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
					int num = Offset.Length - 2;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address + Offset[i]);
					}
					TrainerModul2_3.Write_4Bytes_32Bit(address + Offset[Offset.Length - 1], (int)WhatToWrite);
				}
				else
				{
					TrainerModul2_3.Write_4Bytes_64Bit(address, WhatToWrite);
				}
			}
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x00020154 File Offset: 0x0001E354
		public static void Write_Pointer_8Bytes_32Bit(long WhatToWrite, int address, int[] Offset = null)
		{
			checked
			{
				if (!Information.IsNothing(Offset))
				{
					address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
					int num = Offset.Length - 2;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_8Bytes_32Bit(address + Offset[i]);
					}
					TrainerModul2_3.Write_4Bytes_32Bit(address + Offset[Offset.Length - 1], (int)WhatToWrite);
				}
				else
				{
					TrainerModul2_3.Write_8Bytes_32Bit(address, WhatToWrite);
				}
			}
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x000201B0 File Offset: 0x0001E3B0
		public static void Write_Pointer_8Bytes_64Bit(ulong WhatToWrite, int address, int[] Offset = null)
		{
			checked
			{
				if (!Information.IsNothing(Offset))
				{
					address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
					int num = Offset.Length - 2;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_8Bytes_32Bit(address + Offset[i]);
					}
					TrainerModul2_3.Write_4Bytes_32Bit(address + Offset[Offset.Length - 1], (int)WhatToWrite);
				}
				else
				{
					TrainerModul2_3.Write_8Bytes_64Bit(address, WhatToWrite);
				}
			}
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0002020C File Offset: 0x0001E40C
		public static object Read_Pointer_1Byte_32Bit(int address, int[] Offset = null)
		{
			checked
			{
				address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
				if (!Information.IsNothing(Offset))
				{
					int num = Offset.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_1Byte_32Bit(address + Offset[i]);
					}
				}
				return address;
			}
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x00020254 File Offset: 0x0001E454
		public static object Read_Pointer_1Byte_64Bit(int address, int[] Offset = null)
		{
			checked
			{
				address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
				if (!Information.IsNothing(Offset))
				{
					int num = Offset.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_1Byte_64Bit(address + Offset[i]);
					}
				}
				return address;
			}
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0002029C File Offset: 0x0001E49C
		public static object Read_Pointer_2Bytes_32Bit(int address, int[] Offset = null)
		{
			checked
			{
				address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
				if (!Information.IsNothing(Offset))
				{
					int num = Offset.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_2Bytes_32Bit(address + Offset[i]);
					}
				}
				return address;
			}
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x000202E4 File Offset: 0x0001E4E4
		public static object Read_Pointer_2Bytes_64Bit(int address, int[] Offset = null)
		{
			checked
			{
				address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
				if (!Information.IsNothing(Offset))
				{
					int num = Offset.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_2Bytes_64Bit(address + Offset[i]);
					}
				}
				return address;
			}
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0002032C File Offset: 0x0001E52C
		public static object Read_Pointer_3Bytes_32Bit(int address, int[] Offset = null)
		{
			checked
			{
				address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
				if (!Information.IsNothing(Offset))
				{
					int num = Offset.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_3Bytes_32Bit(address + Offset[i]);
					}
				}
				return address;
			}
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x00020374 File Offset: 0x0001E574
		public static object Read_Pointer_3Bytes_64Bit(int address, int[] Offset = null)
		{
			checked
			{
				address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
				if (!Information.IsNothing(Offset))
				{
					int num = Offset.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_3Bytes_64Bit(address + Offset[i]);
					}
				}
				return address;
			}
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x000203BC File Offset: 0x0001E5BC
		public static object Read_Pointer_4Bytes_32Bit(int address, int[] Offset = null)
		{
			checked
			{
				address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
				if (!Information.IsNothing(Offset))
				{
					int num = Offset.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address + Offset[i]);
					}
				}
				return address;
			}
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x00020404 File Offset: 0x0001E604
		public static object Read_Pointer_4Bytes_64Bit(int address, int[] Offset = null)
		{
			checked
			{
				address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
				if (!Information.IsNothing(Offset))
				{
					int num = Offset.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_4Bytes_64Bit(address + Offset[i]);
					}
				}
				return address;
			}
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x0002044C File Offset: 0x0001E64C
		public static object Read_Pointer_8Bytes_32Bit(int address, int[] Offset = null)
		{
			checked
			{
				address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
				if (!Information.IsNothing(Offset))
				{
					int num = Offset.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_8Bytes_32Bit(address + Offset[i]);
					}
				}
				return address;
			}
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x00020494 File Offset: 0x0001E694
		public static object Read_Pointer_8Bytes_64Bit(int address, int[] Offset = null)
		{
			checked
			{
				address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
				if (!Information.IsNothing(Offset))
				{
					int num = Offset.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_8Bytes_64Bit(address + Offset[i]);
					}
				}
				return address;
			}
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x000204DC File Offset: 0x0001E6DC
		public static object Read_Pointer_String(int length, int address, int[] Offset = null)
		{
			checked
			{
				string result;
				if (!Information.IsNothing(Offset))
				{
					address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
					int num = Offset.Length - 2;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address + Offset[i]);
					}
					result = Conversions.ToString(TrainerModul2_3.Read_String(length, address + Offset[Offset.Length - 1]));
				}
				else
				{
					result = Conversions.ToString(TrainerModul2_3.Read_String(length, address));
				}
				return result;
			}
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x00020550 File Offset: 0x0001E750
		public static void Write_Pointer_String(string WhatToWrite, int address, int[] Offset = null)
		{
			checked
			{
				if (!Information.IsNothing(Offset))
				{
					address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address);
					int num = Offset.Length - 2;
					for (int i = 0; i <= num; i++)
					{
						address = (int)TrainerModul2_3.Read_4Bytes_32Bit(address + Offset[i]);
					}
					TrainerModul2_3.Write_String(address + Offset[Offset.Length - 1], WhatToWrite);
				}
				else
				{
					TrainerModul2_3.Write_String(address, WhatToWrite);
				}
			}
		}

		// Token: 0x040002D0 RID: 720
		private static int process_id = 0;

		// Token: 0x040002D1 RID: 721
		private static int process_handle = 0;

		// Token: 0x040002D2 RID: 722
		private const int ACCESS_RIGHTS_ALL = 2035711;

		// Token: 0x040002D3 RID: 723
		public const int VK_NUMPAD0 = 96;

		// Token: 0x040002D4 RID: 724
		public const int VK_NUMPAD1 = 97;

		// Token: 0x040002D5 RID: 725
		public const int VK_NUMPAD2 = 98;

		// Token: 0x040002D6 RID: 726
		public const int VK_NUMPAD3 = 99;

		// Token: 0x040002D7 RID: 727
		public const int VK_NUMPAD4 = 100;

		// Token: 0x040002D8 RID: 728
		public const int VK_NUMPAD5 = 101;

		// Token: 0x040002D9 RID: 729
		public const int VK_NUMPAD6 = 102;

		// Token: 0x040002DA RID: 730
		public const int VK_NUMPAD7 = 103;

		// Token: 0x040002DB RID: 731
		public const int VK_NUMPAD8 = 104;

		// Token: 0x040002DC RID: 732
		public const int VK_NUMPAD9 = 105;

		// Token: 0x040002DD RID: 733
		public const int VK_MULTIPLY = 106;

		// Token: 0x040002DE RID: 734
		public const int VK_ADD = 107;

		// Token: 0x040002DF RID: 735
		public const int VK_SUBSTRACT = 109;

		// Token: 0x040002E0 RID: 736
		public const int VK_DIVIDE = 111;

		// Token: 0x040002E1 RID: 737
		public const int VK_F1 = 112;

		// Token: 0x040002E2 RID: 738
		public const int VK_F2 = 113;

		// Token: 0x040002E3 RID: 739
		public const int VK_F3 = 114;

		// Token: 0x040002E4 RID: 740
		public const int VK_F4 = 115;

		// Token: 0x040002E5 RID: 741
		public const int VK_F5 = 116;

		// Token: 0x040002E6 RID: 742
		public const int VK_F6 = 117;

		// Token: 0x040002E7 RID: 743
		public const int VK_F7 = 118;

		// Token: 0x040002E8 RID: 744
		public const int VK_F8 = 119;

		// Token: 0x040002E9 RID: 745
		public const int VK_F9 = 120;

		// Token: 0x040002EA RID: 746
		public const int VK_F10 = 121;

		// Token: 0x040002EB RID: 747
		public const int VK_F11 = 122;

		// Token: 0x040002EC RID: 748
		public const int VK_F12 = 123;

		// Token: 0x040002ED RID: 749
		public const int VK_CONTROL = 17;

		// Token: 0x0200006B RID: 107
		public class Teleporter
		{
			// Token: 0x04000325 RID: 805
			public int XKoord;

			// Token: 0x04000326 RID: 806
			public int YKoord;

			// Token: 0x04000327 RID: 807
			public int ZKoord;
		}

		// Token: 0x0200006C RID: 108
		public struct SYSTEM_INFO
		{
			// Token: 0x04000328 RID: 808
			public int dwOemID;

			// Token: 0x04000329 RID: 809
			public long dwPageSize;

			// Token: 0x0400032A RID: 810
			public long lpMinimumApplicationAddress;

			// Token: 0x0400032B RID: 811
			public long lpMaximumApplicationAddress;

			// Token: 0x0400032C RID: 812
			public int dwActiveProcessorMask;

			// Token: 0x0400032D RID: 813
			public int dwNumberOrfProcessors;

			// Token: 0x0400032E RID: 814
			public int dwProcessorType;

			// Token: 0x0400032F RID: 815
			public int dwAllocationGranularity;

			// Token: 0x04000330 RID: 816
			public short wProcessorLevel;

			// Token: 0x04000331 RID: 817
			public short wProcessorRevision;
		}

		// Token: 0x0200006D RID: 109
		private struct MEMORY_BASIC_INFORMATION
		{
			// Token: 0x04000332 RID: 818
			public long BaseAddress;

			// Token: 0x04000333 RID: 819
			public IntPtr AllocationBase;

			// Token: 0x04000334 RID: 820
			public uint AllocationProtect;

			// Token: 0x04000335 RID: 821
			public long RegionSize;

			// Token: 0x04000336 RID: 822
			public uint State;

			// Token: 0x04000337 RID: 823
			public uint Protect;

			// Token: 0x04000338 RID: 824
			public uint zType;
		}

		// Token: 0x0200006E RID: 110
		public enum MemoryState
		{
			// Token: 0x0400033A RID: 826
			MEM_COMMIT = 4096,
			// Token: 0x0400033B RID: 827
			MEM_FREE = 65536,
			// Token: 0x0400033C RID: 828
			MEM_RESERVE = 8192
		}

		// Token: 0x0200006F RID: 111
		public enum MemoryAllocationProtectionType : uint
		{
			// Token: 0x0400033E RID: 830
			PAGE_NOACCESS = 1U,
			// Token: 0x0400033F RID: 831
			PAGE_READONLY,
			// Token: 0x04000340 RID: 832
			PAGE_READWRITE = 4U,
			// Token: 0x04000341 RID: 833
			PAGE_WRITECOPY = 8U,
			// Token: 0x04000342 RID: 834
			PAGE_EXECUTE = 16U,
			// Token: 0x04000343 RID: 835
			PAGE_EXECUTE_READ = 32U,
			// Token: 0x04000344 RID: 836
			PAGE_EXECUTE_READWRITE = 64U,
			// Token: 0x04000345 RID: 837
			PAGE_EXECUTE_WRITECOPY = 128U,
			// Token: 0x04000346 RID: 838
			PAGE_GUARD = 256U,
			// Token: 0x04000347 RID: 839
			PAGE_NOCACHE = 512U,
			// Token: 0x04000348 RID: 840
			PAGE_WRITECOMBINE = 1024U,
			// Token: 0x04000349 RID: 841
			PAGE_CANREAD = 6U
		}

		// Token: 0x02000070 RID: 112
		public enum MemoryAllocationType : uint
		{
			// Token: 0x0400034B RID: 843
			MEM_IMAGE = 16777216U,
			// Token: 0x0400034C RID: 844
			MEM_MAPPED = 262144U,
			// Token: 0x0400034D RID: 845
			MEM_PRIVATE = 131072U
		}

		// Token: 0x02000071 RID: 113
		public enum MemoryAllocationState : uint
		{
			// Token: 0x0400034F RID: 847
			Commit = 4096U,
			// Token: 0x04000350 RID: 848
			Reserve = 8192U,
			// Token: 0x04000351 RID: 849
			Decommit = 16384U,
			// Token: 0x04000352 RID: 850
			Release = 32768U,
			// Token: 0x04000353 RID: 851
			Reset = 524288U,
			// Token: 0x04000354 RID: 852
			Physical = 4194304U,
			// Token: 0x04000355 RID: 853
			TopDown = 1048576U,
			// Token: 0x04000356 RID: 854
			WriteWatch = 2097152U,
			// Token: 0x04000357 RID: 855
			LargePages = 536870912U
		}
	}
}
