﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Profile
    {
        public Profile()
        {
            ProfileAnalize = new HashSet<ProfileAnalize>();
        }

        public int ProfilId { get; set; }
        public string ProfilNume { get; set; }

        public ICollection<ProfileAnalize> ProfileAnalize { get; set; }
    }
}
