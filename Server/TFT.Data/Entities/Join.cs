using System;
using System.Collections.Generic;
using System.Text;

namespace TFTB.Data.Entities
{
    public class Join
    {
        public string MatchId { get; set; }
        public virtual Match Match { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
