public interface ISpaceship
{
    void MoveForward();      // Движение вперед
    void Rotate(int angle);  // Поворот на угол (градусы)
    void Fire();             // Выстрел ракетой
    int Speed { get; }       // Скорость корабля
    int FirePower { get; }   // Мощность выстрела
}

public class Cruiser : ISpaceship
{
    public int Speed { get; } = 50;
    public int FirePower { get; } = 100;
    
    public void MoveForward()
    {
        Console.WriteLine($"Cruiser is moving at speed : {Speed}");
    }
    
    public void Rotate(int angle)
    {
        Console.WriteLine($"Cruiser rotate at an angle: {angle}");
    }
    
    public void Fire()
    {
        Console.WriteLine($"Cruiser shoots with power: {FirePower}");
    }
}

public class Fighter : ISpaceship
{
    public int Speed { get; } = 100;
    public int FirePower { get; } = 50;

    public void MoveForward()
    {
        Console.WriteLine($"Fighter is moving at speed : {Speed}");
    }
    
    public void Rotate(int angle)
    {
        Console.WriteLine($"Fighter rotate at an angle: {angle}");
    }
    
    public void Fire()
    {
        Console.WriteLine($"Fighter shoots with power: {FirePower}");
    }
}
