namespace Atm.Data.Repositories
{
    using System.Data.Entity;
    using Atm.Models.Contracts;
    using Atm.Models;

    public class TransactionHistoryRepository : GenericRepository<TransactionHistory>
    {
        public TransactionHistoryRepository(DbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
