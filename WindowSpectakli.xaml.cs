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
    /// Логика взаимодействия для WindowSpectakli.xaml
    /// </summary>
    public partial class WindowSpectakli : Window
    {
        public WindowSpectakli()
        {
            InitializeComponent();

            var currentSpectakli = DBGoglickEntities.GetContext().Spektakli.ToList();
            LViewSpectakli.ItemsSource = currentSpectakli;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            AddSpekWin addSpekWin = new AddSpekWin();
            addSpekWin.ShowDialog();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            var spekForRemoving = LViewSpectakli.SelectedItems.Cast<Spektakli>().ToList();

            if (MessageBox.Show($"Вы хотите удалить следующие {spekForRemoving.Count()} элементов", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DBGoglickEntities.GetContext().Spektakli.RemoveRange(spekForRemoving);
                    DBGoglickEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    LViewSpectakli.ItemsSource = DBGoglickEntities.GetContext().Spektakli.ToList();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
