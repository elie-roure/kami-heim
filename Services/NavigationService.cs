using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kami_heim.Services
{
    public interface INavigationService
    {
        object? VueCourante { get; }
        void NaviguerVers(object vue);
    }
}
