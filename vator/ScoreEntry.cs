namespace vator;

internal sealed record ScoreEntry(string Name, string Mode, int Attempts, DateTimeOffset PlayedAt);
