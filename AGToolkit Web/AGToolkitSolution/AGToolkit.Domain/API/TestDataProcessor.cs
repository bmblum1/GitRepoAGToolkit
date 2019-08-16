using Newtonsoft.Json;
using NLog;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AGToolkit.Domain.API
{
    public class TestDataProcessor
    {
        // Set up text file logger 
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        Logger logger = LogManager.GetLogger("fileLogger");

        // Set up console output _logger
        private static readonly OutputLogger _logger = new OutputLogger();

        public TestDataProcessor()
        {

        }
        public static async Task<TestDataModel> LoadTestData(int testId = 0)
        {
            string url = "";

            if (testId > 0)
            {
                url = $"http://localhost:3000/api/testdata/{ testId }";
            }
            else
            {
                url = $"http://localhost:3000/api/testdata";
            }

            using (HttpResponseMessage response = await ApiTestDataHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    TestDataModel testdata = await response.Content.ReadAsAsync<TestDataModel>();

                    return testdata;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<TestDataModel> PostTestData(int testId, double frets, double scale)
        {
            string url = $"http://localhost:3000/api/testdata/";

            TestDataModel testdata = new TestDataModel();

            testdata.TestId = testId;
            testdata.FretAmount = frets;
            testdata.ScaleLength = scale;

            StringContent content = new StringContent(JsonConvert.SerializeObject(testdata), Encoding.UTF8, "application/json");

            var response = await ApiTestDataHelper.ApiClient.PostAsync(url, content);

            return testdata;
        }

        public static async Task<int> DeleteTestData(int testId)
        {
            string url = $"http://localhost:3000/api/testdata/{ testId }";

            TestDataModel testdata = new TestDataModel();

            testdata.TestId = testId;
            try
            {
                var response = await ApiTestDataHelper.ApiClient.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return 204;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                logError(ex, testId);
                throw new Exception();
            }
        }

        public static void logError(Exception error, int tId)
        {
            _logger.NotifyOfFailedDeletion(tId);
            Logger.Error(error, message: $"Unable to delete data entry for key -- TestId: { tId }");
        }
    }
}
