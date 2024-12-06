public class PrettyPrint
{
    public static void Print(string someString)
    {
        int index = 0;
        foreach (char letter in someString)
        {
            Console.Write(letter);
            Thread.Sleep(10);
            index++;

            if (letter == '\n') index = 0;

            if (index > 70 && letter == ' ' || index > 50 && letter == '.')
            {
                Console.WriteLine();
                index = 0;
            }
        }
        Console.WriteLine();
    }
}