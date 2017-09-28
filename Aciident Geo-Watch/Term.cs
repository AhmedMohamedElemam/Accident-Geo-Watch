using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aciident_Geo_Watch
{
    class Term
    {
        public int id;
        public String name;
        public double[] prob = new double[5];

        public void Set_term(String n, int i, double[] p)
        {
            name = n;
            id = i;

            for (int j = 0; j < 5; j++)
            {
                prob[j] = p[j];
            }
        }
        public void update_prob(double[] p)
        {
            for (int j = 0; j < 5; j++)
            {
                prob[j] = p[j];
            }
        }
    }
}
