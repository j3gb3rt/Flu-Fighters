using System.Linq;
using System.Text;
#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Audio;
#endregion
namespace Flu_Fighters
{
    class PlayerCharacter
    {

        bool isAlive = true;
        public const int NORTH = 0;
        public const int SOUTH = 1;
        public const int EAST = 2;
        public const int WEST = 3;
        public const int NORTHEAST = 4;
        public const int NORTHWEST = 5;
        public const int SOUTHEAST = 6;
        public const int SOUTHWEST = 7;

        Vector2 pos;
        Single rot;
        Vector2 attackPos;
        Single attackRot;
        int attackTimer = -20;
        SoundEffect moveSound;
        SoundEffect nomSound;
        SoundEffectInstance moveInstance;
        SoundEffectInstance nomInstance;
        Texture2D sheet;
        Texture2D attackSheet;
        public Rectangle attackBound = new Rectangle(-1,-1,0,0);

        //int[,] sprite = new int[,] {{13,8,77,91},{141,8,75,101},{282,5,80,107},{418,4,78,107}};
        Rectangle[] source = new Rectangle[] { new Rectangle(13, 8, 77, 91), new Rectangle(141, 8, 75, 101), new Rectangle(282,5,80,107), new Rectangle(418,4,78,107)};
        Rectangle[] sourceAttack = new Rectangle[] { new Rectangle(14,47,84,48), new Rectangle(11,121,88,62), new Rectangle(10,205,90,79), new Rectangle(11,304,90,96), new Rectangle(12,427,88,102), new Rectangle(13,558, 89,92), new Rectangle(13,679,87,71)};
        int move = 0;
        int anim;
        int attackanim = 0;
        int attackmove = 0;

        int movespeed = 5;

        int direction = 0;

        public PlayerCharacter(ContentManager content)
        {
            pos = new Vector2(1150,300);
            sheet = content.Load<Texture2D>("nkcell.png");
            attackSheet = content.Load<Texture2D>("grabani.png");
            moveSound = content.Load<SoundEffect>("cellmove.wav");
            nomSound = content.Load<SoundEffect>("cellnoms.wav");
            moveInstance=moveSound.CreateInstance();
            nomInstance = nomSound.CreateInstance();
        }

        public void update()
        {
            #region Move Stuff
            if (Keyboard.GetState().IsKeyDown(Keys.Up)&&Keyboard.GetState().IsKeyDown(Keys.Left)){
                pos.X-=movespeed;
                pos.Y -= movespeed;
                direction = NORTHWEST;
                moveTest();
                rot = (float)Math.PI * 7 / 4;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                pos.X += movespeed;
                pos.Y -= movespeed;
                direction = NORTHEAST;
                moveTest();
                rot = (float)Math.PI * 1 / 4;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                pos.X -= movespeed;
                pos.Y += movespeed;
                direction = SOUTHWEST;
                moveTest();
                rot = (float)Math.PI * 5 / 4;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                pos.X += movespeed;
                pos.Y += movespeed;
                direction = SOUTHEAST;
                moveTest();
                rot = (float)Math.PI * 3 / 4;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                pos.Y -= movespeed;
                direction = NORTH;
                moveTest();
                rot = 0;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                pos.Y += movespeed;
                direction = SOUTH;
                moveTest();
                rot = (float)Math.PI;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                pos.X -= movespeed;
                direction = WEST;
                moveTest();
                rot = (float)Math.PI * 3 / 2;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                pos.X += movespeed;
                direction = EAST;
                moveTest();
                rot = (float)Math.PI / 2;
            }
            else
            {
                move = 0;
                anim = 0;
            }
            #endregion

            #region Attack Direction Stuff
            attackTimer--;

            if (attackTimer< -20 && Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                attackTimer = 30;
                if (nomInstance.State != SoundState.Playing)
                {
                    nomInstance.Volume = 100f;
                    nomInstance.Play();
                }
            }

            if (attackTimer > 0)
            {
                
                if (direction == NORTH)
                {
                    attackPos.X = pos.X;
                    attackPos.Y = pos.Y - (source[move].Height/2 + sourceAttack[attackmove].Height/2)/2;
                    attackRot = 0;
                }
                if (direction == SOUTH)
                {
                    attackPos.X = pos.X;
                    attackPos.Y = pos.Y + (sourceAttack[attackmove].Height / 2 + source[move].Height / 2)/2;
                    attackRot = (float)Math.PI;
                }
                if (direction == WEST)
                {
                    attackPos.X = pos.X - (sourceAttack[attackmove].Width / 2 + source[move].Width / 2)/2;
                    attackPos.Y = pos.Y;
                    attackRot = (float)Math.PI*3/2;
                }
                if (direction == EAST)
                {
                    attackPos.X = pos.X + (sourceAttack[attackmove].Width / 2 + source[move].Width / 2)/2;
                    attackPos.Y = pos.Y;
                    attackRot = (float)Math.PI/2;
                }
                if (direction == NORTHWEST)
                {
                    attackPos.X = pos.X - (sourceAttack[attackmove].Height / 2 + source[move].Height / 2)  / 3;
                    attackPos.Y = pos.Y - (sourceAttack[attackmove].Height / 2 + source[move].Height / 2)  / 3;
                    attackRot = (float)Math.PI*7/4;
                }
                if (direction == NORTHEAST)
                {
                    attackPos.X = pos.X + (sourceAttack[attackmove].Height / 2 + source[move].Height / 2)  / 3;
                    attackPos.Y = pos.Y - (sourceAttack[attackmove].Height / 2 + source[move].Height / 2)  / 3;
                    attackRot = (float)Math.PI/4;
                }
                if (direction == SOUTHWEST)
                {
                    attackPos.X = pos.X - (sourceAttack[attackmove].Height / 2 + source[move].Height / 2)  / 3;
                    attackPos.Y = pos.Y + (sourceAttack[attackmove].Height / 2 + source[move].Height / 2)  / 3;
                    attackRot = (float)Math.PI*5/4;
                }
                if (direction == SOUTHEAST)
                {
                    attackPos.X = pos.X + (sourceAttack[attackmove].Height / 2 + source[move].Height / 2)  / 3;
                    attackPos.Y = pos.Y + (sourceAttack[attackmove].Height / 2 + source[move].Height / 2)  / 3;
                    attackRot = (float)Math.PI*3/4;
                }
            }
            else
            {
                attackPos.X = -100;
                attackPos.Y = -100;
            }

            attackBound.X = (int)attackPos.X - 20;//sourceAttack[attackmove].Width / 2;
            attackBound.Y = (int)attackPos.Y - 20;//sourceAttack[attackmove].Height / 2;
            attackBound.Width = 40;//sourceAttack[attackmove].Width;
            attackBound.Height = 40;//sourceAttack[attackmove].Height;

            #endregion

            if(pos.X < 0) pos.X = 0;
            if (pos.X > 1280) pos.X = 1280;
            if (pos.Y < 108 + source[move].Height / 2) pos.Y = 108 + source[move].Height / 2;
            if (pos.Y > 720 - 48 - source[move].Height / 2) pos.Y = 720  - 48 - source[move].Height / 2;


            attackTime();
        }

        public void draw(SpriteBatch SB)
        {
            SB.Draw(attackSheet, new Rectangle((int)attackPos.X, (int)attackPos.Y, sourceAttack[attackmove].Width, sourceAttack[attackmove].Height), sourceAttack[attackmove], Color.White, attackRot, new Vector2(sourceAttack[attackmove].Width / 2, sourceAttack[attackmove].Height / 2), SpriteEffects.None, 0);
            SB.Draw(sheet, new Rectangle((int)pos.X,(int)pos.Y,source[move].Width,source[move].Height), source[move], Color.White, rot, new Vector2(source[move].Width/2, source[move].Height/2), SpriteEffects.None, 0);            
        }

        void moveTest()
        {
            anim++;
            if (anim == 4)
            {
                move++;
                anim = 0;
            }
            if (move > 3)
            {
                move = 2;
            }
            
            if (moveInstance.State!=SoundState.Playing)
            {
                moveInstance.Volume=100f;
                moveInstance.Play();
            }
        }

        void attackTime()
        {
            if (attackTimer > 40) attackmove = 0;
            else if (attackTimer > 30) attackmove = 1;
            else if (attackTimer > 20) attackmove = 2;
            else if (attackTimer > 15) attackmove = 3;
            else if (attackTimer > 10) attackmove = 4;
            else if (attackTimer > 5) attackmove = 5;
            else if (attackTimer > 0) attackmove = 6;
        }


    }
}
