using System;
using System.Collections.Generic;
using System.Text;

namespace DataProvider.Config
{
    public interface IMongoDbSettings
    {
        string TracksCollectionName { get; set; }
        string CommandsCollectionName { get; set; }
        string AnalyticsResultsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
