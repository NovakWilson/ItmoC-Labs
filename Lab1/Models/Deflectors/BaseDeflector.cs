using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;

public abstract class BaseDeflector
{
    protected BaseDeflector(int health)
    {
        if (health < 0)
        {
            health = 0;
        }

        Health = health;
    }

    public bool IsWorking { get; protected set; } = true;
    public int Health { get; protected set; }
    public bool IsModifiedDeflector { get; protected set; }
    public int AntimatterFlaresLeft { get; protected set; }

    public void GetDamage(BaseObstacle obstacle)
    {
        if (obstacle == null)
        {
            throw new ArgumentNullException(nameof(obstacle), "Argument cannot be null");
        }

        Health -= obstacle.Damage;
        SetDead();
    }

    public void SetDead()
    {
        IsWorking = !(Health <= 0);
    }

    public void GetAntimatterFlareHit()
    {
        AntimatterFlaresLeft -= 1;
    }

    public void ModifyDeflector()
    {
        IsModifiedDeflector = true;
        AntimatterFlaresLeft = 3;
    }
}