using System.Globalization;

namespace vator;

internal sealed class ScoreRepository
{
    private readonly string _filePath;

    public ScoreRepository()
    {
        var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        _filePath = Path.Combine(dataDirectory, "scores.csv");
    }

    public bool Save(ScoreEntry score)
    {
        try
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var line = string.Join(',', Escape(score.Name), Escape(score.Mode), score.Attempts, score.PlayedAt.ToString("O", CultureInfo.InvariantCulture));
            File.AppendAllLines(_filePath, [line]);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IReadOnlyList<ScoreEntry> GetScores()
    {
        if (!File.Exists(_filePath))
        {
            return [];
        }

        return File.ReadAllLines(_filePath)
            .Select(Parse)
            .Where(score => score is not null)
            .Select(score => score!)
            .OrderBy(score => score.Attempts)
            .ThenBy(score => score.PlayedAt)
            .ToList();
    }

    private static ScoreEntry? Parse(string line)
    {
        var parts = line.Split(',');
        if (parts.Length < 4 || !int.TryParse(parts[2], out var attempts))
        {
            return null;
        }

        var playedAt = DateTimeOffset.TryParse(parts[3], CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var value)
            ? value
            : DateTimeOffset.MinValue;

        return new ScoreEntry(Unescape(parts[0]), Unescape(parts[1]), attempts, playedAt);
    }

    private static string Escape(string value)
    {
        return value.Replace(",", " ");
    }

    private static string Unescape(string value)
    {
        return value;
    }
}
