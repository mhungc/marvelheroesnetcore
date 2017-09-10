using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelHeroes.Infrastructure.Configuration
{
    public class MarvelHeroesConfiguration : IMarvelHeroesConfiguration
    {
        public string BaseURL { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }
}
