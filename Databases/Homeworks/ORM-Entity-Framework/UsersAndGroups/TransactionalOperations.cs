namespace UsersAndGroups
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using UsersAndGroups.Data;

    /*Create a database holding users and groups. Create 
    a transactional EF based method that creates an 
    user and puts it in a group "Admins". In case the 
    group "Admins" do not exist, create the group in the 
    same transaction. If some of the operations fail (e.g. 
    the username already exist), cancel the entire 
    transaction.*/
    internal class TransactionalOperations
    {
        private static void Main()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<UsersAndGroupsModel>());

            using (var context = new UsersAndGroupsModel())
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {                    
                    var foundGroup = context.Groups.FirstOrDefault(g => g.Name == "Admins");
                    if (foundGroup == null)
                    {
                        context.Users.Add(new User() { Name = "Pesho", Group = new Group() { Name = "Admins" } });
                        context.SaveChanges();
                    }
                    else
                    {
                        context.Users.Add(new User() { Name = "Pesho", Group = foundGroup });
                        context.SaveChanges();
                    }

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    Console.WriteLine(ex.Message + ' ' + ex.StackTrace);
                }
            }
        }
    }
}