using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warship
{
    public abstract class Event
    {
        public enum Type
        {
            MOUSE_MOVED, 
            MOUSE_RELEASED,
            MOUSE_PRESSED
        }

		public Type type;

        protected Event(Type type)
        {
            this.type = type;
        }
    }
}
