using Microsoft.Win32;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ModInfoXMLGenerator
{
    internal class InputValidator {
        ModInfoFileGenerator fileGenerator = new ModInfoFileGenerator();
        ExeptionHandler exeptionHandler = new ExeptionHandler();
        List<string> _fieldsNeededToBeFilled = new List<string>() {
            "Name", "Author", "Version"
        };

        public InputValidator(List<string> _inputValues)
        {
            ValidateNeededFields(_inputValues);
        }

        public void ValidateNeededFields(List<string> _inputValues) {
            for (int i = 0; i < _fieldsNeededToBeFilled.Count; i++) {
                string fieldName = _fieldsNeededToBeFilled[i];
                string nullCheck = _inputValues[GetElementIndex(fieldName)];
                if (string.IsNullOrEmpty(nullCheck)) {
                    exeptionHandler.Exeption(fieldName, 1);
                    break;
                }
                if (i == _fieldsNeededToBeFilled.Count - 1) 
                    ValidateNumericANDEmptyInputs(_inputValues);   
            }
        }

        int GetElementIndex(string fieldName) {
            List<string> data = FieldDataRepository.AcceptedFields;
            if (data.Contains(fieldName))
                return data.IndexOf(fieldName);

            return -1;
        }
        private void StartGeneration(List<string> _inputValues) {
            fileGenerator.GenerateFile(_inputValues);
        }
        private void ValidateNumericANDEmptyInputs(List<string> _inputValues) {
            _inputValues = TestOnUnusedSymbols(_inputValues);
            bool valuesAccepted = TestNumericFields(_inputValues);
            if (valuesAccepted) {
                if (ValidateFilePath())
                    StartGeneration(_inputValues);
            }
        }

        private bool ValidateFilePath() {
            SaveFileDialog fileSave = new SaveFileDialog();
            fileSave.FileName = "ModInfo.xml";
            fileSave.ShowDialog();
            if (fileSave.FileName.Contains(@"\ModInfo.xml")) {
                FieldDataRepository.filePath = fileSave.FileName;
                return true;
            } else {
                exeptionHandler.Exeption(1);
                return false;
            }
        }

        private List<string> TestOnUnusedSymbols(List<string> _inputValues) {
            _inputValues[0] = _inputValues[0].Replace(" ", "_");
            return _inputValues;
        }
        private bool TestNumericFields(List<string> _inputValues) {
            Regex RgxUrl = new Regex("[^a-z. #%$^:;@!?/}{*]");
            bool test = RgxUrl.IsMatch(_inputValues[4]);
            if (!test) {
                exeptionHandler.Exeption("Version", 2);
                return false;
            } else 
                return true;
        }

    } 
}
