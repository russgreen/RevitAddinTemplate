using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace RevitAddinTemplate
{
    internal class WindowHandle : IWin32Window
    {
        private readonly IntPtr _hwnd;

        public WindowHandle(IntPtr h)
        {
            Debug.Assert(IntPtr.Zero != h, "expected non-null window handle");
            _hwnd = h;
        }

        public IntPtr Handle
        {
            get
            {
                return _hwnd;
            }
        }
    }
}
