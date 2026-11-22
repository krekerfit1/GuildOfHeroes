public class PlaySession {
    public int Id { get; private set; }
    public int PlannedHours { get; private set; }
    public Game? TargetGame { get; private set; }
    public PlaySessionStatus Status { get; private set; }

    public PlaySession(int id, int plannedHours) {
        Id = id;
        PlannedHours = plannedHours < 1 ? 1 : plannedHours;
        TargetGame = null;
        Status = PlaySessionStatus.Open;
    }

    public bool TryStart(Game game) {
        if (Status != PlaySessionStatus.Open) {
            return false;
        }
        if (!game.IsInstalled) {
            return false;
        }

        TargetGame = game;
        Status = PlaySessionStatus.Active;
        return true;
    }

    public bool TryFinish() {
        if (Status != PlaySessionStatus.Active) {
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
        Status = PlaySessionStatus.Finished;
        return true;
    }

    public bool TryCancel() {
        if (Status != PlaySessionStatus.Open && Status != PlaySessionStatus.Active) {
            return false;
        }

        Status = PlaySessionStatus.Cancelled;
        return true;
    }

    public string GetStatusText() {
        switch (Status) {
            case PlaySessionStatus.Open:
                return "открыта";
            case PlaySessionStatus.Active:
                return "активна";
            case PlaySessionStatus.Finished:
                return "завершена";
            case PlaySessionStatus.Cancelled:
                return "отменена";
            default:
                return "неизвестно";
        }
    }

    public string GetInfo() {
        string gameText = TargetGame != null ? TargetGame.Title : "не выбрана";
        return $"Сессия №{Id} ({PlannedHours} ч.): {GetStatusText()}, игра {gameText}";
    }
}