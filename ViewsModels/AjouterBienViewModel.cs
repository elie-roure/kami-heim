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
    class AjouterBienViewModel : INotifyPropertyChanged
    {
        public Bien Bien { get; set; } = new();

        public ICommand AjouterCommand { get; }

        private readonly Action? _retourAction;

        public AjouterBienViewModel(Action? retourAction = null)
        {
            _retourAction = retourAction;
            AjouterCommand = new RelayCommand(AjouterBien);
        }

        private void AjouterBien()
        {
            using var db = new AppDbContext();
            db.Biens.Add(Bien);
            db.SaveChanges();
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
