﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Managers;

namespace MonogameDFClone.Core.Features {
    public class AtSymbol : Interactable {
        public AtSymbol(int row, int column, Color color, bool isVisible, bool isActive)
            : base(row, column, color, isVisible, isActive) {
            Rectangle = Globals.Rects.AtSymbol;
        }

        public override void Update(GameTime gameTime, Player player) {
            if (IsActive) {
                if (InputManager.Instance.IsInputAction(eInputAction.Select)) {
                    if (player.Column == Column && player.Row == Row) {
                        IsActive = false;
                        IsVisible = false;
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            if (IsVisible) {
                base.Draw(spriteBatch);
            }
        }
    }
}
