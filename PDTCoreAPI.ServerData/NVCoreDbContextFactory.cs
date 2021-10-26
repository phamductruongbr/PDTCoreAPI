using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PDTCoreAPI.ServerData
{
    public class NVCoreDbContextFactory : IDesignTimeDbContextFactory<NVCoreDbContext>
    {
        public NVCoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionstring = configuration.GetConnectionString("NVCoreDb");
            var optionsBuilder = new DbContextOptionsBuilder<NVCoreDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            return new NVCoreDbContext(optionsBuilder.Options);
        }
    }
}
