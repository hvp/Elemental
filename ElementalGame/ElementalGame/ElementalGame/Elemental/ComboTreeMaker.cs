using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Def2D;

using DefDev;

namespace ElementalGame.Elemental
{
    public class ComboTreeMaker
    {
        private class CTMBranch
        {
            public ComboAction Key;
            public List<CTMBranch> Branches;

            public CTMBranch(ComboAction key)
            {
                Key = key;
                Branches = new List<CTMBranch>();
            }
        }

        private List<CTMBranch> branches;

        private int longest;


        public ComboTreeMaker()
        {
            branches = new List<CTMBranch>();
            longest = 0;
        }


        public void AddCombo(ComboAction[] combo)
        {
            List<CTMBranch> current = branches;
            bool found = true;

            foreach (ComboAction c in combo)
            {
                if (found)
                {
                    found = false;
                    foreach (CTMBranch b in current)
                    {
                        if (c == b.Key)
                        {
                            current = b.Branches;
                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    CTMBranch b = new CTMBranch(c);

                    current.Add(b);

                    current = b.Branches;
                }
            }

            if (combo.Length > longest) longest = combo.Length;
        }

        public ComboTree Finalize()
        {
            CTBranch[] final = new CTBranch[branches.Count];

            for (int i = 0; i < branches.Count; i++)
                final[i] = fillBranch(branches[i]);

            return new ComboTree(final, longest);
        }


        //recursive portion of finalize
        private CTBranch fillBranch(CTMBranch from)
        {
            if(from.Branches.Count == 0)
                return new CTBranch(from.Key, null);

            CTBranch[] branches = new CTBranch[from.Branches.Count];

            for (int i = 0; i < from.Branches.Count; i++)
                branches[i] = fillBranch(from.Branches[i]);

            return new CTBranch(from.Key, branches);
        }

    }
}
