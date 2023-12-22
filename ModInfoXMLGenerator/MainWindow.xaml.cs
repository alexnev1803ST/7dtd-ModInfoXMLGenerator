using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;

namespace ModInfoXMLGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }
        private void BTN_Generate_Click(object sender, RoutedEventArgs e) {
            List<string> TextBoxesInput = new List<string> {
                ModName.textBox.Text,
                DisplayNameTextBox.textBox.Text,
                DescriptionTextBox.textBox.Text,
                AuthorTextBox.textBox.Text,
                VersionTextBox.textBox.Text
            };
            InputValidator validator = new InputValidator(TextBoxesInput);
        }
        private void SettingsBTN_Click(object sender, RoutedEventArgs e) {
        }
    }
}
