namespace XTankWarsLibrary.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public abstract class Control
    {
        #region Fields
        private string name;
        private string text;
        private Vector2 size;
        private Vector2 position;
        private object value;
        private bool hasFocus;
        private bool enabled;
        private bool visible;

        // Tab stop - You will be able to move through all of the controls on a screen and skip over 
        // ones that you may not want selected, like a label.
        private bool tabStop;
        private SpriteFont spriteFont;
        private Color color;
        private string type;
        #endregion

        protected Control()
        {
            this.Color = Color.White;
            this.Enabled = true;
            this.Visible = true;
            this.SpriteFont = ControlManager.SpriteFont;
        }

        public event EventHandler Selected;

        #region Properies
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                this.text = value;
            }
        }

        public Vector2 Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;

                // Resolves an issue with strings printing on fractional position by Y.
                this.position.Y = (int)this.position.Y;
            }
        }

        public object Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public bool HasFocus
        {
            get
            {
                return this.hasFocus;
            }

            set
            {
                this.hasFocus = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }

            set
            {
                this.enabled = value;
            }
        }

        public bool Visible
        {
            get
            {
                return this.visible;
            }

            set
            {
                this.visible = value;
            }
        }

        public bool TabStop
        {
            get
            {
                return this.tabStop;
            }

            set
            {
                this.tabStop = value;
            }
        }

        public SpriteFont SpriteFont
        {
            get
            {
                return this.spriteFont;
            }

            set
            {
                this.spriteFont = value;
            }
        }

        public Color Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }
        #endregion

        #region Abstract Methods

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void HandleInput();
        #endregion

        /// <summary> Body of the event. </summary>
        protected virtual void OnSelected(EventArgs args)
        {
            if (this.Selected != null)
            {
                this.Selected(this, args);
            }
        }
    }
}
