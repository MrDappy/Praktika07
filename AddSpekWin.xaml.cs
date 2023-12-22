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
    /// Логика взаимодействия для AddSpekWin.xaml
    /// </summary>
    public partial class AddSpekWin : Window
    {

        private Spektakli _currentSpek = new Spektakli();

        public AddSpekWin()
        {
            InitializeComponent();

            DataContext = _currentSpek;
        }

        private void AddNewSpek_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentSpek.Budget == null)
                errors.AppendLine("Введите бюджет спектакля");




            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentSpek.ID_spektaklya == 0)
                DBGoglickEntities.GetContext().Spektakli.Add(_currentSpek);
            try
            {
                DBGoglickEntities.GetContext().SaveChanges();
                MessageBox.Show("Спектакль добавлен");


                this.Close();


                WindowSpectakli windowSpectakli = new WindowSpectakli();
                windowSpectakli.ShowDialog();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
