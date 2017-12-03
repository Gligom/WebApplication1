using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Laboratoare
    {
        public Laboratoare()
        {
            Analize = new HashSet<Analize>();
        }

        public int LaboratorId { get; set; }
        public string NumeLaborator { get; set; }

        public ICollection<Analize> Analize { get; set; }
    }
}
