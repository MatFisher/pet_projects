// Система бронирования мест за столами в кафе

int[] CreateArrayRndInt(int size, int min, int max)
{
    int[] arr = new int[size];
    Random rnd = new Random();
    for (int i = 0; i < size; i++)
    {
        arr[i] = rnd.Next(min, max + 1);
    }
    return arr;

}
bool isOpen = true;
int[] tables = CreateArrayRndInt(8, 2, 10);

Console.WriteLine("Система бронирования заведения\n");
while(isOpen)
{
    Console.SetCursorPosition(0, 15);
    for (int i = 0; i < tables.Length; i++)
    {
        Console.WriteLine($"За столом {i + 1} свободно {tables[i]} мест");
    }
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"\n1 - забронировать место\n2 - выход из программы\n");
    Console.Write("Введите номер команды: ");
    switch(Convert.ToInt32(Console.ReadLine()))
    {
        case 1:
            int userTable, userPlace;
            Console.Write("Введите номер стола ");
            userTable = Convert.ToInt32(Console.ReadLine()) - 1;
            if(userTable >= tables.Length || userTable < 0) 
            {
                Console.WriteLine("Стол отсутствует");
                break;
            }
            Console.Write("Введите количество бронируемых мест ");
            userPlace = Convert.ToInt32(Console.ReadLine());
            if (tables[userTable] < userPlace)
            {
                Console.WriteLine("Недостаточно мест");
                break;
            }
            tables[userTable] -= userPlace;
            break; 
        case 2:
            isOpen = false;
            break;
    }
    Console.WriteLine("Нажмите любую клавишу для продолжения");
    Console.ReadKey();
    Console.Clear();
}
