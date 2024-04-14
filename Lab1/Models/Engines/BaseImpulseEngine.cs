namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public abstract class BaseImpulseEngine
{
    protected BaseImpulseEngine()
    {
        Speed = 1;
        Fuel = 1;
    }

    public double Speed { get; protected set; }

    public double Fuel { get; protected set; }

    public int NeedToStart { get; } = 5;

    public abstract double GetFuelCost(double distance);

    public abstract double GetNeededTime(double distance);
}