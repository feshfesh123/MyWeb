using System;
using System.Collections.Generic;
using System.Text;

namespace TFTB.Data.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; } = 0;
    }
}
