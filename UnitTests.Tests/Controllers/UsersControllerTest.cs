using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UnitTests.Controllers;
using UnitTests.Data;
using UnitTests.Models;
using UnitTests.Tests.Utils;

namespace UnitTests.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        [TestMethod]
        public void IndexExits()
        {
            UsersController controller = new UsersController();

            ViewResult result = controller.Index().Result as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexContainsData()
        {
            UsersController controller = new UsersController();

            ViewResult result = controller.Index().Result as ViewResult;
            
            Assert.IsTrue(result.Model is List<User>);
        }

        [TestMethod]
        public void CreatePost()
        {
            DbUtils.ResetDb();

            UsersController controller = new UsersController();

            var initNbLine = 0;
            using (var db = new UnitTestsContext())
            {
                initNbLine = db.Users.Count();
            }
            User test = new User() { Firstname = "testf", Lastname = "testl", Role = null };

            ViewResult result = controller.Create(test).Result as ViewResult;

            var endNbLine = 0;
            using (var db = new UnitTestsContext())
            {
                endNbLine = db.Users.Count();
            }

            Assert.IsTrue(initNbLine == 0 && endNbLine == 1);
            Assert.IsTrue(test.Id == 1);

            User fromDb = null;
            using (var db = new UnitTestsContext())
            {
                fromDb = db.Users.FirstOrDefault();
            }

            Assert.AreNotSame(test, fromDb);
            Assert.IsTrue(test.IsEqualTo(fromDb));
        }

        [TestMethod]
        public void EditPost()
        {
            DbUtils.ResetDb();
            User testDb = DbUtils.AddInitialUser();

            UsersController controller = new UsersController();

            User cloned = new User();
            cloned.CopyIn(testDb);

            cloned.Firstname = "newF";
            cloned.Lastname = "newL";

            ViewResult result = controller.Edit(cloned).Result as ViewResult;

            User updateDb = null;
            using (var db = new UnitTestsContext())
            {
                updateDb = db.Users.Find(testDb.Id);
            }

            Assert.IsTrue(cloned.Firstname.Equals(updateDb.Firstname));
            Assert.IsTrue(cloned.Lastname.Equals(updateDb.Lastname));
        }
    }
}
