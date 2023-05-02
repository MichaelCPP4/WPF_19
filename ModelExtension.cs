using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_18
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    public partial class bd18Entities : DbContext
    {

        private static bd18Entities context;

        public static bd18Entities GetContext()
        {
            if (context == null) context = new bd18Entities();
            return context;
        }
    }
}
