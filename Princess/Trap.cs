using System;
using System.Collections.Generic;
using System.Text;

namespace Princess
{
    public class Trap
    {
        public bool ActivateStatus { get; set; } = true;
        public byte Vertical { get; set; }
        public byte Horizontal { get; set; }
    }
}
