class Program
{
    static void Main( string[] args )
    {
        const int SWAP = 1;

        //Съешь ещё этих мягких французских булок, да выпей же чаю - все буквы русского алфавита
        //The quick brown fox jumps over the lazy dog - все буквы английского алфавита
        string russianCode = ToCaesarCipher( "Съешь ещё этих мягких французских булок, да выпей же чаю", SWAP );
        string englishCode = ToCaesarCipher( "The quick brown fox jumps over the lazy dog", SWAP );
        Console.WriteLine( russianCode );
        Console.WriteLine( englishCode );
        Console.WriteLine( "-------------------------------------------------------------------------------" );
        Console.WriteLine( ToNormalText( russianCode, SWAP ) );
        Console.WriteLine( ToNormalText( englishCode, SWAP ) );
    }

    private static string russianAlphabetBig = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    private static string russianAlphabetSmall = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

    private static string ToCaesarCipher( string str, int swap )
    {
        string result = "";
        foreach ( char ch in str )
        {
            if ( 'A' <= ch && ch <= 'Z' )
            {
                result += ( char )( 65 + ( ch - 65 + swap ) % 26 );
            }
            else if ( 'a' <= ch && ch <= 'z' )
            {
                result += ( char )( 97 + ( ch - 97 + swap ) % 26 );
            }
            else if ( 'А' <= ch && ch <= 'Я' || ch == 'Ё' )
            {
                result += russianAlphabetBig[ ( russianAlphabetBig.IndexOf( ch ) + swap ) % 33 ];
            }
            else if ( 'а' <= ch && ch <= 'я' || ch == 'ё' )
            {
                result += russianAlphabetSmall[ ( russianAlphabetSmall.IndexOf( ch ) + swap ) % 33 ];
            }
            else
            {
                result += ch;
            }
        }
        return result;
    }

    private static string ToNormalText( string str, int swap )
    {
        string result = "";
        foreach ( char ch in str )
        {
            if ( 'A' <= ch && ch <= 'Z' )
            {
                result += ( char )( 65 + ( ch - 65 - swap % 26 + 26 ) % 26 );
            }
            else if ( 'a' <= ch && ch <= 'z' )
            {
                result += ( char )( 97 + ( ch - 97 - swap % 26 + 26 ) % 26 );
            }
            else if ( 'А' <= ch && ch <= 'Я' || ch == 'Ё' )
            {
                result += russianAlphabetBig[ ( russianAlphabetBig.IndexOf( ch ) - swap % 33 + 33 ) % 33 ];
            }
            else if ( 'а' <= ch && ch <= 'я' || ch == 'ё' )
            {
                result += russianAlphabetSmall[ ( russianAlphabetSmall.IndexOf( ch ) - swap % 33 + 33 ) % 33 ];
            }
            else
            {
                result += ch;
            }
        }
        return result;
    }
}