using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flux.Model.Sprites.Shapes {
    public abstract class Tool : Sprite {

        /// <summary>
        /// Initializes a new instance of the <see cref="Tool"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        public Tool ( FluxGame game, Vector2 size, Vector2 position ) : base( game, size, position ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tool"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        public Tool ( FluxGame game, Vector2 size ) : base( game, size ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tool"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public Tool ( FluxGame game ) : base( game ) { }

        /// <summary>
        /// Gets or sets the name of the shape.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the texture of the tool when it is being hovered over
        /// </summary>
        public abstract Texture2D TextureHovered { get; }

    }
}
