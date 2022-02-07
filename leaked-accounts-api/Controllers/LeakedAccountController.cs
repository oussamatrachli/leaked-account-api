using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using leaked_account_api.QueriesAbstraction;
using leaked_account_api.CommandsAbstraction;
using MongoDB.Bson;

namespace leaked_account_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeakedAccountController : ControllerBase
    {
        private readonly ILogger<LeakedAccountController> _querieslogger;
        private readonly ILogger<LeakedAccountController> _commandslogger;
        private readonly ILeakedAccountQueriesRepository _leakedAccountQueriesRepository;
        private readonly ILeakedAccountCommandsRepository _leakedAccountCommandsRepository;

        public LeakedAccountController(ILogger<LeakedAccountController> queriesLogger, ILogger<LeakedAccountController> commandsLogger, ILeakedAccountQueriesRepository leakedAccountQueriesRepository, ILeakedAccountCommandsRepository leakedAccountCommandsRepository)
        {
            _querieslogger = queriesLogger;
            _commandslogger = commandsLogger;
            _leakedAccountQueriesRepository = leakedAccountQueriesRepository;
            _leakedAccountCommandsRepository = leakedAccountCommandsRepository;
        }

        [Route("getByEmail"),HttpGet]
        public bool GetByEmail([FromQuery] String mail)
        {
            try
            {
                return _leakedAccountQueriesRepository.GetLeakedAccountByEmail(mail);
            }
            catch (Exception) { return false; }
        }

        [Route("getById"), HttpGet]
        public bool GetById([FromQuery] string Id)
        {
            try
            {
                return _leakedAccountQueriesRepository.GetLeakedAccountById(Id);
            }
            catch (Exception) { return false; }
        }

        [Route("getByEmailAndPass"),HttpGet]
        public bool GetByEmailAndPassword([FromQuery] String mail, [FromQuery] String pass)
        {
            try
            {
                return _leakedAccountQueriesRepository.GetLeakedAccountByEmailAndPassword(mail,pass);
            }
            catch (Exception) { return false; }
        }

        [Route("deleteByEmail"), HttpDelete]
        public string deleteByEmail([FromQuery] String mail)
        {
            try
            {
                if (_leakedAccountQueriesRepository.GetLeakedAccountByEmail(mail))
                {
                    _leakedAccountCommandsRepository.DeleteLeakedAccount(mail);
                    return "Leaked account with email " + mail + " deleted!";
                }
                else
                {
                    return "Account with email " + mail + " hasn't been leaked!";
                }
            }
            catch (Exception) { return "error!"; }
        }
        [Route("updateById"), HttpPut]
        public string updateEmailById([FromQuery] string Id, [FromQuery] String mail)
        {
            try
            {
                if (_leakedAccountQueriesRepository.GetLeakedAccountById(Id))
                {
                    _leakedAccountCommandsRepository.UpdateLeakedAccount(Id, mail);
                    return "Leaked account with id " + Id + " updated!";
                }
                else
                {
                    return "There is no leaked account with id " + Id;
                }
            }
            catch (Exception) { return "error!"; }
        }

    }
}