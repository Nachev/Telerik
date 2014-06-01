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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameStateManager : Microsoft.Xna.Framework.GameComponent
    {
        #region Fields
        // Used in determining the drawing order. DrawableGameComponent have property DrawOrder.
        private const int StartDrawOrder = 5000;
        private const int DrawOrderInc = 100;

        // Will be triggered when there is a change in state or screens.
        private EventHandler onStateChange;

        private Stack<GameState> gameStates = new Stack<GameState>();
        private int drawOrder;
        #endregion

        public GameStateManager(Game game)
            : base(game)
        {
            this.drawOrder = StartDrawOrder;
        }

        public GameState CurrentState
        {
            get
            {
                return this.gameStates.Peek();
            }
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs
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
            base.Update(gameTime);
        }
                
        /// <summary> Used to return to previous state by removing this one from stack. </summary>
        public void PopState()
        {
            if (this.gameStates.Count > 0)
            {
                this.RemoveState();
                this.drawOrder -= DrawOrderInc;

                if (this.onStateChange != null)
                {
                    this.onStateChange(this, null);
                }
            }
        }
        
        /// <summary> Used to move to another state and keep the previous state in stack </summary>
        public void PushState(GameState newState)
        {
            this.drawOrder += DrawOrderInc;
            newState.DrawOrder = this.drawOrder;

            this.AddState(newState);

            if (this.onStateChange != null)
            {
                this.onStateChange(this, null);
            }
        }

        /// <summary> Removes all other states from stack except the specified one. </summary>
        public void ChangeState(GameState newState)
        {
            while (this.gameStates.Count > 0)
            {
                this.RemoveState();
            }

            newState.DrawOrder = StartDrawOrder;
            this.drawOrder = StartDrawOrder;

            this.AddState(newState);

            if (this.onStateChange != null)
            {
                this.onStateChange(this, null);
            }
        }

        /// <summary> Adds a state to the stack and subscribes it to the event. </summary>
        private void AddState(GameState newState)
        {
            this.gameStates.Push(newState);
            Game.Components.Add(newState);
            this.onStateChange += newState.StateChange;
        }

        /// <summary> Removes the state from top of the stack and from the components while unsubscribes it from the event. </summary>
        private void RemoveState()
        {
            GameState state = this.gameStates.Peek();
            this.onStateChange -= state.StateChange;
            Game.Components.Remove(state);
            this.gameStates.Pop();
        }
    }
}
