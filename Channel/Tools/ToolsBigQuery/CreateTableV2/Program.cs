using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateTableV2
{
    class Program
    {
        private const string projectId = "journey-event-process-stage";
        static void Main(string[] args)
        {
            var tenants = ListDatasets(projectId);
            CreateJourneyEventTables(projectId, tenants);
        }

        private Task<Result<bool>> CreateJourneyEventTables(string tableName, BigQueryDataset dataSet)
        {

            var schema = new TableSchemaBuilder
            {
                { "created", BigQueryDbType.Timestamp, BigQueryFieldMode.Required },
                { "tenantId", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "tenantName", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "journeyId", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "journeyVersion", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "journeyName", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "nodeKey", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "nodeName", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "channelKind", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "shootingId", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "shootingCreated", BigQueryDbType.Timestamp, BigQueryFieldMode.Required },
                { "shootingCorrelationId", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "trackingUrl", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "trackingIp", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "userAgent", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "userAgentBrowserFamily", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "userAgentBrowserVersion", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "userAgentOSFamily", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "userAgentOSVersion", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "userAgentDeviceFamily", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "carrierName", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "recipient", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "eventType", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "bounceType", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "bounceReason", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "response", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "eventDate", BigQueryDbType.Timestamp, BigQueryFieldMode.Required },
                { "providerEventId", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "movementDate", BigQueryDbType.Date, BigQueryFieldMode.Required },
                { "movementFilename", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "movementLot", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "integrationId", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "integrationCreated", BigQueryDbType.Timestamp, BigQueryFieldMode.Required },
                { "integrationProcessingDate", BigQueryDbType.Timestamp, BigQueryFieldMode.Required },
                { "customerId", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "customerIdentification", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "customerName", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "documentDescription", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "documentDueDate", BigQueryDbType.Date, BigQueryFieldMode.Nullable },
                { "isTest", BigQueryDbType.Bool, BigQueryFieldMode.Required },
                { "userName", BigQueryDbType.String, BigQueryFieldMode.Nullable },
                { "userEmail", BigQueryDbType.String, BigQueryFieldMode.Nullable },
                { "documentCorrelationId", BigQueryDbType.String, BigQueryFieldMode.Nullable },
                { "documentNumber", BigQueryDbType.String, BigQueryFieldMode.Nullable },
                { "documentStoragePath", BigQueryDbType.String, BigQueryFieldMode.Nullable },
                { "journeyContextId", BigQueryDbType.String, BigQueryFieldMode.Required },
                { "channelCertificationKind", BigQueryDbType.String, BigQueryFieldMode.Required }

            }.Build();

            TimePartitioning timePartitioning = new TimePartitioning
            {
                Type = "DAY"
            };
            CreateTableOptions tableOptions = new CreateTableOptions
            {
                TimePartitioning = timePartitioning
            };

            var result = dataSet.CreateTable(tableId: tableName, schema: schema, tableOptions);
            if (result == null)
                return Task.FromResult(GetResult(false, HttpStatusCode.BadRequest, null));

            return Task.FromResult(GetResult(true, HttpStatusCode.OK, null));
        }
        private Result<string> GetResult(string response, HttpStatusCode success, Exception exception = null)
        {
            return new Result<string>(response, success, exception);
        }

        private Result<long> GetResult(long response, HttpStatusCode success, Exception exception = null)
        {
            return new Result<long>(response, success, exception);
        }

        private Result<bool> GetResult(bool response, HttpStatusCode success, Exception exception = null)
        {
            return new Result<bool>(response, success, exception);
        }

        static List<string> ListDatasets(string projectId)
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
/*
[{"name": "created","type": "TIMESTAMP","mode" :"REQUIRED"},
{"name": "tenantId","type": "STRING","mode" :"REQUIRED"},
{"name": "tenantName","type": "STRING","mode" :"REQUIRED"},
{"name": "journeyId","type": "STRING","mode" :"REQUIRED"},
{"name": "journeyVersion","type": "STRING","mode" :"REQUIRED"},
{"name": "journeyName","type": "STRING","mode" :"REQUIRED"},
{"name": "nodeKey","type": "STRING","mode" :"REQUIRED"},
{"name": "nodeName","type": "STRING","mode" :"REQUIRED"},
{"name": "channelKind","type": "STRING","mode" :"REQUIRED"},
{"name": "shootingId","type": "STRING","mode" :"REQUIRED"},
{"name": "shootingCreated","type": "TIMESTAMP","mode" :"REQUIRED"},
{"name": "shootingCorrelationId","type": "STRING","mode" :"REQUIRED"},
{"name": "trackingUrl","type": "STRING","mode" :"REQUIRED"},
{"name": "trackingIp","type": "STRING","mode" :"REQUIRED"},
{"name": "userAgent","type": "STRING","mode" :"REQUIRED"},
{"name": "userAgentBrowserFamily","type": "STRING","mode" :"REQUIRED"},
{"name": "userAgentBrowserVersion","type": "STRING","mode" :"REQUIRED"},
{"name": "userAgentOSFamily","type": "STRING","mode" :"REQUIRED"},
{"name": "userAgentOSVersion","type": "STRING","mode" :"REQUIRED"},
{"name": "userAgentDeviceFamily","type": "STRING","mode" :"REQUIRED"},
{"name": "carrierName","type": "STRING","mode" :"REQUIRED"},
{"name": "recipient","type": "STRING","mode" :"REQUIRED"},
{"name": "eventType","type": "STRING","mode" :"REQUIRED"},
{"name": "bounceType","type": "STRING","mode" :"REQUIRED"},
{"name": "bounceReason","type": "STRING","mode" :"REQUIRED"},
{"name": "response","type": "STRING","mode" :"REQUIRED"},
{"name": "eventDate","type": "TIMESTAMP","mode" :"REQUIRED"},
{"name": "providerEventId","type": "STRING","mode" :"REQUIRED"},
{"name": "movementDate","type": "DATE","mode" :"REQUIRED"},
{"name": "movementFilename","type": "STRING","mode" :"REQUIRED"},
{"name": "movementLot","type": "STRING","mode" :"REQUIRED"},
{"name": "integrationId","type": "STRING","mode" :"REQUIRED"},
{"name": "integrationCreated","type": "TIMESTAMP","mode" :"REQUIRED"},
{"name": "integrationProcessingDate","type": "TIMESTAMP","mode" :"REQUIRED"},
{"name": "customerId","type": "STRING","mode" :"REQUIRED"},
{"name": "customerIdentification","type": "STRING","mode" :"REQUIRED"},
{"name": "customerName","type": "STRING","mode" :"REQUIRED"},
{"name": "documentDescription","type": "STRING","mode" :"NULLABLE"},
{"name": "documentDueDate","type": "DATE","mode" :"NULLABLE"},
{"name": "isTest","type": "BOOLEAN","mode" :"REQUIRED"},
{"name": "userName","type": "STRING","mode" :"NULLABLE"},
{"name": "userEmail","type": "STRING","mode" :"NULLABLE"},
{"name": "documentCorrelationId","type": "STRING","mode" :"NULLABLE"},
{"name": "documentNumber","type": "STRING","mode" :"NULLABLE"},
{"name": "documentStoragePath","type": "STRING","mode" :"NULLABLE"},
{"name": "journeyContextId","type": "STRING","mode" :"REQUIRED"},
{"name": "channelCertificationKind","type": "STRING","mode" :"REQUIRED"}]*/