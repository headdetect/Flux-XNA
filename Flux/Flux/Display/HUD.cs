using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Flux.Display {
    public class HUD : DrawableGameComponent {

        /// <summary>
        /// Width of the viewport
        /// </summary>
        public readonly int Width;

        /// <summary>
        /// Height of the viewport
        /// </summary>
        public readonly int Height;


        /// <summary>
        /// Gets or sets the HUD objects, limited to 25 elements.
        /// </summary>
        /// <value>
        /// The HUD objects.
        /// </value>
        public List<IHUDComponent> HUDObjects { get; set; }

        /// <summary>
        /// Gets or sets the cursor.
        /// </summary>
        /// <value>
        /// The cursor.
        /// </value>
        public CursorComponent Cursor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HUD"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public HUD ( FluxGame game )
            : base( game ) {
            HUDObjects = new List<IHUDComponent>( 25 );

            Height = game.GraphicsDevice.Viewport.Height;
            Width = game.GraphicsDevice.Viewport.Width;

            Cursor = new CursorComponent( game );
        }

        public override void Initialize () {
            for ( int i = 0; i < HUDObjects.Count; i++ ) {
                HUDObjects[ i ].Init();
            }
            base.Initialize();
        }
        public override void Update ( GameTime gameTime ) {

            for ( int i = 0; i < HUDObjects.Count; i++ ) {
                HUDObjects[ i ].Update( gameTime );
            }

            /* Cursor always goes on top */
            Cursor.Update( gameTime );

            base.Update( gameTime );
        }

        public override void Draw ( GameTime gameTime ) {

            for ( int i = 0; i < HUDObjects.Count; i++ ) {
                HUDObjects[ i ].Draw( gameTime );
            }

            /* Cursor always goes on top */
            Cursor.Draw( gameTime );

            base.Draw( gameTime );
        }

    }

    /// <summary>
    /// Interface for drawing stuff only to be included in the HUD
    /// </summary>
    public interface IHUDComponent {


        /// <summary>
        /// Inits this instance.
        /// </summary>
        void Init ();

        /// <summary>
        /// Updates this instance.
        /// </summary>
        void Update ( GameTime gameTime );


        /// <summary>
        /// Draws this instance.
        /// </summary>
        void Draw ( GameTime gameTime );
    }

}
