using System.Windows;

namespace ModInfoXMLGenerator
{
    internal class ExeptionHandler
    {
        public void Exeption(string _fieldName, int _errorCode) {
            switch (_errorCode) {
                case 1: 
                    MessageBox.Show($"You need to fill field :{_fieldName}: to generate file");
                    break;
                case 2:
                    MessageBox.Show($"Field :{_fieldName}: need to be field with numeric data like 0.1, 0.0.1 etc.");
                    break;

            }
        }
        public void Exeption(int _errorCode) {
            switch ( _errorCode) {
                case 1:
                    MessageBox.Show("File name needs to be ModInfo.xml");
                    break;
            }
        }
    }
}
