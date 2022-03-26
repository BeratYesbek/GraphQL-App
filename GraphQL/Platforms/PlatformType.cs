using CommanderGraphQL.Data;
using CommanderGraphQL.Models;
using HotChocolate;
using HotChocolate.Types;
namespace CommanderGraphQL.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {

            descriptor.Description("Represents any software or service that has a a command line interface");

            descriptor.Field(t => t.LicenseKey).Ignore();

            descriptor.Field(p => p.Commands)
            .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("This is the list of avaliable commands for this platform");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context)
            {
                return context.Commands.Where(c => c.PlatformId == platform.Id);
            }
        }
    }
}