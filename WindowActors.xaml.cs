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
using System.Windows.Shapes;

namespace Praktika07
{
    /// <summary>
    /// Логика взаимодействия для WindowActors.xaml
    /// </summary>
    public partial class WindowActors : Window
    {
        public WindowActors()
        {
            InitializeComponent();

            DataGridActors.ItemsSource = DBGoglickEntities.GetContext().Actors.ToList();

        }

        private void DeleteActors_Click(object sender, RoutedEventArgs e)
        {
            var actorsForRemoving = DataGridActors.SelectedItems.Cast<Actors>().ToList();

            if (MessageBox.Show($"Вы хотите удалить следующие {actorsForRemoving.Count()} элементов", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DBGoglickEntities.GetContext().Actors.RemoveRange(actorsForRemoving);
                    DBGoglickEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DataGridActors.ItemsSource = DBGoglickEntities.GetContext().Actors.ToList();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }

        private void AddActors_Click(object sender, RoutedEventArgs e)
        {

            this.Close();

            AddActor addwindowActor = new AddActor();
            addwindowActor.ShowDialog();
        }

        private void AddActors_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteActors_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
