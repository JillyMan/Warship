using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Warship
{
    public abstract class MouseButtonEvent : Event
    {
        public int X { get; }
        public int Y { get; }
        public MouseButtons Buttons { get; }

        public MouseButtonEvent(Type type, MouseButtons buttons, int x, int y) : base(type)
        {
            this.X = x;
            this.Y = y;
            this.Buttons = buttons;
        }
    }
}
