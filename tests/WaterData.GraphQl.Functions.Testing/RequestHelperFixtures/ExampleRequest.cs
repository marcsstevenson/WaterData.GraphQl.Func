using WaterData.RequestHandling.Abstractions;

namespace WaterData.GraphQl.Functions.Testing.RequestHelperFixtures
{
    public class ExampleRequest : IRequest
    {
        public string Name { get; set; }
    }
}
