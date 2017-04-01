using System;
using TicTacToe.service;
using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class TicTacToeListFixture
    {
        ITicTacToeListService testee;

        [SetUp]
        public void SetUp()
        {
            testee = new TicTacToeListService();            
        }
        [Test]
        public void GetList_NoData_Works()
        {
            var modelFromTestee = testee.GetList();
            Assert.That(modelFromTestee, Is.Not.Null);
            Assert.That(modelFromTestee.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddGame_Works()
        {
            testee.AddGame("Normal", "Rafał");

            var modelFromTestee = testee.GetList();
            Assert.That(modelFromTestee, Is.Not.Null);
            Assert.That(modelFromTestee.Count, Is.EqualTo(1));
        }
        [Test]
        public void GetGame_Works()
        {
            testee.AddGame("Normal", "Rafał");
            
            var modelFromTestee = testee.GetGame(0);
            Assert.That(modelFromTestee, Is.Not.Null);
            Assert.That(modelFromTestee, Is.InstanceOf<TicTacToeGameService>());
        }


        [Test]
        public void GetGame_GetSecondGame_Works()
        {
            testee.AddGame("Normal", "Rafał");
            testee.AddGame("Fall", "Rafał");

            var modelFromTestee = testee.GetGame(1);
            Assert.That(modelFromTestee, Is.Not.Null);
            Assert.That(modelFromTestee, Is.InstanceOf<FallTicTacToeGameService>());
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
