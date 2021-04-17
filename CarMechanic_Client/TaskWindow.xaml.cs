using Auto_Common.Models;
using CarMechanic_Client.DataProviders;
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

namespace CarMechanic_Client
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        private readonly MClient _mclient;
        public TaskWindow(MClient mclient)
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
                DatePicker.SelectedDate = _mclient.StartingDate;
                ComboBox.Text = _mclient.Status;


                UpdateButton.Visibility = Visibility.Visible;


            }
            else
            {
                _mclient = new MClient();
                
                UpdateButton.Visibility = Visibility.Collapsed;
            }

        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            
            _mclient.FirstName = FirstNameTextBox.Text;
            _mclient.LastName = LastNameTextBox.Text;
            _mclient.CarType = CarTypeTextBox.Text;
            _mclient.LicensePN = LicensePNTextBox.Text;
            _mclient.Description = DescriptionTextBox.Text;
            _mclient.StartingDate = DatePicker.SelectedDate.Value;
            _mclient.Status = ComboBox.Text;


            TaskDataProvider.UpdateMClient(_mclient);

            DialogResult = true;
            Close();
            
        }

       
    }

}
