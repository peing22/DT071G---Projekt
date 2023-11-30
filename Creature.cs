internal class Creature
{
    // Egenskaper av typerna string och integer som kan returnera och eventuellt tilldelas värden
    public string Name { get; }
    public int Health { get; set; }
    public int WeaponStrength { get; set; }
    public int XpValue { get; }

    // Konstruktor som tilldelar egenskaperna värden när en instans av klassen skapas
    public Creature(string name, int health, int weaponStrength, int xpValue)
    {
        Name = name;
        Health = health;
        WeaponStrength = weaponStrength;
        XpValue = xpValue;
    }

    // Metod som returnerar true om varelsens hälsa är större än noll
    public bool IsAlive()
    {
        return Health > 0;
    }
}