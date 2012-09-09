using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flux.Managers {
    public class Settings {

        /// <summary>
        /// Gets or sets the force modifier.
        /// </summary>
        /// <value>
        /// The force modifier.
        /// </value>
        public static float BallForceModifier { get; set; }

        /// <summary>
        /// Gets or sets the ball angular dampage.
        /// </summary>
        /// <value>
        /// The ball angular dampage.
        /// </value>
        public static float BallAngularDampage { get; set; }

        /// <summary>
        /// Gets or sets the ball friction.
        /// </summary>
        /// <value>
        /// The ball friction.
        /// </value>
        public static float BallFriction { get; set; }

        /// <summary>
        /// Gets or sets the speed modifier.
        /// </summary>
        /// <value>
        /// The speed modifier.
        /// </value>
        public static float BallSpeedModifier { get; set; }

        /// <summary>
        /// Gets or sets the ball rotation iteration.
        /// </summary>
        /// <value>
        /// The ball rotation iteration.
        /// </value>
        public static float BallRotationIteration { get; set; }

        /// <summary>
        /// Gets or sets the ball acceleration.
        /// </summary>
        /// <value>
        /// The ball acceleration.
        /// </value>
        public static float BallAcceleration { get; set; }

        static Settings () {
            BallForceModifier = 1f;
            BallAngularDampage = 20f;
            BallFriction = 20f;
            BallSpeedModifier = 1f;
            BallRotationIteration = 1.8f;
            BallAcceleration = 0.9f;
        }


    }
}
