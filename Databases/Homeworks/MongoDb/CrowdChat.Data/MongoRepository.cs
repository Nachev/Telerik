namespace CrowdChat.Data
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Linq.Expressions;

    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.Linq;

    public class MongoRepository<T> : IMongoRepository<T> where T : IEntity
    {
        private const string DbNameKey = "MongoDbDatabaseName";
        private const string ConnectionStringKey = "MongoDbConnectionString";
        private const string DbUserNameKey = "DbUserName";
        private const string DbUserPasswordKey = "DbUserPassword";

        private MongoDatabase database;
        private MongoCollection<T> collection;

        public MongoRepository()
        {
            GetDatabase();
            GetCollection();
        }

        public bool Insert(T entity)
        {
            entity.Id = Guid.NewGuid();
            bool result = collection.Insert(entity).Ok;
            return result;
        }

        public bool Update(T entity)
        {
            if (entity.Id == null)
            {
                return Insert(entity);
            }

            // If entity.Id is unique, it will be inserted.
            bool result = this.collection.Save(entity).DocumentsAffected > 0;
            return result;
        }

        public bool Delete(T entity)
        {
            bool result = this.collection.Remove(Query.EQ("_id", entity.Id)).DocumentsAffected > 0;
            return result;
        }

        public IList<T> Find(Expression<Func<T, bool>> predicate)
        {
            var result = this.collection.AsQueryable<T>().Where(predicate.Compile()).ToList();

            return result;
        }

        public IList<T> GetAll()
        {
            var result = this.collection.FindAllAs<T>().ToList();
            return result;
        }

        public T GetById(Guid id)
        {
            var result = this.collection.FindOneByIdAs<T>(id);
            return result;
        }

        public IQueryable<T> GetAllQueryable()
        {
            var result = this.collection.AsQueryable<T>();
            return result;
        }

        private void GetCollection()
        {
            this.collection = database.GetCollection<T>(typeof(T).Name);
        }

        private void GetDatabase()
        {
            var dbName = ConfigurationManager.AppSettings.Get(DbNameKey);
            var connectionString = ConfigurationManager.AppSettings.Get(ConnectionStringKey);
            var dbUserName = ConfigurationManager.AppSettings.Get(DbUserNameKey);
            var dbUserPassword = ConfigurationManager.AppSettings.Get(DbUserPasswordKey);
            connectionString = connectionString.Replace("{DB_NAME}", dbName);
            connectionString = connectionString.Replace("{DB_USER}", dbUserName);
            connectionString = connectionString.Replace("{DB_PASSWORD}", dbUserPassword);

            var client = new MongoClient(connectionString);
            var server = client.GetServer();

            this.database = server.GetDatabase(dbName);
        }
    }
}