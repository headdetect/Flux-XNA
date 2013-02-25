using System;
using System.Collections.Generic;
using FluxEngine.Entity;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Linq;
using FluxEngine.Display.UI;
using FluxEngine.Display;
using Microsoft.Xna.Framework.Graphics;

namespace FluxEngine.Managers {

    /// <summary>
    /// Manager for all Views in the game
    /// </summary>
    public class ViewManager : IHUDComponent {


        /// <summary>
        /// Gets or sets the sprites.
        /// </summary>
        /// <value>
        /// The sprites.
        /// </value>
        public List<View> Views { get; set; }

        private BaseFluxGame game;

        public ViewManager ( BaseFluxGame game ) {
            Views = new List<View> ( 255 );
            this.game = game;
        }

        /// <summary>
        /// Adds the specified sprite.
        /// </summary>
        /// <param name="sprite">The sprite.</param>
        public void Add ( View view ) {
            Views.Add ( view );
            view.ID = Views.Count;
            view.Init ();
        }

        /// <summary>
        /// Removes the specified sprite.
        /// </summary>
        /// <param name="sprite">The sprite.</param>
        /// <param name="animation">if set to <c>true</c> [animation].</param>
        public void Remove ( View view ) {
            view.Visible = false;
            Views.Remove ( view );
        }

        /// <summary>
        /// Updates all sprites with a specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        [DebuggerStepThrough]
        public override void Update ( GameTime gameTime ) {
            for ( int i = 0; i < Views.Count; i++ ) {
                Views[ i ].Update ( gameTime );
            }
        }

        /// <summary>
        /// Draws all sprites with the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        //[DebuggerStepThrough]
        public override void Draw ( GameTime gameTime ) {
            game.SpriteBatch.Begin ();

            
            foreach ( var sprite in Views.OrderBy ( x => x.ZIndex ) ) {
                sprite.Draw ( gameTime );
            }
            
            game.SpriteBatch.End ();
        }

        public override void Init () {
        }
    }
}
