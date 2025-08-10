using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public class Character
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

        public Race MyRace;
        public Class MyClass;
        public Weapon MyWeapon;
        public Armor MyArmor;
        public int Protection = 0;

        public int MyHealth = 0;
        public int MyStrength => MyRace.Strength + MyClass.Strength;
        public int MyProtection => MyRace.Protection + Protection;

        public void updateHealth()
        {
            MyHealth = MyRace.Health + MyClass.Health;
        }

        public void PrintCharacterStats()
        {
            Console.WriteLine( $"Ваш персонаж :" +
                $"\n- Имя:    {Name}" +
                $"\n- Раса:   {MyRace.Name}" +
                $"\n- Класс:  {MyClass.Name}" +
                $"\n- Оружие: {MyWeapon.Name}" +
                $"\n- Броня:  {MyArmor.Name}\n---------------------------------------------" );
        }

        //public IFighter Attack( IFighter[] characters, int characterIndex )
        //{
        //    if ( characterIndex + 2 <= characters.Length )
        //    {
        //        return 
        //    }
        //}
        public Character Attack( Character defender )
        {
            defender.MyHealth -= Math.Max( MyStrength - defender.MyProtection, 0 );
            if ( defender.MyHealth > 0 )
            {
                Console.WriteLine( MyHealth );
                Console.WriteLine( defender.MyHealth );
                return defender.Attack( this ); // Рекурсия видимо ¯\_(ツ)_/
            }
            return this;
        }

        public void CheckStats( Character defender )
        {

        }
    }
}
