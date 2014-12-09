namespace _11.Groups
{
    using System;
    using System.Transactions;
    using System.Collections.Generic;
    using System.Linq;

    class InsertingUser
    {
        static void Main(string[] args)
        {
            InsertUser("Pesho");
        }

        public static void InsertUser(string userName)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (GroupsSystemContainer context = new GroupsSystemContainer())
                {
                    Group adminGroup = new Group { Name = "Admins" };
                    if (context.Groups.Count(x => x.Name == "Admins") == 0)
                    {
                        context.Groups.Add(adminGroup);
                        context.SaveChanges();
                    }

                    if (context.Users.Count(x => x.Name == userName) > 0)
                    {
                        Console.WriteLine("User already exists.");
                        scope.Dispose();
                    }
                    else
                    {
                        Group currentgroup = context.Groups
                            .Where(x => x.Name == "Admins").First();

                        User newUser = new User()
                        {
                            Name = userName,
                            Group = currentgroup
                        };

                        context.Users.Add(newUser);
                        context.SaveChanges();
                        scope.Complete();
                        Console.WriteLine("Added the new user!");
                    }               
                }
            }
        }
    }
}
