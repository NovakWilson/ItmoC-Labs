using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PassRoute;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ChooseBestShip;

public class ChooseBestShip : IChooseBestShip
{
    public bool IsBestExists { get; protected set; }
    public BaseShip BestShip { get; protected set; } = new Avgur();

    public void ChooseBest(IEnumerable<BaseShip> ships, IEnumerable<BaseSpace> environments)
    {
        if (ships == null)
        {
            throw new ArgumentNullException(nameof(ships), "Argument cannot be null");
        }

        if (environments == null)
        {
            throw new ArgumentNullException(nameof(environments), "Argument cannot be null");
        }

        double bestFuel = double.MaxValue;
        foreach (BaseShip ship in ships)
        {
            double needFuel = 0;
            foreach (BaseSpace environment in environments)
            {
                var shipPass = new PassTheRoute(ship, environment);
                shipPass.Pass();
                double curFuel = shipPass.Fuel;
                if (curFuel == 0)
                {
                    needFuel = -1;
                    break;
                }

                needFuel += curFuel;
            }

            if (needFuel > 0)
            {
                if (needFuel < bestFuel)
                {
                    BestShip = ship;
                    IsBestExists = true;
                    bestFuel = needFuel;
                }
            }
        }
    }
}