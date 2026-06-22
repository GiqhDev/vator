namespace vator;

internal static class ConsoleArt
{
    public static void WriteHeader()
    {
        WriteLine("============================================================", ConsoleColor.DarkGray);
        WriteLine("                       V A T O R", ConsoleColor.Yellow);
        WriteLine("                 Vacas (V) y Toros (T)", ConsoleColor.Cyan);
        WriteLine("============================================================", ConsoleColor.DarkGray);
        Console.WriteLine();
        WriteAnimals();
        Console.WriteLine();
        WriteLine("Adivina el numero secreto: V = vaca, T = toro", ConsoleColor.DarkCyan);
        WriteLine("------------------------------------------------------------", ConsoleColor.DarkGray);
    }

    public static void WriteAnimals()
    {
        WriteLine("          VACA - V                         TORO - T", ConsoleColor.White);
        WriteLine("       ^__^                              ,/         \\", ConsoleColor.Gray);
        WriteLine("       (vv)\\_______                    ((_,-~~~-,_))", ConsoleColor.Gray);
        WriteLine("       (__)\\       )\\/\\                 \\   _ _   /", ConsoleColor.Gray);
        WriteLine("        V  ||----w |                      )  T  (", ConsoleColor.Green);
        WriteLine("           ||     ||                     /  \\_/  \\", ConsoleColor.Gray);
    }

    public static void WriteSection(string title)
    {
        Console.WriteLine();
        WriteLine($"== {title} ==", ConsoleColor.Yellow);
    }

    public static void WriteFeedback(int cows, int bulls)
    {
        WriteLine($"V: {cows} vaca(s) | T: {bulls} toro(s)", ConsoleColor.Cyan);
    }

    public static void WriteWin(string message)
    {
        WriteLine("************************************************************", ConsoleColor.Green);
        WriteLine(message, ConsoleColor.Green);
        WriteLine("************************************************************", ConsoleColor.Green);
    }

    private static void WriteLine(string value, ConsoleColor color)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(value);
        Console.ForegroundColor = previous;
    }
}
