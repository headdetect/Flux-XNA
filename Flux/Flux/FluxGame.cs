using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Flux.Model.Sprites;
using Flux.Managers;
using System.Reflection;

namespace Flux {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class FluxGame : Microsoft.Xna.Framework.Game {
        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;
        public TextureManager TextureManager;

        public Version Version {
            get {
                return Assembly.GetAssembly( typeof( FluxGame ) ).GetName().Version; 
            }
        }
        public FluxGame () {
            Graphics = new GraphicsDeviceManager( this );
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize () {
#if DEBUG
            this.Window.Title = "Flux (Debug Mode) - v" + Version;
            this.IsMouseVisible = true;
#else
            this.Window.Title = "Flux - v" + Version;
#endif

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent () {
            SpriteBatch = new SpriteBatch( GraphicsDevice );

            TextureManager = new Managers.TextureManager( this );

            SpriteManager.Add( new BallSprite( this, new Vector2( GraphicsDevice.Viewport.Bounds.Width / 2, GraphicsDevice.Viewport.Bounds.Height / 2 ) ) );
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent () {
            // TODO: Save scores and such
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update ( GameTime gameTime ) {
            if ( GamePad.GetState( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.F12))
                this.Exit();

            SpriteManager.Update( gameTime );

            base.Update( gameTime );
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw ( GameTime gameTime ) {
            GraphicsDevice.Clear( Color.Black );

            SpriteBatch.Begin();

            SpriteManager.Draw( gameTime );

            SpriteBatch.End();

            base.Draw( gameTime );
        }
    }
}
