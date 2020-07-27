using System;

namespace PlanLimits.Functions
{
    internal class GraphQLBadRequestException : Exception
    {
        public GraphQLBadRequestException(string message)
            : base(message)
        { }
    }
}
