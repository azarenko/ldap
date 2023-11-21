namespace LdapService
{
    class ConsoleLogger : Gatekeeper.LdapServerLibrary.ILogger
    {
        public void LogException(Exception e)
        {
            System.Console.WriteLine(e.ToString());
        }
    }
}