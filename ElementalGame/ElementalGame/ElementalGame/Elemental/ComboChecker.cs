using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Def2D;

using DefDev;

namespace ElementalGame.Elemental
{
    //all possible actions that form a combo
    // _H signifies "holding"
    public enum ComboAction
    {
        Pause,
        Light,
        Light_H,
        Heavy,
        Heavy_H,
        Ranged,
        Ranged_H,
        Jump,
        Jump_H,
        Left,
        Left_H,
        Right,
        Right_H,
        Up,
        Up_H,
        Down,
        Down_H,
    }

    public class ComboChecker
    {
        protected ComboTree _tree;
        protected CTBranch _branch;

        protected float _validTimer;

        public ComboChecker(ComboTree tree)
        {
            _tree = tree;
            _validTimer = 0;
        }


        public int Update(float seconds)
        {
            _validTimer += seconds;
            if (_validTimer > 1)
            {
                _validTimer = 0;
                _branch = null;
                Debug.Post("-");
            }


            return -1;
        }

        public void AddAction(ComboAction action)
        {
            _branch = _branch == null ? _tree[action] : _branch[action];

            if (_branch != null) Debug.Post(_branch.Key);
            else Debug.Post("-");

            _validTimer = 0;
        }

        public void Clear() { }

    }
}
