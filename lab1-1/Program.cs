class Program
{
    private static string RussianAlphabetBig = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    private static string RussianAlphabetSmall = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    private static int EnglishAlpthabetLength = 26;
    private static int RussianAlthabetLenght = 33;
    private static int EnglishFirstBigLetterCode = 65;
    private static int EnglishFirstSmallLetterCode = 97;

    static void Main( string[] args )
    {
        const int Swap = 1;

        //Съешь ещё этих мягких французских булок, да выпей же чаю - все буквы русского алфавита
        //The quick brown fox jumps over the lazy dog - все буквы английского алфавита
        string russianCode = ToCaesarCipher( "Съешь ещё этих мягких французских булок, да выпей же чаю", Swap );
        string englishCode = ToCaesarCipher( "The quick brown fox jumps over the lazy dog", Swap );
        Console.WriteLine( russianCode );
        Console.WriteLine( englishCode );
        Console.WriteLine( "-------------------------------------------------------------------------------" );
        Console.WriteLine( ToNormalText( russianCode, Swap ) );
        Console.WriteLine( ToNormalText( englishCode, Swap ) );
    }

    private static string ToCaesarCipher( string str, int swap )
    {
        string result = "";
        foreach ( char ch in str )
        {
            if ( 'A' <= ch && ch <= 'Z' )
            {
                result += ( char )( EnglishFirstBigLetterCode + ( ch - EnglishFirstBigLetterCode + swap ) % EnglishAlpthabetLength );
            }
            else if ( 'a' <= ch && ch <= 'z' )
            {
                result += ( char )( EnglishFirstSmallLetterCode + ( ch - EnglishFirstSmallLetterCode + swap ) % EnglishAlpthabetLength );
            }
            else if ( 'А' <= ch && ch <= 'Я' || ch == 'Ё' )
            {
                result += RussianAlphabetBig[ ( RussianAlphabetBig.IndexOf( ch ) + swap ) % RussianAlthabetLenght ];
            }
            else if ( 'а' <= ch && ch <= 'я' || ch == 'ё' )
            {
                result += RussianAlphabetSmall[ ( RussianAlphabetSmall.IndexOf( ch ) + swap ) % RussianAlthabetLenght ];
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
                result += ( char )( EnglishFirstBigLetterCode + ( ch - EnglishFirstBigLetterCode - swap % EnglishAlpthabetLength + EnglishAlpthabetLength ) % EnglishAlpthabetLength );
            }
            else if ( 'a' <= ch && ch <= 'z' )
            {
                result += ( char )( EnglishFirstSmallLetterCode + ( ch - EnglishFirstSmallLetterCode - swap % EnglishAlpthabetLength + EnglishAlpthabetLength ) % EnglishAlpthabetLength );
            }
            else if ( 'А' <= ch && ch <= 'Я' || ch == 'Ё' )
            {
                result += RussianAlphabetBig[ ( RussianAlphabetBig.IndexOf( ch ) - swap % RussianAlthabetLenght + RussianAlthabetLenght ) % RussianAlthabetLenght ];
            }
            else if ( 'а' <= ch && ch <= 'я' || ch == 'ё' )
            {
                result += RussianAlphabetSmall[ ( RussianAlphabetSmall.IndexOf( ch ) - swap % RussianAlthabetLenght + RussianAlthabetLenght ) % RussianAlthabetLenght ];
            }
            else
            {
                result += ch;
            }
        }
        return result;
    }
}