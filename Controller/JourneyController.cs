namespace JourneyLLD
{
    public class JourneyController
    {
        public JourneyController()
        {
            this.userService = new UserService();
            this.journeyService = new JourneyService(userService);
        }

        private readonly UserService userService;
        private readonly JourneyService journeyService;


        public Journey CreateJourney(List<string> stages, Dictionary<string, List<string>> adjacencyList, Dictionary<string, List<string>> entryCriteria)
        {
            return journeyService.CreateJourney(stages, adjacencyList, entryCriteria);
        }

        public void UpdateState(int id, JourneyState state) => this.journeyService.UpdateState(id, state);

        public void GetJourney(int id) => this.journeyService.GetJourney(id);

        public void Evaluate(int userId, Dictionary<string, string> payload) => this.journeyService.Evaluate(userId, payload);

        public string GetCurrentStage(int userId, int journeyId) => this.userService.GetCurrentStage(userId, journeyId);

        public bool IsOnboardJourney(int userId, int journeyId) => this.userService.IsOnboardJourney(userId, journeyId);

        public User AddUser() => this.userService.AddUser();

        public void Print()
        {
            foreach (Journey journey in this.journeyService.GetAllJourneys())
            {
                Console.WriteLine("Journey Id = {0}, Status = {1}", journey.Id, journey.State);
                foreach (int userId in journey.UserIds)
                {
                    Console.WriteLine("User = {0}, Stage = [{1}]", userId, string.Join(',', this.userService.GetStages(userId, journey.Id)));
                }
                Console.WriteLine("----");
            }

            Console.WriteLine("***********************");
        }
    }
}