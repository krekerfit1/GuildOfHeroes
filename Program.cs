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

board.AddQuest(new Quest(101, "Вернуть поплавок", 100, 30));
board.TryAssign(101, "Сергей");
board.TryComplete(101);

board.AddQuest(new Quest(102, "Проверить нижнюю площадку", 100, 10));
board.AddQuest(new Quest(103, "Снять мерки для насоса больницы", 100, 20));
board.AddQuest(new Quest(104, "Обследовать ответвление", 100, 15));

Console.WriteLine($"Сергей на №102: {board.TryAssign(102, "Сергей")}");
Console.WriteLine($"Сергей на №103: {board.TryAssign(103, "Сергей")}");
Console.WriteLine($"Отмена №102: {board.TryCancel(102)}");
Console.WriteLine($"Сергей на №103: {board.TryAssign(103, "Сергей")}");
Console.WriteLine($"Завершение №103: {board.TryComplete(103)}");
Console.WriteLine($"Ярослав на №104: {board.TryAssign(104, "Ярослав")}");
Console.WriteLine($"Удалить Сергея: {board.TryRemoveMember("Сергей")}");

Console.WriteLine();
List<Quest> quests = board.GetQuests();
foreach (Quest quest in quests) {
    Console.WriteLine(quest.GetInfo());
}

Console.WriteLine();
Console.WriteLine(sergey.GetInfo());

//=============================================

Console.WriteLine("\n-------------------------------------------------- Самостоятельная работа --------------------------------------------------");

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

PlaySession session1 = new PlaySession(1, 5);
PlaySession session2 = new PlaySession(2, 3);
library.AddSession(session1);
library.AddSession(session2);

Console.WriteLine($"Старт сессии №1 (Witcher 3): {library.TryStartSession(1, "Witcher 3")}");
Console.WriteLine($"Старт сессии №2 (Witcher 3, пока занята): {library.TryStartSession(2, "Witcher 3")}");
Console.WriteLine($"Отмена сессии №1: {library.TryCancelSession(1)}");
Console.WriteLine($"Старт сессии №2 после отмены №1: {library.TryStartSession(2, "Witcher 3")}");
Console.WriteLine($"Завершение сессии №2: {library.TryFinishSession(2)}");

Console.WriteLine(session1.GetInfo());
Console.WriteLine(session2.GetInfo());

Game? updatedWitcher = library.FindGameByTitle("  witcher 3  ");
if (updatedWitcher != null) {
    Console.WriteLine($"В библиотеке у {updatedWitcher.Title}: {updatedWitcher.Hours_Played} ч. (пройдена: {updatedWitcher.IsCompleted()})");
}