using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Flux.Display {
    public partial class DebugForm : Form {

        FluxGame Game;

        public DebugForm (FluxGame game) {
            InitializeComponent();

            this.Game = game;
        }

        private void btnDestroy_Click ( object sender, EventArgs e ) {

            this.Game.Player.Sprite.Destroy(true);

        }
    }
}
