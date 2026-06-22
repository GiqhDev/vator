namespace Vator.Core;

public sealed class SecretNumberGenerator
{
    private readonly Random _random;

    public SecretNumberGenerator()
        : this(Random.Shared)
    {
    }

    public SecretNumberGenerator(Random random)
    {
        _random = random;
    }

    public GameNumber Generate()
    {
        var digits = Enumerable.Range(GameRules.MinDigit, GameRules.MaxDigit)
            .OrderBy(_ => _random.Next())
            .Take(GameRules.DigitCount);

        var value = string.Concat(digits);
        GameNumber.TryCreate(value, out var number, out _);
        return number!;
    }
}
