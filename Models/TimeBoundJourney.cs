
namespace JourneyLLD
{
    public class TimeBoundJourney : Journey
    {
        public TimeBoundJourney(List<string> stages, Dictionary<string, List<string>> adjacencyList, Dictionary<string, List<string>> entryCriteria) : base(stages, adjacencyList, entryCriteria)
        {
        }

        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
    }
}