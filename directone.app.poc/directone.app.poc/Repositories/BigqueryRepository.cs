using DirectOne.App.Poc.Repositories.Interfaces;
using DirectOne.App.Poc.Utils.Interfaces;
using Google.Cloud.BigQuery.V2;
using System;

namespace DirectOne.App.Poc.Repositories
{
    public class BigqueryRepository : IBigqueryRepository
    {
        private readonly BigQueryClient _client;
        private readonly IVariables _variables;

        public BigqueryRepository(IVariables variables, string projectName)
        {
            _variables = variables;





            Console.Write("Digite o nome do Tenant: ");
            projectName = Console.ReadLine();

            _client = BigQueryClient.Create(projectName);
            _variables = variables;            

            string consultaSQL = $"SELECT MAX(eventDate) as Max FROM `{_variables.JOURNEY_EVENT_DATABASE}.{projectName}.{_variables.TABLE_V2}`";
            var resultadoSQL = _client.ExecuteQuery(consultaSQL, null);
            foreach (var item in resultadoSQL)
            {
                Console.WriteLine(item["Max"]);
            }
        }
    }
}
