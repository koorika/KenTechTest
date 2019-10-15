using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using RestSupport;
using RestSupport.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Tutorial.Steps
{
    [Binding]
    public sealed class JSONManipulation
    {
        private readonly ScenarioContext context;
        private readonly RESTClient client;

        public JSONManipulation(ScenarioContext injectedContext, RESTClient restClient)
        {
            context = injectedContext;
            client = restClient;
        }

        [Then(@"The user data is (.*)")]
        public void ThenTheUserDataIsUser_Json(string jsonFile)
        {
            UserModel expected = new UserModel();
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Tests.Data.{jsonFile}");
            using (StreamReader file = new StreamReader(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                expected = (UserModel)serializer.Deserialize(file, typeof(UserModel));
            }

            context["response"].Should().BeOfType<RestResponse<UserModel>>().Which.Data.Equals(expected);
        }

        [Given(@"I create users from (.*)")]
        public void GivenICreateUserFromUser_Json(string jsonFile)
        {
            UserModel input = new UserModel();
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Tests.Data.{jsonFile}");
            using (StreamReader file = new StreamReader(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                input = (UserModel)serializer.Deserialize(file, typeof(UserModel));
            }

            IRestResponse<UserModel> restResponse = client.CreateUser(input);
            context["response"] = restResponse;
        }

        [Given(@"I create multiple users from (.*)")]
        public void GivenICreateMultipleUsersFromMoreusers_Json(string jsonFile)
        {
            List<UserModel> input = new List<UserModel>();
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Tests.Data.{jsonFile}");
            using (StreamReader file = new StreamReader(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                input = (List<UserModel>)serializer.Deserialize(file, typeof(List<UserModel>));
            }

            IRestResponse restResponse = client.CreateMultipleUsers(input);
            context["response"] = restResponse;
        }


        [Then(@"The post data is (.*)")]
        public void ThenThePostDataIsPost_Json(string jsonFile)
        {
            PostModel expected = new PostModel();
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Tests.Data.{jsonFile}");
            using (StreamReader file = new StreamReader(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                expected = (PostModel)serializer.Deserialize(file, typeof(PostModel));
            }

            context["response"].Should().BeOfType<RestResponse<PostModel>>().Which.Data.Equals(expected);
        }


        [Given(@"I create post (.*) from (.*)")]
        public void GivenICreatePostFromPost_Json(int postID, string jsonFile)
        {
            PostModel input = new PostModel();
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Tests.Data.{jsonFile}");
            using (StreamReader file = new StreamReader(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                input = (PostModel)serializer.Deserialize(file, typeof(PostModel));
            }

            IRestResponse<PostModel> restResponse = client.CreatePost(input);
            context["response"] = restResponse;
        }

        [Given(@"I edit post (.*) from (.*)")]
        public void GivenIEditPostFromEmptypost_Json(int id, string jsonFile)
        {
            PostModel input = new PostModel();
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Tests.Data.{jsonFile}");
            using (StreamReader file = new StreamReader(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                input = (PostModel)serializer.Deserialize(file, typeof(PostModel));
            }

            IRestResponse<PostModel> restResponse = client.EditPost(id, input);
            context["response"] = restResponse;
        }

        [Then(@"The response has (.*) users and id (.*)")]
        public void ThenTheResponseHasUsersAndId(int userCount, int lastProcessedId)
        {
            context["response"].Should().BeOfType<RestResponse>();
            JsonObject data = JsonConvert.DeserializeObject<JsonObject>((context["response"] as RestResponse).Content);
            data.Keys.Count.Should().Be(3);
            data.Keys.Should().Contain("id");
            data["id"].Should().Be(11);
        }

    }
}
