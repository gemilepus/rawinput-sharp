﻿using System;
using System.Windows.Forms;
using Linearstar.Windows.RawInput;

namespace RawInput.Sharp.SimpleExample
{
    class RawInputReceiverWindow : NativeWindow
    {
        public event EventHandler<RawInputEventArgs> Input;

        public RawInputReceiverWindow()
        {
            CreateHandle(new CreateParams
            {
                X = 0,
                Y = 0,
                Width = 0,
                Height = 0,
                Style = 0x800000,
            });
        }

        protected override void WndProc(ref Message m)
        {
           
            const int WM_INPUT = 0x00FF;

            if (m.Msg == WM_INPUT)
            {
                var data = RawInputData.FromHandle(m.LParam);

                Input?.Invoke(this, new RawInputEventArgs(data));
            }
            Console.WriteLine("[+]uMsg: " + m.Msg + ", hwnd: " + m.HWnd + ", wParam: " + m.WParam + ", lParam: {0:x}" , m.LParam.ToInt32());

            base.WndProc(ref m);
        }
    }
}