// Игра Pac-Man

int pacmanX, pacmanY;
int ghostX, ghostY;
int pacmanDX = 0, pacmanDY = 1;
int ghostDX = 0, ghostDY = -1;
int allDots = 0, colDots = 0;
bool isAlive = true;
bool isPlaying = true;
Console.CursorVisible = false;
Random random = new Random();


char[,] map = ReadMap("Map1", out pacmanX, out pacmanY, out ghostX, out ghostY, ref allDots);


PrintMap(map);

while (isPlaying)
{
    Console.SetCursorPosition(0, 30);
    Console.WriteLine($"Собрано {colDots}/{allDots}");
    DrawPlayer(pacmanY, pacmanX);
    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        PacmanMove(key, ref pacmanDX, ref pacmanDY);
    }
    if (map[pacmanDX + pacmanX, pacmanDY + pacmanY] != '#')
    {
        if (map[pacmanX, pacmanY] == '.')
        {
            colDots++;
            map[pacmanX, pacmanY] = ' ';
        }

        Move(map, '@', ref pacmanX, ref pacmanY, pacmanDX, pacmanDY);
    }


    if (map[ghostDX + ghostX, ghostDY + ghostY] != '#')
    {
        Move(map, '$', ref ghostX, ref ghostY, ghostDX, ghostDY);
    }
    else
    {
        ChangeDirection(random, ref ghostDX, ref ghostDY);
    }

    if(ghostX == pacmanX && ghostY == pacmanY)
    {
        isAlive = false;
    }

    System.Threading.Thread.Sleep(200);

    if(colDots == allDots || !isAlive)
    {
        isPlaying = false;
    }
}

Console.SetCursorPosition(0, 35);
if (colDots == allDots) Console.WriteLine("You WIN!!!");
else if (isAlive) Console.WriteLine("You LOSE!!!");
Console.ReadKey();


char[,] ReadMap(string mapName, out int pacmanX, out int pacmanY, out int ghostX, out int ghostY, ref int allDots)
{
    pacmanX = 0; pacmanY = 0;
    ghostX = 0; ghostY = 0; 
    string[] newfile = File.ReadAllLines($"Maps/{mapName}.txt");
    char[,] map = new char[newfile.Length, newfile[0].Length];

    for(int i = 0; i < map.GetLength(0); i++)
    {
        for(int j = 0; j < map.GetLength(1); j++) 
        {
            map[i,j] = newfile[i][j];
            if (map[i,j] == '@')
            {
                pacmanX = i; pacmanY = j;
                map[i, j] = '.';
            }
            else if (map[i, j] == '$')
            {
                ghostX = i; ghostY = j;
                map[i, j] = '.';
            }
            else if (map[i, j] == ' ')
            {
                map[i, j] = '.';
                allDots++;
            }
        }
    }
    return map;
}

void PrintMap(char[,] map)
{
    for(int i = 0; i < map.GetLength(0);i++)
    {
        for(int j = 0; j < map.GetLength(1);j++)
        {
            Console.Write(map[i,j]);
        }
        Console.WriteLine();
    }
}

void DrawPlayer(int pacmanY, int pacmanX)
{
   Console.SetCursorPosition(pacmanY, pacmanX);
    Console.Write('@');
}

void Move(char [,] map, char simbol, ref int x, ref int y, int dx, int dy)
{
    Console.SetCursorPosition(y, x);
    Console.Write(map[x,y]);

    x += dx;
    y += dy;

    Console.SetCursorPosition(y, x);
    Console.Write(simbol);
}

void PacmanMove(ConsoleKeyInfo key, ref int dx, ref int dy)
{
    switch (key.Key)
    {
        case ConsoleKey.UpArrow:
            dx = -1; dy = 0;
            break;
        case ConsoleKey.DownArrow:
            dx = 1; dy = 0;
            break;
        case ConsoleKey.LeftArrow:
            dx = 0; dy = -1;
            break;
        case ConsoleKey.RightArrow:
            dx = 0; dy = 1;
            break;
    }
}

void ChangeDirection(Random random, ref int dx, ref int dy)
{
    int ghostDir = random.Next(1, 5);

    switch (ghostDir)
    {
        case 1:
            dx = -1; dy = 0;
            break;
        case 2:
            dx = 1; dy = 0;
            break;
        case 3:
            dx = 0; dy = -1;
            break;
        case 4:
            dx = 0; dy = 1;
            break;
    }
}