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
    /// Логика взаимодействия для AddJobWindow.xaml
    /// </summary>
    public partial class AddJobWindow : Window
    {

        private JobActorsTheatre _currentJob = new JobActorsTheatre();

        public AddJobWindow()
        {
            InitializeComponent();

            DataContext = _currentJob;

            CmbActor.ItemsSource = DBGoglickEntities.GetContext().Actors.ToList();
            CmbSpek.ItemsSource = DBGoglickEntities.GetContext().Spektakli.ToList();
        }

        private void AddNewJob_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentJob.CostContract == null)
                errors.AppendLine("Выберите сумму контракта");




            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

                if (_currentJob.ID_job == 0)
                DBGoglickEntities.GetContext().JobActorsTheatre.Add(_currentJob);
            try
            {
                DBGoglickEntities.GetContext().SaveChanges();
                MessageBox.Show("Занятость добавлена");


                this.Close();


                WindowJobActors windowJobActors = new WindowJobActors();
                windowJobActors.ShowDialog();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
