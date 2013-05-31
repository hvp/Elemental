using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Def2D;

using DefDev;

namespace ElementalGame.Elemental
{
    public class CTBranch
    {
        protected ComboAction _key;
        protected CTBranch[] _branches;


        public ComboAction Key { get { return _key; } }


        public CTBranch(ComboAction key, CTBranch[] branches)
        {
            _key = key;
            _branches = branches;
        }

        public CTBranch this[ComboAction key]
        {
            get
            {
                if (_branches == null) return null;

                foreach (CTBranch b in _branches)
                    if (b._key == key) return b;
                return null;
            }
        }
    }

    public class ComboTree
    {
        public static ComboTree Complete
        {
            get
            {
                ComboTreeMaker maker = new ComboTreeMaker();

                // light
                maker.AddCombo(new ComboAction[4] { ComboAction.Light, ComboAction.Light, ComboAction.Light, ComboAction.Light });

                maker.AddCombo(new ComboAction[2] { ComboAction.Dash, ComboAction.Light });

                maker.AddCombo(new ComboAction[3] { ComboAction.Light, ComboAction.Pause, ComboAction.Light });

                maker.AddCombo(new ComboAction[5] { ComboAction.Light, ComboAction.Light, ComboAction.Pause, ComboAction.Light, ComboAction.Light });

                maker.AddCombo(new ComboAction[5] { ComboAction.Light, ComboAction.Light, ComboAction.Light, ComboAction.Pause, ComboAction.Light_H });

                // heavy
                maker.AddCombo(new ComboAction[2] { ComboAction.Dash, ComboAction.Heavy });

                maker.AddCombo(new ComboAction[3] { ComboAction.Heavy, ComboAction.Heavy, ComboAction.Heavy});

                maker.AddCombo(new ComboAction[4] { ComboAction.Heavy, ComboAction.Heavy, ComboAction.Pause, ComboAction.Heavy });

                // light and heavy
                maker.AddCombo(new ComboAction[3] { ComboAction.Light, ComboAction.Light, ComboAction.Heavy });

                maker.AddCombo(new ComboAction[5] { ComboAction.Light, ComboAction.Light, ComboAction.Light, ComboAction.Pause, ComboAction.Heavy });

                maker.AddCombo(new ComboAction[4] { ComboAction.Light, ComboAction.Pause, ComboAction.Heavy, ComboAction.Heavy });

                return maker.Finalize();
            }
        }

        private int _longest;

        private CTBranch[] branches;


        public int MaxComboSize { get { return _longest; } }


        public ComboTree(CTBranch[] tree, int longest) 
        {
            _longest = longest;
            branches = tree; 
        }

        public CTBranch this[ComboAction key]
        {
            get
            {
                foreach (CTBranch b in branches)
                    if (b.Key == key) return b;
                return null;
            }
        }
    }
}
