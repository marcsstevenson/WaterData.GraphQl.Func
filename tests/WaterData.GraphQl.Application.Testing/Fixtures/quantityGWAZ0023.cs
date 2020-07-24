using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterData.GraphQl.Application.Testing.Fixtures
{
    public class quantityGWAZ0023 : IExampleProvider
    {
        public string GetJson()
        {
            return @"{
    ""id"": ""quantityGWAZ0023"",
    ""name"": ""quantity test type data for GWAZ0023"",
    ""planTableType"": ""quantity"",
    ""attributes"": [
        ""Surface Water""
    ],
    ""spatialUnits"": [
        ""GWAZ0023""
    ],
    ""planDetails"": {
        ""planName"": ""LWRP"",
        ""status"": ""Operative"",
        ""fromDate"": ""2015-08-24T00:00:00+00:00""
    },
    ""planLimits"": {
        ""measuringPoint"": [
            ""SWPT0173""
        ],
        ""planSection"": ""6"",
        ""planTable"": ""Table 2"",
        ""limits"": [
            {
                ""name"": ""A"",
                ""spatialUnits"": [
                    ""GWAZ0023""
                ],
                ""appliesToSpatialUnits"": ""individual"",
                ""parameters"": [
                    {
                        ""type"": ""Allocation Block"",
                        ""boundary"": ""Maximum"",
                        ""unit"": ""Litres/Second"",
                        ""values"": [
                            {
                                ""fromMonth"": 1,
                                ""toMonth"": 3,
                                ""value"": 0
                            },
                            {
                                ""fromMonth"": 4,
                                ""toMonth"": 10,
                                ""value"": 58
                            },
                            {
                                ""fromMonth"": 11,
                                ""toMonth"": 12,
                                ""value"": 0
                            }
                        ]
                    },
                    {
                        ""type"": ""Minimum Flow"",
                        ""boundary"": ""Minimum"",
                        ""unit"": ""Litres/Second"",
                        ""values"": [
                            {
                                ""fromMonth"": 1,
                                ""toMonth"": 3,
                                ""value"": 420
                            },
                            {
                                ""fromMonth"": 4,
                                ""toMonth"": 10,
                                ""value"": 300
                            },
                            {
                                ""fromMonth"": 11,
                                ""toMonth"": 12,
                                ""value"": 420
                            }
                        ]
                    }
                ]
            },
            {
                ""name"": ""B"",
                ""spatialUnits"": [
                    ""GWAZ0023""
                ],
                ""appliesToSpatialUnits"": ""individual"",
                ""parameters"": [
                    {
                        ""type"": ""Allocation Block"",
                        ""boundary"": ""Maximum"",
                        ""unit"": ""Litres/Second"",
                        ""values"": [
                            {
                                ""fromMonth"": 1,
                                ""toMonth"": 12,
                                ""limit"": 50
                            }
                        ]
                    },
                    {
                        ""type"": ""Minimum Flow"",
                        ""boundary"": ""Minimum"",
                        ""unit"": ""Litres/Second"",
                        ""values"": [
                            {
                                ""fromMonth"": 1,
                                ""toMonth"": 12,
                                ""value"": 1095
                            }
                        ]
                    }
                ]
            }
        ]
    },
    ""_rid"": ""rlUhANBLTj0GAAAAAAAAAA=="",
    ""_self"": ""dbs/rlUhAA==/colls/rlUhANBLTj0=/docs/rlUhANBLTj0GAAAAAAAAAA==/"",
    ""_etag"": ""\""1300ee0a-0000-1a00-0000-5f152ae40000\"""",
    ""_attachments"": ""attachments/"",
    ""_ts"": 1595222756
}";
        }
    }
}
