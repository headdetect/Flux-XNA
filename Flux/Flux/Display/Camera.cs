using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Flux.Display {
    public class Camera {

        public FluxGame Game { get; set; }

        public readonly int Width;
        public readonly int Height;

        Vector2 position;
        float zoom;
        float rotation;

        public Matrix Transform {
            get {
                return Matrix.CreateTranslation ( new Vector3 ( -position.X, -position.Y, 0 ) ) *
                       Matrix.CreateRotationZ ( rotation ) *
                       Matrix.CreateScale ( new Vector3 ( zoom, zoom, 1 ) ) *
                       Matrix.CreateTranslation ( new Vector3 ( Width * .5f, Height * .5f, 0 ) );
            }
        }

        public Vector2 Position { get { return position; } set { position = value; } }

        public float Zoom { get { return zoom; } set { zoom = value; if ( zoom < .1f ) zoom = .1f; } }

        public float Rotation { get { return rotation; } set { rotation = value; } }


        public Camera ( FluxGame game ) {
            Game = game;

            position = new Vector2 ();
            zoom = 1f;
            rotation = 0f;

            Width = game.GraphicsDevice.Viewport.Width;
            Height = game.GraphicsDevice.Viewport.Height;
        }

        public void Move ( Vector2 plusAmount ) {
            position += plusAmount;
        }

        internal void Update () {
            var state = Keyboard.GetState ();

            if ( state.IsKeyDown ( Keys.Up ) ) {
                Position -= new Vector2 ( 0, 3 );
            }
            if ( state.IsKeyDown ( Keys.Down ) ) {
                Position += new Vector2 ( 0, 3 );
            }
            if ( state.IsKeyDown ( Keys.Right ) ) {
                Position += new Vector2 ( 3, 0 );
            }
            if ( state.IsKeyDown ( Keys.Left ) ) {
                Position -= new Vector2 ( 3, 0 );
            }


            if ( state.IsKeyDown ( Keys.LeftControl ) ) {
                if ( state.IsKeyDown ( Keys.Up ) ) {
                    Zoom += .04f;
                }
                if ( state.IsKeyDown ( Keys.Down ) ) {
                    Zoom -= .04f;
                }
                if ( state.IsKeyDown ( Keys.RightShift ) ) {
                    Zoom = 1f;
                }

                if ( state.IsKeyDown ( Keys.Right ) ) {
                    Rotation += .1f;
                }
                if ( state.IsKeyDown ( Keys.Left ) ) {
                    Rotation -= .1f;
                }
                if ( state.IsKeyDown ( Keys.RightControl ) ) {
                    Rotation = 0f;
                }

            }
        }


    }
}
