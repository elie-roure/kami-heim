using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kami_heim.Data;

namespace kami_heim.Services
{
    public class DataService
    {
        public AppDbContext Context { get; }

        public DataService()
        {
            Context = new AppDbContext();
        }
    }
}
