using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
    public class MouseMotionEvent : Event
    {
        public int X { get; }
        public int Y { get; }
        public bool Dragged { get; }

        public MouseMotionEvent(int x, int y, bool dragged) : base(Event.Type.MOUSE_MOVED)
        {
            this.X = x;
            this.Y = y;
            this.Dragged = dragged;
        }
    }
}
