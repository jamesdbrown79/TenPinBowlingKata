using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinBowlingKata
{
    public class Game
    {
        private int currentRoll = 0;
        private int[] rolls = new int[21];

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))  
                {
                    score += StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex)) 
                {
                    score += SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += FrameTotal(frameIndex);
                    frameIndex += 2;
                }
            }
            return score;
        }

        private bool IsSpare(int frameIndex)
        {
            return (rolls[frameIndex] + rolls[frameIndex + 1] == 10);
        }

        private bool IsStrike(int frameIndex)
        {
            return (rolls[frameIndex] == 10);
        }

        private int SpareBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private int FrameTotal(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }
    }
}
