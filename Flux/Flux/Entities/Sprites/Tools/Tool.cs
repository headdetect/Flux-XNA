using System;
using FluxEngine;
using FluxEngine.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flux.Entities.Sprites.Tools {
    public abstract class Tool : Sprite {

        /// <summary>
        /// Initializes a new instance of the <see cref="Tool"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        protected Tool ( BaseFluxGame game, Vector2 size, Vector2 position ) : base( game, size, position ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tool"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        protected Tool ( BaseFluxGame game, Vector2 size ) : base( game, size ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tool"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        protected Tool ( BaseFluxGame game ) : base( game ) { }

        /// <summary>
        /// Gets or sets the name of the shape.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public abstract string Name { get; }

        public override Vector2 Position { get; set; }
        public override float Rotation { get; set; }

        /// <summary>
        /// Gets the texture of the tool when it is being hovered over
        /// </summary>
        public abstract Texture2D TextureHovered { get; }

        public abstract Type BlockForm { get; }

    }
}
