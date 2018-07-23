using Company.Data;
using Company.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Company.Services
{
    public class DbInitilizerService : IDbInitilizerService
    {
        private readonly CompanyContext context;

        public DbInitilizerService(CompanyContext context)
        {
            this.context = context;
        }

        public void InitilizeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}
