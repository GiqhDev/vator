using Vator.Core;

var secretGenerator = new SecretNumberGenerator();
var secret = secretGenerator.Generate();
var computer = new ComputerPlayer();
var attemptNumber = 0;

Console.WriteLine("VatorIA - simulacion de PC vs numero secreto");
Console.WriteLine($"Numero secreto de prueba: {secret.Display}");
Console.WriteLine();

while (true)
{
    attemptNumber++;
    var attempt = computer.NextAttempt();
    var result = GameEvaluator.Evaluate(secret, attempt, attemptNumber);

    Console.WriteLine($"Intento {attemptNumber}: {attempt.Display} -> Vacas: {result.Cows} | Toros: {result.Bulls}");

    if (result.IsWinner)
    {
        Console.WriteLine($"La PC encontro el numero en {attemptNumber} intentos.");
        break;
    }

    computer.ApplyFeedback(attempt, result.Bulls, result.Cows);
}
