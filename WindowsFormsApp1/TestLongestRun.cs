using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class TestLongestRun
    {
        public double actually = 0; 
        public double maxLength = 150000;
        public bool workFinished = false;


        public void runTest()
        {
            workFinished = false;
            actually = 0;
            while (actually <= maxLength)
            {
                actually += 0.001;

            }
            workFinished = true;

        }

    }
}
