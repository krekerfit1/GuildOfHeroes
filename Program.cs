Hero yaroslav = new Hero("Ярослав", 100);
Hero anastasia = new Hero("Анастасия", 90);
Hero artem = new Hero("Артём", 120);
Hero alexander = new Hero("   Александр   ", 150);

alexander.TakeDamage(10);
alexander.Heal(10);

Console.WriteLine(">>> Участники готовы <<<");
Console.WriteLine();
Console.WriteLine(yaroslav.GetInfo());
Console.WriteLine();
Console.WriteLine(anastasia.GetInfo());
Console.WriteLine();
Console.WriteLine(artem.GetInfo());
Console.WriteLine();
Console.WriteLine(alexander.GetInfo());
Console.WriteLine($"Предел здоровья Александра: {alexander.MaxHealth}");


//==========================================================================================================================================================================


Console.WriteLine("\n--- Самостоятельная работа ---");

Game game1 = new Game("   Witcher 3   ", "RPG", 2015, 9.5, 45, true);
Game game2 = new Game("Cyberpunk 2077", "Action-RPG", 2020, 8.0, 10, false);

Game probeGame = new Game("   ", "Indie", 2024, 15.0, -50, false);
Console.WriteLine($"Проверка конструктора: [{probeGame.Title}], рейтинг: {probeGame.Rating}, часов: {probeGame.Hours_Played}");
Console.WriteLine($"Очистка пробелов у первой игры: [{game1.Title}]");

Console.WriteLine($"Часов в {game1.Title} до вызова: {game1.Hours_Played}");

game1.AddHours(10); 
game1.AddHours(-20); 
Console.WriteLine($"За последние 2 недели: +10 ч. (попытка -20 ч. отклонена). Всего часов: {game1.Hours_Played}");

game1.ChangeRating(9.8);
game1.ChangeRating(15.0);
game1.ChangeRating(-5.0); 
Console.WriteLine($"Рейтинг {game1.Title} после проверок: {game1.Rating}");
Console.WriteLine($"Часы и рейтинг {game2.Title} не изменились: {game2.Hours_Played} ч., {game2.Rating}/10");

Console.WriteLine($"Пройдена ли {game1.Title}: {game1.IsCompleted()}");
Console.WriteLine($"Пройдена ли {game2.Title}: {game2.IsCompleted()}");

Console.WriteLine();
game1.PrintInfo();
Console.WriteLine();
game2.PrintInfo();