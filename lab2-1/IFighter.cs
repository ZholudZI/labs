using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public interface IFighter
    {
        public string Name { get; set; }
        public int MyHealth { get; set; }
        public int MyStrength { get; }
        public int MyProtection { get; }
        public IFighter Attack( IFighter defender );
    }
}
