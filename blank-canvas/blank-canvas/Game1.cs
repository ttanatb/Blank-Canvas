﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

/*
    Class: Game1
    Purpose: creates Monogame
*/

namespace blank_canvas
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        StageManager stageManager;

        //background position
        Vector2 backgroundPosition;
        Texture2D backgroundTexture;

<<<<<<< HEAD
        // game state
        enum GameState { MainMenu, Gameplay, Pause, EndOfGame};
        GameState state;

        // creates button
        Buttons butt;
=======
        //states to help govern game states
        enum GameState { startMenu, helpMenu, inGame, pauseMenu};
        GameState gState;
>>>>>>> 29d2134d7db5019b411bfe275b26a79d74e5cbb2

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
            

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
            stageManager = new StageManager(new Camera(GraphicsDevice.Viewport), new InputManager());
            butt = new Buttons();

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

            stageManager.LoadContent(Content, "playerStandingStill", "enemyNoColor", "tileGround5");

            backgroundPosition = new Vector2(-500, 0);
            backgroundTexture = Content.Load<Texture2D>("testBackground");

            
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            //handling input
            float deltaTime = gameTime.ElapsedGameTime.Milliseconds;

            stageManager.Update(deltaTime);

            base.Update(gameTime);
            // initializes game state
            switch (state)
            {
                case GameState.MainMenu:
                    UpdateMainMenu(deltaTime);
                    break;
                case GameState.Gameplay:
                    UpdateGameplay(deltaTime);
                    break;
                case GameState.Pause:
                    UpdatePause(deltaTime);
                    break;
                case GameState.EndOfGame:
                    UpdateEndOfGame(deltaTime);
                    break;
            }
        }

        // changes from main menu to gameplay
        private void UpdateMainMenu(float deltaTime)
        {
            if (butt.isPressed())
                state = GameState.Gameplay;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //for camera
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, stageManager.Camera.Transform);
            spriteBatch.Draw(backgroundTexture, backgroundPosition, Color.White);
            stageManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
