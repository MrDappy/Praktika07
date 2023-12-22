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
    /// Логика взаимодействия для AddActor.xaml
    /// </summary>
    public partial class AddActor : Window
    {

        private Actors _currentActors = new Actors();

        public AddActor()
        {
            InitializeComponent();

            DataContext = _currentActors;
            CmbRank.ItemsSource = DBGoglickEntities.GetContext().Actors.ToList();
        }

        private void AddNewActor_Click(object sender, RoutedEventArgs e)
        {
        
                StringBuilder errors = new StringBuilder();

                if (_currentActors.Surname == null)
                    errors.AppendLine("Введите фамилию клиента");

                if (_currentActors.Name == null)
                    errors.AppendLine("Введите имя клиента");

                if (_currentActors.Middlename == null)
                    errors.AppendLine("Введите отчество клиента");

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;

                }
                if (_currentActors.ID_actor == 0)
                    DBGoglickEntities.GetContext().Actors.Add(_currentActors);
                try
                {
                    DBGoglickEntities.GetContext().SaveChanges();
                    MessageBox.Show("Актер добавлен");


                    this.Close();


                    WindowActors windowActors = new WindowActors();
                    windowActors.ShowDialog();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
          
        }
    }
}
