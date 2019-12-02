using System;
using System.Collections.Generic;
using System.Text;

namespace TFTB.Data.Entities
{
    public class Result
    {
        public string Id { get; set; }
        public string Top1 { get; set; }
        public string Top2 { get; set; }
        public string Top3 { get; set; }
        public DateTime End { get; set; }
    }
}
