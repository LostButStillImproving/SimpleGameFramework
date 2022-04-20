using Game;
using Game.AttackBehaviors;
using Game.AttackItems;
using Game.Behaviors.AttackBehaviors;
using Game.DefenceBehavior;
using Game.DefenceItems;
using SimpleGameFramework;


var world = new World {MaxX = 10, MaxY = 10};
var player = new Player {position = new Position {X = 0, Y = 0},
                         Name = "Player",
                         AttackItem = new Sword
                         {
                             Hitpoint = 25, Name = "Diamond crusted sword",
                             
                         },
                         AttackBehavior = new DoubleAttack(),
                         AttackleBehavior = new NormalAttackable()
};

var monster =  new WeakMonster {position = new Position {X = 1, Y = 0},
                                Name = "Weakling",
                                AttackItem = new Sword
                                {
                                    Hitpoint = 5, Name = "Diamond crusted sword",
                                },
                                DefenceItem = new Armor {Name = "thicc leather", ReduceHitpoint = 0},
                                AttackBehavior = new NormalAttack(),
                                AttackleBehavior = new NormalAttackable(),
};

world.AddEntity(player);                         
world.AddEntity(monster);

Console.WriteLine("Entity count: " + world.Entities.Count);
Console.WriteLine("Monster hp: " + monster.Hitpoint);
player.Hit(monster);

Console.WriteLine("Monster hp: " + monster.Hitpoint);
Console.WriteLine("Entity count: " + world.Entities.Count);

/*var loot = new List<object>
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

foreach (var worldEntity in world.entities)
{
    if (worldEntity is Creature creature)
    {
    }
}*/
