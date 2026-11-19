// Probe.Run();

Hero yaroslav = new Hero("Ярослав", 100);
Hero anastasia = new Hero("Анастасия", 90);
Hero artem = new Hero("Артём", 120);
Hero alexander = new Hero("   Александр   ", 150);
Hero sergey = new Hero("Сергей", 110);

alexander.TakeDamage(10);
alexander.Heal(10);

Guild guild = new Guild("Гильдия героев");
guild.Heroes.Add(yaroslav);
guild.Heroes.Add(anastasia);
guild.Heroes.Add(artem);
guild.Heroes.Add(alexander);
guild.Heroes.Add(sergey);

Console.WriteLine($">>> {guild.Name}: перекличка <<<");
Console.WriteLine($"Участников: {guild.Heroes.Count}");

if (guild.Heroes.Count > 0) {
    Console.WriteLine($"Первый: {guild.Heroes[0].Name}");
    Console.WriteLine($"Последний: {guild.Heroes[guild.Heroes.Count - 1].Name}");
}

Console.WriteLine();
foreach (Hero hero in guild.Heroes) {
    Console.WriteLine(hero.GetInfo());
    Console.WriteLine();
}

int strongCount = 0;
foreach (Hero hero in guild.Heroes) {
    if (hero.Health >= 120) {
        strongCount += 1;
    }
}
Console.WriteLine($"Могут нести тяжёлые ящики (здоровье от 120): {strongCount}");

if (guild.Heroes.Count > 0) {
    Hero strongest = guild.Heroes[0];
    foreach (Hero hero in guild.Heroes) {
        if (hero.Health > strongest.Health) {
            strongest = hero;
        }
    }
    Console.WriteLine($"Самый здоровый: {strongest.Name} ({strongest.Health})");
}


//=============================================

Console.WriteLine("\n--- Самостоятельная работа ---");

Game game1 = new Game("Witcher 3", "RPG", 2015, 9.5, 45, true);
Game game2 = new Game("Cyberpunk 2077", "Action-RPG", 2020, 8.0, 10, false);
Game game3 = new Game("Satisfactory", "Sandbox", 2024, 9.2, 120, true);
Game game4 = new Game("DOOM", "Shooter", 2016, 8.8, 25, true);

GameLibrary library = new GameLibrary("Моя библиотека игр");
library.Games.Add(game1);
library.Games.Add(game2);
library.Games.Add(game3);
library.Games.Add(game4); 

Console.WriteLine($">>> {library.Name} <<<");
Console.WriteLine($"Игр в библиотеке: {library.Games.Count}");

if (library.Games.Count > 0) {
    Console.WriteLine($"Первая: {library.Games[0].Title}");
    Console.WriteLine($"Последняя: {library.Games[library.Games.Count - 1].Title}");
}

Console.WriteLine();
foreach (Game game in library.Games) {
    game.PrintInfo();
    Console.WriteLine();
}

int topRatedCount = 0;
foreach (Game game in library.Games) {
    if (game.Rating >= 9.0) {
        topRatedCount += 1;
    }
}
Console.WriteLine($"Игр с рейтингом от 9.0: {topRatedCount}");

game2.AddHours(15);
Console.WriteLine($"Часов в {game2.Title} через переменную: {game2.Hours_Played}");
Console.WriteLine($"Часов в {library.Games[1].Title} через список: {library.Games[1].Hours_Played}");






