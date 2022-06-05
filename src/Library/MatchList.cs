using System;
using System.Collections.Generic;

namespace Library
{
    public class MatchList
    {
        private List<Match> activeMatches;

        public List<Match> AciveMatches
        {
            get
            {
                return this.activeMatches;
            }
        }

        public MatchList ()
        {
            activeMatches = new List<Match>();
        }

        public void addMatch(Match match)
        {
            activeMatches.Add(match);
        }
    }
}
