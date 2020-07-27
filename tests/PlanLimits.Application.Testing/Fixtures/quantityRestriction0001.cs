namespace PlanLimits.Application.Testing.Fixtures
{
    public class quantityRestriction0001 : IExampleProvider
    {
        public string GetJson()
        {
            return @"
            {
                ""id"": ""quantityRestriction0001"",
                ""name"": ""Okuti River and tribs"",
                ""planTableType"": ""quantityRestrictions"",
                ""attributes"": [
                    ""Surface Water""
                ],
                ""spatialUnits"": [
                    ""SWPT0110""
                ],
                ""planDetails"": {
                    ""planName"": ""LWRP"",
                    ""status"": ""Operative"",
                    ""fromDate"": ""2015-08-24T00:00:00+00:00""
                },
                ""planLimits"": {
                    ""measuringPoint"": [
                        ""SWPT0110""
                    ],
                    ""planSection"": ""10"",
                    ""planTable"": ""Table 10(c)"",
                    ""limits"": [
                        {
                            ""name"": ""A"",
                            ""spatialUnits"": [
                                ""SWPT0110""
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
                                            ""value"": 20
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
                                            ""value"": 59
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                },
                ""planRestictions"": {
                    ""measuringPoint"": [
                        ""SWPT0110""
                    ],
                    ""section"": ""10"",
                    ""planTable"": ""Table 10(c)"",
                    ""restictions"": [
                        {
                            ""flow"": {
                                ""rate"": 79,
                                ""units"": ""L/s""
                            },
                            ""restrictionType"": ""stepped"",
                            ""value"": 25,
                            ""unit"": ""percentage""
                        },
                        {
                            ""flow"": {
                                ""rate"": 69,
                                ""units"": ""L/s""
                            },
                            ""restrictionType"": ""stepped"",
                            ""value"": 50,
                            ""unit"": ""percentage""
                        },
                        {
                            ""flow"": {
                                ""rate"": 59,
                                ""units"": ""L/s""
                            },
                            ""restrictionType"": ""stepped"",
                            ""value"": 100,
                            ""unit"": ""percentage""
                        }
                    ]
                },
                ""_rid"": ""rlUhANBLTj0BAAAAAAAAAA=="",
                ""_self"": ""dbs/rlUhAA==/colls/rlUhANBLTj0=/docs/rlUhANBLTj0BAAAAAAAAAA==/"",
                ""_etag"": ""\""00003f09-0000-1a00-0000-5f0d5c7f0000\"""",
                ""_attachments"": ""attachments/"",
                ""_ts"": 1594711167
            }
            ";
        }
    }
}
