﻿using System;
using FarseerPhysics.Collision.Shapes;
using Flux.Managers;
using FluxEngine.Entity;
using FluxEngine.Utils;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using FarseerPhysics;

namespace Flux.Entities.Sprites {
    public class MoveOverlaySprite : Sprite {

        private static readonly Rectangle PADDING = new Rectangle( 8, 8, 8, 8 );


        #region Constuctors
        /// <summary>
        /// Initializes a new instance of the <see cref="MoveOverlaySprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        public MoveOverlaySprite ( FluxGame game, Vector2 size, Vector2 position )
            : base( game, size, position ) {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveOverlaySprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        public MoveOverlaySprite ( FluxGame game, Vector2 size ) : this( game, size, Vector2.Zero ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveOverlaySprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public MoveOverlaySprite ( FluxGame game ) : this( game, Vector2.Zero, Vector2.Zero ) { }

        #endregion

        public override Vector2 Position { get; set; }
        public override float Rotation { get; set; }

        /// <summary>
        /// Gets or sets the hover bounds.
        /// </summary>
        /// <value>
        /// The hover bounds.
        /// </value>
        public Rectangle HoverBounds { get; set; }



        /// <summary>
        /// Sets the bounds with a sprite.
        /// </summary>
        /// <param name="sprite">The sprite.</param>
        public void SetBoundsWithSprite ( Sprite sprite ) {
            HoverBounds = VectorUtils.VectorsToRectangle( sprite.Position, sprite.Size );
        }

        /// <summary>
        /// Sets the bounds with a body.
        /// </summary>
        /// <param name="body">The body.</param>
        public void SetBoundsWithBody ( Body body ) {
            if ( body == null ) {
                HoverBounds = Rectangle.Empty;
                return;
            }

            HoverBounds =  VectorUtils.AddRectanglesAsPadding( VectorUtils.VectorsToRectangle( ConvertUnits.ToDisplayUnits( body.Position ), VectorUtils.GetSizeFromShape( body.FixtureList[ 0 ].Shape ) ) , PADDING );
        }


        public override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            if ( !HoverBounds.IsEmpty ) {
                Position = HoverBounds.Location.ToVector();
                Size = new Vector2( HoverBounds.Width, HoverBounds.Height );
            }
        }

        public override void Init () {
            Texture = ContentManager.MoveOverlay;
        }

        public override void Draw ( GameTime gameTime ) {
            if ( Visible && !HoverBounds.IsEmpty )
                Game.SpriteBatch.Draw( Texture, HoverBounds, null, Color.White, Convert.ToSingle( Rotation * ( Math.PI / 180 ) ), Origin, SpriteEffect, ZIndex );
        }

        public override void Destroy ( bool animation ) {

        }
    }
}
