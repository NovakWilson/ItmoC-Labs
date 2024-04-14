using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullStrength;

public abstract class BaseHullStrength
{
    protected BaseHullStrength(int health)
    {
        if (health < 0)
        {
            health = 0;
        }

        Health = health;
    }

    public bool IsProtecting { get; set; } = true;
    public int Health { get; set; }

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
        IsProtecting = !(Health <= 0);
    }
}