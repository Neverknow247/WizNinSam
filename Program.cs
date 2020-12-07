using System;

namespace wizNinSam
{
    class Program
    {
        static void Main(string[] args)
        {
            // Human human = new Human("Plain Nathan");
            // Ninja nin = new Ninja("Ninja Nathan");
            // Wizard wiz = new Wizard("Wizard Nathan");
            // Samurai sam = new Samurai("Samurai Nathan");
            // wiz.Attack(sam);
            // sam.Meditate();
            // sam.Attack(nin);
            // wiz.Attack(sam);
            // sam.Attack(wiz);
            // nin.Attack(sam);
        }
    }
    class Human
    {
        public string Name;
        public int Strength;
        virtual public int Intelligence{get;}
        virtual public int Dexterity{get;}
        virtual public int maxHealth{get;}

        protected int health;

        public int Health
        {
            get { return health; }
        }

        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            maxHealth = 100;
            health = maxHealth;
        }

        public Human(string name, int str, int intel, int dex, int maxHP)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            maxHealth = maxHP;
            health = maxHP;
        }

        // Build Attack method
        virtual public void Attack(Human target, int dmg = 9)
        {
            target.TakeDamage(dmg);
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        }
        public int TakeDamage(int dmg){
            health -= dmg;
            if(health<0){
                health=0;
            }
            return health;
        }
        public int GainHealth(int healthGained){
            health += healthGained;
            if(health>maxHealth){
                health=maxHealth;
            }
            return health;
        }
    }
    class Ninja : Human
    {
        public override int Dexterity{
            get{
                return 175;
            }
        }
        public Ninja(string name) : base(name){}
        public override void Attack(Human target, int dmg = 9)
        {
            dmg = Dexterity * 5;
            base.Attack(target, dmg);
            Random rand = new Random();
            if(rand.Next(1,101) > 80){
                target.TakeDamage(10);
                Console.WriteLine($"{Name} deals a critical hit and deals and additional 10 damage to {target.Name}!");
            }
        }
        public void Steal(Human target){
            target.TakeDamage(5);
            GainHealth(5);
            Console.WriteLine($"{Name} has stolen 5 Health from {target.Name} and used it to heal themselves");
        }
    }
    class Wizard : Human
    {
        public override int Intelligence{
            get{return 25;}
        }
        public override int maxHealth{
            get{return 50;}
        }
        public Wizard(string name) : base(name){}
        public override void Attack(Human target, int dmg = 9){
            dmg = Intelligence * 5;
            base.Attack(target,dmg);
            Console.WriteLine($"{Name} healed themselves for {dmg}!");
            GainHealth(dmg);
        }
        public void Heal(Human target){
            int heal = Intelligence * 10;
            Console.WriteLine($"{Name} has healed {Name} for {heal}");
            target.GainHealth(heal);
        }
    }
    class Samurai : Human
    {
        public override int maxHealth{
            get{return 200;}
        }
        public Samurai(string name) : base(name){}
        public override void Attack(Human target, int dmg = 9)
        {
            base.Attack(target);
            if(target.Health < 50){
                Console.WriteLine($"{target.Name} is too weak and {Name} decapitates {target.Name}");
                target.TakeDamage(50);
            }
        }
        public void Meditate(){
            Console.WriteLine($"{Name} has meditated and is at full health");
            GainHealth(200);
        }
    }
}
