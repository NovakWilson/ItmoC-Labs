using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.PassRoute;

public interface IPassTheRoute
{
    BaseShip Ship { get; }
    BaseSpace Space { get; }

    double Time { get; }
    double Fuel { get; }

    void Pass();
}