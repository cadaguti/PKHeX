using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace PKHeX
{
        public class MP3Player
        {
            private string _command;
            private bool isOpen;
            [DllImport("winmm.dll")]

            private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        private string tmpFile;

        public void Close()
            {
                _command = "close MediaFile";
                mciSendString(_command, null, 0, IntPtr.Zero);
            if (File.Exists(tmpFile))
            {
                File.Delete(tmpFile);
            }
            isOpen = false;
            }

        public void Open(Byte[] data)
        {
            tmpFile = createTMP();
            if (File.Exists(tmpFile))
            {
                writeData(data);
                Open(tmpFile);
            }
            }

        public void Open(string sFileName)
            {
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

        private string createTMP()
    {
        string fileName = string.Empty;
        fileName = Path.GetTempFileName();
        FileInfo fileInfo = new FileInfo(fileName);
        fileInfo.Attributes = FileAttributes.Temporary;
        return fileName;
    }

private void writeData(Byte[] data)
    {
        FileStream streamWriter = new FileStream(tmpFile, FileMode.Open, FileAccess.Write);
                        streamWriter.Write(data, 0, data.Length);
        streamWriter.Close();
    }

    }

}
