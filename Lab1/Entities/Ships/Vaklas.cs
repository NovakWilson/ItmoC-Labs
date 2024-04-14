using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Vaklas : BaseShip
{
    public Vaklas()
        : base(new ImpulseEngineE(), new SecondClassHull(),  new GammaJumpEngine(), new FirstClassBaseDeflector())
    {
    }
}