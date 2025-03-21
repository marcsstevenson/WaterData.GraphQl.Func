using GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PlanLimits.Functions
{
    internal class GraphQLExecutionResult : ActionResult
    {
        private const string CONTENT_TYPE = "application/json";

        private readonly ExecutionResult _executionResult;
        private readonly IDocumentWriter _documentWriter;

        public GraphQLExecutionResult(ExecutionResult executionResult, IDocumentWriter documentWriter)
        {
            _executionResult = executionResult ?? throw new ArgumentNullException(nameof(executionResult));
            _documentWriter = documentWriter;
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            //IDocumentWriter documentWriter = context.HttpContext.RequestServices.GetRequiredService<IDocumentWriter>();
            IDocumentWriter documentWriter = _documentWriter;

            HttpResponse response = context.HttpContext.Response;
            response.ContentType = CONTENT_TYPE;
            response.StatusCode = StatusCodes.Status200OK;

            // Azure functions 3 disallowing async IO and newtonsoft json is not able to
            // make real async IO, we need copy to a MemoryStream.
            // After graphql has switch to System.Text.Json this can be written directly to response.Body
            using var stream = new MemoryStream();
            await documentWriter.WriteAsync(stream, _executionResult);
            stream.Position = 0;
            await stream.CopyToAsync(response.Body);
        }
    }
}
