namespace JourneyLLD
{
    public class UserService
    {
        public UserService()
        {
            this.userRepository = new UserRepository();
        }

        private readonly UserRepository userRepository;

        public void MoveInJourney(int userId, int journeyId, string stage)
        {
            this.userRepository.GetUserById(userId).MoveInJourney(journeyId, stage);
        }

        public User GetUserById(int userId) => this.userRepository.GetUserById(userId);

        public User AddUser()
        {
            var user = new User(); // Use Factory
            this.userRepository.AddUser(user);
            return user;
        }

        public string GetCurrentStage(int userId, int journeyId) => this.userRepository.GetUserById(userId).GetCurrentStageInJourney(journeyId);
        public List<string> GetStages(int userId, int journeyId) => this.userRepository.GetUserById(userId).GetStagesInJourney(journeyId);
        public bool IsOnboardJourney(int userId, int journeyId) => this.userRepository.GetUserById(userId).IsOnboardJourney(journeyId);
    }
}