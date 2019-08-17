using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApiRL;

namespace RetroLauncher.Services
{
    public class RepositoryImage
    {
        private readonly string Token;// = "AgAAAAAGq9GCAAXRAb30qVKOiEknksyK2vlHa2E";
        private readonly string ApiHost;// = "https://cloud-api.yandex.net";
        private  readonly HttpClient _client;
        private IConfiguration _config;

        public  RepositoryImage()
        {
            _config = Startup.Configuration;
            Token = _config["Token"];
            ApiHost = _config["ApiHost"];


            //            ApplicationServices.GetService<IMessageSender>();
            var _client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(Token))
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", Token);
        }


        /// <summary>
        /// Получить прямую ссылку на файл диска
        /// </summary>
        /// <param name="file">Название файла</param>
        /// <returns>true если запрос выполнен успешно</returns>
        public async Task<string> GetFileDirectUrl(string file)
        {
            using (var response = await _client.GetAsync(ApiHost + "/v1/disk/resources/download?path=RetroLauncherFiles/" + file))
            {
                var urlResult = await response.Content.ReadAsStringAsync();
                var loadjson = JsonConvert.DeserializeObject<Dictionary<string, string>>(urlResult);

                return loadjson["href"];
            }
        }
    }
}
