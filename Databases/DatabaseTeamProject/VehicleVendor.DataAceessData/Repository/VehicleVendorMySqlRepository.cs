namespace VehicleVendor.DataAceessData.Repository
{
    using System;
    using System.Linq;
    using Telerik.OpenAccess;
    using VehicleVendor.DataAceessData;

    public class VehicleVendorMySqlRepository : IVehicleVendorMySqlRepository, IDisposable
    {
        private IVehicleVendorMySqlDbContextUnitOfWork context;

        public VehicleVendorMySqlRepository()
            : this(new VehicleVendorMySqlDbContext())
        {
            var initDb = new DatabaseInitializer(this.context);
            initDb.UpdateDatabase();
        }

        public VehicleVendorMySqlRepository(IVehicleVendorMySqlDbContextUnitOfWork context)
        {
            this.context = context;
        }

        public IQueryable<DataAccessDealer> DataAccessDealers
        {
            get
            {
                return this.context.DataAccessDealers;
            }
        }

        public IQueryable<DataAccessIncome> DataAccessIncomes
        {
            get
            {
                return this.context.DataAccessIncomes;
            }
        }

        public IQueryable<DataAccessCountry> DataAccessCountries
        {
            get
            {
                return this.context.DataAccessCountries;
            }
        }

        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public void Update<T>(T old, T entity) where T : class
        {
            this.context.Delete(old);
            this.context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
