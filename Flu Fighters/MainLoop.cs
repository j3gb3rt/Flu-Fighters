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
    public enum state {Title, PlayerSelect, StageSelect, Settings, Battle, Pause, Transfer, Selection}

    public class MainLoop : Game
    {


        enum menu {Battle, Settings, Exit };

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D titleScreen;
        Texture2D titleMenuBattle;
        Texture2D titleMenuSettings;
        Texture2D titleMenuExit;
        Texture2D pauseScreen;
        Texture2D titlePointer;
        int menuX;
        int menuY;
        public static state gameState { get; set; }
        static menu menuItem;
        Pointer menuSelector;


        public MainLoop()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            gameState = state.Title;
            menuItem = menu.Battle;
            menuX = 720;
            menuY = 680;

            

            this.graphics.PreferredBackBufferHeight = 720;
            this.graphics.PreferredBackBufferWidth = 1280;
            this.graphics.IsFullScreen = false;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
            
            
            
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Components.Add(new GameLoop(this)); has been moved to Update
            //titleScreen = Content.Load<Texture2D>("Title_Background.png");
            //titleMenuBattle = Content.Load<Texture2D>("Title_Text_Battle.png");
            //titleMenuSettings = Content.Load<Texture2D>("Title_Text_Settings.png");
            //titleMenuExit = Content.Load<Texture2D>("Title_Text_Sexit.png");
            //titlePointer = Content.Load<Texture2D>("Title_Menu_Arrow.png");
            //pauseScreen = Content.Load<Texture2D>("Pause_Screen_Shade.png");
            //menuSelector = new Pointer(new int[]{660, 660, 660},new int[]{725, 860, 995}, titlePointer);

            // TODO: use this.Content to load your game content here
            //Components.Add(new GameLoop(this)); 
            Components.Add(new TitleLoop(this));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //if (gameState == state.Title)
            //{
            //    menuSelector.update();

            //    switch(menuSelector.getOption()){
            //        case 0:
            //            menuItem = menu.Battle;
            //            break;
            //        case 1:
            //            menuItem = menu.Settings;
            //            break;
            //        case 2:
            //            menuItem = menu.Exit;
            //            break;
            //    }

            //    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            //    {
            //        if (menuItem == menu.Battle)
            //        {
            //            gameState = state.Battle;
            //            Components.Add(new GameLoop(this));
            //            GameLoop.delay = gameTime;
            //        }
            //        if (menuItem == menu.Exit)
            //        {
            //            Exit();
            //        }
            //    }
            //}
            base.Update(gameTime);

            if (gameState == state.Title) Title();
            else if (gameState == state.Battle) Battle();
            else if (gameState == state.Selection) Selection();

            

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);

            //if (gameState == state.Title)
            //{
            //    spriteBatch.Begin();
            //    spriteBatch.Draw(titleScreen, new Vector2(0, 0), Color.White);
            //    spriteBatch.Draw(titleMenuBattle, new Vector2(menuX, menuY), Color.White);
            //    spriteBatch.Draw(titleMenuSettings, new Vector2(menuX, menuY + 130), Color.White);
            //    spriteBatch.Draw(titleMenuExit, new Vector2(menuX, menuY + 260), Color.White);
            //    menuSelector.draw(spriteBatch);
            //    spriteBatch.End();
            //}6
            //if (gameState == state.Pause)
            //{
            //    spriteBatch.Begin();
            //    spriteBatch.Draw(pauseScreen, new Vector2(0, 0), Color.White * 0.5f);
            //    spriteBatch.End();
            //}
            base.Draw(gameTime);
        }








        private void Title()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                GameLoop.stage = 0;
                Components.Clear();
                Heart.health = 10;
                Heart.score = 0;
                Components.Add(new GameLoop(this));
                gameState = state.Battle;
                

            }
        }

        private void Battle()
        {
            if (ContentController.getViruses().Count == 0)
            {
                Components.Clear();
                ContentController.Clear();
                Components.Add(new SelectionLoop(this));
                gameState = state.Selection;
            }

            if (Heart.health <= 0)
            {
                Components.Clear();
                ContentController.Clear();
                Components.Add(new TitleLoop(this));
                gameState = state.Title;
            }
        }

        private void Selection()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Components.Clear();
                Components.Add(new GameLoop(this));
                gameState = state.Battle;
                Heart.health = 10;
            }
        }
    }
}
