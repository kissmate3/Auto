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
    /// Interaction logic for MClientWindow.xaml
    /// </summary>
    public partial class MClientWindow : Window
    {
        private readonly MClient _mclient;
        public MClientWindow(MClient mclient)
        {
            InitializeComponent();

            if (mclient != null)
            {
                _mclient = mclient;

                FirstNameTextBox.Text = _mclient.FirstName;
                LastNameTextBox.Text = _mclient.LastName;
                CarTypeTextBox.Text = _mclient.CarType;
                LicensePNTextBox.Text = _mclient.LicensePN;
                DescriptionTextBox.Text = _mclient.Description;
                //DatePicker.SelectedDate = _mclient.StartingDate;
                ComboBox.Text = _mclient.Status;

                CreateButton.Visibility = Visibility.Collapsed;
                UpdateButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
            }
            else
            {
                _mclient = new MClient();

                CreateButton.Visibility = Visibility.Visible;
                UpdateButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateMclient())
            {
                _mclient.FirstName = FirstNameTextBox.Text;
                _mclient.LastName = LastNameTextBox.Text;
                _mclient.CarType = CarTypeTextBox.Text;
                _mclient.LicensePN = LicensePNTextBox.Text;
                _mclient.Description = DescriptionTextBox.Text;
                _mclient.StartingDate = DateTime.Now;
                //MessageBox.Show(DateTime.Now.ToString());
                _mclient.Status = "New work";

                MClientDataProvider.CreateMClient(_mclient);

                DialogResult = true;
                Close();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            if (ValidateMclient())
            {
                _mclient.FirstName = FirstNameTextBox.Text;
                _mclient.LastName = LastNameTextBox.Text;
                _mclient.CarType = CarTypeTextBox.Text;
                _mclient.LicensePN = LicensePNTextBox.Text;
                _mclient.Description = DescriptionTextBox.Text;
                //_mclient.StartingDate = DatePicker.SelectedDate.Value;
                _mclient.Status = ComboBox.Text;

                MClientDataProvider.UpdateMClient(_mclient);

                DialogResult = true;
                Close();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MClientDataProvider.DeleteMClient(_mclient.Id);

                DialogResult = true;
                Close();
            }
        }

        private bool ValidateMclient()
        {
            if (string.IsNullOrEmpty(FirstNameTextBox.Text))
            {
                MessageBox.Show("First name should not be empty.");
                return false;
            }

            if (string.IsNullOrEmpty(LastNameTextBox.Text))
            {
                MessageBox.Show("Last name should not be empty.");
                return false;
            }

            if (string.IsNullOrEmpty(CarTypeTextBox.Text))
            {
                MessageBox.Show("Car type should not be empty.");
                return false;
            }

            if (string.IsNullOrEmpty(LicensePNTextBox.Text))
            {
                MessageBox.Show("License PN should not be empty.");
                return false;
            }

            if (string.IsNullOrEmpty(DescriptionTextBox.Text))
            {
                MessageBox.Show("Descriptions should not be empty.");
                return false;
            }
            /*
            if (!DatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a date.");
                return false;
            }*/

            return true;
        }
    }
}
