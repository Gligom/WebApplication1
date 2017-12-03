using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class AnalizeEvaluari
    {
        public int Id { get; set; }
        public int EvaluareId { get; set; }
        public int AnalizaId { get; set; }

        public Analize Analiza { get; set; }
        public EvaluariPacienti Evaluare { get; set; }
    }
}
