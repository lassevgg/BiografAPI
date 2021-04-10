using NUnit.Framework;
using BiografAPI.Web;
using BiografAPI.Web.Controllers;
using System.Net.Http;
using BiografAPI.Web.Models;

namespace BiografAPI.NUnitTest
{
    public class Tests
    {
        GenreController controller;
        Genre genre;

        [SetUp]
        public void Setup()
        {
            controller = new GenreController();
            genre = new Genre
            {
                Id = 50,
                Type = "UnitTest"
            };
        }

        [Test]
        public void TestGenre()
        {
            Assert.IsTrue(controller.ListAll().IsCompleted);

            Assert.IsNotNull(controller.ListAll(genre));

            Assert.IsNotNull(controller.Post(genre));

            Assert.IsNotNull(controller.Update(genre));

            Assert.IsNotNull(controller.Delete(genre));
        }
    }
}