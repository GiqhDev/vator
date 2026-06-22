using Vator.Core;

namespace vator;

internal static class Usuario
{
    public static List<int> NumUser(string numUsuario)
    {
        return numUsuario.Select(digit => digit - '0').ToList();
    }

    public static bool ValidarUsuario(string? numUsuario, out string msg)
    {
        return GameNumber.TryCreate(numUsuario, out _, out msg);
    }

    public static bool GuardarDatos(DataUser dataUser)
    {
        var repository = new ScoreRepository();
        return repository.Save(new ScoreEntry(dataUser.Nombre, "Clasico", dataUser.Intentos, DateTimeOffset.Now));
    }

    public static bool MostrarDatos(out string str1, out string str2, out List<string> str3, out string str4)
    {
        str1 = "Nombre\t\tIntentos";
        str2 = "------\t\t--------";
        str3 = new List<string>();
        str4 = string.Empty;

        var repository = new ScoreRepository();
        var scores = repository.GetScores();

        foreach (var score in scores)
        {
            str3.Add($"{score.Name}\t\t{score.Attempts}");
        }

        return scores.Count > 0;
    }
}
