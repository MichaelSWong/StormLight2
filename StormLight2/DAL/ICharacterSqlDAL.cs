using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StormLight2.Models;

namespace StormLightArchive.DAL
{
    public interface ICharacterSqlDAL
    {
        List<CharacterModel> GetAllCharacters();

        CharacterModel GetCharacter(string name);
    }
}
