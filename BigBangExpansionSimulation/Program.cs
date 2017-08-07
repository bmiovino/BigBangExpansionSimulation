using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBangExpansionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Region R = new Region(0.0F, new Coordinate(0, 0));

            Region[] Universe = { R };

            int maxage = 11;


            for(int age = 0; age <= maxage; age++)
            {
                Console.WriteLine($"Universe Age {age}");

                if (age > 0)
                {
                    List<Region> expansion = new List<Region>();

                    foreach (Region r in Universe)
                        expansion.AddRange(r.Expand());

                    Universe = expansion.ToArray();
                }

                Console.WriteLine($"Age {age} of {maxage}");
            }

            //foreach (Region r in Universe)
            //    Console.WriteLine(r.ToString());

            RenderEngine re = new RenderEngine();
            re.Render(@"D:\Git\BigBangExpansionSimulation\Results\parabolic01.png", Universe);

            Console.WriteLine("Done:");
            Console.ReadLine();
        }
    }
}
