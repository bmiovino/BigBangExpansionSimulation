using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBangExpansionSimulation
{
    public class Universe
    {
        public static Region[] Normalize(Region[] universe)
        {
            double min = Math.Abs((from u in universe select u.Energy).Min());
            double max = Math.Abs((from u in universe select u.Energy).Max());

            Region[] cloneUniverse = (Region[])universe.Clone();

            foreach(Region r in cloneUniverse)
            {
                if (r.Energy < 0)
                    r.Energy /= min;
                else
                    r.Energy /= max;
            }

            return cloneUniverse;
        }
    }
}
