using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    internal class Game
    {
        static private Class[] classes = {
            new Class() { Name = "Воин", Health = 20, Strength = 3 },
            new Class() { Name = "Лучник", Health = 15, Strength = 1 },
            new Class() { Name = "Волшебник", Health = 15, Strength = 3 },
            new Class() { Name = "Бард", Health = 10, Strength = 0 }
        };

        static private Race[] races =
        {
            new Race() { Name = "Человек", Health = 10, Strength = 2, Protection = 5 },
            new Race() { Name = "Эльф", Health = 15, Strength = 1, Protection = 3 },
            new Race() { Name = "Дворф", Health = 10, Strength = 2, Protection = 7 },
            new Race() { Name = "Орк", Health = 17, Strength = 3, Protection = 3 },
        };

        static private Weapon[] weapons =
        {
            new Weapon() { Name = "Алмазный меч", Strength = 7},
            new Weapon() { Name = "Деревянный Лук",  Strength = 5},
            new Weapon() { Name = "Волшебная палочка", Strength = 8},
            new Weapon() { Name = "Гитара Егора Летова", Strength = 6},
        };

        static private Armor[] armors =
        {
            new Armor() { Name = "Кожанный нагрудник", Protection = 3},
            new Armor() { Name = "Золотоцй нагрудник",  Protection = 4},
            new Armor() { Name = "Железный нагрудник", Protection = 6},
            new Armor() { Name = "Алмазный нагрудник", Protection = 8},
        };

        public static void ChoseAction( List<Character> characters )
        {
            Console.WriteLine( "Что хотите сделать?\n  1. Создать персонажа\n  2. Начать битву" );
            bool isActionCorrect = false;
            while ( !isActionCorrect )
            {
                isActionCorrect = true;
                string action = Console.ReadLine();
                switch ( action )
                {
                    case ( "1" ):
                        CreateCharacter( characters );
                        break;
                    case ( "2" ):
                        if ( characters.Count > 1 )
                        {
                            Console.WriteLine( "Battle" );
                        }
                        else
                        {
                            Console.WriteLine( "Нельзя начать битву, имея менее двух персонажей. Выберите другое действие" );
                            isActionCorrect = false;
                        }
                        break;
                    default:
                        isActionCorrect = false;
                        Console.WriteLine( "Выбрано некорректное действией. Введите действие снова" );
                        break;
                }
            }
        }

        static void CreateCharacter( List<Character> characters )
        {
            int characterIndex = characters.Count;
            characters.Add( new Character() );
            EnterName( characters[ characterIndex ] );
            characters[ characterIndex ].MyRace = ChooseItemFromArray( races, "расы" );
            characters[ characterIndex ].MyClass = ChooseItemFromArray( classes, "класса" );
            characters[ characterIndex ].MyWeapon = ChooseItemFromArray( weapons, "оружия" ); //try get sets
            characters[ characterIndex ].MyArmor = ChooseItemFromArray( armors, "брони" );
            PrintCharacterStats( characters[ characterIndex ] );
        }

        static void EnterName( Character character )
        {
            Console.Write( "Введите имя персонажа: " );
            character.Name = Console.ReadLine();
            Console.WriteLine( "---------------------------------------------" );
        }

        static Class ChooseItemFromArray( Class[] array, string chooseItemName )
        {
            Console.WriteLine( $"Выберите {chooseItemName} из списка ниже" );
            printArray( array );
            bool isActionCorrect = false;
            Class result = new();
            while ( !isActionCorrect )
            {
                try
                {
                    Console.Write( $"Введите номер {chooseItemName}: " );
                    string itemNum = Console.ReadLine();
                    result = array[ int.Parse( itemNum ) - 1 ];
                    isActionCorrect = true;
                }
                catch
                {
                    Console.WriteLine( $"Введён некоректный номер {chooseItemName}" );
                }
            }
            Console.WriteLine( "---------------------------------------------" );
            return result;
        }

        static Weapon ChooseItemFromArray( Weapon[] array, string chooseItemName )
        {
            Console.WriteLine( $"Выберите {chooseItemName} из списка ниже" );
            printArray( array );
            bool isActionCorrect = false;
            Weapon result = new();
            while ( !isActionCorrect )
            {
                try
                {
                    Console.Write( $"Введите номер {chooseItemName}: " );
                    string itemNum = Console.ReadLine();
                    result = array[ int.Parse( itemNum ) - 1 ];
                    isActionCorrect = true;
                }
                catch
                {
                    Console.WriteLine( $"Введён некоректный номер {chooseItemName}" );
                }
            }
            Console.WriteLine( "---------------------------------------------" );
            return result;
        }

        static Armor ChooseItemFromArray( Armor[] array, string chooseItemName )
        {
            Console.WriteLine( $"Выберите {chooseItemName} из списка ниже" );
            for ( int i = 1; i <= array.Length; i++ )
            {
                Console.WriteLine( $"{i}. {array[ i - 1 ].Name}" );
            }
            bool isActionCorrect = false;
            Armor result = new();
            while ( !isActionCorrect )
            {
                try
                {
                    Console.Write( $"Введите номер {chooseItemName}: " );
                    string itemNum = Console.ReadLine();
                    result = array[ int.Parse( itemNum ) - 1 ];
                    isActionCorrect = true;
                }
                catch
                {
                    Console.WriteLine( $"Введён некоректный номер {chooseItemName}" );
                }
            }
            Console.WriteLine( "---------------------------------------------" );
            return result;
        }
    }
}