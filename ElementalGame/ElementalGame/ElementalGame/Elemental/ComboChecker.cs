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
        Special,
        Special_H,
        Jump,
        Jump_H,
        Dash
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
            if (action == ComboAction.Pause && _branch == null) return;

            if(_branch != null)_branch = _branch[action];

            if (_branch == null)_branch = _tree[action];

            if (_branch != null) Debug.Post(_branch.Key);
            else Debug.Post("-");

            _validTimer = 0;
        }

        public void Clear() { }

    }
}
