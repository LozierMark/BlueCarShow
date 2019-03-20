using CarShow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShow.Services
{
    public class WinnerService
    {
        private readonly Guid _userId;

        public WinnerService(Guid userId)
        {
            _userId = userId;
        }
        public int[] FindWinners()
        {
            IEnumerable<Vote> votelist = GetVotes();
            var bestPaint = new MutableDictionary<int, int>();
            var bestEngine = new MutableDictionary<int, int>();
            var bestInterior = new MutableDictionary<int, int>();
            var bestOfShow = new MutableDictionary<int, int>();

            foreach (Vote currentvote in votelist)
            {
                bestPaint[currentvote.Paint]++;
                bestEngine[currentvote.Engine]++;
                bestInterior[currentvote.Interior]++;
                bestOfShow[currentvote.BestOfShow]++;

            }
            int bestpaintwinner = CalcWinner(bestPaint);
            int bestenginewinner = CalcWinner(bestEngine);
            int bestinteriorwinner = CalcWinner(bestInterior);
            int bestofshowwinner = CalcWinner(bestOfShow);

            return new int[]
            {
                bestpaintwinner,
                bestenginewinner,
                bestinteriorwinner,
                bestofshowwinner,
            };
        }

        public int CalcWinner(MutableDictionary<int, int> dict)
        {
            var winner = -1;
            var valu = -1;
            foreach (KeyValuePair<int, int> pair in dict)
            {
                if (pair.Value > valu)
                {
                    valu = pair.Value;
                    winner = pair.Key;
                }
            }
            return winner;

        }
        private IEnumerable<Vote> GetVotes()
        {
            var ctx = new ApplicationDbContext();
            return ctx.Votes.ToList();
        }

        public class MutableDictionary<A, B> : Dictionary<A, B>
        {
            public new B this[A key]
            {
                get { return base[key]; }
                set
                {
                    if (base.ContainsKey(key))
                    {
                        base[key] = value;
                    }
                    else
                    {
                        Add(key, value);
                    }
                }
            }
        }


    }
}