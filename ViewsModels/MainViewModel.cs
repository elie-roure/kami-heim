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
        private readonly DataService _dataService;
        private readonly INavigationService _navigationService;
        public object? VueCourante => _navigationService.VueCourante;

        public ICommand AfficherAccueilCommand { get; }
        public ICommand AfficherLocatairesCommand { get; }
        public ICommand AfficherBiensCommand { get; }
        public ICommand AfficherLocationCommand { get; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Locataire> Locataires { get; set; } = new();
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel(DataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;

            AfficherAccueilCommand = new RelayCommand(() => _navigationService.NaviguerVers(new AccueilView()));
            AfficherLocatairesCommand = new RelayCommand(() => _navigationService.NaviguerVers(new LocatairesView { DataContext = new LocatairesViewModel(_dataService,_navigationService) }));
            AfficherBiensCommand = new RelayCommand(() => _navigationService.NaviguerVers(new BiensView { DataContext = new BiensViewModel(_dataService,_navigationService) }));
            AfficherLocationCommand = new RelayCommand(() => _navigationService.NaviguerVers(new LocationsView { DataContext = new LocationsViewModel(_dataService,_navigationService) }));

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
        }
    }
}
