namespace Vator.Core;

public sealed class ComputerPlayer
{
    private List<GameNumber> _candidates = CreateCandidates();

    public int RemainingCandidates => _candidates.Count;

    public GameNumber NextAttempt()
    {
        if (_candidates.Count == 0)
        {
            throw new InvalidOperationException("La PC no tiene candidatos posibles con las pistas recibidas.");
        }

        return _candidates[0];
    }

    public void ApplyFeedback(GameNumber attempt, int bulls, int cows)
    {
        _candidates = _candidates
            .Where(candidate =>
            {
                var result = GameEvaluator.Evaluate(candidate, attempt, 0);
                return result.Bulls == bulls && result.Cows == cows;
            })
            .ToList();
    }

    private static List<GameNumber> CreateCandidates()
    {
        var candidates = new List<GameNumber>();

        for (var first = GameRules.MinDigit; first <= GameRules.MaxDigit; first++)
        for (var second = GameRules.MinDigit; second <= GameRules.MaxDigit; second++)
        for (var third = GameRules.MinDigit; third <= GameRules.MaxDigit; third++)
        for (var fourth = GameRules.MinDigit; fourth <= GameRules.MaxDigit; fourth++)
        {
            var value = $"{first}{second}{third}{fourth}";
            if (GameNumber.TryCreate(value, out var number, out _))
            {
                candidates.Add(number!);
            }
        }

        return candidates;
    }
}
