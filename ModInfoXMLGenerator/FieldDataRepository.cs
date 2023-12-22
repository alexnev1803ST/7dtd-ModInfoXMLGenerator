using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModInfoXMLGenerator
{
    internal static  class FieldDataRepository
    {
        public static  List<string> AcceptedFields { get; private set; } = new List<string>() {
            "Name",
            "DisplayName",
            "Description",
            "Author",
            "Version"
        };

        public static string filePath;
        
        public static void AddField(string _fieldToAddByName) {
            AcceptedFields.Add(_fieldToAddByName);
        }
    }
}
