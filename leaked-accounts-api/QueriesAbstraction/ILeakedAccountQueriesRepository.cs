using MongoDB.Bson;
using System;

namespace leaked_account_api.QueriesAbstraction
{
    public interface ILeakedAccountQueriesRepository
    {
        bool GetLeakedAccountByEmail(string mail);
        bool GetLeakedAccountById(string Id);
        bool GetLeakedAccountByEmailAndPassword(string mail,string pass);
    }
}
