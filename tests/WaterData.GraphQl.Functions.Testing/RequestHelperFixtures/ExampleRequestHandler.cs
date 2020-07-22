using System.Threading.Tasks;
using WaterData.RequestHandling.Abstractions;

namespace WaterData.GraphQl.Functions.Testing.RequestHelperFixtures
{
    public class ExampleRequestHandler : IRequestHandler<ExampleRequest, string>
    {
        public async Task<string> GetResult(ExampleRequest request)
        {
            return await Task.FromResult(request.Name);
        }
    }
}
