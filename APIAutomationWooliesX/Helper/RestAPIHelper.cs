using APIAutomationWooliesX.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace APIAutomationWooliesX.Helper
{
    public static class RestAPIHelper
    {
        // https://supervillain.herokuapp.com/api-docs/#/
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static RestResponse restResponse;
        public static string baseUrl = "https://supervillain.herokuapp.com/";
        public static string strResource = "V1/user"; //default/get_user
        //public static string strPOSTResource = "v1/user"; //default/post_user//api-docs/#/default/post_user

        public static RestClient setURL(string endpoint)
        {
            var url = baseUrl + endpoint;
            return restClient = new RestClient(url);
        }

        /// <summary>
        /// Create REST resquest for GET method
        /// </summary>
        /// <returns></returns>
        public static RestRequest createRequest()
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("accept", "application/json");
            return restRequest;

        }

        /// <summary>
        /// Get the REST response and Deserialze the JSON array
        /// </summary>
        /// <returns></returns>
        public static IRestResponse GetRestResponse()
        {
            var response = restClient.Execute(restRequest);
            
            //Deserialization of Json
            JArray array = JArray.Parse(response.Content);
            foreach (JObject item in array)
            {
                string name = item.GetValue("username").ToString();
                string score = item.GetValue("score").ToString();
            }

            return response;
        }

        /// <summary>
        /// Create REST resquest for POST method
        /// </summary>
        /// <returns></returns>
        public static RestRequest createRequestForPOST(string uName, int intScore)
        {
            restRequest = new RestRequest(Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(new POSTModel() { username = uName, score = intScore });
            return restRequest;
        }

        /// <summary>
        /// Verify if resource is successfully added after POST method
        /// </summary>
        /// <returns></returns>
        public static IRestResponse GetRestResponseAfterPOST()
        {
            var result = restClient.Execute(restRequest);
            
            //Deseralize JSON
            JObject obj = JObject.Parse(result.Content);
            Assert.AreEqual(obj["status"].ToString(), "success", "User is not created");
            return result;
        }


        /// <summary>
        /// Create REST resquest for PUT method and increments score field by 1
        /// </summary>
        /// <returns></returns>
        public static IRestRequest createRequestForPUT(string uName, int intScore)
        {
            // Initiate POST to create a new resource
            createRequestForPOST(uName, intScore);
            restClient.Execute(restRequest);
            
            // PUT method to update in resource
            
            restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            intScore++; // After POST it increments the score by "1" during PUT
            restRequest.AddJsonBody(new POSTModel() { username = uName, score = intScore });
            return restRequest;
        }

        /// <summary>
        /// Verify if resource is successfully added after PUT method
        /// </summary>
        /// <returns></returns>
        public static IRestResponse GetRestResponseAfterPUT()
        {
            return restClient.Execute(restRequest);
        }
    }
}
