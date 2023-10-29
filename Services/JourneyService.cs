namespace JourneyLLD
{
    public class JourneyService
    {
        public JourneyService(UserService userService)
        {
            this.journeyRepository = new JourneyRepository();
            this.userService = userService;
        }

        private readonly JourneyRepository journeyRepository;
        private readonly UserService userService;

        public Journey CreateJourney(List<string> stages, Dictionary<string, List<string>> adjacencyList, Dictionary<string, List<string>> entryCriteria)
        {
            var journey = new Journey(stages, adjacencyList, entryCriteria);
            this.journeyRepository.Add(journey);
            return journey;
        }

        public void UpdateState(int id, JourneyState state) => this.journeyRepository.GetById(id).UpdateState(state);
        public void GetJourney(int id) => this.journeyRepository.GetById(id);
        public List<Journey> GetAllJourneys() => this.journeyRepository.GetAllJourneys();

        public void Evaluate(int userId, Dictionary<string, string> payload)
        {
            List<Journey> journeys = this.journeyRepository.GetAllJourneys();

            foreach (Journey journey in journeys)
            {
                if (journey.State != JourneyState.ACTIVE)
                    continue;

                bool isPartOfJourney = this.userService.IsOnboardJourney(userId, journey.Id);
                string currentStage = this.userService.GetCurrentStage(userId, journey.Id);

                var (canMove, newStage) = journey.CanMoveStage(currentStage, payload);

                if (canMove)
                {
                    this.userService.MoveInJourney(userId, journey.Id, newStage);

                    if (!isPartOfJourney)
                    {
                        this.journeyRepository.GetById(journey.Id).AddUserToJourney(userId);
                    }
                }
            }
        }
    }
}