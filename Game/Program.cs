// See https://aka.ms/new-console-template for more information

using Game;
using Game.AttackItems;
using Game.DefenceItems;
using Game.WorldObjects;
using SimpleGameFramework;

var world = new World {MaxX = 10, MaxY = 10};
var player = new Player {position = new Position {X = 0, Y = 0},
                         Name = "Player",
                         AttackItem = new Sword {Hitpoint = 25, Name = "Diamond crusted sword"}
};
var monster =  new WeakMonster {position = new Position {X = 1, Y = 0},
                                Name = "Weakling"
};

var loot = new List<object>
{
    new Sword {Hitpoint = 25, Name = "Diamond crusted sword"},
    new Armor {ReduceHitpoint = 12, Name = "Tattered leather armor"}
};

var lootbox = new LootBox {Position = new Position {X = 5, Y = 3}, 
                           loot = loot, Name = "A heavy chest"
};

world.entities.Add(player);                         
world.entities.Add(monster);
world.entities.Add(lootbox);

/*foreach (var worldEntity in world.entities)
{
    if (worldEntity is Creature creature)
    {
    }
}*/

Console.WriteLine(monster.Hitpoint);
player.Hit(monster);
Console.WriteLine(monster.Hitpoint);