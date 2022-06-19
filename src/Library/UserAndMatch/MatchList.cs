using System;
using System.Collections.Generic;

namespace Library
{
    public class MatchList
    {
        private List<Match> historicMatches;

        public List<Match> HistoricMatches
        { get { return this.historicMatches; } }

        private static MatchList matchList;

        public static MatchList Instance
        {
            get
            {
                if (matchList == null)
                {
                    matchList = new MatchList();
                }
                return matchList;
            }
        }

        private MatchList ()
        {
            historicMatches = new List<Match>();
        }

        public void addNewMatch(Match match)
        {
            historicMatches.Add(match);
        }
    }
}
