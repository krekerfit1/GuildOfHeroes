public class GameLibrary {
    private List<Game> _games = new List<Game>();

    public string Name { get; private set; }

    public int GameCount {
        get { return _games.Count; }
    }

    public GameLibrary(string name) {
        Name = name;
    }

    public bool AddGame(Game game) {
        if (FindGameByTitle(game.Title) != null) {
            return false;
        }

        _games.Add(game);
        return true;
    }

    public Game? FindGameByTitle(string title) {
        if (string.IsNullOrWhiteSpace(title)) {
            return null;
        }

        string searchTitle = title.Trim();

        foreach (Game game in _games) {
            if (string.Equals(game.Title, searchTitle, StringComparison.OrdinalIgnoreCase)) {
                return game;
            }
        }

        return null;
    }

    public bool RemoveGame(string title) {
        Game? game = FindGameByTitle(title);
        if (game == null) {
            return false;
        }

        return _games.Remove(game);
    }

    public List<Game> GetGames() {
        List<Game> result = new List<Game>();
        foreach (Game game in _games) {
            result.Add(game);
        }
        return result;
    }

    public int CountTopRated(double minRating) {
        int count = 0;
        foreach (Game game in _games) {
            if (game.Rating >= minRating) {
                count += 1;
            }
        }
        return count;
    }


    private List<PlaySession> _sessions = new List<PlaySession>();

public bool AddSession(PlaySession session) {
    if (session.Status != PlaySessionStatus.Open) {
        return false;
    }
    if (FindSession(session.Id) != null) {
        return false;
    }

    _sessions.Add(session);
    return true;
}

public PlaySession? FindSession(int sessionId) {
    foreach (PlaySession session in _sessions) {
        if (session.Id == sessionId) {
            return session;
        }
    }
    return null;
}

public bool IsGameBusy(Game game) {
    foreach (PlaySession session in _sessions) {
        if (session.Status == PlaySessionStatus.Active && session.TargetGame == game) {
            return true;
        }
    }
    return false;
}

public bool TryStartSession(int sessionId, string gameTitle) {
    PlaySession? session = FindSession(sessionId);
    if (session == null) {
        return false;
    }

    Game? game = FindGameByTitle(gameTitle);
    if (game == null) {
        return false;
    }

    if (IsGameBusy(game)) {
        return false;
    }

    return session.TryStart(game);
}

public bool TryFinishSession(int sessionId) {
    PlaySession? session = FindSession(sessionId);
    if (session == null) {
        return false;
    }
    return session.TryFinish();
}

public bool TryCancelSession(int sessionId) {
    PlaySession? session = FindSession(sessionId);
    if (session == null) {
        return false;
    }
    return session.TryCancel();
}
}