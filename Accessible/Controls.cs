using System;
using System.Drawing;
using System.Windows.Forms;

namespace Accessibility
{
    namespace Controls
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
}
