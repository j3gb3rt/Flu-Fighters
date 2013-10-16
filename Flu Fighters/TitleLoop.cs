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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Flu_Fighters
{
    class TitleLoop : DrawableGameComponent
    {
        Texture2D background;
        SpriteBatch spriteBatch;
        Song titleMusic;
        FontString startText;
        bool songstart = false;

        public TitleLoop(MainLoop game)
            : base(game)
        {

        }

        protected override void LoadContent()
        {
            base.LoadContent();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Game.Content.Load<Texture2D>("startbg.png");
            titleMusic = Game.Content.Load<Song>("VGJ - Title or Transition.wav");
            startText = new FontString("press enter to start", new Vector2(420, 650), 0.7f, Game.Content);
            MediaPlayer.Volume = 0.07f;
            MediaPlayer.IsRepeating = true;


        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            startText.update("press enter to start");

            if (!songstart)
            {
                MediaPlayer.Play(titleMusic);
                songstart = true;
            }
            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(titleMusic);
            }


        }


        public override void Draw(GameTime gameTime)
        {
           
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            startText.draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
