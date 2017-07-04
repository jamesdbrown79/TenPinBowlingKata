using Microsoft.VisualStudio.TestTools.UnitTesting;
using TenPinBowlingKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinBowlingKata.Tests
{
    [TestClass()]
    public class GameTests
    {
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            //setup
            game = new Game();
        }

        private void rollMultiple(int numberOfBalls, int pins)
        {
            for (int index = 0; index < numberOfBalls; index++)
            {
                game.Roll(pins);
            }
        }

        private void rollSpare()
        {
            game.Roll(5);
            game.Roll(5); 
        }

        private void rollStrike()
        {
            game.Roll(10);
        }

        //Kata test 1
        [TestMethod()]
        public void should_return_gutter_game_scores_0()
        {
            //setup

            //act
            rollMultiple(20, 0);

            //assert
            Assert.AreEqual(0, game.Score());
        }

        //Kata test 2
        [TestMethod()]
        public void should_return_one_pin_per_frame_scores_20()
        {
            //setup

            //act
            rollMultiple(20, 1);

            //assert
            Assert.AreEqual(20, game.Score());
        }

        //Kata test 3
        [TestMethod()]
        public void should_return_spare_then_three_pins_then_all_misses_scores_16()
        {
            //setup

            //act
            rollSpare();
            game.Roll(3);
            rollMultiple(17, 0);

            //assert
            Assert.AreEqual(16, game.Score());
        }

        //Kata test 4
        [TestMethod()]
        public void should_return_strike_then_three_pins_then_four_pins_then_all_misses_scores_24()
        {
            //setup

            //act
            rollStrike();
            game.Roll(3);
            game.Roll(4);
            rollMultiple(16, 0);

            //assert
            Assert.AreEqual(24, game.Score());
        }

        //Kata test 5
        [TestMethod()]
        public void should_return_perfect_game_scores_300()
        {
            //setup

            //act
            rollMultiple(12, 10);

            //assert
            Assert.AreEqual(300, game.Score());
        }
    }
}