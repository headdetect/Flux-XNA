﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Flux.Managers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision.Shapes;

namespace Flux.Model.Sprites {

    public abstract class Sprite {





        /// <summary>
        /// Gets the flux game.
        /// </summary>
        protected FluxGame Flux { get; private set; }

        /// <summary>
        /// Gets or sets the texture.
        /// </summary>
        /// <value>
        /// The texture.
        /// </value>
        protected Texture2D Texture { get; set; }


        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        public int ID { get; internal set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public Vector2 Size { get; set; }

        /// <summary>
        /// Gets or sets the sprite effect.
        /// </summary>
        /// <value>
        /// The sprite effect.
        /// </value>
        public SpriteEffects SpriteEffect { get { return _spriteEffect; } set { _spriteEffect = value; } }
        private SpriteEffects _spriteEffect = SpriteEffects.None;



        /// <summary>
        /// Gets or sets the rotation. Rotation goes from 0 - 359 degrees.
        /// </summary>
        /// <value>
        /// The rotation.
        /// </value>
        public float Rotation {
            get { return _rot; }
            set {
                _rot = value % 360;
            }
        }
        private float _rot;

        /// <summary>
        /// Gets or sets the index of the Z vert.
        /// </summary>
        /// <value>
        /// The index of the Z.
        /// </value>
        public int ZIndex { get; set; }

        /// <summary>
        /// Gets or sets the zoom scale.
        /// </summary>
        /// <value>
        /// The zoom scale.
        /// </value>
        public float ZoomScale { get { return _zoomScale; } set { _zoomScale = value; } }
        private float _zoomScale = 1f; //Default zoom scale




        /// <summary>
        /// Initializes a new empty instance of the <see cref="Sprite"/> class.
        /// </summary>
        /// <param name="fluxGame">The flux game.</param>
        public Sprite ( FluxGame fluxGame ) {
            this.Flux = fluxGame;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class.
        /// </summary>
        /// <param name="fluxGame">The flux game.</param>
        /// <param name="size">The size.</param>
        public Sprite ( FluxGame fluxGame, Vector2 size ) {
            this.Flux = fluxGame;
            this.Size = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class.
        /// </summary>
        /// <param name="fluxGame">The flux game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        public Sprite ( FluxGame fluxGame, Vector2 size, Vector2 position ) {
            this.Flux = fluxGame;
            this.Size = size;
            this.Position = position;
        }



        /// <summary>
        /// Draws this instance.
        /// </summary>
        public virtual void Draw ( GameTime gameTime ) {
            Flux.SpriteBatch.Draw( Texture, Position, null, Color.White, Convert.ToSingle( Rotation * ( Math.PI / 180 ) ), Size, ZoomScale, SpriteEffect, ZIndex );
        }



        /// <summary>
        /// Updates this instance.
        /// </summary>
        public abstract void Update ( GameTime gameTime );

        /// <summary>
        /// Inits this instance.
        /// </summary>
        public abstract void Init ();

        /// <summary>
        /// Destroys the specified sprite.
        /// </summary>
        /// <param name="animation">if set to <c>true</c> animation SHOULD be shown.</param>
        public abstract void Destroy ( bool animation );

    }

}
