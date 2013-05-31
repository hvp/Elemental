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

using ElementalGame.Elemental;

using Def2D;
using Def2D.Interface;
using DefDev;

namespace ElementalGame.TestLoops
{
    public class ComboLoop : DefDev.Tools.TestLoop
    {
        ComboChecker checker;

        ComboTree tree = ComboTree.Complete;

        PlayerInput player = new PlayerInput();

        public override void Initialize(Game game)
        {
            checker = new ComboChecker(tree);
        }

        public override void Update(float seconds)
        {
            player.Update(seconds, checker);

            checker.Update(seconds);
        }

        public override void Draw()
        {
        } 
    }
}
