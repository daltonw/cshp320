using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework2
{

    class Program
    {
        static void Main(string[] args)
        {

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            //Use Linq for all requirements, and not for/foreach loops to manipulate the users list.
            var userList =
                from user in users
                select user;

            //test print out all users.
            Console.WriteLine();
            Console.WriteLine("0. All Users");
            Console.WriteLine("------------");
            foreach (var user in userList)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine();

            // 1. display users with password = hello

            var userPasswordHello =
                from user in users
                where user.Password == "hello"
                select user;

            Console.WriteLine();
            Console.WriteLine("1. Users with Password 'hello'");
            Console.WriteLine("------------------------------");
            foreach (var user in userPasswordHello)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine();

            // 2. Delete any passwords that are the lower-cased version of their Name.

            //var userPasswordNotLowercaseName =
            //    from user in users
            //    where user.Password != user.Name.ToLower()
            //    select user;

            //Console.WriteLine();
            //Console.WriteLine("2. Users not using Password 'lowercase of name'");
            //Console.WriteLine("-----------------------------------------------");
            //foreach (var user in userPasswordNotLowercaseName)
            //{
            //    Console.WriteLine(user);
            //}
            //Console.WriteLine();

            //users.Remove(users.Find(x => x.Password == x.Name.ToLower()));

            //Console.WriteLine();
            //Console.WriteLine("2. User List after removing First User with Password of 'Lowercase of Name'");
            //Console.WriteLine("---------------------------------------------------------------------------");
            //foreach (var user in userList)
            //{
            //    Console.WriteLine(user);
            //}
            //Console.WriteLine();

            users.RemoveAll(x => x.Password == x.Name.ToLower());

            Console.WriteLine();
            Console.WriteLine("2. User List after removing All Users with Password of \"Lowercase of Name\"");
            Console.WriteLine("--------------------------------------------------------------------------");
            foreach (var user in userList)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine();

            // 3. Delete the first User that has the password "hello."

            users.Remove(users.FirstOrDefault(x => x.Password == "hello"));

            Console.WriteLine();
            Console.WriteLine("3. User List after removing First User with Password of \"hello\"");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var user in userList)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine();


            // 4. Display to console remaining users with their Name and Password

            Console.WriteLine();
            Console.WriteLine("4. Display remaining users with their Name and Password");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Name" + "          " + "Password");
            Console.WriteLine("----" + "          " + "--------");
            foreach (var user in userList)
            {
                Console.WriteLine(user.Name + "          " + user.Password);
            }
            Console.WriteLine();




        }
    }
}
