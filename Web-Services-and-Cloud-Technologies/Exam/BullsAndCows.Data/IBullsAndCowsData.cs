namespace BullsAndCows.Data
{
    using System;
    using System.Linq;

    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public interface IBullsAndCowsData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Game> Games { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Guess> Guesses { get; }

        void SaveChanges();
    }
}
