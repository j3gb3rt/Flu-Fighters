using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Flu_Fighters

{
    class Pointer
    {
        int positionIndex;
        Vector2[] validPositions;
        Vector2 currentPosition;
        Texture2D menuPointer;
        int wait;

        public Pointer(int[] xValues, int[] yValues, Texture2D pointerImage)
        {
            validPositions = new Vector2[xValues.Length];
            for (int i = 0; i < xValues.Length; i++)
            {
                validPositions[i] = new Vector2(xValues[i], yValues[i]);
            }
            positionIndex = 0;
            menuPointer = pointerImage;
            currentPosition = validPositions[positionIndex];
        }
        public void update()
        {
            if (wait > 7)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    if (positionIndex < validPositions.Length - 1)
                    {
                        positionIndex++;
                        wait = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    if (positionIndex > 0)
                    {
                        positionIndex--;
                        wait = 0;
                    }
                }
            }
            wait++;
            if (wait > 2000)
            {
                wait = 8;
            }
            currentPosition.Y = currentPosition.Y + ((validPositions[positionIndex].Y - currentPosition.Y)/2);
            //displayHealth = displayHealth + ((health - displayHealth) / 10);
        }
        public void draw(SpriteBatch SB)
        {
            SB.Draw(menuPointer, currentPosition, Color.White);
        }

        public int getOption()
        {
            return positionIndex;
        }
    }
}
