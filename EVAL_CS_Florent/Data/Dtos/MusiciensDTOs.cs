using System;
using System.Collections.Generic;

#nullable disable

namespace ECF.Data.Dtos
{
    public class MusiciensDTOIn
    {
        public int IdMusicien { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Instrument { get; set; }
        public int IdGroupe { get; set; }
    }
    public class MusiciensDTOOut
    {
        public int IdMusicien { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Instrument { get; set; }
    }

    public class MusiciensDTOOutAvecGroupe
    {
        public int IdMusicien { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Instrument { get; set; }
        public int IdGroupe { get; set; }
        public string NomDuGroupe { get; set; }
    }
}
