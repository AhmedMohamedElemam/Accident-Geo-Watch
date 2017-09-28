using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aciident_Geo_Watch
{
    class ClassLabel
    {
        public int id;
        public String name;
        public double prob;
        public int length;
        public void Set_Class_label(int i, String n, double p, int l)
        {
            name = n;
            id = i;
            prob = p;
            length = l;
        }
        public void update_prob(double p)
        {
            prob = p;
        }
        public void update_length(int l)
        {
            length = l;
        }
    }
}
