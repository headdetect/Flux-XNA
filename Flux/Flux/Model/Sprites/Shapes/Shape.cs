using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Flux.Model.Sprites.Shapes {
    public abstract class Shape : PhysicsSprite {

        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        public Shape ( FluxGame game, Vector2 size, Vector2 position ) : base( game, size, position ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        public Shape ( FluxGame game, Vector2 size ) : base( game, size ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public Shape ( FluxGame game ) : base( game ) { }

        /// <summary>
        /// Gets or sets the name of the shape.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public abstract string Name { get; }

    }
}
