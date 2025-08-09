using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    internal class Character
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
        public Race MyRace = new Race();
        public Class MyClass = new Class();
        public Weapon MyWeapon = new Weapon();
        public Armor MyArmor = new Armor();
        int Protection = 0;
        int MyHealth => MyRace.Health + MyClass.Health;
        int MyStrength => MyRace.Strength + MyClass.Strength;
        int MyProtection => MyRace.Protection + Protection;

        public void PrintCharacterStats()
        {
            Console.WriteLine( $"Ваш персонаж :" +
                $"\n- Имя: {Name}" +
                $"\n- Раса: {MyRace.Name}" +
                $"\n- Класс: {MyClass.Name}" +
                $"\n- Оружие: {MyWeapon.Name}" +
                $"\n- Броня: {MyArmor.Name}" );
        }
    }
}
