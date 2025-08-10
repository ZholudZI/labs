using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public class Character : IFighter
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

        public int Number;
        public Race MyRace;
        public Class MyClass;
        public Weapon MyWeapon;
        public Armor MyArmor;

        public int MyHealth { get; set; }
        public int MyStrength => MyRace.Strength + MyClass.Strength + MyWeapon.Strength;
        public int MyProtection => MyRace.Protection + MyArmor.Protection;

        public void updateHealth()
        {
            MyHealth = MyRace.Health + MyClass.Health;
        }

        public void PrintCharacterStats()
        {
            Console.WriteLine( $"Ваш персонаж :" +
                $"\n- Имя:    {Name}" +
                $"\n- Номер:  {Number}" +
                $"\n- Раса:   {MyRace.Name}" +
                $"\n- Класс:  {MyClass.Name}" +
                $"\n- Оружие: {MyWeapon.Name}" +
                $"\n- Броня:  {MyArmor.Name}\n---------------------------------------------" );
        }

        public IFighter Attack( IFighter defender )
        {
            defender.MyHealth -= Math.Max( MyStrength - defender.MyProtection, 0 );
            CheckStats( defender );
            Console.ReadKey();
            if ( defender.MyHealth > 0 )
            {
                return defender.Attack( this ); // Рекурсия видимо ¯\_(ツ)_/¯ Тесты может написать?
            }
            return this;
        }

        public void CheckStats( IFighter defender )
        {
            Console.WriteLine( $"{Name} нанёс {Math.Max( MyStrength - defender.MyProtection, 0 )} урона. Его здоровье {MyHealth}" );
        }
    }
}
