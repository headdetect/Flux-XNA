using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Flux.Utils;
using FarseerPhysics.Dynamics;
using FarseerPhysics;

namespace Flux.Model.Sprites {
    public class MoveOverlaySprite : Sprite {

        #region Constuctors
        /// <summary>
        /// Initializes a new instance of the <see cref="MoveOverlaySprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        public MoveOverlaySprite ( FluxGame game, Vector2 size, Vector2 position )
            : base ( game, size, position ) {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveOverlaySprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        public MoveOverlaySprite ( FluxGame game, Vector2 size ) : this ( game, size, Vector2.Zero ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveOverlaySprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public MoveOverlaySprite ( FluxGame game ) : this ( game, Vector2.Zero, Vector2.Zero ) { }

        #endregion


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
            HoverBounds = VectorUtils.VectorsToRectangle ( sprite.Position, sprite.Size );
        }

        /// <summary>
        /// Sets the bounds with a body.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="size">The size.</param>
        public void SetBoundsWithBody ( Body body, Vector2 size ) {
            if(body == null){
                HoverBounds = new Rectangle();
            }
            HoverBounds = VectorUtils.VectorsToRectangle( ConvertUnits.ToDisplayUnits( body.Position ) - ConvertUnits.ToDisplayUnits( body.Position ) * 2, size + size * 2 );
        }

        public override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            if ( !HoverBounds.IsEmpty ) {
                Position = HoverBounds.Location.ToVector ();
                Size = new Vector2 ( HoverBounds.Width, HoverBounds.Height );
            }
        }

        public override void Init () {
            Texture = Flux.TextureManager.MoveOverlay;
        }

        public override void Draw ( GameTime gameTime ) {
            if ( Visible )
                Flux.SpriteBatch.Draw ( Texture, HoverBounds, null, Color.White, Convert.ToSingle ( Rotation * ( Math.PI / 180 ) ), Origin, SpriteEffect, ZIndex );
        }

        public override void Destroy ( bool animation ) {

        }
    }
}
