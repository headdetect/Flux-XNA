using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using FluxEngine.Utils;
using Microsoft.Xna.Framework;

namespace FluxEngine.Display.UI {
    public class Button : View {

        public event EventHandler Click;

        public string Content { get; set; }

        public new Rectangle Bounds {
            get { return base.Bounds; }
            set {
                base.Bounds = value;
                gradient = TextureUtils.CreateFromGradient ( Game, new Color ( 0xBF, 0xB0, 0xB0 ), new Color ( 0xAD, 0xAD, 0xAD ), value.Width, value.Height );
            }
        }

        private Texture2D gradient;

        public Button ( BaseFluxGame game ) : base ( game ) {
            Visible = true;

        }


        public override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            base.Update ( gameTime );

            //TODO: Check for click.
        }

        public override void Draw ( Microsoft.Xna.Framework.GameTime gameTime ) {
            base.Draw ( gameTime );

            Game.SpriteBatch.Draw ( gradient, Bounds, Color.White );

        }

        public override void Init () {
            base.Init ();
            gradient = TextureUtils.CreateFromGradient ( Game, new Color ( 0xBD, 0xBD, 0xBD ), new Color ( 0xAD, 0xAD, 0xAD ), Bounds.Width, Bounds.Height );
        }
    }
}
