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
using System.Windows.Shapes;

namespace Auto_Client
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        private readonly MClient _mclient;
        private string _pn;
        public Search(object p)
        {
            InitializeComponent();
        }


        private void SearchPN_Click(object sender, RoutedEventArgs args)
        {
            if (Validate()) {
                _pn = CarLicensePN.Text;
                var aclient = MClientDataProvider.MClient().Where(x => x.LicensePN == _pn).ToList();
                SearchListBox.ItemsSource = aclient;
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(CarLicensePN.Text))
            {
                MessageBox.Show(" License PN should not be empty.");
                return false;
            }

            return true;
        }
    }
}

