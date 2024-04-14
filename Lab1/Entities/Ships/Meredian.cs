using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Meredian : BaseShip
{
    public Meredian()
        : base(new ImpulseEngineE(), new SecondClassHull(),  null, new SecondClassBaseDeflector())
    {
    }
}