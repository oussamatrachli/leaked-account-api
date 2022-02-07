using MongoDB.Bson;
using System;

namespace leaked_account_api.CommandsAbstraction
{
    public interface ILeakedAccountCommandsRepository
    {
        void DeleteLeakedAccount(string mail);
        void UpdateLeakedAccount(string id, string mail);
    }
}
