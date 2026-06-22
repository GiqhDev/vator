namespace Vator.Core;

public static class GameEvaluator
{
    public static AttemptResult Evaluate(GameNumber secret, GameNumber attempt, int attemptNumber)
    {
        var bulls = 0;
        var cows = 0;

        for (var index = 0; index < GameRules.DigitCount; index++)
        {
            if (attempt.Digits[index] == secret.Digits[index])
            {
                bulls++;
                continue;
            }

            if (secret.Digits.Contains(attempt.Digits[index]))
            {
                cows++;
            }
        }

        return new AttemptResult(attempt, bulls, cows, attemptNumber);
    }
}
