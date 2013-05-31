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
        protected Queue<ComboAction> _actions;

        protected ComboAction[][] _combos;


        public ComboChecker(ComboAction[][] combos, int longest)
        {
            _combos = combos;
           
            _actions = new Queue<ComboAction>(longest);
        }


        public int Update(float seconds)
        {
            foreach (ComboAction i in _actions) Debug.Write(i);



            return -1;
        }

        public void AddAction(ComboAction action)
        {
            _actions.Enqueue(action);
        }

        public void Clear() { _actions.Clear(); }

    }
}
