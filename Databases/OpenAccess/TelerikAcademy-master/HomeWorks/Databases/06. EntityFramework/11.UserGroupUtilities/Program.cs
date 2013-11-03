using System;
using System.Linq;
using System.Transactions;
using UserRepository.Model;


class UserGroupUtilities
{
    static void Main(string[] args)
    {

       bool result =  CreateUser("Milcho Ivanov", "taliban");
       Console.WriteLine(result);

    }

    private static bool CreateUser(string name, string group)
    {
        User newUser = new User();
        newUser.Name = name;
        Group newGroup = new Group();
        newGroup.Name = group;
        bool success = false;

            using (var contextDB = new UserRepositoryEntities())
            {
                using(TransactionScope trans = new TransactionScope())
                {
                    try
                    {
                        if (contextDB.Groups.FirstOrDefault(x => x.Name == newGroup.Name) == null)
                        {
                            contextDB.Groups.Add(newGroup);
                            contextDB.SaveChanges();
                        }
                        var groupID = contextDB.Groups.First(x => x.Name == newGroup.Name);
                        newUser.GroupID = groupID.ID;
                        contextDB.Users.Add(newUser);
                        contextDB.SaveChanges();
                        trans.Complete();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        if (ex.GetType() != typeof(System.Data.UpdateException))
                        {
                            Console.WriteLine("An error occured. "
                                + "The operation cannot be retried."
                                + ex.Message);
                        }
                    }
                }

            }

            return success;
    }
}