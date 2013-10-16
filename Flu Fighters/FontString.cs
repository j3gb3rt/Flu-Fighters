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
    class FontString
    {
        List<Rectangle> fontChars;
        Vector2 fontLoc;
        Texture2D font;
        float fontScale;
        ContentManager cont;
        string currentString;

        public FontString(string str, Vector2 loc, float scale, ContentManager content)
        {
            fontLoc = loc;
            cont = content;
            fontScale = scale;
            currentString = str;
            initialize(str);
        }

        public FontString(int number, Vector2 loc, float scale, ContentManager content) 
        {
            fontLoc = loc;
            cont = content;
            fontScale = scale;
            string str = number.ToString();
            currentString = str;
            initialize(str);
        }

        private void initialize(string str)
        {
            load();
            fontChars = new List<Rectangle>();
            foreach (char c in str)
            {
                fontChars.Add(getTexture(c));
            }
        }
        public void load()
        {
            font = cont.Load<Texture2D>("FluFightFont.png");
        }

        public void update(string str)
        {
            if (!str.Equals(currentString))
            {
                fontChars.Clear();
                foreach (char c in str)
                {
                    fontChars.Add(getTexture(c));
                }
            }
        }

        public void update(int number)
        {
            string str = number.ToString();
            if (!str.Equals(currentString))
            {
                fontChars.Clear();
                foreach (char c in str)
                {
                    fontChars.Add(getTexture(c));
                }
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.End(); 
            spriteBatch.Begin();
            float currentX = fontLoc.X;
            foreach (Rectangle fontChar in fontChars)
            {
                spriteBatch.Draw(font, new Vector2(currentX, fontLoc.Y), fontChar, Color.White, 0, new Vector2(0,0), fontScale, SpriteEffects.None, 0);
                currentX = (currentX + fontScale * (fontChar.Width + 3));
            }
            spriteBatch.End();
        }
        private Rectangle getTexture(char alphaNum)
        {
            switch (alphaNum)
            {
                case ' ':
                    {
                        return new Rectangle(821, 8, 20, 90);
                    }
                case '0':
                    {
                        return new Rectangle(8, 106, 65, 90);
                    }
                case '1':
                    {
                        return new Rectangle(81, 106, 28, 90);
                    }
                case '2':
                    {
                        return new Rectangle(117, 106, 66, 90);
                    }
                case '3':
                    {
                        return new Rectangle(191, 106, 66, 90);
                    }
                case '4':
                    {
                        return new Rectangle(265, 106, 61, 90);
                    }
                case '5':
                    {
                        return new Rectangle(334, 106, 68, 90);
                    }
                case '6':
                    {
                        return new Rectangle(410, 106, 67, 90);
                    }
                case '7':
                    {
                        return new Rectangle(485, 106, 55, 90);
                    }
                case '8':
                    {
                        return new Rectangle(548, 106, 65, 90);
                    }
                case '9':
                    {
                        return new Rectangle(621, 106, 66, 90);
                    }
                case ':':
                    {
                        return new Rectangle(695, 106, 17, 90);
                    }
                case 'a':
                    {
                        return new Rectangle(81, 204, 66, 90);
                    }
                case 'b':
                    {
                        return new Rectangle(155, 204, 66, 90);
                    }
                case 'c':
                    {
                        return new Rectangle(229, 204, 67, 90);
                    }
                case 'd':
                    {
                        return new Rectangle(304, 204, 66, 90);
                    }
                case 'e':
                    {
                        return new Rectangle(378, 204, 68, 90);
                    }
                case 'f':
                    {
                        return new Rectangle(454, 204, 68, 90);
                    }
                case 'g':
                    {
                        return new Rectangle(530, 204, 67, 90);
                    }
                case 'h':
                    {
                        return new Rectangle(605, 204, 68, 90);
                    }
                case 'i':
                    {
                        return new Rectangle(681, 204, 68, 90);
                    }
                case 'j':
                    {
                        return new Rectangle(757, 204, 68, 90);
                    }
                case 'k':
                    {
                        return new Rectangle(833, 204, 59, 90);
                    }
                case 'l':
                    {
                        return new Rectangle(900, 204, 54, 90);
                    }
                case 'm':
                    {
                        return new Rectangle(962, 204, 66, 90);
                    }
                case 'n':
                    {
                        return new Rectangle(1036, 204, 68, 90);
                    }
                case 'o':
                    {
                        return new Rectangle(1112, 204, 65, 90);
                    }
                case 'p':
                    {
                        return new Rectangle(8, 302, 66, 90);
                    }
                case 'q':
                    {
                        return new Rectangle(82, 302, 65, 90);
                    }
                case 'r':
                    {
                        return new Rectangle(155, 302, 66, 90);
                    }
                case 's':
                    {
                        return new Rectangle(229, 302, 68, 90);
                    }
                case 't':
                    {
                        return new Rectangle(305, 302, 55, 90);
                    }
                case 'u':
                    {
                        return new Rectangle(368, 302, 67, 90);
                    }
                case 'v':
                    {
                        return new Rectangle(443, 302, 64, 90);
                    }
                case 'w':
                    {
                        return new Rectangle(515, 302, 67, 90);
                    }
                case 'x':
                    {
                        return new Rectangle(590, 302, 68, 90);
                    }
                case 'y':
                    {
                        return new Rectangle(666, 302, 60, 90);
                    }
                case 'z':
                    {
                        return new Rectangle(734, 302, 68, 90);
                    }
                default:
                    {
                        return new Rectangle(908, 106, 45, 90);
                    }
            }
        }
    }
}
