using AZ400_Backend.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AZ400_Backend
{
    public class Service
    {
        public IConfiguration configuration;

        public HttpClient client;

        public Service()
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            if (client == null)
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "",
                        configuration["AzureDevOpsRestApi:PersonalAccessToken"]))));

            }
        }

        //Consume the Rest API Azure DevOps Get Packages
        public async Task<ResultList> GetPackages(string feedId)
        {
            ResultList packages = new();
            var response = await client.GetAsync(configuration["AzureDevOpsRestApi:AzureDevOpsUrl"] +
                                                 configuration["AzureDevOpsRestApi:Organization"] + "/" +
                                                 configuration["AzureDevOpsRestApi:Project"] + "/_apis/packaging/feeds/" +
                                                 feedId + "/packages" + configuration["AzureDevOpsRestApi:AzureDevOpsApiVersion"]);
            
            if (!response.IsSuccessStatusCode) return packages;
            var result = await response.Content.ReadAsStringAsync();
            packages = JsonConvert.DeserializeObject<ResultList>(result);
            
            return packages;
        }

        //Consume the Rest API Azure DevOps Get Package
        public async Task<string?> GetPackage(string feedId, string packageId)
        {
            var response = await client.GetAsync(configuration["AzureDevOpsRestApi:AzureDevOpsUrl"] +
                                                configuration["AzureDevOpsRestApi:Organization"] + "/" +
                                                configuration["AzureDevOpsRestApi:Project"] + "/_apis/packaging/feeds/" +
                                                feedId + "/packages" + "?packageNameQuery=" + packageId);

            if (!response.IsSuccessStatusCode) return null;
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

    }
}
