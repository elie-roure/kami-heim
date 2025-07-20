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
    public class LocatairesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Locataire> Locataires { get; set; } = new();

        public ICommand OuvrirAjouterLocataireCommand { get; }
        public LocatairesViewModel()
        {
            OuvrirAjouterLocataireCommand = new RelayCommand(OuvrirAjouterLocataire);

            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                // Données fictives pour le designer
                Locataires.Add(new Locataire { Nom = "Dupont", Prenom = "Jean", Email = "jean@email.com", Telephone = "0600000000" });
                Locataires.Add(new Locataire { Nom = "Martin", Prenom = "Sophie", Email = "sophie@email.com", Telephone = "0600000001" });
            }
            else
            {
                // Chargement réel (base de données)
                ChargerLocataires();
            }
        }

        private void ChargerLocataires()
        {
            using var db = new AppDbContext();
            Locataires = new ObservableCollection<Locataire>(db.Locataires.ToList());
            OnPropertyChanged(nameof(Locataires));
        }
        private void OuvrirAjouterLocataire()
        {
            var window = new AjouterLocataireView();
            window.DataContext = new AjouterLocataireViewModel();
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            // Après fermeture, recharge la liste
            ChargerLocataires();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
