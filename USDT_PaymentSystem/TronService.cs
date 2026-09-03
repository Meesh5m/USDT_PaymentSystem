using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace USDT_PaymentSystem
{
    public class TronService
    {
        private readonly HttpClient _httpClient;

        public TronService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> VerifyTransactionAsync(string txHash, string expectedWallet, decimal expectedAmount)
        {
            var url = $"https://api.trongrid.io/v1/transactions/{txHash}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return false;

            var jsonString = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(jsonString);

            var contractRet = json["ret"]?[0]?["contractRet"]?.ToString();
            return contractRet == "SUCCESS";
        }
    }
}