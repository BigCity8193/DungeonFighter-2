using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonfighter
{
    class consumeable : item
    {
        public override string name { get; set; }
        public override string type { get; set; }
        public override bool isUnique { get; set; }
        public override int quantity { get; set; }
    }
}
