using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.BaseData
{
    public class LMainColor
    {
        private int count;
        private string color;
        public LMainColor(string color, int count)
        {
            this.color = color;
            this.count = count;
        }


        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
    }
}
