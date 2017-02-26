using System;
using TicTacToe.service;
using NUnit.Framework;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class MainServiceFixture
    {
        TicTacToeGameService testee;

        [SetUp]
        public void SetUp()
        {
            testee = new TicTacToeGameService();
            testee.Reset(0, 0);
        }

        [Test]
        public void Reset_CheckGameBoardSize_Works()
        {
            testee.Reset(5, 1);
            var modelFromTestee = testee.GetModel();

            Assert.That(modelFromTestee, Is.Not.Null);
            Assert.That(modelFromTestee.Board.Count, Is.EqualTo(25));
            
        }

        [Test]
        public void Reset_CheckGameBoardClear_Works()
        {
            testee.Reset(5, 1);
            testee.SetLeftPlayer("Rafał");
            testee.SetRightPlayer("Aga");
            testee.MarkCell("Rafał", 1, 1);
            testee.MarkCell("Aga", 1, 2);
            var modelFromTestee = testee.GetModel();

            Assert.That(modelFromTestee.Board[0], Is.EqualTo('g'));
            Assert.That(modelFromTestee.Board[1], Is.EqualTo('o'));

            testee.Reset(5, 1);
            modelFromTestee = testee.GetModel();

            Assert.That(modelFromTestee.Board[0], Is.EqualTo(' '));
            Assert.That(modelFromTestee.Board[1], Is.EqualTo(' '));
            
        }

        [Test]
        public void SetLeftPlayer_Works()
        {
            testee.Reset(5, 1);
            testee.SetLeftPlayer("Rafał");
            var modelFromTestee = testee.GetModel();

            Assert.That(modelFromTestee, Is.Not.Null);
            Assert.That(modelFromTestee.Lplayer, Is.EqualTo("Rafał"));
        }

        [Test]
        public void MarkCell_Works()
        {
            testee.Reset(5, 3);
            testee.SetLeftPlayer("Rafał");

            testee.MarkCell("Rafał", 1, 1);
            var modelFromTestee = testee.GetModel();

            Assert.That(modelFromTestee, Is.Not.Null);
            Assert.That(modelFromTestee.Board[0], Is.EqualTo('g'));
        }

        [Test]
        public void MarkCell_CheckWinPlayer_Works()
        {
            testee.Reset(5, 3);
            testee.SetLeftPlayer("Rafał");

            testee.MarkCell("Rafał", 1, 1);
            testee.MarkCell("Rafał", 1, 2);
            testee.MarkCell("Rafał", 1, 3);
            var modelFromTestee = testee.GetModel();

            Assert.That(modelFromTestee, Is.Not.Null);
            Assert.That(modelFromTestee.Board[0], Is.EqualTo('g'));
            Assert.That(modelFromTestee.Board[1], Is.EqualTo('g'));
            Assert.That(modelFromTestee.Board[2], Is.EqualTo('g'));
            Assert.That(modelFromTestee.WinPlayer, Is.EqualTo("Rafał"));

        }
        [Test]
        public void Mark_Cell_CheckWinPlayer_2_Works()
        {
            testee.Reset(5, 3);
            testee.SetLeftPlayer("Rafał");
            testee.SetRightPlayer("Aga");

            testee.MarkCell("Rafał", 1, 1);
            testee.MarkCell("Aga", 2, 1);
            testee.MarkCell("Rafał", 1, 2);
            testee.MarkCell("Aga", 2, 2);
            testee.MarkCell("Rafał", 1, 3);
            var modelFromTestee = testee.GetModel();

            Assert.That(modelFromTestee, Is.Not.Null);
            Assert.That(modelFromTestee.Board[0], Is.EqualTo('g'));
            Assert.That(modelFromTestee.Board[1], Is.EqualTo('g'));
            Assert.That(modelFromTestee.Board[2], Is.EqualTo('g'));
            Assert.That(modelFromTestee.WinPlayer, Is.EqualTo("Rafał"));
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
