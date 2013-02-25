using System;
using FarseerPhysics;
using FarseerPhysics.DebugViews;
using Flux.Entities;
using Flux.Entities.Sprites;
using FluxEngine;
using FluxEngine.Display;
using FluxEngine.Managers;
using FluxEngine.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection;
using FarseerPhysics.Dynamics;
using Flux.Display;
using System.Diagnostics;
using FluxEngine.Display.UI;

namespace Flux {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class FluxGame : BaseFluxGame {

        /// <summary>
        /// Gets the version.
        /// </summary>
        public Version Version {
            get {
                return Assembly.GetAssembly ( typeof ( FluxGame ) ).GetName ().Version;
            }
        }

        public Flux.Managers.ContentManager TextureManager;

        private DebugViewXNA _debugView;

        //-- Game Entities --//

        public Background Background;

        public Player Player;
        public ToolBox ToolBox;


#if DEBUG
        public DebugForm DebugForm;
#endif


        public FluxGame ()
            : base () {

            Graphics = new GraphicsDeviceManager ( this );
            Content.RootDirectory = "Content";

            this.IsFixedTimeStep = true;
            ConvertUnits.SetDisplayUnitToSimUnitRatio ( 64f );

            Graphics.PreferredBackBufferHeight = 600;
            Graphics.PreferredBackBufferWidth = 1200;

#if !DEBUG
            Graphics.PreferredBackBufferHeight = 1080;
            Graphics.PreferredBackBufferWidth = 1650;
            Graphics.PreferMultiSampling = false;
            Graphics.IsFullScreen = true;
#endif

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
            this.IsMouseVisible = false;
#else
            this.Window.Title = "Flux - v" + Version;
#endif

            base.Initialize ();

            HUD.HUDObjects.Add ( new CursorComponent ( this ) );
            HUD.HUDObjects.Add ( new FPSComponent ( this ) );
            HUD.HUDObjects.Add ( new CursorLocationComponent ( this ) );

            Components.Add ( HUD );
            HUD.Initialize ();

            var button = new Button ( this ) { Bounds = new Rectangle ( HUD.Width - 80 , HUD.Height - 35, 40, 20 ) };

            ViewManager.Add ( button );
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent () {
            base.LoadContent ();

            Background = new Background ( this );

            Background.ChangeBackground ( "BackgroundTextureOne" );
            SpriteManager.Add ( Background );

            TextureManager = new Managers.ContentManager ( this );

            /* Top Wall */
            SpriteManager.Add ( new WallSprite ( this, new Vector2 ( 0, -HUD.Height / 2f ), HUD.Width, 30 ) );

            /* Left Wall */
            SpriteManager.Add ( new WallSprite ( this, new Vector2 ( -HUD.Width / 2f, 0 ), 30, HUD.Height ) );

            /* Right Wall */
            SpriteManager.Add ( new WallSprite ( this, new Vector2 ( HUD.Width / 2f - 15, 0 ), 30, HUD.Height ) );

            /* Bottom Wall */
            SpriteManager.Add ( new WallSprite ( this, new Vector2 ( 0, HUD.Height / 2f - 15 ), HUD.Width, 30 ) );


            ToolBox = new Display.ToolBox ( this );
            HUD.HUDObjects.Add ( ToolBox );
            Player = new Player ( this );



            Prefabs.CreatePrefabs ( this );

            SetupDebug ();
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
        [DebuggerStepThrough]
        protected override void Update ( GameTime gameTime ) {
            if ( GamePad.GetState ( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown ( Keys.F12 ) )
                this.Exit ();

            PhysicsWorld.Step ( (float) gameTime.ElapsedGameTime.TotalMilliseconds * .001f );



#if DEBUG
            if ( Keyboard.GetState ().IsKeyDown ( Keys.H ) ) {
                if ( DebugForm == null )
                    DebugForm = new Display.DebugForm ( this );
                DebugForm.Show ();
            }
#endif

            base.Update ( gameTime );
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw ( GameTime gameTime ) {
            GraphicsDevice.Clear ( Color.Black );

            SpriteBatch.Begin ( SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointWrap, null, null, null, Camera.View );

            SpriteManager.Draw ( gameTime );

            SpriteBatch.End ();

            DrawDebugData ();

            base.Draw ( gameTime );
        }

        #region DEBUG

        private void SetupDebug () {
            // create and configure the debug view
            _debugView = new DebugViewXNA ( this, PhysicsWorld );

            _debugView.AppendFlags ( DebugViewFlags.PerformanceGraph );
            _debugView.AppendFlags ( DebugViewFlags.CenterOfMass );
            _debugView.AppendFlags ( DebugViewFlags.Shape );
            _debugView.AppendFlags ( DebugViewFlags.DebugPanel );
            //_debugView.AppendFlags(DebugViewFlags.AABB);

            _debugView.DefaultShapeColor = Color.White;
            _debugView.SleepingShapeColor = Color.LightGray;
            _debugView.LoadContent ( GraphicsDevice, Content );
        }

        private void DrawDebugData () {
            Matrix proj = Matrix.CreateOrthographicOffCenter ( 0f, HUD.Width, HUD.Height, 0f, 0f, 1f );
            Matrix view2 = Matrix.CreateScale ( 64 );
            view2 *= Camera.View;
            _debugView.RenderDebugData ( ref proj, ref view2 );
        }

        #endregion
    }
}
