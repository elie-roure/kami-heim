using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using kami_heim.Data;
using kami_heim.Helpers;
using kami_heim.Models;
using kami_heim.Views;

namespace kami_heim.ViewsModels
{
    public class BiensViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Bien> Biens { get; set; } = new();

        public ICommand OuvrirAjouterBienCommand { get; }
        public BiensViewModel()
        {
            OuvrirAjouterBienCommand = new RelayCommand(OuvrirAjouterBien);

            ChargerBiens();
        }

        private void ChargerBiens()
        {
            using var db = new AppDbContext();
            Biens = new ObservableCollection<Bien>(db.Biens.ToList());
            OnPropertyChanged(nameof(Biens));
        }
        private void OuvrirAjouterBien()
        {
            var window = new AjouterBienView();
            window.DataContext = new AjouterBienViewModel();
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            // Après fermeture, recharge la liste
            ChargerBiens();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
