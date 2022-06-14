using System;
using System.Collections.Generic;

namespace Library
{
    public class MatchList
    {
        private List<Match> historicMatches;

        public List<Match> HistoricMatches
        {
            get
            {
                return this.historicMatches;
            }
        }

        public MatchList ()
        {
            historicMatches = new List<Match>();
        }

        // public void addMatch(Match match)
        // {
        //     activeMatches.Add(match);
        // }

        public Match addNewMatch()
        {
            Match match = new Match();
            historicMatches.Add(match);
            return match;
        }
    }
}
