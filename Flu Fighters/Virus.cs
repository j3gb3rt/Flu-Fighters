using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Flu_Fighters
{
    class Virus : Enemy
    {
        protected Texture2D sheet;
        double rotate;

        public Virus()
        {

        }

          public Virus(Vector2 pos, ContentManager content, int rotationStart)
        {
            this.pos = pos;
            horSpeed = 0;
            sheet = content.Load<Texture2D>("friendly_enemy.png");
            bound = new Rectangle((int)pos.X - 30, (int)pos.Y - 30, 60, 60);
            rotate = (2.0 * Math.PI * (rotationStart / 360.0));
        }

        protected float maxSpeed = 30;
        protected float health = 15;
        public override void update()
        {
            bound.X = (int)pos.X - 30;
            bound.Y = (int)pos.Y - 30;

            if (bound.Intersects(ContentController.getBound()))
            {
                horSpeed = 0;
                health--;
                if (health == 0)
                {
                    ContentController.getViruses().Remove(this);
                    Heart.score += 50;
                }
            }

            else if (Heart.onBeat)
            {
                horSpeed = maxSpeed - Heart.timer*15;
            }
            else if (!Heart.onBeat)
            {
                horSpeed = (maxSpeed - Heart.timer*15) / -12;
            }

            damageHeart();
            
            pos.X += horSpeed;

            if (rotate > 6.283)
            {
                rotate = (rotate - (Math.PI * 2.0));
            }
            rotate = (rotate - 0.017);
        }

        public void damageHeart()
        {
            if (pos.X >= 1350)
            {
                Heart.health--;
                ContentController.getViruses().Remove(this);
                Heart.score -= 15;
                if (Heart.score < 0)
                {
                    Heart.score = 0;
                }
            }
        }

        public void draw(SpriteBatch sb)
        {
            //sb.Draw(sheet, pos, Color.White);
            sb.Draw(sheet, new Vector2(pos.X, pos.Y), new Rectangle(141,10,91,110), Color.White, (float) rotate, new Vector2(46,55), (health+5)/20, SpriteEffects.None, 0);
        }
    }
}
