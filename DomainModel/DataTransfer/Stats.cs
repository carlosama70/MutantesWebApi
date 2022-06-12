using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DataTransfer
{
    public class Stats
    {
        public int Count_mutant_dna { get; set; }
        public int Count_human_dna { get; set; }
        public double Ratio { get; set; }
    }
}
