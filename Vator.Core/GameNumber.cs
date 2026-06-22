namespace Vator.Core;

public sealed class GameNumber
{
    private readonly int[] _digits;

    private GameNumber(int[] digits)
    {
        _digits = digits;
    }

    public IReadOnlyList<int> Digits => _digits;

    public string Display => string.Concat(_digits);

    public static bool TryCreate(string? value, out GameNumber? number, out string message)
    {
        number = null;
        value = value?.Trim();

        if (string.IsNullOrWhiteSpace(value))
        {
            message = "Digite un numero de 4 digitos.";
            return false;
        }

        if (value.Length != GameRules.DigitCount)
        {
            message = "El numero debe tener exactamente 4 digitos.";
            return false;
        }

        if (!value.All(char.IsDigit))
        {
            message = "El numero solo puede contener digitos.";
            return false;
        }

        if (value.Contains('0'))
        {
            message = "El numero no puede contener ceros.";
            return false;
        }

        if (value.Distinct().Count() != value.Length)
        {
            message = "El numero no puede repetir digitos.";
            return false;
        }

        number = new GameNumber(value.Select(digit => digit - '0').ToArray());
        message = "Numero valido.";
        return true;
    }
}
