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
using Def2D.Entity;
using Def2D.Collision;

using DefDev;

using ElementalGame.Elemental;

namespace ElementalGame.TestLoops
{
    public class AnimationLoop : DefDev.Tools.TestLoop
    {
        Vector2 center = new Vector2(Debug.Width / 2f, Debug.Height / 2f);

        Sprite sprite1;

        Shape spriteBox;

        Shape circle1, circle2, circle3, circle4;

        Shape origin;

        Command Select = Command.MouseL();

        public enum AnimEditState
        {
            Nothing,
            ChangeOrigin,
            Move
        }

        AnimEditState state;


        public override void Initialize(Game game)
        {
            sprite1 = new Sprite(center);

            sprite1.Texture = DefDev.Tools.TexMaker.Rectangle(Core.Graphics.GraphicsDevice, Color.White, 100, 150);

            spriteBox = sprite1.Bounds;

            circle1 = new Circle(spriteBox.Points[0], 10);

            origin = new Circle(spriteBox.Position2, 5);

        }

        public override void Update(float seconds)
        {
            if (Select.Given)
            {
                
            }
        }

        public override void Draw()
        {
            Debug.SpriteBatch.Begin();

            //sprite1.Draw(Debug.SpriteBatch);

            spriteBox.Draw(Debug.SpriteBatch, Color.Red);



            circle1.Draw(Debug.SpriteBatch, Color.Yellow);

            Debug.SpriteBatch.End();

        } 
    }
}
