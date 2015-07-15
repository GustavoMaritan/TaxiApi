using System.Data.Entity.Migrations;
using DadosSql.Contextos;
using DadosSql.Entities;

namespace DadosSql.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Operadora.AddOrUpdate(
              x => x.Nome, new Operadora("Claro"), new Operadora("Tim"), new Operadora("Vivo"));
            //
        }
    }
}