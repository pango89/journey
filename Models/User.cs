namespace JourneyLLD
{
    public class User
    {
        private static int count = 0;

        public User()
        {
            Id = ++count;
            Journeys = new();
        }

        public int Id { get; set; }

        // JourneyId -> Stage
        public Dictionary<int, LinkedList<string>> Journeys { get; set; }

        public void MoveInJourney(int journeyId, string stage)
        {
            if (!this.Journeys.ContainsKey(journeyId))
            {
                this.Journeys.Add(journeyId, new());
            }

            this.Journeys[journeyId].AddLast(stage);
        }

        public string GetCurrentStageInJourney(int journeyId)
        {
            if (!this.Journeys.ContainsKey(journeyId))
            {
                return string.Empty;
            }

            return Journeys[journeyId].Last.Value;
        }

        public bool IsOnboardJourney(int journeyId) => this.Journeys.ContainsKey(journeyId);

        public List<string> GetStagesInJourney(int journeyId)
        {
            if (!this.Journeys.ContainsKey(journeyId))
            {
                return new List<string>();
            }

            return new List<string>(Journeys[journeyId]);
        }
    }
}