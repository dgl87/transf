using DirectOne.App.Poc.Utils.Interfaces;
using System;

namespace DirectOne.App.Poc.Utils
{
    public class Variables : IVariables
    {
        public string JOURNEY_EVENT_DATABASE => GetEnvironmentVariable("JOURNEY_EVENT_DATABASE");
        public string TABLE_V2 => GetEnvironmentVariable("TABLE_V2");

        private static string GetEnvironmentVariable(string variableName)
        {
            var variable = Environment.GetEnvironmentVariable(variableName);

            if (string.IsNullOrWhiteSpace(variable))
                throw new ArgumentNullException(variableName);

            return variable;
        }
    }
}
