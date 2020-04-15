using System;
using GrillMaster.Domain;
using NUnit.Framework;
using Moq;


namespace GrillMaster.Tests
{
    [TestFixture]
    public class Tests
    {
        private GetMenuInteractor _interactor;
        [OneTimeSetUp]
        public void SetUp()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetGrillMenu()).Returns(TestUtils.TestGrillMenuEntity);
            _interactor = new GetMenuInteractor(mock.Object);
        }

        [Test]
        public void TestGetRounds()
        {
            var result = _interactor.Handle();
            Assert.NotNull(result);
            Assert.AreEqual(TestUtils.TestGrillMenuEntity, 1);
        }
    }
}
