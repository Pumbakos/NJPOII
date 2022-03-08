namespace DesignPatterns.Strategy
{
    public abstract class Monster
    {
        protected internal string Name { protected init; get; }
        protected int Strength { set; get; }
        protected int Defence { set; get; }
        protected int Agile { set; get; }

        protected Monster()
        {
        }

        protected Monster(string name, int strength, int defence, int agile)
        {
            Name = name;
            Strength = strength;
            Defence = defence;
            Agile = agile;
        }

        public abstract void Attack(Monster monster, int strength);

        public abstract void Avoid(Monster monster);

        public abstract void Defense(Monster monster);
    }
}