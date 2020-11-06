using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cryptocop.Software.API.Services.Helpers;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.Dtos;
using System;
using System.Net.Http.Headers;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class CryptoCurrencyService : ICryptoCurrencyService
    {
        public async Task<IEnumerable<CryptoCurrencyDto>> GetAvailableCryptocurrencies()
        {
            
            var path = "https://data.messari.io/api/v2/assets?fields=id,symbol,name,slug,profile/general/overview/project_details,metrics/market_data/price_usd%22";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(path);
            var res = await HttpResponseMessageExtensions.DeserializeJsonToList<CryptoCurrencyDto>(response, true);

            Console.WriteLine(res);

            return res;
        }
    }
}