namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public abstract class BaseJumpEngine
{
    protected BaseJumpEngine(double jumpDistance, double fuel)
    {
        if (JumpDistance < 0)
        {
            JumpDistance = 0;
        }

        if (fuel < 0)
        {
            fuel = 0;
        }

        JumpDistance = jumpDistance;
        Fuel = fuel;
    }

    public double JumpDistance { get; protected set; }

    public double NeedTime { get; } = 1;

    public double Fuel { get; protected set; }

    public double GetNeededTime
    {
        get { return NeedTime; }
    }

    public double GetFuelCost
    {
        get { return Fuel; }
    }
}