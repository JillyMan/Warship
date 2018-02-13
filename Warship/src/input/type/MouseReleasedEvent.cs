using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Warship
{
    public class MouseReleasedEvent : MouseButtonEvent
    {
        public MouseReleasedEvent(MouseButtons buttons, int x, int y) : base(Event.Type.MOUSE_RELEASED, buttons, x, y)
        {
        }
    }
}
