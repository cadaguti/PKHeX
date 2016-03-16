using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Media
{
    public class MP3Player
    {
        private string _command;
        private bool isOpen;
        [DllImport("winmm.dll")]

        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        public void Close()
        {
            _command = "close MediaFile";
            mciSendString(_command, null, 0, IntPtr.Zero);
            isOpen = false;
        }

        public void Open(string sFileName)
        {
            if (isOpen)
            {
                Close();
            }
            _command = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";
            mciSendString(_command, null, 0, IntPtr.Zero);
            isOpen = true;
        }

        public void Play()
        {
            if (isOpen)
            {
                _command = "play MediaFile";
                mciSendString(_command, null, 0, IntPtr.Zero);
            }
        }

    }

}
