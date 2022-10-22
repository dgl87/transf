using Google.Apis.Auth.OAuth2;
using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectOne.App.Poc
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var jsonPath = @"C:\credentials\journey-event-process-prod-cd7958e50f14.json";
            InfoTenants tenant;

            Console.Write("Digite o TenantId: ");
            string tenantId = Console.ReadLine();
            Console.Write("Digite a data de início: ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Digite a data fim: ");
            DateTime EndDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Início da operação: ");

            tenant = new InfoTenants(tenantId, startDate, EndDate);

            string projetoId = "journey-event-process-prod";
            var credentials = GoogleCredential.FromFile(jsonPath);
            var cliente = BigQueryClient.Create(projetoId, credentials);

            //Loop de data
            string consultaSQL;
            BigQueryResults resultadoSQL;
            //DateTime StartDate = new DateTime(2021, 08, 02); //2021 - 08 - 02
            //DateTime EndDate = new DateTime(2022, 01, 18); //2022-01-19

            foreach (DateTime tenantDay in EachDay(startDate, EndDate))
            {
                Console.WriteLine($"Iniciando procedimento para {tenantDay.ToString("yyyy-MM-dd")}");
                consultaSQL = $"CALL `{projetoId}.alliedsoudi.sp_merge_journey_customer`('{tenantId}', '{tenantDay.ToString("yyyy-MM-dd")}');\n"
                            + $"CALL `{projetoId}.alliedsoudi.sp_merge_journey_rate`('{tenantId}', '{tenantDay.ToString("yyyy-MM-dd")}');";
                resultadoSQL = await cliente.ExecuteQueryAsync(consultaSQL, null);
                Console.WriteLine($"Procedimento criado com sucesso para o dia {tenantDay.ToString("yyyy-MM-dd")}");
                Console.WriteLine();
            }

            //metodo
            static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
            {
                for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                    yield return day;
            }
        }
    }
} 