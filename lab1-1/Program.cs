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
                const int firstLetterCode = 65;
                const int alpthabetLength = 26;
                result += ( char )( firstLetterCode + ( ch - firstLetterCode + swap ) % alpthabetLength );
            }
            else if ( 'a' <= ch && ch <= 'z' )
            {
                const int firstLetterCode = 97;
                const int alpthabetLength = 26;
                result += ( char )( firstLetterCode + ( ch - firstLetterCode + swap ) % alpthabetLength );
            }
            else if ( 'А' <= ch && ch <= 'Я' || ch == 'Ё' )
            {
                const int alpthabetLength = 33;
                result += russianAlphabetBig[ ( russianAlphabetBig.IndexOf( ch ) + swap ) % alpthabetLength ];
            }
            else if ( 'а' <= ch && ch <= 'я' || ch == 'ё' )
            {
                const int alpthabetLength = 33;
                result += russianAlphabetSmall[ ( russianAlphabetSmall.IndexOf( ch ) + swap ) % alpthabetLength ];
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
                const int firstLetterCode = 65;
                const int alpthabetLength = 26;
                result += ( char )( firstLetterCode + ( ch - firstLetterCode - swap % alpthabetLength + alpthabetLength ) % alpthabetLength );
            }
            else if ( 'a' <= ch && ch <= 'z' )
            {
                const int firstLetterCode = 97;
                const int alpthabetLength = 26;
                result += ( char )( firstLetterCode + ( ch - firstLetterCode - swap % alpthabetLength + alpthabetLength ) % alpthabetLength );
            }
            else if ( 'А' <= ch && ch <= 'Я' || ch == 'Ё' )
            {
                const int alpthabetLength = 33;
                result += russianAlphabetBig[ ( russianAlphabetBig.IndexOf( ch ) - swap % alpthabetLength + alpthabetLength ) % alpthabetLength ];
            }
            else if ( 'а' <= ch && ch <= 'я' || ch == 'ё' )
            {
                const int alpthabetLength = 33;
                result += russianAlphabetSmall[ ( russianAlphabetSmall.IndexOf( ch ) - swap % alpthabetLength + alpthabetLength ) % alpthabetLength ];
            }
            else
            {
                result += ch;
            }
        }
        return result;
    }
}