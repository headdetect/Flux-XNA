using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using FluxEngine.Display;
using FluxEngine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FluxEngine {
    public abstract class BaseFluxGame : Game {


        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;
        public SpriteManager SpriteManager;

        public Camera Camera;
        public HUD HUD;


        public World PhysicsWorld;

    }
}
