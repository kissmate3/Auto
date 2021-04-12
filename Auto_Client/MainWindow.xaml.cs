using Auto_Client.DataProviders;
using Auto_Common.Models;
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

namespace Auto_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs args) {

            var selectedMClient = ClientsListBox.SelectedItem as MClient;

            if (selectedMClient != null)
            {
                var window = new MClientWindow(selectedMClient);
                if (window.ShowDialog() ?? false)
                {
                    UpdatePeopleListBox();
                }

                ClientsListBox.UnselectAll();
            }
        }

        private void AddCLient_Click(object sender, RoutedEventArgs args) {

            var window = new MClientWindow(null);
            if (window.ShowDialog() ?? false)
            {
                UpdatePeopleListBox();
            }
        }


        private void UpdatePeopleListBox()
        {
            var people = MClientDataProvider.MClient().ToList();
            ClientsListBox.ItemsSource = people;
        }
    }
}
