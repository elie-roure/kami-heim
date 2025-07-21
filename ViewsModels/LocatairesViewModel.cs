using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using kami_heim.Data;
using kami_heim.Helpers;
using kami_heim.Models;
using kami_heim.Services;
using kami_heim.Views;

namespace kami_heim.ViewsModels
{
    public class LocatairesViewModel : INotifyPropertyChanged
    {
        private readonly DataService _dataService;
        private readonly INavigationService _navigationService;
        public ObservableCollection<Locataire> Locataires { get; set; } = new();

        public ICommand OuvrirAjouterLocataireCommand { get; }
        public LocatairesViewModel(DataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            OuvrirAjouterLocataireCommand = new RelayCommand(() => _navigationService.NaviguerVers(new AjouterLocataireView { DataContext = new AjouterLocataireViewModel(_dataService,RetourNaviguerVersAjouterLocataire) }));

            ChargerLocataires();
        }

        private void ChargerLocataires()
        {
            Locataires = new ObservableCollection<Locataire>(_dataService.Context.Locataires.ToList());
            OnPropertyChanged(nameof(Locataires));
        }
        private void RetourNaviguerVersAjouterLocataire()
        {
            _navigationService.NaviguerVers(new LocatairesView { DataContext = new LocatairesViewModel(_dataService,_navigationService) });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
