namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public abstract class BaseObstacle
{
    protected BaseObstacle(int damage)
    {
        if (damage < 0)
        {
            damage = 0;
        }

        Damage = damage;
    }

    public int Damage { get; protected set; }
}