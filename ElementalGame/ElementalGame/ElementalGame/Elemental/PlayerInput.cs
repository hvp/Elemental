using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Def2D;
using Def2D.Interface;

using DefDev;

namespace ElementalGame.Elemental
{
    public class PlayerInputAction
    {
        public Command Start, Finish;

        public ComboAction Tap, Hold;

        public bool started;

        public PlayerInputAction(Command start, Command finish, ComboAction tap, ComboAction hold)
        {
            Start = start;
            Finish = finish;
            Tap = tap;
            Hold = hold;

            started = false;
        }
    }

    public class PlayerInput
    {
        static float time_hold = .2f;
        static float tap_delay = .05f;
        static float time_holdMax = .2f;
        static float time_pause = .2f;
        static float time_max = .2f;

        public PlayerInputAction Light, Heavy, Special;
        public Command DashLs, DashRs;

        private bool dashl, dashr;
        private float timer = 0;

        public PlayerInput()
        {
            Light = new PlayerInputAction(Command.KeyPr(Keys.A), Command.KeyRel(Keys.A), ComboAction.Light, ComboAction.Light_H);
            Heavy = new PlayerInputAction(Command.KeyPr(Keys.S), Command.KeyRel(Keys.S), ComboAction.Heavy, ComboAction.Heavy_H);
            Special = new PlayerInputAction(Command.KeyPr(Keys.W), Command.KeyRel(Keys.W), ComboAction.Special, ComboAction.Special_H);

            DashLs = Command.KeyPr(Keys.Left);

            DashRs = Command.KeyPr(Keys.Right);
        }


        public void Update(float seconds, ComboChecker checker)
        {
            timer += seconds;

            bool hold = false;

            hold = UpdateActions(Light, checker) || hold;
            hold = UpdateActions(Heavy, checker) || hold;
            hold = UpdateActions(Special, checker) || hold;

            if (DashLs.Given)
            {
                if (!dashl)
                {
                    dashl = true;
                    dashr = false;
                    timer = 0;
                }
                else
                {
                    checker.AddAction(ComboAction.Dash);
                    dashl = false;
                    timer = 0;
                }
            }

            if (DashRs.Given)
            {
                if (!dashr)
                {
                    dashr = true;
                    dashl = false;
                    timer = 0;
                }
                else
                {
                    checker.AddAction(ComboAction.Dash);
                    dashr = false;
                    timer = 0;
                }
            }

            if (timer >= time_max)
            {
                dashl = false;
                dashr = false;
            }


            if (!hold && timer >= .2f)
            {
                timer = .05f;
                checker.AddAction(ComboAction.Pause);
            }
        }

        private bool UpdateActions(PlayerInputAction a, ComboChecker checker)
        {
            if (a.Start.Given && timer >= tap_delay)
            {
                timer = 0;
                a.started = true;
            }

            if (a.started)
            {
                if (a.Finish.Given)
                {
                    if (timer > time_hold) checker.AddAction(a.Hold);
                    else checker.AddAction(a.Tap);

                    a.started = false;
                    timer = 0;
                }
                else if (timer > time_holdMax)
                {
                    checker.AddAction(a.Hold);
                    a.started = false;
                    timer = 0;
                }

                return true;
            }
            return false;
        }
    }
}
