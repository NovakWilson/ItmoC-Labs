using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Shuttle : BaseShip
{
    public Shuttle()
        : base(new ImpulseEngineC(), new FirstClassHull())
    {
    }
}