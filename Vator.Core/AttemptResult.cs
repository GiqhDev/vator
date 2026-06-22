namespace Vator.Core;

public sealed record AttemptResult(GameNumber Attempt, int Bulls, int Cows, int AttemptNumber)
{
    public bool IsWinner => Bulls == GameRules.DigitCount;
}
