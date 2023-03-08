namespace MonogameDFClone.Builder {
    partial class SpriteSheetEditorForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lstBoxSpriteSheetTiles = new System.Windows.Forms.ListBox();
            this.propGrdSelectedSpriteSheetTile = new System.Windows.Forms.PropertyGrid();
            this.spriteSheetRenderer1 = new MonogameDFClone.SpriteSheetRenderer();
            this.SuspendLayout();
            // 
            // lstBoxSpriteSheetTiles
            // 
            this.lstBoxSpriteSheetTiles.FormattingEnabled = true;
            this.lstBoxSpriteSheetTiles.Location = new System.Drawing.Point(12, 12);
            this.lstBoxSpriteSheetTiles.Name = "lstBoxSpriteSheetTiles";
            this.lstBoxSpriteSheetTiles.Size = new System.Drawing.Size(215, 433);
            this.lstBoxSpriteSheetTiles.TabIndex = 1;
            // 
            // propGrdSelectedSpriteSheetTile
            // 
            this.propGrdSelectedSpriteSheetTile.Location = new System.Drawing.Point(12, 451);
            this.propGrdSelectedSpriteSheetTile.Name = "propGrdSelectedSpriteSheetTile";
            this.propGrdSelectedSpriteSheetTile.Size = new System.Drawing.Size(215, 208);
            this.propGrdSelectedSpriteSheetTile.TabIndex = 2;
            // 
            // spriteSheetRenderer1
            // 
            this.spriteSheetRenderer1.Location = new System.Drawing.Point(233, 12);
            this.spriteSheetRenderer1.MouseHoverUpdatesOnly = false;
            this.spriteSheetRenderer1.Name = "spriteSheetRenderer1";
            this.spriteSheetRenderer1.Size = new System.Drawing.Size(902, 647);
            this.spriteSheetRenderer1.TabIndex = 0;
            this.spriteSheetRenderer1.Text = "spriteSheetRenderer1";
            this.spriteSheetRenderer1.OnSelect += new System.EventHandler(this.spriteSheetRenderer1_OnSelect);
            this.spriteSheetRenderer1.Click += new System.EventHandler(this.spriteSheetRenderer1_Click);
            // 
            // SpriteSheetEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 671);
            this.Controls.Add(this.propGrdSelectedSpriteSheetTile);
            this.Controls.Add(this.lstBoxSpriteSheetTiles);
            this.Controls.Add(this.spriteSheetRenderer1);
            this.Name = "SpriteSheetEditorForm";
            this.Text = "Sprite Sheet Editor";
            this.Load += new System.EventHandler(this.SpriteSheetEditorForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SpriteSheetRenderer spriteSheetRenderer1;
        private System.Windows.Forms.ListBox lstBoxSpriteSheetTiles;
        private System.Windows.Forms.PropertyGrid propGrdSelectedSpriteSheetTile;
    }
}

