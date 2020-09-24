using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Data;
using UnitTests.Models;

namespace UnitTests.Tests.Utils
{
    public class DbUtils
    {
        public static void ResetDb()
        {
            using (var db = new UnitTestsContext())
            {
                db.Users.RemoveRange(db.Users.ToList());
                db.Roles.RemoveRange(db.Roles.ToList());
                string userTableName = (db as IObjectContextAdapter).ObjectContext.CreateObjectSet<User>().EntitySet.Name;
                db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT('{userTableName}', RESEED, 0)");
                string roleTableName = (db as IObjectContextAdapter).ObjectContext.CreateObjectSet<Role>().EntitySet.Name;
                db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT('{roleTableName}', RESEED, 0)");
                db.SaveChanges();
            }
        }

        public static User AddInitialUser()
        {
            User result = null;

            result = new User() { Firstname = "testf", Lastname = "testl", Role = null };

            using (var db = new UnitTestsContext())
            {
                db.Users.Add(result);
                db.SaveChanges();
            }

            return result;
        }
    }
}
