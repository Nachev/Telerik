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
    public abstract partial class GameState : DrawableGameComponent
    {
        private GameStateManager stateManager;

        private List<GameComponent> childComponents;
        private GameState tag;

        public GameState(Game game, GameStateManager manager)
            : base(game)
        {
            this.stateManager = manager;
            this.childComponents = new List<GameComponent>();
            this.tag = this;
        }

        public GameStateManager StateManager
        {
            get
            {
                return this.stateManager;
            }
        }

        public GameState Tag
        {
            get
            {
                return this.tag;
            }
        }

        public List<GameComponent> Components
        {
            get
            {
                return this.childComponents;
            }
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs.
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
            foreach (GameComponent component in this.childComponents)
            {
                if (component.Enabled)
                {
                    component.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent drawableComponent;
            foreach (var component in this.childComponents)
            {
                if (component is DrawableGameComponent)
                {
                    drawableComponent = component as DrawableGameComponent;
                    if (drawableComponent.Visible)
                    {
                        drawableComponent.Draw(gameTime);
                    }
                }
            }

            base.Draw(gameTime);
        }

        /// <summary> Body of the event handler. </summary>
        protected internal virtual void StateChange(object sender, EventArgs args)
        {
            if (this.stateManager.CurrentState == this.Tag)
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary> Makes all available components visible and enabled. </summary>
        protected virtual void Show()
        {
            this.Visible = true;
            this.Enabled = true;
            foreach (var component in this.childComponents)
            {
                component.Enabled = true;
                if (component is DrawableGameComponent)
                {
                    (component as DrawableGameComponent).Visible = true;
                }
            }
        }

        /// <summary> Makes all available components hidden and disabled. </summary>
        protected virtual void Hide()
        {
            this.Visible = false;
            this.Enabled = false;
            foreach (var component in this.childComponents)
            {
                component.Enabled = false;
                if (component is DrawableGameComponent)
                {
                    (component as DrawableGameComponent).Visible = false;
                }
            }
        }
    }
}
