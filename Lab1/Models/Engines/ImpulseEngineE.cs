using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class ImpulseEngineE : BaseImpulseEngine
{
    public ImpulseEngineE()
        : base()
    {
    }

    public override double GetFuelCost(double distance)
    {
        double time = 1;
        double fuelSpent = 1;

        while (distance > 0)
        {
            Speed *= Math.Exp(0.5 * time);
            distance -= Speed;
            time += 1;
            fuelSpent += Speed;
        }

        return fuelSpent + NeedToStart;
    }

    public override double GetNeededTime(double distance)
    {
        double time = 1;
        double fuelSpent = 1;

        while (distance > 0)
        {
            Speed *= Math.Exp(0.5 * time);
            distance -= Speed;
            time += 1;
            fuelSpent += Speed;
        }

        return time;
    }
}