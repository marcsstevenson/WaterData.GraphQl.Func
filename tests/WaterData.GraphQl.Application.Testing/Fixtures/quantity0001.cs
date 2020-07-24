namespace WaterData.GraphQl.Application.Testing.Fixtures
{
    public class quantity0001 : IExampleProvider
    {
        public string GetJson()
        {
            return @"{
    ""id"": ""quantity0001"",
    ""name"": ""Lyell Creek/Waikawau mainstem"",
    ""planTableType"": ""quantity"",
    ""attributes"": [
        ""Surface Water""
    ],
    ""spatialUnits"": [
        ""SWPT0173""
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
                    ""SWPT0173""
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
                    ""SWPT0173""
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
    ""_rid"": ""rlUhANBLTj0CAAAAAAAAAA=="",
    ""_self"": ""dbs/rlUhAA==/colls/rlUhANBLTj0=/docs/rlUhANBLTj0CAAAAAAAAAA==/"",
    ""_etag"": ""\""9e0058c6-0000-1a00-0000-5f0c3d2b0000\"""",
    ""_attachments"": ""attachments/"",
    ""_ts"": 1594637611
}";
        }
    }
}
