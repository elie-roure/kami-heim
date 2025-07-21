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
    public class BiensViewModel : INotifyPropertyChanged
    {
        private readonly DataService _dataService;
        private readonly INavigationService _navigationService;
        public ObservableCollection<Bien> Biens { get; set; } = new();

        public ICommand OuvrirAjouterBienCommand { get; }
        public BiensViewModel(DataService dataService,INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            OuvrirAjouterBienCommand = new RelayCommand(() => _navigationService.NaviguerVers(new AjouterBienView { DataContext = new AjouterBienViewModel(_dataService,RetourNaviguerVersAjouterBien) }));

            ChargerBiens();
        }

        private void ChargerBiens()
        {
            Biens = new ObservableCollection<Bien>(_dataService.Context.Biens.ToList());
            OnPropertyChanged(nameof(Biens));
        }
        private void RetourNaviguerVersAjouterBien()
        {
            _navigationService.NaviguerVers(new BiensView { DataContext = new BiensViewModel(_dataService,_navigationService) });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
