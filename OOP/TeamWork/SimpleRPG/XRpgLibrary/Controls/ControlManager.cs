namespace XTankWarsLibrary.Controls
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class ControlManager : List<Control>
    {
        #region Fields
        private static SpriteFont spriteFont;
        private int selectedControl = 0;
        #endregion

        #region Constructors
        public ControlManager(SpriteFont spriteFont)
            : base()
        {
            ControlManager.spriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, int capacity)
            : base(capacity)
        {
            ControlManager.spriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, IEnumerable<Control> collection)
            : base(collection)
        {
            ControlManager.spriteFont = spriteFont;
        }
        #endregion

        public event EventHandler FocusChanged;

        #region Properties
        public static SpriteFont SpriteFont
        {
            get
            {
                return spriteFont;
            }
        }
        #endregion

        #region Methods
        public void Update(GameTime gameTime)
        {
            if (this.Count == 0)
            {
                return;
            }

            foreach (Control control in this)
            {
                if (control.Enabled)
                {
                    control.Update(gameTime);
                }

                if (control.HasFocus)
                {
                    control.HandleInput();
                }
            }

            if (InputHandler.IsKeyPressed(Keys.Up))
            {
                this.NextControl(Keys.Up);
            }
            else if (InputHandler.IsKeyPressed(Keys.Down))
            {
                this.NextControl(Keys.Down);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Control control in this)
            {
                if (control.Visible)
                {
                    control.Draw(spriteBatch);
                }
            }
        }

        /// <summary> Selects next option in the menu depending on specified direction. </summary>
        public void NextControl(Keys direction)
        {
            if (this.Count > 0)
            {
                int currentControl = this.selectedControl;
                this[this.selectedControl].HasFocus = false;

                do
                {
                    if (direction == Keys.Up)
                    {
                        this.selectedControl--;
                    }
                    else if (direction == Keys.Down)
                    {
                        this.selectedControl++;
                    }

                    // Ensures rotation of the menu.
                    this.selectedControl %= this.Count;
                    if (this.selectedControl < 0)
                    {
                        this.selectedControl += this.Count;
                    }

                    if (this[this.selectedControl].TabStop && this[this.selectedControl].Enabled)
                    {
                        if (this.FocusChanged != null)
                        {
                            this.FocusChanged(this[this.selectedControl], null);
                        }

                        break;
                    }
                }
                while (currentControl != this.selectedControl);

                this[this.selectedControl].HasFocus = true;
            }
        }
        #endregion
    }
}
