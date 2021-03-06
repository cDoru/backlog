using System.Data.Entity.Migrations;
using System.Linq;
using Backlog.Model;

namespace Backlog.Data.Migrations
{
    public class TileConfiguration
    {
        public static void Seed(BacklogContext context) {

            var tenant = context.Tenants.Single(x => x.Name == "Default");

            context.Tiles.AddOrUpdate(x => x.Name, new Tile()
            {
                Name = "Home Page",
                TenantId = tenant.Id
            });

            context.Tiles.AddOrUpdate(x => x.Name, new Tile()
            {
                Name = "Digital Assets",
                TenantId = tenant.Id
            });

            context.Tiles.AddOrUpdate(x => x.Name, new Tile()
            {
                Name = "Products",
                TenantId = tenant.Id
            });

            context.Tiles.AddOrUpdate(x => x.Name, new Tile()
            {
                Name = "Epics",
                TenantId = tenant.Id
            });

            context.Tiles.AddOrUpdate(x => x.Name, new Tile()
            {
                Name = "Sprints",
                TenantId = tenant.Id
            });

            context.Tiles.AddOrUpdate(x => x.Name, new Tile()
            {
                Name = "Tasks",
                TenantId = tenant.Id
            });

            context.SaveChanges(Constants.DefaultUsername);
        }
    }
}
