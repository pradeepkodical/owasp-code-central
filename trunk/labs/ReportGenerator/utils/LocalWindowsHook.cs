// Dinis note: I took this from http://www.codeproject.com/csharp/NetWin32Hooks.asp

// ***********************************************************************
//  LocalWindowsHook class
//  Dino Esposito, summer 2002 
// 
//  Provide a general infrastructure for using Win32 
//  hooks in .NET applications
// 
// ***********************************************************************

//
// I took this class from the example at http://msdn.microsoft.com/msdnmag/issues/02/10/cuttingedge
// and made a couple of minor tweaks to it - dpk
//

using System;
using System.Runtime.InteropServices;

namespace  Owasp.VulnReport.utils
{
	#region Class LocalWindowsHook
	public class LocalWindowsHook
	{
		public bool bCallNextHook;

		// ************************************************************************
		// Filter function delegate
		public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);
		// ************************************************************************

		// ************************************************************************
		// Internal properties
		protected IntPtr m_hhook = IntPtr.Zero;
		protected HookProc m_filterFunc = null;
		protected HookType m_hookType;
		// ************************************************************************
		
		// ************************************************************************
		// Event delegate
		public delegate void HookEventHandler(object sender, HookEventArgs e);
		// ************************************************************************

		// ************************************************************************
		// Event: HookInvoked 
		public event HookEventHandler HookInvoked;
		protected void OnHookInvoked(HookEventArgs e)
		{
			if (HookInvoked != null)
				HookInvoked(this, e);
		}
		// ************************************************************************

		// ************************************************************************
		// Class constructor(s)
		public LocalWindowsHook(HookType hook)
		{
			m_hookType = hook;
			m_filterFunc = new HookProc(this.CoreHookProc); 
		}

		public LocalWindowsHook(HookType hook, HookProc func)
		{
			m_hookType = hook;
			m_filterFunc = func; 
		}		
		// ************************************************************************
	
		// ************************************************************************
		// Default filter function
		protected int CoreHookProc(int code, IntPtr wParam, IntPtr lParam)
		{
			this.bCallNextHook = true;
			if (code < 0)
				return CallNextHookEx(m_hhook, code, wParam, lParam);

			// Let clients determine what to do
			HookEventArgs e = new HookEventArgs();
			e.HookCode = code;
			e.wParam = wParam;
			e.lParam = lParam;
			OnHookInvoked(e);

			// Yield to the next hook in the chain
			if (this.bCallNextHook)
				return CallNextHookEx(m_hhook, code, wParam, lParam);
			else
				return -1;
		}
		// ************************************************************************

		// ************************************************************************
		// Install the hook
		public void Install()
		{
            // We use the AppDomain.GetCurrentThreadId instead of System.Threading.Thread.CurrentThread.Manag....
            // because that doesn't give us the actual thread id for the application as a whole.  Since this 
            // is a very low level function we need the actual thread id for the application.
#pragma warning disable 0618
            m_hhook = SetWindowsHookEx(
                m_hookType,
                m_filterFunc,
                IntPtr.Zero,
                (int)AppDomain.GetCurrentThreadId());
#pragma warning restore 0618
        }
		// ************************************************************************

		// ************************************************************************
		// Uninstall the hook
		public void Uninstall()
		{
			UnhookWindowsHookEx(m_hhook); 
			m_hhook = IntPtr.Zero;
		}
		// ************************************************************************

		public bool IsInstalled
		{
			get{ return m_hhook != IntPtr.Zero; }
		}

		#region Win32 Imports
		// ************************************************************************
		// Win32: SetWindowsHookEx()
		[DllImport("user32.dll")]
		protected static extern IntPtr SetWindowsHookEx(HookType code, 
			HookProc func,
			IntPtr hInstance,
			int threadID);
		// ************************************************************************

		// ************************************************************************
		// Win32: UnhookWindowsHookEx()
		[DllImport("user32.dll")]
		protected static extern int UnhookWindowsHookEx(IntPtr hhook); 
		// ************************************************************************

		// ************************************************************************
		// Win32: CallNextHookEx()
		[DllImport("user32.dll")]
		protected static extern int CallNextHookEx(IntPtr hhook, 
			int code, IntPtr wParam, IntPtr lParam);
		// ************************************************************************
		#endregion

		#region Class HookEventArgs
		public class HookEventArgs : EventArgs
		{
			public int HookCode;	// Hook code
			public IntPtr wParam;	// WPARAM argument
			public IntPtr lParam;	// LPARAM argument
		}
		#endregion

		#region Enums (HookType, HookCode)
		// Hook Types
		public enum HookType : int
		{
			WH_JOURNALRECORD = 0,
			WH_JOURNALPLAYBACK = 1,
			WH_KEYBOARD = 2,
			WH_GETMESSAGE = 3,
			WH_CALLWNDPROC = 4,
			WH_CBT = 5,
			WH_SYSMSGFILTER = 6,
			WH_MOUSE = 7,
			WH_HARDWARE = 8,
			WH_DEBUG = 9,
			WH_SHELL = 10,
			WH_FOREGROUNDIDLE = 11,
			WH_CALLWNDPROCRET = 12,		
			WH_KEYBOARD_LL = 13,
			WH_MOUSE_LL = 14
		}

		public enum HookCode : int
		{
			HC_ACTION = 0,
			HC_GETNEXT,
			HC_SKIP,
			HC_NOREMOVE
		}
		#endregion
	}
	#endregion
}
