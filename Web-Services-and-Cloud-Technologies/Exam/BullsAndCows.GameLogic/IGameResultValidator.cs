namespace BullsAndCows.GameLogic
{
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IGameResultValidator
    {
        GuessResult GetResult(string guess, string number);
    }
}
