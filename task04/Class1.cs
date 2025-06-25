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
        Console.WriteLine($"Крейсер движется вперед со скоростью : {Speed}");
    }
    
    public void Rotate(int angle)
    {
        Console.WriteLine($"Крейсер поворачивается на : {angle}");
    }
    
    public void Fire()
    {
        Console.WriteLine($"Крейсер стреляет c мощностью выстрела: {FirePower}");
    }
}

public class Fighter : ISpaceship
{
    public int Speed { get; } = 100;
    public int FirePower { get; } = 50;
    
    public void MoveForward()
    {
        Console.WriteLine($"Истребитель движется вперед со скоростью : {Speed}");
    }
    
    public void Rotate(int angle)
    {
        Console.WriteLine($"Истребитель поворачивается на : {angle}");
    }
    
    public void Fire()
    {
        Console.WriteLine($"Истребитель стреляет c мощностью выстрела : {FirePower}");
    }
}