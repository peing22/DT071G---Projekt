internal abstract class Level 
{ 
    // Egenskap av typen string som kan returnera och tilldelas ett värde
    public string? Name { get; set; }

    // Abstrakta metoder som måste implementeras i underordnade klasser
    public abstract void Descript();
    public abstract void TaskMenu(Player player);
}