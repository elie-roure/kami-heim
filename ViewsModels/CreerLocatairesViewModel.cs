using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using kami_heim.Data;
using kami_heim.Helpers;
using kami_heim.Models;

namespace kami_heim.ViewsModels
{
    class CreerLocatairesViewModel : INotifyPropertyChanged
    {
        public Locataire Locataire { get; set; } = new();

        public ICommand AjouterCommand { get; }

        private readonly Action? _retourAction;

        public CreerLocatairesViewModel(Action? retourAction = null)
        {
            _retourAction = retourAction;
            AjouterCommand = new RelayCommand(AjouterLocataire);
        }

        private void AjouterLocataire()
        {
            using var db = new AppDbContext();
            db.Locataires.Add(Locataire);
            db.SaveChanges();
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
