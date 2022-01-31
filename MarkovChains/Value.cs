using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovChains
{
    class Value
    {
        public List<string> Words = new();

        public List<int> CountWordOf = new();

        public int GetCountAll()
        {
            int sum = 0;

            foreach(var count in CountWordOf)
            {
                sum += count;
            }

            return sum;
        }
    }
}
