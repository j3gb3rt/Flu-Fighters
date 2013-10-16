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
    class Cell:Virus
    {

        public Cell()
        {

        }

        public Cell(Vector2 pos, ContentManager content)
        {
            this.pos = pos;
            horSpeed = 0;
            sheet = content.Load<Texture2D>("VirusSheet.png");
            bound = new Rectangle((int)pos.X, (int)pos.Y, sheet.Width, sheet.Height);
        }
    }
}
