using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VolumeMixerPlus
{
    public class HotKey
    {
        public Keys Key;
        public Modifier Modifiers;

        public enum Modifier
        {
            None = 0,
            Control = 2,
            Alt = 4 ,
            Shift = 8
        }

        public override bool Equals(object obj)
        {
            if (!(obj is HotKey))
                return false;

            return (obj as HotKey).Key.Equals(Key) && (obj as HotKey).Modifiers.Equals(Modifiers);
        }

        public override int GetHashCode()
        {
            var hashCode = 34518437;
            hashCode = hashCode * -1521134295 + Key.GetHashCode();
            hashCode = hashCode * -1521134295 + Modifiers.GetHashCode();
            return hashCode;
        }
    }
}
