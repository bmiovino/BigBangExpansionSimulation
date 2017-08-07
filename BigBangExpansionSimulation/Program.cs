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

            Region[] universe = { R };
            
            Console.Write("max age: ");
            int maxage = int.Parse(Console.ReadLine());

            Console.Write("Delta 0.0 to 1.0: ");
            double delta = double.Parse(Console.ReadLine());

            if (maxage > 11)
                throw new Exception("Max age of 11 allowed.");

            IExpansionKernel epk = new ParabolicKernel(delta);

            for (int age = 0; age <= maxage; age++)
            {
                Console.WriteLine($"Universe Age {age}");

                if (age > 0)
                {
                    List<Region> expansion = new List<Region>();

                    foreach (Region r in universe)
                        expansion.AddRange(r.Expand(epk));

                    universe = expansion.ToArray();
                }
                
                Console.WriteLine($"Age {age} of {maxage}");
            }

            RenderEngine re = new RenderEngine();
            re.Render($"D:\\Git\\BigBangExpansionSimulation\\Results\\parabolic_{maxage}.png", Universe.Normalize(universe));
            
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
