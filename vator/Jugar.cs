using Vator.Core;

namespace vator;

internal static class Jugar
{
    private static readonly SecretNumberGenerator SecretNumberGenerator = new();
    private static readonly ScoreRepository ScoreRepository = new();

    public static void Presentacion()
    {
        var exit = false;

        while (!exit)
        {
            Console.ResetColor();
            ConsoleArt.WriteHeader();
            Console.WriteLine("Menu de opciones");
            Console.WriteLine("[1] Jugador vs PC");
            Console.WriteLine("[2] PC vs Jugador");
            Console.WriteLine("[3] Duelo contra PC");
            Console.WriteLine("[4] Multijugador local");
            Console.WriteLine("[5] Tabla de posiciones");
            Console.WriteLine("[6] Reglas");
            Console.WriteLine("[0] Salir");
            Console.Write("Seleccione una opcion: ");

            var select = Console.ReadLine();
            if (select is null)
            {
                return;
            }

            if (Console.IsInputRedirected && string.IsNullOrWhiteSpace(select))
            {
                return;
            }

            ClearScreen();

            switch (select)
            {
                case "1":
                    PlayHumanVsComputer();
                    break;
                case "2":
                    PlayComputerVsHuman();
                    break;
                case "3":
                    PlayComputerDuel();
                    break;
                case "4":
                    PlayLocalMultiplayer();
                    break;
                case "5":
                    TablaPosicion();
                    break;
                case "6":
                    Reglas();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    if (Console.IsInputRedirected)
                    {
                        return;
                    }

                    Console.WriteLine("Opcion no valida.");
                    break;
            }

            if (!exit)
            {
                Pause();
                ClearScreen();
            }
        }
    }

    private static void PlayHumanVsComputer()
    {
        ConsoleArt.WriteSection("Jugador vs PC");
        var secret = SecretNumberGenerator.Generate();
        var playerName = ReadPlayerName("Nombre del jugador: ");

        Console.WriteLine();
        Console.WriteLine("La PC ya eligio su numero secreto.");
        var result = RunGuessingLoop(secret, playerName);

        ConsoleArt.WriteWin($"Ganaste, {playerName}. El numero era {secret.Display}.");

        SaveScore(playerName, "Jugador vs PC", result.AttemptNumber);
    }

    private static void PlayLocalMultiplayer()
    {
        ConsoleArt.WriteSection("Multijugador local");
        var ownerName = ReadPlayerName("Jugador que crea el numero: ");
        var guesserName = ReadPlayerName("Jugador que adivina: ");
        var secret = ReadGameNumber($"{ownerName}, ingrese el numero secreto: ", hideInput: true);

        ClearScreen();
        Console.WriteLine($"{guesserName}, es tu turno de adivinar.");
        var result = RunGuessingLoop(secret, guesserName);

        ConsoleArt.WriteWin($"{guesserName} gano en {result.AttemptNumber} intentos. El numero de {ownerName} era {secret.Display}.");

        SaveScore(guesserName, "Multijugador local", result.AttemptNumber);
    }

    private static void PlayComputerDuel()
    {
        ConsoleArt.WriteSection("Duelo contra PC");
        var playerName = ReadPlayerName("Nombre del jugador: ");
        var humanSecret = ReadGameNumber($"{playerName}, ingrese su numero secreto: ", hideInput: true);
        var computerSecret = SecretNumberGenerator.Generate();
        var computer = new ComputerPlayer();
        var round = 0;

        ClearScreen();
        Console.WriteLine("Duelo contra PC iniciado.");
        Console.WriteLine("La PC ya eligio su numero secreto. Ambos van a adivinar por turnos.");
        Console.WriteLine();

        while (true)
        {
            round++;
            ConsoleArt.WriteSection($"Ronda {round}");

            var humanAttempt = ReadGameNumber($"{playerName}, tu intento contra la PC: ", hideInput: false);
            var humanResult = GameEvaluator.Evaluate(computerSecret, humanAttempt, round);
            Console.Write("PC responde -> ");
            ConsoleArt.WriteFeedback(humanResult.Cows, humanResult.Bulls);

            if (humanResult.IsWinner)
            {
                ConsoleArt.WriteWin($"{playerName} gano el duelo. El numero de la PC era {computerSecret.Display}.");
                SaveScore(playerName, "Duelo contra PC", round);
                return;
            }

            var computerAttempt = computer.NextAttempt();
            var computerResult = GameEvaluator.Evaluate(humanSecret, computerAttempt, round);
            Console.WriteLine($"Intento de la PC: {computerAttempt.Display}");
            Console.Write($"{playerName} responde -> ");
            ConsoleArt.WriteFeedback(computerResult.Cows, computerResult.Bulls);

            if (computerResult.IsWinner)
            {
                ConsoleArt.WriteWin($"La PC gano el duelo. Tu numero era {humanSecret.Display}.");
                SaveScore("PC", "Duelo contra PC", round);
                return;
            }

            computer.ApplyFeedback(computerAttempt, computerResult.Bulls, computerResult.Cows);
            Console.WriteLine($"Candidatos posibles de la PC: {computer.RemainingCandidates}");
            Console.WriteLine();
        }
    }

    private static void PlayComputerVsHuman()
    {
        ConsoleArt.WriteSection("PC vs Jugador");
        var playerName = ReadPlayerName("Nombre del jugador: ");
        var secret = ReadGameNumber($"{playerName}, ingrese el numero que la PC debe adivinar: ", hideInput: true);
        var computer = new ComputerPlayer();
        var attemptNumber = 0;

        ClearScreen();
        Console.WriteLine("La PC empieza a adivinar.");

        while (true)
        {
            attemptNumber++;
            var attempt = computer.NextAttempt();
            var result = GameEvaluator.Evaluate(secret, attempt, attemptNumber);

            Console.Write($"Intento {attemptNumber}: {attempt.Display} -> ");
            ConsoleArt.WriteFeedback(result.Cows, result.Bulls);

            if (result.IsWinner)
            {
                ConsoleArt.WriteWin($"La PC encontro el numero {secret.Display} en {attemptNumber} intentos.");
                SaveScore("PC", "PC vs Jugador", attemptNumber);
                return;
            }

            computer.ApplyFeedback(attempt, result.Bulls, result.Cows);
            Console.WriteLine($"Candidatos posibles restantes: {computer.RemainingCandidates}");
        }
    }

    private static AttemptResult RunGuessingLoop(GameNumber secret, string playerName)
    {
        var attemptNumber = 0;

        while (true)
        {
            var attempt = ReadGameNumber($"{playerName}, digite un numero de 4 digitos: ", hideInput: false);
            attemptNumber++;

            var result = GameEvaluator.Evaluate(secret, attempt, attemptNumber);
            Console.Write($"Intento {result.AttemptNumber}: {attempt.Display} -> ");
            ConsoleArt.WriteFeedback(result.Cows, result.Bulls);

            if (result.IsWinner)
            {
                return result;
            }
        }
    }

    public static void TablaPosicion()
    {
        ConsoleArt.WriteSection("Tabla de posiciones");

        var scores = ScoreRepository.GetScores();
        if (scores.Count == 0)
        {
            Console.WriteLine("Todavia no hay partidas guardadas.");
            return;
        }

        Console.WriteLine("Nombre\t\tModo\t\tIntentos");
        Console.WriteLine("------\t\t----\t\t--------");

        foreach (var score in scores)
        {
            Console.WriteLine($"{score.Name}\t\t{score.Mode}\t\t{score.Attempts}");
        }
    }

    public static void Reglas()
    {
        ConsoleArt.WriteSection("Reglas");
        ConsoleArt.WriteAnimals();
        Console.WriteLine();
        Console.WriteLine("El juego consiste en adivinar un numero secreto de cuatro cifras.");
        Console.WriteLine();
        Console.WriteLine("Reglas:");
        Console.WriteLine("1. El numero tiene 4 digitos.");
        Console.WriteLine("2. No se pueden repetir digitos.");
        Console.WriteLine("3. No puede contener ceros.");
        Console.WriteLine("4. Un TORO es un digito correcto en la posicion correcta.");
        Console.WriteLine("5. Una VACA es un digito correcto en otra posicion.");
        Console.WriteLine();
        Console.WriteLine("Modos:");
        Console.WriteLine("- Jugador vs PC: la PC crea el numero y el jugador adivina.");
        Console.WriteLine("- PC vs Jugador: el jugador crea el numero y la PC adivina por descarte.");
        Console.WriteLine("- Duelo contra PC: jugador y PC intentan adivinar sus numeros en la misma partida.");
        Console.WriteLine("- Multijugador local: un jugador crea el numero y otro lo adivina.");
    }

    private static void SaveScore(string playerName, string mode, int attempts)
    {
        var saved = ScoreRepository.Save(new ScoreEntry(playerName, mode, attempts, DateTimeOffset.Now));
        Console.WriteLine(saved ? "Datos guardados." : "Error al guardar los datos.");
    }

    private static string ReadPlayerName(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var value = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            Console.WriteLine("El nombre no puede estar vacio.");
        }
    }

    private static GameNumber ReadGameNumber(string prompt, bool hideInput)
    {
        while (true)
        {
            Console.Write(prompt);
            var value = hideInput && !Console.IsInputRedirected ? ReadHiddenLine() : Console.ReadLine();

            if (GameNumber.TryCreate(value, out var number, out var message))
            {
                return number!;
            }

            Console.WriteLine(message);
        }
    }

    private static string ReadHiddenLine()
    {
        var value = string.Empty;

        while (true)
        {
            var key = Console.ReadKey(intercept: true);

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return value;
            }

            if (key.Key == ConsoleKey.Backspace)
            {
                if (value.Length == 0)
                {
                    continue;
                }

                value = value[..^1];
                Console.Write("\b \b");
                continue;
            }

            value += key.KeyChar;
            Console.Write("*");
        }
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Presione ENTER para continuar.");
        if (!Console.IsInputRedirected)
        {
            Console.ReadLine();
        }
    }

    private static void ClearScreen()
    {
        if (Console.IsOutputRedirected)
        {
            return;
        }

        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            // Some hosts expose a console-like stream without screen buffer support.
        }
    }
}
