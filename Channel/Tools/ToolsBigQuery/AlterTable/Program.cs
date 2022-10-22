using Google.Apis.Auth.OAuth2;
using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterTable
{
    class Program
    {
        private const string jsonPath = @"C:\credentials\journey-event-process-stage-onboard-8edbcce432eb.json";
        private static GoogleCredential credentials = GoogleCredential.FromFile(jsonPath);
        private const string projectId = "journey-event-process-stage";
        static void Main(string[] args)
        {            
            var tenants = ListDatasets(projectId);

            foreach (var tenant in tenants)
            {
                try
                {
                    InsertColumns(tenant);                    
                }
                catch (Exception)
                {
                    continue;
                }                
            }            
        }

        static void InsertColumns(string tenant)
        {
            var cliente = BigQueryClient.Create(projectId, credentials);
            Console.WriteLine($"A tabela do tenant: {tenant} foi alterado com sucesso");

                string consultaSQL = $"ALTER TABLE `{projectId}.{tenant}.journey_event_v2`\n" +
                        $"ADD COLUMN isBetterChannel BOOLEAN, ADD COLUMN properties ARRAY<STRUCT<key STRING, value STRING>>;";
                var resultadoSQL = cliente.ExecuteQuery(consultaSQL, null);            
        }        

        private static List<string> ListDatasets(string projectId)
        {
            var tenants = new List<string>();
            BigQueryClient client = BigQueryClient.Create(projectId);
            
            List<BigQueryDataset> datasets = client.ListDatasets().ToList();
            
            if (datasets.Count > 0)
            {
                Console.WriteLine($"Datasets in project {projectId}:");
                foreach (var dataset in datasets)
                {
                    tenants.Add(dataset.Reference.DatasetId);
                }
            }
            else
            {
                Console.WriteLine($"{projectId} does not contain any datasets.");
            }
            return tenants;
        }
    }
}