using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ModInfoXMLGenerator
{
    internal class ModInfoFileGenerator
    {

        public void GenerateFile(List<string> _inputValues) {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", null));

            XElement mainNode = new XElement("xml");
            doc.Add(mainNode);

            for (int i = 0; i < FieldDataRepository.AcceptedFields.Count; i++) {
                if (!string.IsNullOrEmpty(_inputValues[i])) {
                    XElement elem = new XElement(
                        FieldDataRepository.AcceptedFields[i],
                        new XAttribute("value", _inputValues[i]));
                    mainNode.Add(elem);
                }
            }

            doc.Save(FieldDataRepository.filePath);
        }
    }
}
