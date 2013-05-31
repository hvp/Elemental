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

        ComboAction[][] combos;

        //temp commands for input
        Command lightStart = Command.KeyPr(Keys.A);
        Command lightFinish = Command.KeyRel(Keys.A);

        Command clearCombo = Command.KeyPr(Keys.R);

        bool lightS = false;

        float timer = 0;

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

            combos = new ComboAction[2][];

            combos[0] = new ComboAction[4] { ComboAction.Light, ComboAction.Light, ComboAction.Light, ComboAction.Light_H};

            combos[1] = new ComboAction[2] { ComboAction.Light, ComboAction.Heavy };

            //
            //should implement some sort of combo sorting
            //

            checker = new ComboChecker(combos, 5);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            float seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Debug.Write("Elemental Game V.1");

            if (clearCombo.Given) checker.Clear();

            //temp timing values
            float time_h = .15f;
            float tap_delay = .05f;

            timer += seconds;

            if (lightStart.Given && timer >= tap_delay)
            {
                timer = 0;
                lightS = true;
            }

            if(lightS && lightFinish.Given)
            {
                if (timer > time_h) checker.AddAction(ComboAction.Light_H);
                else checker.AddAction(ComboAction.Light);

                lightS = false;
                timer = 0;
            }

            Debug.Write(Math.Round(timer, 2));

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
