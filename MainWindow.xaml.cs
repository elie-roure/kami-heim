using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using kami_heim.Services;
using kami_heim.Views;
using kami_heim.ViewsModels;
using NavigationService = kami_heim.Services.NavigationService;

namespace kami_heim
{
    /// <summary>  
    /// Interaction logic for MainWindow.xaml  
    /// </summary>  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            INavigationService navigationService = new NavigationService();
            DataContext = new MainViewModel(navigationService);
        }
    }
}