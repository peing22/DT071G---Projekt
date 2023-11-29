internal class MenuItem
{
    // Egenskap av typen string som kan returnera ett värde
    public string Description { get; }

    // Egenskap av typen Action som kan returnera en metod utan returvärde
    public Action Action { get; }

    // Konstruktor som tilldelar egenskaperna värden när en instans av klassen skapas
    public MenuItem(string description, Action action)
    {
        Description = description;
        Action = action;
    }
}