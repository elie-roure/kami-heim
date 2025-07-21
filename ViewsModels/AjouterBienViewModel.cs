using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using kami_heim.Data;
using kami_heim.Helpers;
using kami_heim.Models;
using kami_heim.Services;

namespace kami_heim.ViewsModels
{
    class AjouterBienViewModel : INotifyPropertyChanged
    {
        private readonly DataService _dataService;
        private readonly Action? _retourAction;
        public Bien Bien { get; set; } = new();

        public ICommand AjouterCommand { get; }


        public AjouterBienViewModel(DataService dataService, Action? retourAction = null)
        {
            _dataService = dataService;
            _retourAction = retourAction;
            AjouterCommand = new RelayCommand(AjouterBien);
        }

        private void AjouterBien()
        {
            _dataService.Context.Biens.Add(Bien);
            _dataService.Context.SaveChanges();
            Bien = new Bien();
            OnPropertyChanged(nameof(Bien));

            // Naviguer vers la liste après ajout
            _retourAction?.Invoke();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
