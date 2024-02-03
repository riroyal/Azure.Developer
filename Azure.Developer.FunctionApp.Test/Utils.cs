using CDW.Developer.Service.Common;
using CDW.Developer.Service.DbContext;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;

namespace CDW.Developer.FunctionApp.Test
{
    public static class Utils
    {
        public static string GetJsonFromTestDataFile()
        {
            string result;
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = Constants.TestDataResource;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        public static AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Constants.InMemoryDatabaseName)
                .Options;

            return new AppDbContext(options);
        }
    }
}
