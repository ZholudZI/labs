using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public class Armor : IChooseableItem
    {
        private string _name = "Unnamed";
        public string Name
        {
            get => _name;
            set
            {
                if ( !String.IsNullOrEmpty( value ) )
                {
                    _name = value;
                }
            }
        }
        public int Protection = 0;
    }
}
