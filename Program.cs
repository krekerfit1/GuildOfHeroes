// Probe.Run();
Hero yaroslav = new Hero("Ярослав", 100);
Hero anastasia = new Hero("Анастасия", 90);
Hero artem = new Hero("Артём", 120);
Hero alexander = new Hero("   Александр   ", 150);
Hero sergey = new Hero("Сергей", 110);

alexander.TakeDamage(10);
alexander.Heal(10);

Guild guild = new Guild("Гильдия героев");

guild.AddHero(yaroslav);
guild.AddHero(anastasia);
guild.AddHero(artem);
guild.AddHero(alexander);
guild.AddHero(sergey);

Console.WriteLine($">>> {guild.Name}: участников {guild.MemberCount} <<<");
Console.WriteLine();

QuestBoard board = new QuestBoard(guild);

Quest floatQuest = new Quest(101, "Вернуть поплавок", 100, 30);
Console.WriteLine($"Поручение добавлено: {board.AddQuest(floatQuest)}");
Console.WriteLine($">>> №{floatQuest.Id}: {floatQuest.Title} <<<");


Console.WriteLine($"Назначение Сергея: {board.TryAssign(101, " сЕрГеЙ ")}");
Hero? assigned = floatQuest.AssignedHero;
if (assigned != null) {
    Console.WriteLine($"Исполнитель: {assigned.Name}");
}
Console.WriteLine($"Опыт после назначения: {sergey.Experience}");

Console.WriteLine($"Завершение: {board.TryComplete(101)}");
Console.WriteLine($"Опыт после завершения: {sergey.Experience}");
Console.WriteLine($"Повторное завершение: {board.TryComplete(101)}");
Console.WriteLine($"Опыт после повтора: {sergey.Experience}");




//=============================================

Console.WriteLine("\n--- Самостоятельная работа ---");

Game game1 = new Game("Witcher 3", "RPG", 2015, 9.5, 45, true);
Game game2 = new Game("Cyberpunk 2077", "Action-RPG", 2020, 8.0, 10, false);
Game game3 = new Game("Satisfactory", "Sandbox", 2024, 9.2, 120, true);
Game game4 = new Game("DOOM", "Shooter", 2016, 8.8, 25, true);

GameLibrary library = new GameLibrary("Моя библиотека игр");
Console.WriteLine($"Добавлен Witcher 3: {library.AddGame(game1)}");
library.AddGame(game2);
library.AddGame(game3);
library.AddGame(game4);

Console.WriteLine($"Повтор DOOM принят: {library.AddGame(new Game(" doom ", "Shooter", 2016, 8.8))}");

List<Game> games = library.GetGames();

Console.WriteLine($"\n>>> {library.Name} <<<");
Console.WriteLine($"Игр в библиотеке: {library.GameCount}");

if (games.Count > 0) {
    Console.WriteLine($"Первая: {games[0].Title}");
    Console.WriteLine($"Последняя: {games[games.Count - 1].Title}");
}

Console.WriteLine();
foreach (Game game in games) {
    game.PrintInfo();
    Console.WriteLine();
}

Game? foundGame = library.FindGameByTitle("  satisfactory  ");
if (foundGame != null) {
    Console.WriteLine($"Найдена игра: {foundGame.Title} (рейтинг {foundGame.Rating})");
} else {
    Console.WriteLine("Игра не найдена.");
}

Game? missingGame = library.FindGameByTitle("Half-Life 3");
if (missingGame != null) {
    Console.WriteLine($"Найдена игра: {missingGame.Title}");
} else {
    Console.WriteLine("По запросу «Half-Life 3» ничего не найдено.");
}

Console.WriteLine($"Игр с рейтингом от 9.0: {library.CountTopRated(9.0)}");

Console.WriteLine($"Игр до удаления: {library.GameCount}");
Console.WriteLine($"Удалена Cyberpunk 2077: {library.RemoveGame("cyberpunk 2077")}");
Console.WriteLine($"Игр после удаления: {library.GameCount}");