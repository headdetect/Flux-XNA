﻿using System;
using Flux.Managers;
using FluxEngine.Entity;
using FluxEngine.Utils;
using Microsoft.Xna.Framework;

namespace Flux.Entities.Sprites {
    public class RotationOverlaySprite : Sprite {

        #region Constuctors

        /// <summary>
        /// Initializes a new instance of the <see cref="MySprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        public RotationOverlaySprite ( FluxGame game, Vector2 size, Vector2 position )
            : base( game, size, position ) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MySprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        public RotationOverlaySprite ( FluxGame game, Vector2 size ) : this( game, size, Vector2.Zero ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MySprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public RotationOverlaySprite ( FluxGame game ) : this( game, Vector2.Zero, Vector2.Zero ) { }

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

        public override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            if ( !HoverBounds.IsEmpty ) {
                Position = HoverBounds.Location.ToVector();
                Size = new Vector2( HoverBounds.Width, HoverBounds.Height );
            }
        }

        public override void Init () {
            Texture = ContentManager.RotationOverlay;
        }

        public override void Draw ( GameTime gameTime ) {
            if ( Visible )
                Game.SpriteBatch.Draw( Texture, HoverBounds, null, Color.White, Convert.ToSingle( Rotation * ( Math.PI / 180 ) ), Origin, SpriteEffect, ZIndex );
        }

        public override void Destroy ( bool animation ) {

        }
    }
}
