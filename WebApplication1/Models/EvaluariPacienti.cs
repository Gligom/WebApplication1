using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class EvaluariPacienti
    {
        public EvaluariPacienti()
        {
            AnalizeEvaluari = new HashSet<AnalizeEvaluari>();
        }

        public int EvaluareId { get; set; }
        public DateTime DataEvaluare { get; set; }
        public string NumePacient { get; set; }
        public string PrenumePacient { get; set; }
        public DateTime DataNasterii { get; set; }
        public string Observatii { get; set; }

        public ICollection<AnalizeEvaluari> AnalizeEvaluari { get; set; }
    }
}
