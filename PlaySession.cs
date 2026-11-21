public class PlaySession {
    public int Id { get; private set; }
    public int PlannedHours { get; private set; }
    public Game? TargetGame { get; private set; }
    public bool IsFinished { get; private set; }

    public PlaySession(int id, int plannedHours) {
        Id = id;
        PlannedHours = plannedHours < 1 ? 1 : plannedHours;
        TargetGame = null;
        IsFinished = false;
    }

    public bool TryStart(Game game) {
        if (IsFinished) {
            return false;
        }
        if (TargetGame != null) {
            return false;
        }
        if (!game.IsInstalled) {
            return false;
        }

        TargetGame = game;
        return true;
    }

    public bool TryFinish() {
        if (IsFinished) {
            return false;
        }

        Game? game = TargetGame;
        if (game == null) {
            return false;
        }
        if (!game.IsInstalled) {
            return false;
        }
        if (!game.CanAddHours(PlannedHours)) {
            return false;
        }

        game.AddHours(PlannedHours);
        IsFinished = true;
        return true;
    }

    public string GetInfo() {
        string gameText = TargetGame != null ? TargetGame.Title : "не выбрана";
        string doneText = IsFinished ? "да" : "нет";
        return $"Сессия №{Id} ({PlannedHours} ч.): игра {gameText}, завершена: {doneText}";
    }
}