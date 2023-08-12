namespace Blasco.Web.ViewModels.Challenge
{
    public class AllChallengesModel
    {
        public AllChallengesModel()
        {
            this.Challenges = new HashSet<ChallangeAllViewModel>();
        }
        public int TotalChallengesCount { get; set; }

        public IEnumerable<ChallangeAllViewModel> Challenges { get; set; }
    }
}
