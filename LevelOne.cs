// Intern klass som ärver från den abstrakta klassen "Level"
internal class LevelOne : Level
{
    // Konstruktor som körs när en instans av klassen "LevelOne" skapas
    public LevelOne(string name)
    {
        // Sätter värde på Name-egenskapen
        base.Name = name;
    }

    // Metod för att implementera den abstrakta metoden
    public override void LevelDescript()
    {
        Game.Print("Du befinner dig vid stenporten där du möter du den mystiska figuren Eldrion, \n");
        Game.Print("väktaren av skogen. Han berättar att skogen har förändrats den senaste tiden \n");
        Game.Print("och att han inte vet hur han ska kunna återställa balansen...");
    }
}