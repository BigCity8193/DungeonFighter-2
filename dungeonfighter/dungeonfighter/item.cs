using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonfighter
{
    public abstract class item
    {
        abstract public string name { get; set; }

        abstract public string type { get; set; }
        
        abstract public bool isUnique { get; set; }

        abstract public int quantity { get; set; }
    }
}
