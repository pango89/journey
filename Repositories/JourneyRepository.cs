namespace JourneyLLD
{
    public class JourneyRepository
    {
        private readonly Dictionary<int, Journey> journeys;

        public JourneyRepository()
        {
            journeys = new();
        }

        public Journey GetById(int id)
        {
            if (!journeys.ContainsKey(id))
                throw new JourneyNotFoundException();

            return journeys[id];
        }

        public void Add(Journey journey)
        {
            if (journeys.ContainsKey(journey.Id))
                throw new DuplicateJourneyException();

            journeys.Add(journey.Id, journey);
        }

        public List<Journey> GetAllJourneys() => this.journeys.Values.ToList();
    }
}