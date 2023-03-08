using MonogameDFClone.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MonogameDFClone.Builder {
    public partial class SpriteSheetEditorForm : Form {
        private const int _rows = 16;
        private const int _columns = 16;
        private IDictionary<string, SpriteSheetTile> _spriteSheetTiles = new Dictionary<string, SpriteSheetTile>();
        public SpriteSheetEditorForm() {
            InitializeComponent();
        }

        private void spriteSheetRenderer1_OnSelect(object sender, EventArgs e) {
            if(sender is SpriteSheetTile) {
                var selectedTile = ((SpriteSheetTile)sender);
                string selectedIdx = $"{selectedTile.Column}_{selectedTile.Row}";
                int index = lstBoxSpriteSheetTiles.FindStringExact(selectedIdx);
                if(index != -1) {
                    lstBoxSpriteSheetTiles.SetSelected(index, true);
                    propGrdSelectedSpriteSheetTile.SelectedObject = _spriteSheetTiles[selectedIdx];
                }
            }
        }

        private void SpriteSheetEditorForm_Load(object sender, EventArgs e) {
            //Check if file exists, if so load

            //else initialize
            for (int y = 0; y < _columns; y++) {
                for (int x = 0; x < _rows; x++) {
                    var cell = new SpriteSheetTile(x, y);
                    _spriteSheetTiles.Add($"{x}_{y}", cell);
                }
            }
            spriteSheetRenderer1.SetData(_spriteSheetTiles);
            _populateListBox();
        }

        private void _populateListBox() {
            lstBoxSpriteSheetTiles.DataSource = new BindingSource(_spriteSheetTiles, null);
            lstBoxSpriteSheetTiles.DisplayMember = "Key";
            lstBoxSpriteSheetTiles.ValueMember = "Value";
        }

        private void spriteSheetRenderer1_Click(object sender, EventArgs e) {

        }
    }
}
