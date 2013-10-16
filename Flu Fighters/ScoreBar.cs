#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Flu_Fighters
{
    class ScoreBar
    {
        FontString enemiesRemainingText;
        FontString enemiesRemainingValue;
        FontString heartHealthText;
        FontString heartHealthValue;
        FontString playerScoreText;
        FontString playerScoreValue;

        public ScoreBar(Game game)   
        {
            LoadContent(game);
        }
        public void LoadContent(Game game)
        {
            enemiesRemainingText = new FontString("remaining:", new Vector2(10, 5), 0.5f, game.Content);
            enemiesRemainingValue = new FontString(ContentController.getViruses().Count, new Vector2(345, 5), 0.5f, game.Content);
            heartHealthText = new FontString("health:", new Vector2(500, 5), 0.5f, game.Content);
            heartHealthValue = new FontString(Heart.health, new Vector2(715, 5), 0.5f, game.Content);
            playerScoreText = new FontString("score:", new Vector2(900, 5), 0.5f, game.Content);
            playerScoreValue = new FontString(Heart.score, new Vector2(1090, 5), 0.5f, game.Content);
            
        }
        public void Update()
        {
            enemiesRemainingText.update("remaining:");
            enemiesRemainingValue.update(ContentController.getViruses().Count);
            heartHealthText.update("health:");
            heartHealthValue.update(Heart.health);
            playerScoreText.update("score:");
            playerScoreValue.update(Heart.score);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            enemiesRemainingText.draw(spriteBatch);
            enemiesRemainingValue.draw(spriteBatch);
            heartHealthText.draw(spriteBatch);
            heartHealthValue.draw(spriteBatch);
            playerScoreText.draw(spriteBatch);
            playerScoreValue.draw(spriteBatch);
            spriteBatch.End();
        }
        
    }
}
