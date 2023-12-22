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
    /// Логика взаимодействия для WindowJobActors.xaml
    /// </summary>
    public partial class WindowJobActors : Window
    {
        public WindowJobActors()
        {
            InitializeComponent();

            DataGridJob.ItemsSource = DBGoglickEntities.GetContext().JobActorsTheatre.ToList();

        }

        private void AddActors_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddJob_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            AddJobWindow addJobWindow = new AddJobWindow();
            addJobWindow.ShowDialog(); 
        }

        private void DeleteJob_Click(object sender, RoutedEventArgs e)
        {
            var jobForRemoving = DataGridJob.SelectedItems.Cast<JobActorsTheatre>().ToList();

            if (MessageBox.Show($"Вы хотите удалить следующие {jobForRemoving.Count()} элементов", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DBGoglickEntities.GetContext().JobActorsTheatre.RemoveRange(jobForRemoving);
                    DBGoglickEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DataGridJob.ItemsSource = DBGoglickEntities.GetContext().JobActorsTheatre.ToList();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
