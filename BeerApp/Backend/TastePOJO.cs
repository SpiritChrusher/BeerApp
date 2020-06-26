using System;
using System.Collections.Generic;
using System.Text;

namespace Mobeer.Backend
{
    class TastePOJO
    {

            public string Taste { get; set; }

            public bool Visible { get; set; }

        public TastePOJO() { }

    public TastePOJO(string taste) 
        { Taste = taste; Visible = false; }
    }
}
