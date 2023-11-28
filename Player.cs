// Importerar klass för att slippa upprepa "Console"
using static System.Console;

internal class Player
{
    // Skapar en statisk medlemsvariabel och en instans av klassen Player som kan användas av övriga klasser 
    public static Player CurrentPlayer = new();

    // Egenskaper som kan returnera och tilldelas värden
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Level { get; set; } = 1;
    public int Xp { get; set; } = 0;
    public int Health { get; set; } = 10;
    public int WeaponStrength { get; set; } = 0;
    public int Potions { get; set; } = 0;

    // Metod för att visa spelarens status
    public void PlayerStatus()
    {
        Clear();
        WriteLine("-----------------------------");
        WriteLine("   S P E L A R S T A T U S   ");
        WriteLine("-----------------------------\n");
        WriteLine($"      Spelare   {Name}");
        WriteLine($"        Hälsa   {Health}");
        WriteLine($"  Vapenstyrka   {WeaponStrength}");
        WriteLine($" Trolldrycker   {Potions}");
        WriteLine($"        Level   {Level}");
        WriteLine($"           XP   {Xp}");
        Write("\n Tryck på valfri tangent...");
        ReadKey();
    }

    // Metod för att skriva ut en XP-indikator
    public void ProgressBar()
    {
        decimal value = (decimal)Xp / 100;
        int size = 10;
        int dif = (int)(value * size);
        Write("[");
        for (int i = 0; i < size; i++)
        {
            if (i < dif)
            {
                Write("+");
            }
            else
            {
                Write(" ");
            }
        }
        WriteLine("]");
    }

    // Metod för att dricka en läkande trolldryck
    public void DrinkPotion()
    {
        if (Potions > 0)
        {
            Clear();
            Write("Trolldrycken gör susen och ökar din hälsa med 10...");
            ReadKey();
            Health += 10;
            Potions -= 1;
        }
        else
        {
            Clear();
            Write("Du har inga läkande trolldrycker kvar...");
            ReadKey();
        }
    }

    // Metod för att ta reda på om spelaren kan nå nästa level
    public bool CanLevelUp()
    {
        if (Xp >= 100) { return true; }
        else { return false; }
    }

    // Metod för att öka spelarens level
    public void LevelUp()
    {
        while (CanLevelUp())
        {
            Xp = 0;
            Level++;
        }
        Clear();
        ForegroundColor = ConsoleColor.Green;
        Write($"Grattis! Du har nått Level {Level}...");
        ResetColor();
        ReadKey();
    }
}