    public class Game
    {
        public string Title;
        public string Janr;
        public int Release_Year;
        public double Rating;
        public int Hours_Played;
        public bool IsInstalled;

        public Game(
            string title, 
            string janr, 
            int release_Year, 
            double rating, 
            int hours_Played = 0, 
            bool isInstalled = false)
        {
            Title = title;
            Janr = janr;
            Release_Year = release_Year;
            Rating = rating;
            Hours_Played = hours_Played;
            IsInstalled = isInstalled;
        }

        public void PrintInfo()
        {
            string status = IsInstalled ? "Установлена" : "Не установлена";
            Console.WriteLine($"Игра: {Title} ({Release_Year})");
            Console.WriteLine($"Жанр: {Janr}");
            Console.WriteLine($"Рейтинг: {Rating}/10");
            Console.WriteLine($"Наиграно часов: {Hours_Played} ч.");
            Console.WriteLine($"Статус в системе: {status}");
            }
    }