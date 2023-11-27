internal class Player
{
    // Skapar en statisk medlemsvariabel och en instans av klassen Player som kan användas av övriga klasser 
    public static Player CurrentPlayer = new();

    // Egenskaper som kan returnera och tilldelas värden
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Level { get; set; } = 1;
}