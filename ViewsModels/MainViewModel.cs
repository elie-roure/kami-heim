using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using kami_heim.Data;
using kami_heim.Helpers;
using kami_heim.Models;
using kami_heim.Services;
using kami_heim.Views;

namespace kami_heim.ViewsModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        public object? VueCourante => _navigationService.VueCourante;

        public ICommand AfficherAccueilCommand { get; }
        public ICommand AfficherLocatairesCommand { get; }
        //public ICommand AfficherCreerLocatairesCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Locataire> Locataires { get; set; } = new();
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            AfficherAccueilCommand = new RelayCommand(() => _navigationService.NaviguerVers(new AccueilView()));
            AfficherLocatairesCommand = new RelayCommand(() => _navigationService.NaviguerVers(new LocatairesView { DataContext = new LocatairesViewModel() }));
            //AfficherCreerLocatairesCommand = new RelayCommand(() => _navigationService.NaviguerVers(new CreerLocatairesView()));

            // Vue par défaut  
            _navigationService.NaviguerVers(new AccueilView());

            // Synchronise VueCourante avec le service  
            if (_navigationService is INotifyPropertyChanged notifyPropertyChanged)
            {
                notifyPropertyChanged.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(_navigationService.VueCourante))
                        OnPropertyChanged(nameof(VueCourante));
                };
            }


            ChargerLocataires();
        }

        private void ChargerLocataires()
        {
            using var db = new AppDbContext();
            Locataires = new ObservableCollection<Locataire>(db.Locataires.ToList());
            OnPropertyChanged(nameof(Locataires));
        }
    }
}
