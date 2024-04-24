using System.Web.Mvc;
using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Collections.Generic;
using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace CRUD_application_2.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTest
    {
        private UserController _controller;
        private List<User> _users;

        [SetUp]
        public void Setup()
        {
            _users = new List<User>
            {
                new User { Id = 1, Name = "Test User 1", Email = "test1@example.com" },
                new User { Id = 2, Name = "Test User 2", Email = "test2@example.com" },
                new User { Id = 3, Name = "Test User 3", Email = "test3@example.com" }
            };

            UserController.userlist = _users;
            _controller = new UserController();
        }

        [Test]
        public void Index_ReturnsCorrectView_WithUsers()
        {
            var result = _controller.Index() as ViewResult;

            ClassicAssert.IsNotNull(result);
            var model = result.Model as List<User>;
            ClassicAssert.AreEqual(3, model.Count);
        }

        [Test]
        public void Details_ReturnsCorrectView_WithUser()
        {
            var result = _controller.Details(1) as ViewResult;

            ClassicAssert.IsNotNull(result);
            var model = result.Model as User;
            ClassicAssert.AreEqual("Test User 1", model.Name);
        }

        [Test]
        public void Details_ReturnsHttpNotFound_ForInvalidId()
        {
            var result = _controller.Details(999);

            ClassicAssert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void Create_ReturnsCorrectView()
        {
            var result = _controller.Create() as ViewResult;

            ClassicAssert.IsNotNull(result);
        }

        [Test]
        public void Create_Post_RedirectsToIndex_AfterSuccessfulCreation()
        {
            var result = _controller.Create(new User { Name = "New User", Email = "newuser@example.com" }) as RedirectToRouteResult;

            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("Index", result.RouteValues["action"]);
            ClassicAssert.AreEqual(4, UserController.userlist.Count);
        }

        // Add similar tests for Edit and Delete actions
    }
}
