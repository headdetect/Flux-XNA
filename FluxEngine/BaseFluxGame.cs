using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using FluxEngine.Display;
using FluxEngine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FluxEngine.Utils;

namespace FluxEngine {
    public abstract class BaseFluxGame : Game {


        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;
        public SpriteManager SpriteManager;

        public Camera Camera;
        public HUD HUD;

        public World PhysicsWorld;

        public ViewManager ViewManager;

        protected BaseFluxGame () {
            PhysicsWorld = new World ( PhysicsUtils.EarthGravity );
        }


        protected override void Initialize () {
            Camera = new Camera ( this );
            HUD = new HUD ( this );
            SpriteBatch = new SpriteBatch ( GraphicsDevice );
            SpriteManager = new SpriteManager ();

            base.Initialize ();
        }

        protected override void Update ( GameTime gameTime ) {
            base.Update ( gameTime );

            Camera.Update ( gameTime );
            SpriteManager.Update ( gameTime );
        }
    }
}
