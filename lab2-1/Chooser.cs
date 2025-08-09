using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public static class Chooser<T> where T : IChooseableItem, new()
    {
        public static T ChooseItemFromArray( T[] array, string chooseItemName )
        {
            T result = new();
            Console.WriteLine( $"Выберите {chooseItemName} из списка ниже" );
            for ( int i = 1; i <= array.Length; i++ )
            {
                Console.WriteLine( $"{i}. {array[ i - 1 ].Name}" );
            }
            bool isActionCorrect = false;
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
