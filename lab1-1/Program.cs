const int SWAP = 1;

string toCaesarCipher(string str, int swap)
{
	string result = "";
	string russianAlphabetBig = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
	string russianAlphabetSmall = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
	foreach (char ch in str)
    {
		if ('A' <= ch && ch <= 'Z')
        {
			result += (char)(65 + (ch - 65 + swap) % 26);
		}
        else if ('a' <= ch && ch <= 'z')
        {
			result += (char)(97 + (ch - 97 + swap) % 26);
		}
		else if ('А' <= ch && ch <= 'Я' || ch == 'Ё')
		{	
			result += russianAlphabetBig[(russianAlphabetBig.IndexOf(ch) + swap) % 33];
		}
		else if ('а' <= ch && ch <= 'я' || ch == 'ё')
		{
			result += russianAlphabetSmall[(russianAlphabetSmall.IndexOf(ch) + swap) % 33];
		}
		else
        {
            result += ch;
        }
    }
    return result;
}

string toNormalText(string str, int swap)
{
	string result = "";
	string russianAlphabetBig = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
	string russianAlphabetSmall = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
	foreach (char ch in str)
	{
		if ('A' <= ch && ch <= 'Z')
		{
			result += (char)(65 + (ch - 65 - swap % 26 + 26) % 26);
		}
		else if ('a' <= ch && ch <= 'z')
		{
			result += (char)(97 + (ch - 97 - swap % 26 + 26) % 26);
		}
		else if ('А' <= ch && ch <= 'Я' || ch == 'Ё')
		{
			result += russianAlphabetBig[(russianAlphabetBig.IndexOf(ch) - swap % 33 + 33) % 33];
		}
		else if ('а' <= ch && ch <= 'я' || ch == 'ё')
		{
			result += russianAlphabetSmall[(russianAlphabetSmall.IndexOf(ch) - swap % 33 + 33) % 33];
		}
		else
		{
			result += ch;
		} 
	}
	return result;
}

//Съешь ещё этих мягких французских булок, да выпей же чаю - все буквы русского алфавита
//The quick brown fox jumps over the lazy dog - все буквы английского алфавита
Console.WriteLine(toCaesarCipher("Съешь ещё этих мягких французских булок, да выпей же чаю", SWAP));
Console.WriteLine(toCaesarCipher("The quick brown fox jumps over the lazy dog", SWAP));
Console.WriteLine("-------------------------------------------------------------------------------");
Console.WriteLine(toNormalText(toCaesarCipher("Съешь ещё этих мягких французских булок, да выпей же чаю", SWAP), SWAP));
Console.WriteLine(toNormalText(toCaesarCipher("The quick brown fox jumps over the lazy dog", SWAP), SWAP));