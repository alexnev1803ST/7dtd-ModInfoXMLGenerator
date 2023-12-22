using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ModInfoXMLGenerator.View.UserControls
{
    public partial class CheckableTextBox : UserControl
    {
        public CheckableTextBox() {
            InitializeComponent();
        }

        private string _placeholderText;
        public string placeholderText {
            get { return _placeholderText; }
            set { 
                _placeholderText = value;
                textBox_Placeholder.Text = _placeholderText;
            }
        }

        private void checkBox_Click(object sender, RoutedEventArgs e) {
            if (checkBox.IsChecked == true)
                textBox.IsEnabled = true;
            else {
                textBox.IsEnabled = false;
                textBox.Clear();
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e) {
            if (!string.IsNullOrEmpty(textBox.Text)) 
                textBox_Placeholder.Visibility = Visibility.Hidden;
            else 
                textBox_Placeholder.Visibility= Visibility.Visible;
        }
    }
}
