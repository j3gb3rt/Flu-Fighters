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
    class ContentController
    {
        static PlayerCharacter p1;
        static List<Virus> Viruses = new List<Virus>();
        Texture2D background;
        static Random randomizer;

        public ContentController()
        {

        }

        public static void load(int wave, ContentManager content)
        {
            randomizer = new Random();
            p1 = new PlayerCharacter(content);
            waveMaker(wave, content);
            
            //background = content.Load<Texture2D>();

        }

        public static void update()
        {
            Heart.update();
            p1.update();
            Viruses.ForEach(delegate(Virus vir)
                {
                    vir.update();
                });
        }

        public static void draw(SpriteBatch spriteBatch)
        {
            p1.draw(spriteBatch);
            Viruses.ForEach(delegate(Virus vir)
            {
                vir.draw(spriteBatch);
            });
        }

        public static List<Virus> getViruses()
        {
            return Viruses;
        }

        public static Rectangle getBound()
        {
            return p1.attackBound;
        }



        private static void waveMaker(int wave, ContentManager content)
        {
            /*if (wave == 1)
            {
                Console.Write(randomizer.Next(360));
                Viruses.Add(new Virus(new Vector2(15, 500), content, randomizer.Next(0,360)));
                Viruses.Add(new Virus(new Vector2(30, 525), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(45, 560), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(60, 590), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-15, 510), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-30, 300), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-40, 200), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-60, 700), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-80, 584), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-95, 500), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-100, 500), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-200, 500), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-300, 500), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-400, 500), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-500, 500), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-600, 500), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-500, 500), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-400, 400), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-200, 300), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-100, 100), content, randomizer.Next(0,360)));
                Viruses.Add(new Virus(new Vector2(-25, 500), content, randomizer.Next(0, 360)));
                Viruses.Add(new Virus(new Vector2(-75, 500), content, randomizer.Next(0, 360)));
            }
            else if (wave == 2)
            {
                Viruses.Add(new Virus(new Vector2(-40, 200), content, randomizer.Next(0, 360)));
            }*/

            for (int i = 0; i < (7 + wave * 5); i++ )
            {
                Viruses.Add(new Virus(new Vector2(randomizer.Next(-1200-(wave*50),-200),randomizer.Next(150,650)), content, randomizer.Next(0,360)));
            }

        }

        public static void Clear()
        {
            Viruses.Clear();
        }
    }
}
