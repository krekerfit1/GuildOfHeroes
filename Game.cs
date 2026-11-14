public class Game {
    private string _title = "Без названия";

    public string Title {
        get {
            return _title;
        }

        private set {
            if (string.IsNullOrWhiteSpace(value)) {
                _title = "Без названия";
                return;
            }

            _title = value.Trim();
        }
    }

    public string Janr { get; private set; }
    public int Release_Year { get; private set; }
    public double Rating { get; private set; }
    public int Hours_Played { get; private set; }
    public bool IsInstalled { get; private set; }

    public Game(
        string title,
        string janr,
        int release_Year,
        double rating,
        int hours_Played = 0,
        bool isInstalled = false) {
        Title = title;
        Janr = janr;
        Release_Year = release_Year;

        Rating = rating;

        if (Rating < 0) {
            Rating = 0;
        }

        if (Rating > 10) {
            Rating = 10;
        }

        Hours_Played = hours_Played;

        if (Hours_Played < 0) {
            Hours_Played = 0;
        }

        IsInstalled = isInstalled;
    }

    // вторая
    public void AddHours(int hours) {
        if (hours <= 0) {
            return;
        }

        if (hours > 2147483647 - Hours_Played) {
            return;
        }

        Hours_Played += hours;
    }

    // вторая
    public void ChangeRating(double newRating) {
        if (newRating < 0 || newRating > 10) {
            return;
        }

        Rating = newRating;
    }

    // вторая
    public bool IsCompleted() {
        return Hours_Played >= 50;
    }

    public void PrintInfo() {
        string status = IsInstalled ? "Установлена" : "Не установлена";
        Console.WriteLine($">>> {Title} ({Release_Year}) <<<");
        Console.WriteLine($"Жанр: {Janr}");
        Console.WriteLine($"Рейтинг: {Rating}/10");
        Console.WriteLine($"Наиграно часов: {Hours_Played} ч.");
        Console.WriteLine($"Статус в системе: {status}");
    }
}