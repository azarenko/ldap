using System;
using Gatekeeper.LdapServerLibrary;

namespace LdapService
{
    class ConsoleLogger : ILogger
    {
        public void LogException(Exception e)
        {
            System.Console.WriteLine(e.ToString());
        }
    }
}