using RestSupport;
using TechTalk.SpecFlow;

namespace Tutorial.Steps
{
    [Binding]
    public sealed class Posts
    {
        private readonly ScenarioContext context;
        private readonly RESTClient client;

        public Posts(ScenarioContext injectedContext, RESTClient restClient)
        {
            context = injectedContext;
            client = restClient;
        }

        [When(@"I request all posts")]
        public void WhenIRequestAllPosts()
        {
            context["response"] = client.GetAllPosts();
        }

        [When(@"I request post (.*)")]
        public void WhenIRequestPost(int id)
        {
            context["response"] = client.GetPostById(id);
        }

        [Given(@"I delete post (.*)")]
        public void GivenIDeletePost(int id)
        {
            context["response"] = client.DeletePost(id);
        }

        [Given(@"I delete all posts")]
        public void GivenIDeleteAllPosts()
        {
            context["response"] = client.DeleteAllPosts();
        }

    }
}
