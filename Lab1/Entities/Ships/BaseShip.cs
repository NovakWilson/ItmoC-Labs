using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullStrength;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public abstract class BaseShip
{
    protected BaseShip(
        BaseImpulseEngine impulseEngine,
        BaseHullStrength hullStrength,
        BaseJumpEngine? jumpEngine = null,
        BaseDeflector? deflector = null)
    {
        if (impulseEngine == null)
        {
            throw new ArgumentNullException(nameof(impulseEngine), "Argument cannot be null");
        }

        if (hullStrength == null)
        {
            throw new ArgumentNullException(nameof(hullStrength), "Argument cannot be null");
        }

        ImpulseEngine = impulseEngine;
        JumpEngine = jumpEngine;
        Deflector = deflector;
        HullStrength = hullStrength;
    }

    public BaseImpulseEngine ImpulseEngine { get; protected set; }
    public BaseJumpEngine? JumpEngine { get; protected set;  }
    public BaseDeflector? Deflector { get; protected set; }
    public BaseHullStrength HullStrength { get; protected set; }
    public bool IsAlive { get; protected set; } = true;
    public bool HasAntinitrineEmitter { get; set; }

    public void TakeDamage(IReadOnlyList<BaseObstacle> obstacles)
    {
        if (obstacles == null)
        {
            throw new ArgumentNullException(nameof(obstacles), "Argument cannot be null");
        }

        foreach (BaseObstacle obstacle in obstacles)
        {
            if (obstacle is AntimatterFlares)
            {
                if (Deflector is not null &&
                    Deflector.IsWorking &&
                    Deflector.IsModifiedDeflector &&
                    Deflector.AntimatterFlaresLeft > 0)
                {
                    Deflector.GetAntimatterFlareHit();
                }
                else
                {
                    IsAlive = false;
                    break;
                }
            }
            else if (obstacle is CosmoWhale)
            {
                if (!HasAntinitrineEmitter)
                {
                    if (Deflector is not null &&
                        Deflector.IsWorking &&
                        Deflector is ThirdClassBaseDeflector)
                    {
                        Deflector.GetDamage(obstacle);
                    }
                    else
                    {
                        IsAlive = false;
                        break;
                    }
                }
            }
            else
            {
                if (HullStrength is not null && HullStrength.IsProtecting)
                {
                    HullStrength.GetDamage(obstacle);
                }
                else
                {
                    IsAlive = false;
                    break;
                }
            }
        }
    }
}