using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelHeroes.Infrastructure.Configuration
{
    public interface IMarvelHeroesConfiguration
    {
         string BaseURL { get; set; }
         string PublicKey { get; set; }
         string PrivateKey { get; set; }
    }
}
