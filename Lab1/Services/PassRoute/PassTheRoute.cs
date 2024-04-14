using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.PassRoute;

public class PassTheRoute : IPassTheRoute
{
    public PassTheRoute(BaseShip ship, BaseSpace space)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship), "Argument cannot be null");
        }

        if (space == null)
        {
            throw new ArgumentNullException(nameof(space), "Argument cannot be null");
        }

        Ship = ship;
        Space = space;
    }

    public BaseShip Ship { get; }
    public BaseSpace Space { get; }

    public double Time { get; protected set; }
    public double Fuel { get; protected set; }

    public void Pass()
    {
        if (Space is Space)
        {
            Ship.TakeDamage(Space.GetListObstacles());
            Time = Ship.ImpulseEngine.GetNeededTime(Space.Distance);
            Fuel = Ship.ImpulseEngine.GetFuelCost(Space.Distance);

            if (!Ship.IsAlive)
            {
                Time = 0;
                Fuel = 0;
            }
        }

        if (Space is HighDensityNebulae)
        {
            Ship.TakeDamage(Space.GetListObstacles());
            if (Ship.JumpEngine != null)
            {
                Time = Ship.JumpEngine.GetNeededTime;
                Fuel = Ship.JumpEngine.GetFuelCost;
            }

            if (Ship.JumpEngine is null ||
                Ship.JumpEngine.JumpDistance < Space.Distance ||
                !Ship.IsAlive)
            {
                Time = 0;
                Fuel = 0;
            }
        }

        if (Space is NitrineParticleNebulae)
        {
            Ship.TakeDamage(Space.GetListObstacles());
            Time = Ship.ImpulseEngine.GetNeededTime(Space.Distance);
            Fuel = Ship.ImpulseEngine.GetFuelCost(Space.Distance);

            if (!Ship.IsAlive || Ship.ImpulseEngine is not ImpulseEngineE)
            {
                Time = 0;
                Fuel = 0;
            }
        }
    }
}