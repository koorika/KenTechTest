using FluentAssertions;
using RestSharp;
using RestSupport.Models;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace KenTechTest.Steps
{
    [Binding]
    public sealed class Lists
    {
        private readonly ScenarioContext context;

        public Lists(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Then(@"The response code is (.*)")]
        public void ThenTheResponseCodeIs(int statusCode)
        {
            context["response"].Should().BeAssignableTo<RestResponseBase>().Which.StatusCode.Should().Be(statusCode);
        }

        [Then(@"The response has (.*) users")]
        public void ThenTheResponseHasUsers(int count)
        {
            context["response"].Should().BeOfType<RestResponse<List<UserModel>>>().Which.Data.Count.Should().Be(count);
        }

        [Then(@"The response has (.*) posts")]
        public void ThenTheResponseHasPosts(int count)
        {
            context["response"].Should().BeOfType<RestResponse<List<PostModel>>>().Which.Data.Count.Should().Be(count);
        }
    }
}
