using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public static class Game
    {
        static private List<Character> characters = new();

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
            new Armor() { Name = "Золотой нагрудник",  Protection = 4},
            new Armor() { Name = "Железный нагрудник", Protection = 6},
            new Armor() { Name = "Алмазный нагрудник", Protection = 8},
        };

        public static void ChooseAction()
        {
            Console.WriteLine( "Что хотите сделать?\n  1. Создать персонажа\n  2. Вывести список персонажей\n  3. Начать битву" );
            Console.Write( "Введите номер действия: " );
            string action = Console.ReadLine();
            Console.WriteLine( "---------------------------------------------" );
            switch ( action )
            {
                case ( "1" ):
                    CreateCharacter( characters );
                    break;
                case ( "2" ):
                    PrintCharacterList();
                    break;
                case ( "3" ):
                    if ( characters.Count > 1 )
                    {
                        StartBattle();
                        Console.WriteLine( "---------------------------------------------" );
                    }
                    else
                    {
                        Console.WriteLine( "Нельзя начать битву, имея менее двух персонажей. Выберите другое действие" );
                    }
                    break;
                default:
                    Console.WriteLine( "Выбрано некорректное действией. Введите действие снова" );
                    Console.WriteLine( "---------------------------------------------" );
                    break;
            }
        }

        static void CreateCharacter( List<Character> characters )
        {
            int characterIndex = characters.Count;
            characters.Add( new Character() { Number = characterIndex + 1 } );
            EnterName( characters[ characterIndex ] );
            characters[ characterIndex ].MyRace = Chooser<Race>.ChooseItemFromArray( races, "расы" );
            characters[ characterIndex ].MyClass = Chooser<Class>.ChooseItemFromArray( classes, "класса" );
            characters[ characterIndex ].MyWeapon = Chooser<Weapon>.ChooseItemFromArray( weapons, "оружия" );
            characters[ characterIndex ].MyArmor = Chooser<Armor>.ChooseItemFromArray( armors, "брони" );
            characters[ characterIndex ].updateHealth();
            Console.Clear();
            characters[ characterIndex ].PrintCharacterStats();
        }

        static void EnterName( Character character )
        {
            Console.Write( "Введите имя персонажа: " );
            character.Name = Console.ReadLine();
            Console.WriteLine( "---------------------------------------------" );
        }

        static void PrintCharacterList()
        {
            Console.Clear();
            foreach ( Character character in characters )
            {
                character.PrintCharacterStats();
            }
        }

        static void StartBattle()
        {
            Battle( EnterCharacterNumbers() );
        }

        static List<Character> EnterCharacterNumbers()
        {
            List<Character> fighters = new() { characters[ 0 ], characters[ 1 ] };
            bool isActionCorrect = false;
            while ( !isActionCorrect )
            {
                isActionCorrect = true;
                try
                {
                    Console.Write( "Введите номер первого бойца: " );
                    string firstFigtherNumber = Console.ReadLine();
                    fighters[ 0 ] = characters[ int.Parse( firstFigtherNumber ) - 1 ];
                    Console.Write( "Введите номер второго бойца: " );
                    string secondFigtherNumber = Console.ReadLine();
                    fighters[ 1 ] = characters[ int.Parse( secondFigtherNumber ) - 1 ];
                    if ( firstFigtherNumber == secondFigtherNumber )
                    {
                        Console.WriteLine( "Боец не может сражаться сам с собой" );
                    }
                }
                catch
                {
                    Console.WriteLine( "Введён некорректный номер бойца" );
                    isActionCorrect = false;
                }
                Console.WriteLine( "---------------------------------------------" );
            }
            return fighters;
        }

        static void Battle( List<Character> fighters )
        {
            Console.WriteLine( "----Начало битвы----" );
            if ( fighters[ 0 ].MyStrength - fighters[ 1 ].MyProtection > 0 || fighters[ 1 ].MyStrength - fighters[ 0 ].MyProtection > 0 )
            {
                Console.WriteLine( $"Победил {fighters[ 0 ].Attack( fighters[ 1 ] ).Name}" );
            }
            else
            {
                Console.WriteLine( "Ничья" );
            }
        }
    }
}