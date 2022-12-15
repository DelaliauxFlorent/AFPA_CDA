using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_PremierCRUD
{
    class FichierJSON
    {
        public String LireJSON(String fichier)
        {
            using (StreamReader r = new StreamReader(fichier))
            {
                String json = r.ReadToEnd();
                return json;
            }
        }
    }
}
