using MarvelHeroes.Infrastructure.Configuration;
using MarvelHeroes.Services.ServicesImplementations.CharactersServicesImplementations;
using MarvelHeroes.Services.ServicesInterfaces.CharactersServicesInterfaces;
using System;
using Xunit;

namespace MarvelHeroes.XUnitTest
{
    public class MarvelHeroesApi
    {
        private readonly ICharactersServices _charactersServices;
        private readonly MarvelHeroesConfiguration _marvelHeroesConfigurationMock;

        public MarvelHeroesApi()
        {
            _marvelHeroesConfigurationMock = new MarvelHeroesConfiguration()
            {
                BaseURL = "https://gateway.marvel.com:443/v1/public/",
                PrivateKey = "9c4140bc8e0ac0f94b19316de08b12f683d23d1b",
                PublicKey = "714bb5a21a336a01dc4205c7f1146991"
            };
        }

        [Fact]
        public async void GetCharacters_AllCharacters_Characters()
        {
            var characters = new CharactersServices(_marvelHeroesConfigurationMock);
            var charactersTesting = await characters.GetMarvelCharacters();
            
            Assert.True(charactersTesting.Count > 0);
        }
    }
}
