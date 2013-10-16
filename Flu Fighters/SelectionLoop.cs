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

namespace Flu_Fighters

{
    public class SelectionLoop : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D background;
        FontString stageText;
        FontString stageValue;
        FontString scoreText;
        FontString scoreValue;
        Song winMusic;
        bool songstart = false;

        public SelectionLoop(MainLoop game)
            : base(game)
        {
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            winMusic = Game.Content.Load<Song>("Theme Song.wav");
            background = Game.Content.Load<Texture2D>("stageclear.png");
            stageText = new FontString("stage:", new Vector2(400, 380), 0.8f, Game.Content);
            stageValue = new FontString(GameLoop.stage, new Vector2(695, 380), 0.8f, Game.Content); ;
            scoreText = new FontString("score:", new Vector2(400, 500), 0.8f, Game.Content);;
            scoreValue = new FontString(Heart.score, new Vector2(700, 500), 0.8f, Game.Content);;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(winMusic);

        }
        public override void Update(GameTime gameTime)
        {
            stageText.update("stage:");
            stageValue.update(GameLoop.stage);
            scoreText.update("score:");
            scoreValue.update(Heart.score);
            
            if (!songstart)
            {
                MediaPlayer.Play(winMusic);
                songstart = true;
            }
            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(winMusic);
            }


        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            stageText.draw(spriteBatch);
            stageValue.draw(spriteBatch);
            scoreText.draw(spriteBatch);
            scoreValue.draw(spriteBatch);
            spriteBatch.End();
        }

    }
}
