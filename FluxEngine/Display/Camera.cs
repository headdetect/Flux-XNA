using System;
using FluxEngine.Entity;
using Microsoft.Xna.Framework;
using FarseerPhysics;
using Microsoft.Xna.Framework.Input;

namespace FluxEngine.Display {

    public class Camera {

        #region Consts

        private const float MIN_ZOOM = .05f;
        private const float MAX_ZOOM = 20f;
        private const float _maxRotation = -(float) Math.PI;
        private const float _minRotation = (float) Math.PI;

        #endregion

        BaseFluxGame game;

        Vector2 _minPosition;
        Vector2 _maxPosition;


        Matrix transform;
        Vector2 currentPos;
        float currentRotation;
        float currentZoom;

        bool spriteTracking;
        Sprite trackedSprite;

        Matrix projection;
        Vector2 targetPos;
        float targetRot;

        Vector2 center;
        Matrix screen;

        /// <summary>
        /// The constructor for the Camera2D class.
        /// </summary>
        public Camera ( BaseFluxGame game ) {
            this.game = game;
            projection = Matrix.CreateOrthographicOffCenter( 0f, ConvertUnits.ToSimUnits( game.GraphicsDevice.Viewport.Width ),
                                                             ConvertUnits.ToSimUnits( game.GraphicsDevice.Viewport.Height ), 0f, 0f,
                                                             1f );
            screen = Matrix.Identity;
            transform = Matrix.Identity;

            center = new Vector2( ConvertUnits.ToSimUnits( game.GraphicsDevice.Viewport.Width / 2f ),
                                           ConvertUnits.ToSimUnits( game.GraphicsDevice.Viewport.Height / 2f ) );

            ResetCamera();
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        public Matrix View { get { return transform; } }

        /// <summary>
        /// Gets the simulated view.
        /// </summary>
        public Matrix SimView { get { return screen; } }

        /// <summary>
        /// Gets the simulated projection.
        /// </summary>
        public Matrix SimProjection {
            get { return projection; }
        }

        /// <summary>
        /// The current position of the camera.
        /// </summary>
        public Vector2 Position {
            get { return ConvertUnits.ToDisplayUnits( currentPos ); }
            set {
                targetPos = ConvertUnits.ToSimUnits( value );
                if ( _minPosition != _maxPosition ) {
                    Vector2.Clamp( ref targetPos, ref _minPosition, ref _maxPosition, out targetPos );
                }
            }
        }

        /// <summary>
        /// The furthest up, and the furthest left the camera can go.
        /// if this value equals maxPosition, then no clamping will be 
        /// applied (unless you override that function).
        /// </summary>
        public Vector2 MinPosition {
            get { return ConvertUnits.ToDisplayUnits( _minPosition ); }
            set { _minPosition = ConvertUnits.ToSimUnits( value ); }
        }

        /// <summary>
        /// the furthest down, and the furthest right the camera will go.
        /// if this value equals minPosition, then no clamping will be 
        /// applied (unless you override that function).
        /// </summary>
        public Vector2 MaxPosition {
            get { return ConvertUnits.ToDisplayUnits( _maxPosition ); }
            set { _maxPosition = ConvertUnits.ToSimUnits( value ); }
        }

        /// <summary>
        /// Gets or sets the rotation in rads.
        /// </summary>
        /// <value>
        /// The rotation in rads.
        /// </value>
        public float Rotation {
            get { return currentRotation; }
            set {
                targetRot = value % (float) Math.PI * 2f;
                targetRot = MathHelper.Clamp( targetRot, _minRotation, _maxRotation );
            }
        }


        /// <summary>
        /// The current rotation of the camera in radians.
        /// </summary>
        public float Zoom {
            get { return currentZoom; }
            set {
                currentZoom = value;
                currentZoom = MathHelper.Clamp( currentZoom, MIN_ZOOM, MAX_ZOOM );
            }
        }

        /// <summary>
        /// the body that this camera is currently tracking. 
        /// Null if not tracking any.
        /// </summary>
        public Sprite TrackedSprite {
            get { return trackedSprite; }
            set {
                trackedSprite = value;
                if ( trackedSprite != null ) {
                    spriteTracking = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether sprite tracking will be enabled.
        /// If sprite to track is null, this will return false.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if position tracking is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool EnablePositionTracking {
            get { return spriteTracking; }
            set {
                if ( value && trackedSprite != null ) {
                    spriteTracking = true;
                }
                else {
                    spriteTracking = false;
                }
            }
        }

        /// <summary>
        /// Moves the camera.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public void MoveCamera ( Vector2 amount ) {
            currentPos += amount;
            if ( _minPosition != _maxPosition ) {
                Vector2.Clamp( ref currentPos, ref _minPosition, ref _maxPosition, out currentPos );
            }
            targetPos = currentPos;
            spriteTracking = false;
        }

        /// <summary>
        /// Rotates the camera.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public void RotateCamera ( float amount ) {
            currentRotation += amount;
            currentRotation = MathHelper.Clamp( currentRotation, _minRotation, _maxRotation );
            targetRot = currentRotation;
            spriteTracking = false;
        }

        /// <summary>
        /// Resets the camera to default values.
        /// </summary>
        public void ResetCamera () {
            currentPos = Vector2.Zero;
            targetPos = Vector2.Zero;
            _minPosition = Vector2.Zero;
            _maxPosition = Vector2.Zero;

            currentRotation = 0f;
            targetRot = 0f;

            spriteTracking = false;

            currentZoom = .7f;

            SetView();
        }

        /// <summary>
        /// Moves the camera to the specified target
        /// </summary>
        public void MoveToTarget () {
            currentPos = targetPos;
            currentRotation = targetRot;

            SetView();
        }

        private void SetView () {
            Matrix matRotation = Matrix.CreateRotationZ( currentRotation );
            Matrix matZoom = Matrix.CreateScale( currentZoom );
            Vector3 translateCenter = new Vector3( center, 0f );
            Vector3 translateBody = new Vector3( -currentPos, 0f );

            screen = Matrix.CreateTranslation( translateBody ) *
                    matRotation *
                    matZoom *
                    Matrix.CreateTranslation( translateCenter );

            translateCenter = ConvertUnits.ToDisplayUnits( translateCenter );
            translateBody = ConvertUnits.ToDisplayUnits( translateBody );

            transform = Matrix.CreateTranslation( translateBody ) *
                         matRotation *
                         matZoom *
                         Matrix.CreateTranslation( translateCenter );
        }

        /// <summary>
        /// Moves the camera forward one timestep.
        /// </summary>
        public void Update ( GameTime gameTime ) {
            if ( trackedSprite != null ) {
                if ( spriteTracking ) {
                    targetPos = trackedSprite.Position;
                    if ( _minPosition != _maxPosition ) {
                        Vector2.Clamp( ref targetPos, ref _minPosition, ref _maxPosition, out targetPos );
                    }
                }
            }
            Vector2 delta = targetPos - currentPos;
            float distance = delta.Length();
            if ( distance > 0f ) {
                delta /= distance;
            }
            float inertia;
            if ( distance < 10f ) {
                inertia = (float) Math.Pow( distance / 10.0, 2.0 );
            }
            else {
                inertia = 1f;
            }

            float rotDelta = targetRot - currentRotation;

            float rotInertia;
            if ( Math.Abs( rotDelta ) < 5f ) {
                rotInertia = (float) Math.Pow( rotDelta / 5.0, 2.0 );
            }
            else {
                rotInertia = 1f;
            }
            if ( Math.Abs( rotDelta ) > 0f ) {
                rotDelta /= Math.Abs( rotDelta );
            }

            currentPos += 100f * delta * inertia * (float) gameTime.ElapsedGameTime.TotalSeconds;
            currentRotation += 80f * rotDelta * rotInertia * (float) gameTime.ElapsedGameTime.TotalSeconds;

            var state = Keyboard.GetState();

            if ( state.IsKeyDown( Keys.Up ) ) {
                MoveCamera( -new Vector2( 0, .1f ) );
            }
            if ( state.IsKeyDown( Keys.Down ) ) {
                MoveCamera( new Vector2( 0, .1f ) );
            }
            if ( state.IsKeyDown( Keys.Right ) ) {
                MoveCamera( new Vector2( .1f, 0 ) );
            }
            if ( state.IsKeyDown( Keys.Left ) ) {
                MoveCamera( -new Vector2( .1f, 0 ) );
            }


            if ( state.IsKeyDown( Keys.LeftControl ) ) {
                if ( state.IsKeyDown( Keys.Up ) ) {
                    Zoom += .01f;
                }
                if ( state.IsKeyDown( Keys.Down ) ) {
                    Zoom -= .01f;
                }

                /* Reset */
                if ( state.IsKeyDown( Keys.RightShift ) ) {
                    ResetCamera();
                }
            }

            SetView();
        }

        /// <summary>
        /// Converts a screen location to world location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public Vector2 ConvertScreenLocationToWorldLocation ( Vector2 location ) {
            Vector3 t = new Vector3( location, 0 );

            t = game.GraphicsDevice.Viewport.Unproject( t, projection, screen, Matrix.Identity );

            return new Vector2( t.X, t.Y );
        }

        /// <summary>
        /// Converts a world location to screen location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public Vector2 ConvertWorldLocationToScreenLocation ( Vector2 location ) {
            Vector3 t = new Vector3( location, 0 );

            t = game.GraphicsDevice.Viewport.Project( t, projection, screen, Matrix.Identity );

            return new Vector2( t.X, t.Y );
        }
    }
}