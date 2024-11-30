using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22._10.Context
{
    public class ShopContextFactory : IDesignTimeDbContextFactory<ShopContext>
    {
        private static IConfigurationRoot config;

        static ShopContextFactory()
        {
            // Загружаем конфигурацию из файла appsettings.json
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            config = builder.Build();
        }

        public ShopContext CreateDbContext(string[]? args = null)
        {
            // Настраиваем DbContext с использованием строки подключения
            var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            return new ShopContext(optionsBuilder.Options);
        }
    }
}
