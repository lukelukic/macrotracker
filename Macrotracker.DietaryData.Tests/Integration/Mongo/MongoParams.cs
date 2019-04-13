using System;
using System.Collections.Generic;
using System.Text;

namespace Macrotracker.DietaryData.Tests.Integration.Mongo
{
    public static class MongoParams
    {
        public static string ConnectionString => "mongodb://localhost:27017";
        public static string DbName => "UserData";
    }
}
