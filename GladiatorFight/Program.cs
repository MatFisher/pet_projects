// Бои гладиаторов

Random rand = new Random();
double health1 = rand.Next(90, 140);
int damage1 = rand.Next(30, 60);
int armor1 = rand.Next(30, 60);
double health2 = rand.Next(90, 140);
int damage2 = rand.Next(30, 60);
int armor2 = rand.Next(30, 60);

Console.WriteLine($"Первый гладиатор:\n\n{health1} Здоровья\n{damage1} Силы удара\n{armor1} Брони\n");
Console.WriteLine($"Второй гладиатор:\n\n{health2} Здоровья\n{damage2} Силы удара\n{armor2} Брони\n");
Console.Write("Кто победит?\nВведи номер гладиатора - ");
int userBet = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Нажимайте пробел для удара\n");

int result = 0;
while (health1 > 0 && health2 > 0) 
{
    Console.ReadKey();
    double kick2 = Math.Round(Convert.ToSingle(rand.Next(0, damage2)) / 100 * (100 - armor1), 0);
    Console.WriteLine($"Первый гладиатор получил {kick2} урона. Осталось {health1 -= kick2} здоровья.\n");
    Console.ReadKey();
    double kick1 = Math.Round(Convert.ToSingle(rand.Next(0, damage1)) / 100 * (100 - armor2), 0);
    Console.WriteLine($"Второй гладиатор получил {kick1} урона. Осталось {health2 -= kick1} здоровья.\n");
}
Console.WriteLine();
if (health1 <= 0 && health2 <= 0)
{
    Console.WriteLine("Ничья, оба мертвы");
    result = 0;
}

else if (health1 <= 0)
{
    Console.WriteLine("Первый гладиатор пал");
    result = 2;
}
else if (health2 <= 0)
{
    Console.WriteLine("Второй гладиатор пал");
    result = 1;
}
if(userBet == result) Console.WriteLine("Ты был прав!");
else Console.WriteLine("Ставка не сработала. Попробуй еще.");
Console.ReadKey();
