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
    class AjouterLocataireViewModel : INotifyPropertyChanged
    {
        private readonly DataService _dataService;
        private readonly Action? _retourAction;
        public Locataire Locataire { get; set; } = new();

        public ICommand AjouterCommand { get; }


        public AjouterLocataireViewModel(DataService dataService, Action? retourAction = null)
        {
            _dataService = dataService;
            _retourAction = retourAction;
            AjouterCommand = new RelayCommand(AjouterLocataire);
        }

        private void AjouterLocataire()
        {
            _dataService.Context.Locataires.Add(Locataire);
            _dataService.Context.SaveChanges();
            Locataire = new Locataire();
            OnPropertyChanged(nameof(Locataire));

            // Naviguer vers la liste après ajout
            _retourAction?.Invoke();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
