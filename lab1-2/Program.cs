class Program
{
    static void Main( string[] args )
    {
        Program program = new Program();
        List<int> numbers = new List<int>() { 4, 3, 2, 1 };
        program.OptimizeBubbleSort( numbers );
        program.PrintList( numbers );
    }
    private void OptimizeBubbleSort( List<int> numbers )
    {
        bool isSorted = false;
        for ( int j = 0; j < numbers.Count - 1 && !isSorted; j++ )
        {
            isSorted = true;
            for ( int i = 0; i < numbers.Count - 1; i++ )
            {
                if ( numbers[ i ] > numbers[ i + 1 ] )
                {
                    isSorted = false;
                    int temp = numbers[ i ];
                    numbers[ i ] = numbers[ i + 1 ];
                    numbers[ i + 1 ] = temp;
                }
            }
        }
    }
    private void PrintList( List<int> list )
    {
        foreach ( int el in list )
        {
            Console.Write( $"{el}; " );
        }
    }

}