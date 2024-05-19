using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExtendedContacts
{
    [Serializable]
    public class Contact
    {
        public string ImagePath { get; set; } = DefaultImgPath();
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public DateTime DateOfBitrh { get; set; } = DateTime.MinValue;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        protected static string DefaultImgPath()
        {
            string programPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string programDirectory = System.IO.Path.GetDirectoryName(programPath);
            for (int i = 0; i < 3; i++)
            {
                int position = programDirectory.LastIndexOf("\\");
                if (position > -1)
                    programDirectory = programDirectory.Substring(0, position);
            }
            return $"{programDirectory}\\img.png";
        }
    }
}
