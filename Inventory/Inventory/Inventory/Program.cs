using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            Weapon Axe = new Weapon(50, "Fire", false, "Axe", 15, "IDK", 98);
            Weapon Hammer = new Weapon(50, "Fire", false, "Hammer", 15, "IDK", 8);
            Potion HealingPotion = new Potion(false, 50, "Healing Potion", 1, "IDK", 78);
            Inventory inv = new Inventory(100);
            inv.Add(Axe);
            inv.Add(Hammer);
            inv.Add(HealingPotion);
            inv.Info();
            inv.Discard();
        }
    }

    class Inventory
    {
        public List<Item> InventoryO;
        public float Capacity;

        public Inventory(float capacity)
        {
            Capacity = capacity;
            InventoryO = new List<Item>();
        }

        public void Add(Item item)
        {
            float totalCapacity = 0;
            foreach (Item prop in InventoryO)
            {
                totalCapacity = totalCapacity + prop.Weight;
            }
            if (totalCapacity + item.Weight <= Capacity)
            {
                InventoryO.Add(item);
                Console.WriteLine(item.Name + " Added to inventory");
                Console.ReadKey();
            }
        }
        public void Info()
        {
            foreach (Item prop in InventoryO)
            {
                Console.WriteLine(prop.Name);
                Console.WriteLine(prop.Weight);
                Console.WriteLine(prop.Description);
                Console.ReadKey();
            }
        }
        public void Discard()
        {
            foreach (Item prop in InventoryO)
            {
                string option;
                if (prop.Durability <= 10)
                {
                    Console.WriteLine(prop.Name);
                    Console.WriteLine("Do you want to discard this item?");
                    Console.WriteLine("Y ---- N");
                    option = Console.ReadLine();
                    switch (option)
                    {
                        case "Y":
                            InventoryO.Remove(prop);
                            Console.WriteLine(prop.Name + "Removed");
                            Console.ReadKey();
                            break;
                        case "N":
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    class Item
    {
        public string Name;
        public float Weight;
        public string Description;
        public float Durability;

        public Item(string name, float weight, string description, float durability)
        {
            Name = name;
            Weight = weight;
            Description = description;
            Durability = durability;
        }

        public virtual void Use()
        {
        }
        public virtual void Info()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Weight: " + Weight);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Durability: " + Durability);
        }
    }

    class Weapon : Item
    {
        public float Damage;
        public string Type;
        public bool Destroyed = false;

        public Weapon(float damage, string type, bool destroyed, string name, float weight, string description, float durability) : base(name, weight, description, durability)
        {
            Damage = damage;
            Type = type;
            Destroyed = destroyed;
        }
        public override void Use()
        {
            Console.WriteLine("Damage: " + Damage);
            this.Durability = Durability - Durability / 10;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine("Damage: " + Damage);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Destroyed: " + Destroyed);
        }
    }

    class Potion : Item
    {
        public bool Destroyed = false;
        public int Efficiency;

        public Potion(bool destroyed, int efficiency, string name, float weight, string description, float durability) : base(name, weight, description, durability)
        {
            Destroyed = destroyed;
            Efficiency = efficiency;
        }
        public override void Use()
        {
            Console.WriteLine("Efficiency: " + Efficiency);
            this.Destroyed = true;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine("Efficiency: " + Efficiency);
            Console.WriteLine("Destroyed: " + Destroyed);
        }
    }

    class Armor : Item
    {
        public bool FireP;
        public bool PoisonP;
        public float ArmorNum;
        public bool Destroyed = false;

        public Armor(bool fireP, bool poisonP, float armorNum, bool destroyed, string name, float weight, string description, float durability) : base(name, weight, description, durability)
        {
            FireP = fireP;
            PoisonP = poisonP;
            ArmorNum = armorNum;
            Destroyed = destroyed;
        }
        public void Protect(Weapon weapon)
        {
            ArmorNum = ArmorNum - weapon.Damage / 5;
            if (weapon.Type == "Fire")
            {

            }
            else if (weapon.Type == "Poison")
            {

            }
            else
            {

            }

        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine("Fire Protection: " + FireP);
            Console.WriteLine("Poison Protection: " + PoisonP);
            Console.WriteLine("Armor Number: " + ArmorNum);
            Console.WriteLine("Destroyed: " + Destroyed);
        }
    }
}
