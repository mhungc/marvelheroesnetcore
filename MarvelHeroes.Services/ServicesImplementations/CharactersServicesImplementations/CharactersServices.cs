using MarvelHeroes.Services.ServicesInterfaces.CharactersServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MarvelHeroes.Domain.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using MarvelHeroes.Infrastructure.Configuration;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MarvelHeroes.Services.ServicesImplementations.CharactersServicesImplementations
{
    public class CharactersServices : ICharactersServices
    {
        private readonly IMarvelHeroesConfiguration _config;
        public CharactersServices(IMarvelHeroesConfiguration config)
        {
            _config = config;
        }

        public async Task<List<CharacterDataWrapper>> GetMarvelCharacters()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string publicKey = _config.PublicKey;
                string hash = GerarHash(ts, publicKey,
                    _config.PrivateKey);

                var serializer = new DataContractJsonSerializer(typeof(List<CharacterDataWrapper>));

                var streamCharacters = client.GetStreamAsync(
                    _config.BaseURL +
                    $"characters?limit=10&offset=5&ts={ts}&apikey={publicKey}&hash={hash}");

                var response = serializer.ReadObject(await streamCharacters) as List<CharacterDataWrapper>;

                return response;
            }


        }

        private string GerarHash(
            string ts, string publicKey, string privateKey)
        {
            byte[] bytes =
                Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash)
                .ToLower().Replace("-", String.Empty);
        }
    }
}
