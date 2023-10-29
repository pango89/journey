namespace JourneyLLD
{
    public class Journey
    {
        private static int count = 0;

        public Journey(List<string> stages, Dictionary<string, List<string>> adjacencyList, Dictionary<string, List<string>> entryCriteria)
        {
            Id = ++count;
            State = JourneyState.CREATED;
            Stages = stages;
            AdjacencyList = adjacencyList;
            EntryCriteria = entryCriteria;
            UserIds = new();
        }

        public int Id { get; set; }
        public JourneyState State { get; set; }
        public List<string> Stages { get; set; }
        public Dictionary<string, List<string>> AdjacencyList { get; set; }


        // Stage : List of Keys Needed e.g.
        // A : [k1, k2]
        // B : [k3, k4]
        // ...etc
        public Dictionary<string, List<string>> EntryCriteria { get; set; }
        public HashSet<int> UserIds { get; set; }

        public void UpdateState(JourneyState state)
        {
            if (!JourneyStateMachine.IsTransitionAllowed(State, state))
            {
                throw new InvalidTransitionException();
            }

            State = state;
        }

        public void AddUserToJourney(int userId) => UserIds.Add(userId);

        public (bool, string) CanMoveStage(string currentStage, Dictionary<string, string> payload)
        {
            if (currentStage == string.Empty)
            {
                string onboardingStage = Stages[0];

                if (!EntryCriteria[onboardingStage].Except(payload.Keys).Any())
                    return (true, onboardingStage);

                return (false, string.Empty);
            }

            if (!AdjacencyList.ContainsKey(currentStage))
                return (false, string.Empty);

            foreach (string nextStage in AdjacencyList[currentStage])
            {
                if (!EntryCriteria.ContainsKey(nextStage))
                    continue;

                if (EntryCriteria[nextStage].Except(payload.Keys).Any())
                    continue;

                return (true, nextStage);
            }

            return (false, string.Empty);
        }
    }
}