using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

class Utility
{
    public static dynamic LoadJson(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<dynamic>(json);
    }

    public static void PressEnterToContinue()
    {
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}
