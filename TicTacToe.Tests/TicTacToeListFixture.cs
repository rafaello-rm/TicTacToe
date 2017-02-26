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

        [TearDown]
        public void TearDown()
        {

        }
    }
}
