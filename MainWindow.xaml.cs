using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Praktika07
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FrmMain_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void BtnSpektakli_Click(object sender, RoutedEventArgs e)
        {
            WindowSpectakli windowSpectakli = new WindowSpectakli();
            windowSpectakli.ShowDialog();
        }

        private void BtnActors_Click(object sender, RoutedEventArgs e)
        {
            WindowActors windowActors = new WindowActors();
            windowActors.ShowDialog();
        }

        private void BtnJob_Actors_Click(object sender, RoutedEventArgs e)
        {
            WindowJobActors windowJobs = new WindowJobActors();
            windowJobs.ShowDialog();
        }
    }
}
