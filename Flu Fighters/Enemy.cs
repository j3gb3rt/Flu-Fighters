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
    class Enemy
    {
        protected Vector2 pos;
        protected float horSpeed;
        protected Rectangle bound;
        Texture2D sheet;

        public Enemy()
        {
            pos = new Vector2(0, 0);
            horSpeed = 0;
            //bound = new Rectangle((int)pos.X, (int)pos.Y, sheet.Width, sheet.Height);
        }

        public Enemy(Vector2 pos)
        {
            this.pos = pos;
            horSpeed = 0;
           // bound = new Rectangle((int)pos.X, (int)pos.Y, sheet.Width, sheet.Height);
        }

        public Enemy(float xPos, float yPos)
        {
            this.pos = new Vector2(xPos, yPos);
            horSpeed = 0;
            //bound = new Rectangle((int)pos.X, (int)pos.Y, sheet.Width, sheet.Height);
        }

        public Enemy(Vector2 pos, float speed)
        {
            this.pos = pos;
            horSpeed = speed;
           // bound = new Rectangle((int)pos.X, (int)pos.Y, sheet.Width, sheet.Height);
        }

        public Enemy(float xPos, float yPos, float speed)
        {
            this.pos = new Vector2(xPos, yPos);
            horSpeed = speed;
           // bound = new Rectangle((int)pos.X, (int)pos.Y, sheet.Width, sheet.Height);
        }

        public virtual void update()
        {

        }

    }
}
