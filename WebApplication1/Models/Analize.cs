using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Analize
    {
        public Analize()
        {
            AnalizeEvaluari = new HashSet<AnalizeEvaluari>();
            ProfileAnalize = new HashSet<ProfileAnalize>();
        }

        public int AnalizaId { get; set; }
        public string NumeAnaliza { get; set; }
        public int LaboratorId { get; set; }

        public Laboratoare Laborator { get; set; }
        public ICollection<AnalizeEvaluari> AnalizeEvaluari { get; set; }
        public ICollection<ProfileAnalize> ProfileAnalize { get; set; }
    }
}
