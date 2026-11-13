Hero yaroslav = new Hero("Ярослав", 100);
Hero anastasia = new Hero("Анастасия", 90);
Hero artem = new Hero("Артём", 120);

Console.WriteLine($"До вызовов: {yaroslav.Health}, {anastasia.Health}, {artem.Health}");

yaroslav.TakeDamage(25);
anastasia.TakeDamage(30);

Console.WriteLine($"После вызовов: {yaroslav.Health}, {anastasia.Health}, {artem.Health}");

yaroslav.TakeDamage(-20);
Console.WriteLine($"После неверного урона: {yaroslav.Health}");

artem.TakeDamage(200);
Console.WriteLine($"После сильного урона, Артём: {artem.Health}");

yaroslav.Heal(10);
yaroslav.GainExperience(40);
yaroslav.GainExperience(25);

Console.WriteLine($"После лечения, Ярослав: {yaroslav.Health}");
Console.WriteLine($"Опыт Ярослава: {yaroslav.Experience}");

bool yaroslavAlive = yaroslav.IsAlive();
Console.WriteLine($"Ярослав жив: {yaroslavAlive}");
Console.WriteLine($"Артём жив: {artem.IsAlive()}");

if (yaroslavAlive) {
    Console.WriteLine("Ярослав может продолжать приключение.");
} else {
    Console.WriteLine("Ярослав больше не может сражаться.");
}

string info = yaroslav.GetInfo();
Console.WriteLine("Строка получена. Сейчас выведем её:");
Console.WriteLine(info);

Console.WriteLine();
Console.WriteLine(anastasia.GetInfo());
Console.WriteLine();
Console.WriteLine(artem.GetInfo());



//==========================================================================================================================================================================


Console.WriteLine("\n--- Самостоятельная работа ---");

Game game1 = new Game("Witcher 3", "RPG", 2015, 9.5, 45, true);
Game game2 = new Game("Cyberpunk 2077", "Action-RPG", 2020, 8.0, 10, false);

// 2
Console.WriteLine($"Часов в {game1.Title} до вызова: {game1.Hours_Played}");

game1.AddHours(10); // 2
Console.WriteLine($"за последние 2 недели: 10 ч. Всего часов: {game1.Hours_Played}");


// 2
game1.ChangeRating(9.8);
game1.ChangeRating(15.0); 

Console.WriteLine($"Пройдена ли {game1.Title}: {game1.IsCompleted()}");
Console.WriteLine($"Пройдена ли {game2.Title}: {game2.IsCompleted()}");

Console.WriteLine();
game1.PrintInfo();
Console.WriteLine();
game2.PrintInfo();