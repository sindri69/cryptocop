using System.Net.Http;
using System.Threading.Tasks;
using Cryptocop.Software.API.Models;
using Cryptocop.Software.API.Services.Helpers;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.Dtos;
using System;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class ExchangeService : IExchangeService
    {
        public async Task<Envelope<ExchangeDto>> GetExchanges(int pageNumber = 1)
        {
            if(pageNumber < 1) {throw new Exception("pageNumber should not be lower than 1");}
            var path = "https://data.messari.io/api/v1/markets?Pagenumber=" + pageNumber +"?";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(path);
            var res = await HttpResponseMessageExtensions.DeserializeJsonToList<ExchangeDto>(response, true);

            var envelope = new Envelope<ExchangeDto>
            {
                Items = new List<ExchangeDto>(res)
            };
            return envelope;
        }
    }
}