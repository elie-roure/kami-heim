using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace kami_heim.Services
{
    public class NavigationService : INotifyPropertyChanged, INavigationService
    {
        private object? _vueCourante;
        public object? VueCourante
        {
            get => _vueCourante;
            private set { _vueCourante = value; OnPropertyChanged(); }
        }

        public void NaviguerVers(object vue)
        {
            VueCourante = vue;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
