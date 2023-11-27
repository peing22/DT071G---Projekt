internal abstract class Level 
{ 
    // Egenskap som kan returnera och tilldelas ett värde
    public string? Name { get; set; }

    // Abstrakt metod som måste implementeras i underordnade klasser
    public abstract void LevelDescript();
}