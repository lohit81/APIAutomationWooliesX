using APIAutomationWooliesX.Helper;
using Newtonsoft.Json.Linq;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace APIAutomationWooliesX.Steps
{
    [Binding]
    public class SuperVillianSteps
    {
        [Given(@"I have url with endpoint (.*)")]
        public void GivenIHaveUrlWithEndpointEndpoint(string strEndPoint)
        {
            RestAPIHelper.setURL(RestAPIHelper.strResource);
        }


        [Given(@"I have GET endpoint (.*)")]
        public void GivenIHaveGETEndpointGetEndPoint(string strGETEndPoint)
        {
            //strGETEndPoint = RestAPIHelper.strResource;
            //RestAPIHelper.setURL(strGETEndPoint);
        }
        
        [Given(@"I have POST endpoint (.*)")]
        public void GivenIHavePOSTEndpointPostEndpoint(string strPOSTEndPoint)
        {
            // I can keep same method as for GET method but for test explanation purpose I used separate calls
            //strPOSTEndPoint = RestAPIHelper.strResource;
            //RestAPIHelper.setURL(strPOSTEndPoint);
        }
        
        [When(@"I call get method of API")]
        public void WhenICallGetMethodOfAPI()
        {
            RestAPIHelper.createRequest();
        }
        
        [When(@"I call POST method of API using (.*) and (.*)")]
        public void WhenICallPOSTMethodOfAPIUsingJohnAnd(string strUserName, int iScore)
        {
            RestAPIHelper.createRequestForPOST(strUserName, iScore);
        }
        
        [Then(@"I will get the response")]
        public void ThenIWillGetTheResponse()
        {
           RestAPIHelper.GetRestResponse();
          
        }

        [Then(@"I will get the response after POST")]
        public void ThenIWillGetTheResponseAfterPOST()
        {
            RestAPIHelper.GetRestResponseAfterPOST();
        }

        [When(@"I call PUT method of API using (.*) and (.*)")]
        public void WhenICallPUTMethodOfAPIUsingAndrewAnd(string strUserName, int iScore)
        {
            RestAPIHelper.createRequestForPUT(strUserName, iScore);
        }

        [Then(@"I will get the response after PUT")]
        public void ThenIWillGetTheResponseAfterPUT()
        {
            RestAPIHelper.GetRestResponseAfterPUT(); // Gives a success message
        }

    }
}
