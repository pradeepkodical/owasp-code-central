using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Owasp.VulnReport.utils
{
    class win32
    {
        // Required for the utils.windowsForms.getRowAndColFromRichTextBox method
        [DllImport("User32.Dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public const int EM_LINEINDEX = 0xBB; 
    }
}
