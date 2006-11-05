using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Owasp.SiteGenerator
{
    class SharedMemoryForDotNet
    {
        [DllImport(@"SharedMemoryForDotNet.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr smdt_Create(string strNameOfSharedMemory);
        [DllImport(@"SharedMemoryForDotNet.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr smdt_send(IntPtr smdtToUse, string strMessageToSend);
        [DllImport(@"SharedMemoryForDotNet.dll", CharSet = CharSet.Ansi)]
        public static extern int smdt_UnReadMessages(IntPtr smdtToUse);
        [DllImport(@"SharedMemoryForDotNet.dll", CharSet = CharSet.Ansi)]
        public static extern int smdt_waitForEvent_NewMessage(IntPtr smdtToUse);
        [DllImport(@"SharedMemoryForDotNet.dll", CharSet = CharSet.Unicode)]
        public static extern int smdt_getNextMessageToProcess(IntPtr smdtToUse, StringBuilder sbMessageToProcess);
        [DllImport(@"SharedMemoryForDotNet.dll", CharSet = CharSet.Unicode)]
        public static extern int smdt_CheckIfCurrentMessageShouldHaveAnAnswer(IntPtr smdtToUse, int iAnswerPosition);
        [DllImport(@"SharedMemoryForDotNet.dll", CharSet = CharSet.Unicode)]
        public static extern void smdt_sendAnswerUsingEvent(IntPtr smdtToUse, StringBuilder sAnswer, int iAnswerPosition);
        [DllImport(@"SharedMemoryForDotNet.dll", CharSet = CharSet.Ansi)]
        public static extern string smdt_detours_injdll(string strDllToInject, int iProcessIdOfProcessToInject);
        [DllImport(@"SharedMemoryForDotNet.dll")]
        public static extern void smdt_SetApplyHooksFlag(IntPtr smdtToUse, int iApplyHooksValue);
        [DllImport(@"SharedMemoryForDotNet.dll", CharSet = CharSet.Unicode)]
        public static extern void smdt_test();        
        [DllImport(@"SharedMemoryForDotNet.dll", CharSet = CharSet.Unicode)]
        public static extern StringBuilder smdt_sendAsQuestion(IntPtr smdtToUse, StringBuilder sbMessageToProcess);
    }
}
