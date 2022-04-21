using System.Diagnostics;
using System.Xml.Schema;
using Game.AttackItems;
using Game.Behaviors.AttackBehaviors;
using Game.DefenceBehavior;
using Game.DefenceItems;
using Game.worlds;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using SimpleGameFramework;

namespace Game;

public static class Program
{
    private static IConfigurationRoot configuration;

    private static int Main()
    {
            Run();
            GameLoop();
            return 0;
    }

    private static void Run()
    {
        // Create service collection
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
    }

    private static void ConfigureServices(IServiceCollection serviceCollection)
    {
        
        // Build configuration
        configuration = new ConfigurationBuilder()
            .SetBasePath(@"C:\Users\dnielsen\RiderProjects\SimpleGameFramework\Game")
            .AddJsonFile("appsettings.json", false)
            .Build();

        // Add access to generic IConfigurationRoot
        serviceCollection.AddSingleton(configuration);
    }

    private static void GameLoop()
    {
        Trace.Listeners.Clear();  
        Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        var doubleAttack = new DoubleAttack();
        var doubleDamage = new DoubleDamage();
        var world = new NewWorld(configuration);
        var player = new Player {position = new Position {X = 0, Y = 0},
            Name = "Player",
            AttackItem = new Sword
            {
                Hitpoint = 25, Name = "Diamond crusted sword",
                             
            },
            AttackBehavior = doubleAttack,
            AttackleBehavior = new NormalAttackable(),
            Observe = false
        };

        var monster =  new WeakMonster {position = new Position {X = 1, Y = 0},
            Name = "Weakling",
            AttackItem = new Sword
            {
                Hitpoint = 5, Name = "Diamond crusted sword",
            },
            DefenceItem = new Armor {Name = "thicc leather", ReduceHitpoint = 0},
            AttackBehavior = doubleDamage,
            AttackleBehavior = new NormalAttackable(),
            Observe = false
        };

        world.AddEntity(player);                         
        world.AddEntity(monster);

        player.Hit(monster);
        monster.Hit(player);
    }

}