namespace XTankWarsLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;

    /// <summary>
    /// Handles keyboard inputs.
    /// </summary>
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        private static KeyboardState keyboardState;
        private static KeyboardState lastKeyboardState;

        public InputHandler(Game game)
            : base(game)
        {
            keyboardState = Keyboard.GetState();
        }

        #region KeyboardState properties
        public static KeyboardState LastKeyboardState
        {
            get
            {
                return lastKeyboardState;
            }
        }

        public static KeyboardState KeyboardState
        {
            get
            {
                return keyboardState;
            }
        }
        #endregion

        /// <summary>
        /// Clears previous states of the keyboard.
        /// </summary>
        public static void Flush()
        {
            lastKeyboardState = keyboardState;
        }

        /// <summary>
        /// Returns true if previously pressed button is now released.
        /// </summary>
        public static bool IsKeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) && lastKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// Returns true if previously untouched button is now pressed.
        /// </summary>
        public static bool IsKeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
        }

        /// <summary>
        /// Checks if specified key is down.
        /// </summary>
        public static bool IsKeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            base.Update(gameTime);
        }
    }
}
