using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ProfileAnalize
    {
        public int ProfilId { get; set; }
        public int AnalizaId { get; set; }

        public Analize Analiza { get; set; }
        public Profile Profil { get; set; }
    }
}
