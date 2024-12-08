public class PrettyPrint
{
    public static void Print(string someString)
    {
        int index = 0;
        bool newLine = false;
        for (int i = 0; i < someString.Length; i++)
        {
            char letter = someString[i];

            if (letter == ' ' && newLine)
            {
                continue;
            }
            else newLine = false;

            Console.Write(letter);
            Thread.Sleep(10);
            index++;

            if (letter == '\n') index = 0;
            if (index > 70 && letter == ' ' || index > 50 && letter == '.')
            {
                Console.WriteLine();
                newLine = true;
                index = 0;
            }
        }
        Console.WriteLine();
    }
}