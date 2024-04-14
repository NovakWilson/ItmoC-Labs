using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Avgur : BaseShip
{
    public Avgur()
        : base(new ImpulseEngineE(), new ThirdClassHull(), new AlphaJumpEngine(), new ThirdClassBaseDeflector())
    {
    }
}