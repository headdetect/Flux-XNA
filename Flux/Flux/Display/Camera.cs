using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Flux.Model.Sprites;

namespace Flux.Display {
    public class Camera {

        private FluxGame Game { get; set; }

        /// <summary>
        /// Gets the center of the camera.
        /// </summary>
        public Vector2 Center { get { return new Vector2( Width, Height ) / 2f; } }

        /// <summary>
        /// Gets or sets the sprite to follow.
        /// </summary>
        /// <value>
        /// The sprite to follow.
        /// </value>
        public Sprite SpriteToFollow { get; set; }

        /// <summary>
        /// Gets or sets the bounds that when the sprite exits. It follows it.
        /// </summary>
        /// <value>
        /// The follow bounds.
        /// </value>
        public Rectangle FollowBounds { get; set; }

        public readonly int Width;
        public readonly int Height;

        Vector2 position;
        float zoom;
        float rotation;
        bool unlocked;

        /// <summary>
        /// Gets the transformation of the camera matrix.
        /// </summary>
        public Matrix Transform {
            get {
                return Matrix.CreateTranslation( new Vector3( -position.X, -position.Y, 0 ) ) *
                       Matrix.CreateRotationZ( rotation ) *
                       Matrix.CreateScale( new Vector3( zoom, zoom, 1 ) ) *
                       Matrix.CreateTranslation( new Vector3( Width * .5f, Height * .5f, 0 ) );
            }
        }

        public Vector2 Position { get { return position; } set { position = value; } }

        public float Zoom { get { return zoom; } set { zoom = value; if ( zoom < .1f ) zoom = .1f; } }

        public float Rotation { get { return rotation; } set { rotation = value; } }


        public Camera ( FluxGame game ) {
            Game = game;
            Width = game.GraphicsDevice.Viewport.Width;
            Height = game.GraphicsDevice.Viewport.Height;

            position = new Vector2();
            zoom = .7f;
            rotation = 0f;
            unlocked = false;
            FollowBounds = new Rectangle( 10, 10, Width - 20, Height - 20 );


        }

        public void Move ( Vector2 plusAmount ) {
            position += plusAmount;
        }

        internal void Update () {
            var state = Keyboard.GetState();

            if ( !unlocked && SpriteToFollow != null && FollowBounds != null ) {

                if ( (int) SpriteToFollow.Position.X < FollowBounds.X ) {
                    float delta = FollowBounds.X - SpriteToFollow.Position.X;
                    Position -= new Vector2( delta, 0 );
                    FollowBounds = new Rectangle( FollowBounds.X - (int) delta, FollowBounds.Y, FollowBounds.Width - (int) delta, FollowBounds.Height );
                }
                else if ( (int) SpriteToFollow.Position.X + (int) SpriteToFollow.Size.X > FollowBounds.Width ) {
                    float delta = SpriteToFollow.Position.X + (int) SpriteToFollow.Size.X - FollowBounds.Width;
                    Position += new Vector2( delta, 0 );
                    FollowBounds = new Rectangle( FollowBounds.X + (int) delta, FollowBounds.Y, FollowBounds.Width + (int) delta, FollowBounds.Height );
                }
                else if ( (int) SpriteToFollow.Position.Y < FollowBounds.Y ) {
                    float delta = FollowBounds.Y - SpriteToFollow.Position.Y;
                    Position -= new Vector2( 0, delta );
                    FollowBounds = new Rectangle( FollowBounds.X, FollowBounds.Y - (int) delta, FollowBounds.Width, FollowBounds.Height - (int) delta );
                }
                else if ( (int) SpriteToFollow.Position.Y + (int) SpriteToFollow.Size.Y > FollowBounds.Height ) {
                    float delta = SpriteToFollow.Position.Y + (int) SpriteToFollow.Size.Y - FollowBounds.Height;
                    Position += new Vector2( 0, delta );
                    FollowBounds = new Rectangle( FollowBounds.X, FollowBounds.Y + (int) delta, FollowBounds.Width, FollowBounds.Height + (int) delta );
                }

            }

            if ( state.IsKeyDown( Keys.Up ) ) {
                Position -= new Vector2( 0, 3 );
                unlocked = true;
            }
            if ( state.IsKeyDown( Keys.Down ) ) {
                Position += new Vector2( 0, 3 );
                unlocked = true;
            }
            if ( state.IsKeyDown( Keys.Right ) ) {
                Position += new Vector2( 3, 0 );
                unlocked = true;
            }
            if ( state.IsKeyDown( Keys.Left ) ) {
                Position -= new Vector2( 3, 0 );
                unlocked = true;
            }


            if ( state.IsKeyDown( Keys.LeftControl ) ) {
                if ( state.IsKeyDown( Keys.Up ) ) {
                    Zoom += .04f;
                    unlocked = true;
                }
                if ( state.IsKeyDown( Keys.Down ) ) {
                    Zoom -= .04f;
                    unlocked = true;
                }


                if ( state.IsKeyDown( Keys.Right ) ) {
                    Rotation += .1f;
                    unlocked = true;
                }
                if ( state.IsKeyDown( Keys.Left ) ) {
                    Rotation -= .1f;
                    unlocked = true;
                }

                /* Reset */
                if ( state.IsKeyDown( Keys.RightShift ) ) {
                    Zoom = .7f;
                    Rotation = 0f;
                    unlocked = false;
                }

            }
        }


    }
}
