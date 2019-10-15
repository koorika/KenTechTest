using RestSupport;
using TechTalk.SpecFlow;

namespace KenTechTest.Steps
{
    [Binding]
    public sealed class Users
    {
        private readonly ScenarioContext context;
        private readonly RESTClient restClient;

        public Users(ScenarioContext injectedContext, RESTClient client)
        {
            context = injectedContext;
            restClient = client;
        }

        [When(@"I request all users")]
        public void WhenIRequestAllUsers()
        {
            context["response"] = restClient.GetAllUsers();
        }

        [When(@"I request data on user (.*)")]
        public void WhenIRequestDataOnUser(int userId)
        {
            context["response"] = restClient.GetUser(userId);
        }

    }
}
