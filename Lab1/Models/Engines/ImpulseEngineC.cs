namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class ImpulseEngineC : BaseImpulseEngine
{
    public ImpulseEngineC()
        : base()
    {
    }

    public override double GetFuelCost(double distance)
    {
        return (distance * Fuel) + NeedToStart;
    }

    public override double GetNeededTime(double distance)
    {
        return distance * Fuel;
    }
}