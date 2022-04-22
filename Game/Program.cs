using System.Diagnostics;
using System.Xml.Schema;
using Game.AttackBehaviors;
using Game.AttackItems;
using Game.Behaviors.AttackBehaviors;
using Game.DefenceBehavior;
using Game.DefenceItems;
using Game.Factories;
using Game.worlds;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using SimpleGameFramework;

namespace Game;

public static class Program
{
    private static IConfigurationRoot? _configuration;

    private static int Main()
    {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Run();
            GameLoop();
            return 0;
    }

    private static void Run()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
    }

    private static void ConfigureServices(IServiceCollection serviceCollection)
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(@"C:\Users\dnielsen\RiderProjects\SimpleGameFramework\Game")
            .AddJsonFile("appsettings.json", false)
            .Build();
        
        serviceCollection.AddSingleton(_configuration);
    }

    private static void Battle(Creature creatureOne, Creature? creatureTwo)
    {
        while (creatureOne.Hitpoint > 0 && creatureTwo!.Hitpoint > 0)
        {
            creatureOne.Hit(creatureTwo);
        }
    }

    private static void GameLoop()
    {
        
        var world = new NewWorld(_configuration);

        var weakMonsterFactory = new WeakMonsterFactory();
        
        var normalAttack = new NormalAttack();
        var normalAttackable = new NormalAttackable();
        var player = new Player {
            Position = new Position {X = 0, Y = 0},
            Name = "Player",
            AttackItem = new Sword
            {
                Hitpoint = 25, Name = "Diamond crusted sword",
            },
            AttackBehavior = normalAttack,
            AttackleBehavior = normalAttackable,
            Observe = true
        };
        world.AddEntity(player);

        var monsters = weakMonsterFactory.CreateCreatures(10, world).ToList();
        world.AddEntities(monsters);

        var opponent = world.Entities.Skip(1).First() as Creature;
        
        Battle(player, opponent);
    }
}