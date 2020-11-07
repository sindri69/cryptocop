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
            
            var path = "https://data.messari.io/api/v2/assets?fields=id,symbol,name,slug,profile/general/overview/project_details,metrics/market_data/price_usd";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(path);
            var res = await HttpResponseMessageExtensions.DeserializeJsonToList<CryptoCurrencyDto>(response, true);

            //filter by the currencies that are asked for in the project description
            return res.Where(r => r.Symbol == "BTC" || r.Symbol == "ETH" || r.Symbol == "USDT" || r.Symbol == "XMR");
        }
    }
}