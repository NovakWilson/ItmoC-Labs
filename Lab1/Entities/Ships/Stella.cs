using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Stella : BaseShip
{
    public Stella()
        : base(new ImpulseEngineC(), new FirstClassHull(),  new OmegaJumpEngine(), new FirstClassBaseDeflector())
    {
    }
}