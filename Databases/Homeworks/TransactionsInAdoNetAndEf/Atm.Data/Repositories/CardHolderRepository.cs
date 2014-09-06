namespace Atm.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Atm.Models;

    public class CardHolderRepository : GenericRepository<CardHolder>
    {
        public CardHolderRepository(DbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
