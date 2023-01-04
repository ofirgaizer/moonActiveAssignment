using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Infrastructure;
using System.IO;
using System.Text.Json;

namespace Tests
{
    [TestClass]
    public class Tests:TestBase
    {
        private readonly IGetRequests _requests;
        public Tests(IGetRequests requests)
        {
            _requests = requests;
        }
        [TestMethod]
        async public void Assignment1()
        {
            var response = await _requests.Get(_config.connectionsStrings.firstAssignmentEndPoint); ;
            response.StatusCode.Should().Equals(200);
        }
        [TestMethod]
        [DataTestMethod]
        [DataRow(3)]

        async public void Assignment2(int catagoryNum)
        {
            var response = await _requests.GetDeserialized<JokeModel>(_config.connectionsStrings.secondAssignmentEndPoint);
            var catagory = response.Contents.Categories[catagoryNum];
            var filterdResponse = await _requests.GetWithFilters(_config.connectionsStrings.thirdAssignmentEndPoint, JsonSerializer.Serialize(catagory));
            var filterdResponseModel = JsonSerializer.Deserialize<JokeDecriptionModel>(await filterdResponse.Content.ReadAsStringAsync());
            string text =
            @$"description:{filterdResponseModel.description}, title:{filterdResponseModel.title},
            catagory: {filterdResponseModel.catagory},
            text:{filterdResponseModel.text}";
            await File.WriteAllTextAsync($@"{filterdResponseModel.id}.txt", text);
            filterdResponse.StatusCode.Should().Equals(200);
        }
    }
    
}
