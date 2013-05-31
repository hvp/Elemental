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

using Def2D;
using Def2D.Interface;
using DefDev;

using ElementalGame.Elemental;

namespace ElementalGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainScreen : Microsoft.Xna.Framework.Game
    {
        SpriteBatch spriteBatch;

        ComboChecker checker;

        ComboTree tree = ComboTree.Complete;

        PlayerInput player = new PlayerInput();

        public MainScreen()
        {
            Content.RootDirectory = "Content";

            Core.Initialize(this);

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Debug.Start();

            Input.ResetMouse = false;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            checker = new ComboChecker(tree);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            float seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Debug.Write("Elemental Game V.1");

            player.Update(seconds, checker);

            checker.Update(seconds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Core.Graphics.GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }
    }
}
