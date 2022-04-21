using Game.AttackBehaviors;
using Game.AttackItems;
using Game.DefenceBehavior;
using Game.DefenceItems;
using SimpleGameFramework;
using SimpleGameFramework.Factories;

namespace Game.Factories;

public class WeakMonsterFactory : ICreatureFactory
{
    private World World { get; set; }
    private readonly IAttackBehavior _attackBehavior = new NormalAttack();
    private readonly IAttackable _attackable = new NormalAttackable();
    public WeakMonsterFactory(World world)
    {
        World = world;
    }

    public IEnumerable<Creature> CreateCreatures(int count, World world)
    {
        var maxX = world.MaxX;
        var maxY = world.MaxY;
        var random = new Random();
        var listOfWeakMonsters = new List<Creature>();

        while (true)
        {
            var position = new Position {X = random.Next(0, maxX), Y = random.Next(0, maxY)};
            
            if (world.PositionIsOccupied(position)) continue;
            var weakMonster = new WeakMonster
            {
                Position = position,
                Name = "Weakling",
                AttackItem = new Sword
                {
                    Hitpoint = 5, Name = "Diamond crusted sword",
                },
                DefenceItem = new Armor {Name = "thick leather", ReduceHitpoint = 0},
                AttackBehavior = _attackBehavior,
                AttackleBehavior = _attackable,
                Observe = true
            };
            
            listOfWeakMonsters.Add(weakMonster);
            if (listOfWeakMonsters.Count == count) break;
        }

        return listOfWeakMonsters;
    }

    public IEnumerable<Creature> CreateCreatures(int count)
    {
        throw new NotImplementedException();
    }
}