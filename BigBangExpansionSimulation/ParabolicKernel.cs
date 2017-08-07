using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBangExpansionSimulation
{
    public class ParabolicKernel : IExpansionKernel
    {
        public double Delta = 1.0F;

        public bool IsClipped;

        public ParabolicKernel(double delta, bool isClipped = false)
        {
            this.Delta = delta;
            this.IsClipped = isClipped;
        }

        public double Clip(double r)
        {
            if(IsClipped)
                if (r > 1.0)
                    r = 1.0;
                else if (r < -1.0)
                    r = -1.0;

            return r;
        }
        
        public double EnergyPdf(double r)
        {
            if (Math.Abs(r) > Delta)
                return 0;

            return ((0.75F / Delta) * (r - (Math.Pow(r, 3) / (3.0F * Math.Pow(Delta, 2)) ))) + 0.5F;
        }
    }
}
