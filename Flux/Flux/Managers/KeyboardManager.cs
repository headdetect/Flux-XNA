using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace Flux.Managers {

    public class KeyboardManager : System.Windows.Forms.IMessageFilter {

        /// <summary>
        /// Occurs when any key is pressed.
        /// </summary>
        public static event EventHandler<KeyEventArgs> KeyPressEvent;

        static KeyboardManager () {
            System.Windows.Forms.Application.AddMessageFilter( new KeyboardManager() );
        }

        private KeyboardManager () {
            //--Do nothing
        }

        [DllImport( "user32.dll" )]
        static extern bool TranslateMessage ( ref System.Windows.Forms.Message msg );

        const int WM_CHAR = 0x0102;
        const int WM_KEY = 0x0100;

        [DebuggerStepThrough]
        public bool PreFilterMessage ( ref System.Windows.Forms.Message m ) {
            if ( m.Msg == WM_KEY ) {
                TranslateMessage( ref m );
            }
            else if ( m.Msg == WM_CHAR ) {
                if ( KeyPressEvent != null ) {
                    KeyPressEvent( this, new KeyEventArgs(Keyboard.GetState().GetPressedKeys()));
                }
            }
            return false;
        }
    }

    public class KeyEventArgs : EventArgs {

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public Keys[] Keys { get; set; }

        public KeyEventArgs ( Keys[] keys ) {
            this.Keys = keys;
        }
    }

}
