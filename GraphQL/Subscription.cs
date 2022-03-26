using CommanderGraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGraphQL.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
        
    }
}