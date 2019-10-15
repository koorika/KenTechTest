using RestSharp;
using RestSupport.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace RestSupport
{
    public class RESTClient
    {
        private readonly string Host = @"https://jsonplaceholder.typicode.com/";
        private readonly RestClient client;

        public RESTClient()
        {
            client = new RestClient(Host);
        }

        public IRestResponse<List<UserModel>> GetAllUsers()
        {
            var request = new RestRequest("users", Method.GET);

            IRestResponse<List<UserModel>> response = client.Execute<List<UserModel>>(request);
            return response;
        }

        public IRestResponse<UserModel> GetUser(int userId)
        {
            var request = new RestRequest($"users/{userId}/", Method.GET);

            IRestResponse<UserModel> response = client.Execute<UserModel>(request);
            return response;
        }

        public IRestResponse<UserModel> CreateUser(UserModel user)
        {
            var request = new RestRequest("users", Method.POST);
            request.AddJsonBody(user);

            IRestResponse<UserModel> response = client.Execute<UserModel>(request);
            return response;
        }

        public IRestResponse<JsonObject> CreateMultipleUsers(List<UserModel> input)
        {
            var request = new RestRequest("users", Method.POST);
            request.AddJsonBody(input);

            IRestResponse<JsonObject> response = client.Execute<JsonObject>(request);
            return response;
        }

        public IRestResponse<List<PostModel>> GetAllPosts()
        {
            var request = new RestRequest("posts", Method.GET);

            IRestResponse<List<PostModel>> response = client.Execute<List<PostModel>>(request);
            return response;
        }

        public IRestResponse<PostModel> GetPostById(int postId)
        {
            var request = new RestRequest($"posts/{postId}", Method.GET);

            IRestResponse<PostModel> response = client.Execute<PostModel>(request);
            return response;
        }

        public IRestResponse<PostModel> CreatePost(PostModel post)
        {
            var request = new RestRequest("posts", Method.POST);
            request.AddJsonBody(post);

            IRestResponse<PostModel> response = client.Execute<PostModel>(request);
            return response;
        }

        public IRestResponse<PostModel> EditPost(int postId, PostModel post)
        {
            var request = new RestRequest($"posts/{postId}", Method.PUT);
            request.AddJsonBody(post);

            IRestResponse<PostModel> response = client.Execute<PostModel>(request);
            return response;
        }

        public IRestResponse DeletePost(int postId)
        {
            var request = new RestRequest($"posts/{postId}", Method.DELETE);

            IRestResponse<PostModel> response = client.Execute<PostModel>(request);
            return response;
        }

        public IRestResponse DeleteAllPosts()
        {
            var request = new RestRequest("posts", Method.DELETE);

            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
