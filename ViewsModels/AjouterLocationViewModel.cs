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
    public class AjouterLocationViewModel : INotifyPropertyChanged
    {
        private readonly DataService _dataService;
        private readonly Action? _retourAction;
        public ObservableCollection<Bien> Biens { get; set; }
        public ObservableCollection<Locataire> Locataires { get; set; }
        public ICommand AjouterCommand { get; }
        public Location Location { get; set; } = new();

        public AjouterLocationViewModel(DataService dataService, Action? retourAction = null)
        {
            _dataService = dataService;
            _retourAction = retourAction;
            Location.DateDebut = DateTime.Today;
            ChargerBiens();
            ChargerLocataires();

            AjouterCommand = new RelayCommand(AjouterLocation);
        }

        private void ChargerBiens()
        {
            Biens = new ObservableCollection<Bien>(_dataService.Context.Biens.ToList());
            OnPropertyChanged(nameof(Biens));
        }
        private void ChargerLocataires()
        {
            Locataires = new ObservableCollection<Locataire>(_dataService.Context.Locataires.ToList());
            OnPropertyChanged(nameof(Locataires));
        }
        private void AjouterLocation()
        {
            _dataService.Context.Locations.Add(Location);
            _dataService.Context.SaveChanges();

            // Naviguer vers la liste après ajout
            _retourAction?.Invoke();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
