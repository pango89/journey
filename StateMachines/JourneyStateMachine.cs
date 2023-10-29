namespace JourneyLLD
{
    public static class JourneyStateMachine
    {
        private static readonly Dictionary<JourneyState, List<JourneyState>> SM = new() {
            { JourneyState.CREATED, new List<JourneyState>(){ JourneyState.ACTIVE, JourneyState.EXPIRED, JourneyState.ENDED }},
            { JourneyState.ACTIVE, new List<JourneyState>(){ JourneyState.EXPIRED, JourneyState.ENDED }},
            { JourneyState.ENDED, new List<JourneyState>()},
            { JourneyState.EXPIRED, new List<JourneyState>()},
        };

        public static bool IsTransitionAllowed(JourneyState current, JourneyState next)
        {
            if (SM.ContainsKey(current) && SM[current].Contains(next))
                return true;
            return false;
        }
    }
}