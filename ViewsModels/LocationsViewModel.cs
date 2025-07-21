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
using Microsoft.EntityFrameworkCore;

namespace kami_heim.ViewsModels
{
    public class LocationsViewModel : INotifyPropertyChanged
    {
        private readonly DataService _dataService;
        private readonly INavigationService _navigationService;
        public ObservableCollection<Location> Locations { get; set; } = new();
        public ICommand OuvrirAjouterLocationCommand { get; }

        public LocationsViewModel(DataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            OuvrirAjouterLocationCommand = new RelayCommand(() => _navigationService.NaviguerVers(new AjouterLocationView { DataContext = new AjouterLocationViewModel(_dataService,RetourNaviguerVersAjouterLocation) }));

            ChargerLocations();
        }

        private void ChargerLocations()
        {
            var locations = _dataService.Context.Locations
           .Include(l => l.Bien)
           .Include(l => l.Locataire)
           .ToList();

            Locations.Clear();
            foreach (var loc in locations)
            {
                Locations.Add(loc);
            }
        }


        private void RetourNaviguerVersAjouterLocation()
        {
            _navigationService.NaviguerVers(new LocationsView { DataContext = new LocationsViewModel(_dataService,_navigationService) });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
