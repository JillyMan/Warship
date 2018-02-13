using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Warship
{
    public class MousePressedEvent : MouseButtonEvent
    {
        public MousePressedEvent(MouseButtons buttons, int x, int y) : base(Event.Type.MOUSE_PRESSED, buttons, x, y)
        {
        }
    }
}
