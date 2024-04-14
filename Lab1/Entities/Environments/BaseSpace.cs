using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public abstract class BaseSpace
{
    protected BaseSpace(int distance)
    {
        if (distance < 0)
        {
            distance = 0;
        }

        Distance = distance;
    }

    public int Distance { get; protected set; }
    private List<BaseObstacle> Obstacles { get; } = new List<BaseObstacle>();

    public void AddObstacle(BaseObstacle obstacle)
    {
        if (obstacle == null)
        {
            throw new ArgumentNullException(nameof(obstacle), "Argument cannot be null");
        }

        Obstacles.Add(obstacle);
    }

    public IReadOnlyList<BaseObstacle> GetListObstacles()
    {
        return Obstacles.AsReadOnly();
    }
}