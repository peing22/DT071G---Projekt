internal class Player
{
    // Skapar en statisk medlemsvariabel och en instans av klassen Player som kan användas av övriga klasser 
    public static Player CurrentPlayer = new();

    // Egenskaper av typerna integer och string som kan returnera och tilldelas värden
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Level { get; set; }
    public int Xp { get; set; }
    public int Health { get; set; }
    public int WeaponStrength { get; set; }
    public int Potions { get; set; }

    // Metod (ej konstruktor) för att kunna sätta värden på den befintliga CurrentPlayer-instansens egenskaper
    public void SetPlayerValues(int id, string name, int level, int xp, int health, int weaponStrength, int potions)
    {
        Id = id;
        Name = name;
        Level = level;
        Xp = xp;
        Health = health;
        WeaponStrength = weaponStrength;
        Potions = potions;
    }

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
    public void XpIndicator()
    {
        // Skapar variabel som lagrar att indikatorns storlek ska vara tio tecken
        int barSize = 10;

        // Skapar variabel som lagrar hur många tecken som ska fyllas i indikatorn baserat på spelarens XP
        int progressValue = Xp / 10;

        // Skriver ut indikatorn
        Write("[");
        for (int i = 0; i < barSize; i++)
        {
            if (i < progressValue) { Write("+"); }
            else { Write(" "); }
        }
        WriteLine("]");
    }

    // Metod för att uppdatera värden när spelaren väljer att dricka en trolldryck
    public void DrinkPotion()
    {
        // Rensar konsol
        Clear();

        // Om Potions är större än noll skrivs meddelande ut, Health ökar och Potions minskar
        if (Potions > 0)
        {
            Write("Du dricker en trolldryck som gör susen och som ökar din hälsa med 10...");
            Health += 10;
            Potions -= 1;
        }
        // Om Potions är mindre än noll skrivs meddelande ut
        else
        {
            Write("Du har inga läkande trolldrycker kvar...");
        }
        ReadKey();
    }

    // Metod som returnerar true om spelarens hälsa är större än noll
    public bool IsAlive()
    {
        return Health > 0;
    }

    // Metod för att ta reda på om spelaren kan nå nästa level
    public bool CanLevelUp()
    {
        // Om Xp är större än eller lika med 100 returneras true, annars false
        if (Xp >= 100) { return true; }
        else { return false; }
    }

    // Metod för att öka spelarens level
    public void LevelUp()
    {
        // Så länge metoden returnerar true sätts Xp till noll och Level ökar med 1
        while (CanLevelUp())
        {
            Xp = 0;
            Level++;
        }
        // Rensar konsol, ändrar förgrundsfärg i konsol, skriver ut meddelande och återställer förgrundsfärg
        Clear();
        ForegroundColor = ConsoleColor.Cyan;
        Write($"Grattis! Du har nått Level {Level}...");
        ResetColor();
        ReadKey();
    }
}