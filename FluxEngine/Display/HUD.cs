using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FluxEngine.Managers;

namespace FluxEngine.Display {
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

        private BaseFluxGame fluxGame;


        /// <summary>
        /// Initializes a new instance of the <see cref="HUD"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public HUD ( BaseFluxGame game )
            : base ( game ) {

            fluxGame = game;

            HUDObjects = new List<IHUDComponent> ();

            Height = game.GraphicsDevice.Viewport.Height;
            Width = game.GraphicsDevice.Viewport.Width;
        }

        public override void Initialize () {
            HUDObjects.Add ( fluxGame.ViewManager = new ViewManager ( fluxGame ) );

            for ( int i = 0; i < HUDObjects.Count; i++ ) {
                HUDObjects[ i ].Init ();
            }

            base.Initialize ();
        }
        public override void Update ( GameTime gameTime ) {

            for ( int i = 0; i < HUDObjects.Count; i++ ) {
                HUDObjects[ i ].Update ( gameTime );
            }

            base.Update ( gameTime );
        }

        public override void Draw ( GameTime gameTime ) {

            foreach ( var sprite in HUDObjects.OrderBy ( x => x.ZIndex ) ) {
                sprite.Draw ( gameTime );
            }

            base.Draw ( gameTime );
        }

    }

    /// <summary>
    /// Interface for drawing stuff only to be included in the HUD
    /// </summary>
    public abstract class IHUDComponent {

        /// <summary>
        /// Gets or sets the index of the Z.
        /// </summary>
        /// <value>
        /// The index of the Z.
        /// </value>
        public int ZIndex { get; set; }

        /// <summary>
        /// Inits this instance.
        /// </summary>
        public abstract void Init ();

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public abstract void Update ( GameTime gameTime );


        /// <summary>
        /// Draws this instance.
        /// </summary>
        public abstract void Draw ( GameTime gameTime );
    }

}
