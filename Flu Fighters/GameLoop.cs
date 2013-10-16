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
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;



namespace Flu_Fighters
{
    public class GameLoop : DrawableGameComponent
    {

        SpriteBatch spriteBatch;
        Texture2D background;
        Texture2D scorebarback;
        Texture2D wallTop;
        Texture2D wallBottom;
        ScoreBar bar;
        
        public static int stage = 0;
        
        Song playSong;
        bool songStarted = false;
        
        
        public GameLoop(MainLoop game)
            : base(game)
        {
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Game.Content.Load<Texture2D>("bground.png");
            scorebarback = Game.Content.Load<Texture2D>("scoreboard.png");
            wallTop = Game.Content.Load<Texture2D>("bgwalltop.png");
            wallBottom = Game.Content.Load<Texture2D>("bgwallbot.png");
            bar = new ScoreBar(Game);
            //stage++;
            
            stage++;
            ContentController.load(stage, Game.Content);

            playSong = Game.Content.Load<Song>("VGJ - Phase 1 (1).wav");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.07f;
            MediaPlayer.Play(playSong);
            
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ContentController.update();
            bar.Update();
            
            /*if(!songStarted)
            {
                MediaPlayer.Play(playSong);
                songStarted = true;
            }*/

        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkRed);
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(scorebarback, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(wallTop, new Vector2(0, 60), Color.White);
            spriteBatch.Draw(wallBottom, new Vector2(0, 672), Color.White);
            ContentController.draw(spriteBatch);
            bar.Draw(spriteBatch);
            
        }
        public static void createVirus()
        {
           
        }
    }
}
