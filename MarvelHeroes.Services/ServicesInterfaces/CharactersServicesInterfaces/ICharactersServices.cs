using MarvelHeroes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarvelHeroes.Services.ServicesInterfaces.CharactersServicesInterfaces
{
    public interface ICharactersServices
    {
        Task<List<CharacterDataWrapper>> GetMarvelCharacters();
    }
}
