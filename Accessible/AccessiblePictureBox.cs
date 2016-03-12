using System;
using System.Drawing;
using System.Windows.Forms;

namespace PKHeX
{
    class AccessiblePictureBox : PictureBox
    {

        public AccessiblePictureBox()
        {
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
        }

    }
}
