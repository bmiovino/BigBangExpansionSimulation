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

        public double CalculateEngergy(IExpansionKernel epk)
        {
            double r = (2 * (rand.NextDouble() - 0.5F));

            double res = epk.Clip(epk.EnergyPdf(r) + Energy);
            
            return res;
        }

        public override string ToString()
        {
            return $"Coord ({Coordinate.X},{Coordinate.Y}) - Energy {Energy}";
        }
        
    }
}
