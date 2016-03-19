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

        //initialize classes and variables
        Player p;
        Camera camera;

        //Textures
        Texture2D pTextureSS; // Player Standing Still
        Texture2D eTextureSS; // Enemy Standing Still

        //for camera
        //center of player
        Vector2 spriteOrigin;
        //starting location for player
        public Vector2 spritePosition;
        //background position
        Vector2 backgroundPosition;
        Texture2D backgroundTexture;
        public Rectangle playerRec;

        public Game1()
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
            // TODO: Add your initialization logic here
            p = new Player(new Rectangle(20, 20, 100, 100));
            camera = new Camera(GraphicsDevice.Viewport);
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
            p.Texture = this.Content.Load<Texture2D>("testChar");
            // TODO: use this.Content to load your game content here
            pTextureSS = Content.Load<Texture2D>("playerStandingStill");
            eTextureSS = Content.Load<Texture2D>("enemyNoColor");
            //for camera
            //values can be changed
            backgroundPosition = new Vector2(-500, 0);
            spritePosition = new Vector2(300, 250);
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
            float timer = gameTime.ElapsedGameTime.Milliseconds;

            KeyboardState kbState = Keyboard.GetState();

            //for camera
            playerRec = new Rectangle((int)spritePosition.X, (int)spritePosition.Y, pTextureSS.Width, pTextureSS.Height);
            spriteOrigin = new Vector2(playerRec.Width / 2, playerRec.Height / 2);

            //if the user hits the escape button
            if (kbState.IsKeyDown(Keys.Escape))
                Exit();

            //movement
            if(kbState.IsKeyDown(Keys.A))
            {
                //move left
                p.MoveLeft();
            }
            if (kbState.IsKeyDown(Keys.D))
            {
                //move right
                p.MoveRight();
            }
            if (kbState.IsKeyDown(Keys.W))
            {
                //jump
                if (p.CanJump == true)
                {

                }
            }
            if(kbState.IsKeyDown(Keys.Space))
            {
                //shooting
                p.Shoot();
            }

            //for camera
            camera.Update(gameTime, this);

            //tracking the player
            p.Halt();
            p.UpdateVx(timer);
            p.UpdateVy(timer);

            p.UpdatePos(timer);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //for camera
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);
            spriteBatch.Draw(backgroundTexture, backgroundPosition, Color.White);
            spriteBatch.Draw(pTextureSS, spritePosition, null, Color.White, 0, spriteOrigin, 1f, SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
