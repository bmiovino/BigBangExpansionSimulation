using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace BigBangExpansionSimulation
{
    public class Region
    {
        static Random rand = new Random();

        public Region(double energy, Coordinate coordinate)
        {
            Energy = energy;
            Coordinate = coordinate;
        }

        public Coordinate Coordinate;
        public double Energy = 0.0;

        public Region[] Expand(IExpansionKernel epk)
        {
            Region[] regions = new Region[4];

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    regions[j * 2 + i] = 
                        new Region(CalculateEngergy(epk),
                        new Coordinate(i + (Coordinate.X * 2), j + (Coordinate.Y * 2)));

            return regions;
        }

        /// <summary>
        /// bias will induce clipping and max/min energy
        /// </summary>
        /// <returns></returns>
        public double CalculateEngergy(IExpansionKernel epk)
        {
            double res = 0.0F;

            //rand 0-1 => 2r -1.0
            //input to => 3/4(n-(n^3/3))+1/2)

            double r = (2 * (rand.NextDouble() - 0.5F)) + Energy;

            if (r > 1.0)
                r = 1.0;
            else if (r < -1.0)
                r = -1.0;

            res = epk.EnergyPdf(r);
            
            return res;
        }

        public override string ToString()
        {
            return $"Coord ({Coordinate.X},{Coordinate.Y}) - Energy {Energy}";
        }
    }
}
