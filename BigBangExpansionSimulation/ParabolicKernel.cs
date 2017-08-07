using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBangExpansionSimulation
{
    public class ParabolicKernel : IExpansionKernel
    {
        public double EnergyPdf(double r)
        {
            return (0.75F * (r - (Math.Pow(r, 3) / 3.0F))) + 0.5F;
        }
    }
}
