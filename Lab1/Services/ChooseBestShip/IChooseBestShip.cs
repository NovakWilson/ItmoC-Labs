using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ChooseBestShip;

public interface IChooseBestShip
{
    bool IsBestExists { get; }
    BaseShip BestShip { get; }
    void ChooseBest(IEnumerable<BaseShip> ships, IEnumerable<BaseSpace> environments);
}