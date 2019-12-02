using System;
using System.Collections.Generic;
using System.Text;

namespace TFTB.Data.Entities
{
    public class Match
    {
        public string Id { get; set; }
        public DateTime Start { get; set; }
        public bool IsFinish { get; set; } = false;
        public bool IsStart { get; set; } = false;
        public virtual Result Result { get; set; }
    }
}
