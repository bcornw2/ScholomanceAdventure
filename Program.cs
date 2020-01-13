using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

namespace Scholomance
{
    class Program
    {
        public static Player _player;
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.ResetColor();
            Console.WriteLine("");
            Console.ResetColor();
            Console.WriteLine("Welcome.");
            Thread.Sleep(200);
            Console.WriteLine("What is your name?");
            string characterName = Console.ReadLine();
            characterName = (char.ToUpper(characterName[0]) + characterName.Substring(1));
            string characterClass = "default";
            Console.WriteLine("Select your Class:");
            Console.Write(" 1.) -  "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("Paladin \n"); Console.ResetColor();
            Console.Write(" 2.) -  "); Console.ForegroundColor = ConsoleColor.DarkGreen; Console.Write("Huntsman\n"); Console.ResetColor();
            Console.Write(" 3.) -  "); Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("Warrior\n"); Console.ResetColor();
            Console.Write(" 4.) -  "); Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("Sorcerer\n"); Console.ResetColor();
            Console.Write(" 5.) -  "); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("Rogue\n"); Console.ResetColor();
            Console.ResetColor();
            //Console.WriteLine("\n(If no class is selected, then you will be assigned one at random...)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.Write("Or, enter ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("i");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" to learn more about the classes.");
            Console.ResetColor();
            int health, wisdom, strength, spellPower, determination;
            health = -2; wisdom = -2; strength = -2; spellPower = -2; determination = -2;
            bool menu = true;

            Console.Write("> ");
            while (menu)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        characterClass = "Paladin"; health = 10; wisdom = 5; strength = 8; spellPower = 7; determination = 5;
                        menu = false;
                        break;
                    case "2":
                        characterClass = "Huntsman"; health = 10; wisdom = 5; strength = 6; spellPower = 4; determination = 10;
                        menu = false;
                        break;
                    case "3":
                        characterClass = "Warrior"; health = 12; wisdom = 1; strength = 12; spellPower = 0; determination = 10;
                        menu = false;
                        break;
                    case "4":
                        characterClass = "Sorcerer"; health = 8; wisdom = 10; strength = 2; spellPower = 10; determination = 5;
                        menu = false;
                        break;
                    case "5":
                        characterClass = "Rogue"; health = 8; wisdom = 5; strength = 8; spellPower = 2; determination = 12;
                        menu = false;
                        break;
                    case "i":
                        Console.WriteLine("\n - Paladins are holy agents, who are strong both physically and magically. They have high health, and are privy to maces and axes. They have damage bonus against undead type enemies. They are a very balanced class.");
                        Console.WriteLine(" - Huntsmen are survivalists, in tune with nature, and while they tend to favor physical damage, they do have magical defensive abilities. They are best with axes or staves. They have a strong damage bonus against beast type enemies. They are a very balanced class.");
                        Console.WriteLine(" - Warriors are strong, and are capable of dealing and receiving enormous amounts of damage. They have no magical abilities, but are able to get damage bonuses from most of the weapons in the game, where other classes get only one or two. They have the highest strength and health of any class.");
                        Console.WriteLine(" - Sorcerers are strongly magical, and most of their damage will come from spell casting. They have a high wisdom pool and depend very little on physical attacks. They can have Spell Power or Wisdom buffs from their choice weapon - staves. They have a damage bonus against ghost type enemies. Sorcerers can also use daggers and swords for a balanced magical and physical build. They have the highest wisdom and spell power of any class.");
                        Console.WriteLine(" - Rogues are silent and cunning adversaries, who tend to favor physcial damage over magical damage. They are unqiue in that they are able to use two weapons at the same time, where every other class uses one, and due to their Sneak Attack passive ability, they almost always get to attack first. Their magcal abilities are purely defensive. They have a damage buff with daggers. They have a damage bonus against human enemies. They also have the highest determination of any class.");
                        Console.WriteLine("\n ");
                        Console.WriteLine("Select your Class:");
                        Console.Write(" 1.) -  "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("Paladin \n"); Console.ResetColor();
                        Console.Write(" 2.) -  "); Console.ForegroundColor = ConsoleColor.DarkGreen; Console.Write("Woodsman\n"); Console.ResetColor();
                        Console.Write(" 3.) -  "); Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("Warrior\n"); Console.ResetColor();
                        Console.Write(" 4.) -  "); Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("Sorcerer\n"); Console.ResetColor();
                        Console.Write(" 5.) -  "); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("Rogue\n"); Console.ResetColor();
                        Console.ResetColor();
                        menu = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect choice - please enter a number 1 through 5 to select class.");
                        health = -1; wisdom = -1; strength = -1; spellPower = -1; determination = -1;
                        menu = true;
                        break;
                }
            }
            _player = Player.CreatePlayer(characterName, characterClass, health, wisdom, strength, spellPower, determination, wisdom, health, 0, 1);
            _player.CurrentLocation = World.LocationByID(World.LOCATION_ID_EMPTY_FIELD);
            EquipWeapon("gnarlegnarled stick");

            Console.WriteLine("You are {0}, a fledgling {1} in Gravothos, at the foot of the mountain where the fabled Scholomanarie school of dark magic lies.", _player.Name, _player.Class);
            Console.WriteLine("Stats:");
            Console.WriteLine("Total Health Points: {0}", _player.Health);
            Console.WriteLine("Total Wisdom Points: {0}", _player.Wisdom);
            Console.WriteLine("Strength: {0}", _player.Strength);
            Console.WriteLine("Spell Power: {0}", _player.SpellPower);
            Console.WriteLine("Determination: {0}", _player.Determination);
            Console.WriteLine("");
            Console.WriteLine("\nWould you like to read an explanation on your stats? (Y/n)");
            Console.Write("> ");
            string yn = Console.ReadLine();
            if (yn.ToLower() == "y" || yn.ToLower() == "yes")
            {
                Console.Write(" - ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Health");
                Console.ResetColor();
                Console.WriteLine(" is how much damage you can sustain from enemies, monsters, and the environment.");

                Console.Write(" - ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Wisdom ");
                Console.ResetColor();
                Console.WriteLine(" is the meter that determines how strong a spell can be cast in any given turn. More powerful spells require more wisdom to cast.");

                Console.Write(" - ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Strength ");
                Console.ResetColor();
                Console.WriteLine(" correlates to how much physical damage you can do to enemies and objects, and also correlates to how much health you regenerate per turn.");

                Console.Write(" - ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Spell Power ");
                Console.ResetColor();
                Console.WriteLine(" correlates to how much magical damage you can do to enemies, or the general effectiveness of your spells, and also correlates to how much wisdom you regenerate per turn.");

                Console.Write(" - ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Determination ");
                Console.ResetColor();
                Console.Write("correlates to your chance to land a critical strike against an enemy, the chance to resist a strike from an enemy, and also general luck in loot.");
            }

            Console.WriteLine("\nWould you like to read an explanation of your Class? (Y/n)");
            Console.WriteLine("> ");
            yn = Console.ReadLine();
            if (yn.ToLower() == "y" || yn.ToLower() == "yes")
            {
                ClassInfo();

            }
            Console.WriteLine("\nAre you ready to begin your journey into the Scholomanarie? (Y/n)");
            yn = Console.ReadLine();

            if (yn.ToLower() == "y" || yn.ToLower() == "yes")
            {

                //Game Start

                Console.WriteLine("\n ============================================== \n Deep inside the wooded hills of Gravothos, overlooking a lake of still black water, wolves howl in the night. A giant stone spire erupts out of the side of the mountain, its windows illuminated by candle light within, but even the very stars behind it seem to be sucked into dark forboding. There stands the Scholomanarie, a vessel of dark academia, where withes and wizards and scholars of black magic study under the Devil himself.");
                Console.WriteLine("");
                Console.WriteLine("Get started by equipping a weapon. Type 'inventory' to see what items you currently have, and then type 'equip gnarled stick' to equip your default weapon");
                Console.WriteLine("");
                Console.WriteLine("Then, see where you are by typing 'Look'");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Type 'Help' to see a list of commands");
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine("Do you want to change your name or your class?");
                // add functionality to change class or name.
            }
            while (true)
            {
                // Display a prompt, so the user knows to type something
                Console.Write(">");

                // Wait for the user to type something, and press the <Enter> key
                string userInput = Console.ReadLine();

                // If they typed a blank line, loop back and wait for input again
                if (userInput == null)
                {
                    continue;
                }

                // Convert to lower-case, to make comparisons easier
                string cleanedInput = userInput.ToLower();

                // Save the current game data, and break out of the "while(true)" loop
                if (cleanedInput == "exit")
                {
                    break;
                }

                // If the user typed something, try to determine what to do
                ParseInput(cleanedInput);
            }
        }

        private static void ClassInfo()
        {
            switch (_player.Class.ToLower())
            {
                case "paladin":
                    Console.WriteLine("The Paladin is an agent of God, sent to this demonic academy to purge the unholiness that is studied within. You have high health, and high stregnth, and high spell power. In combat, he has the ability to Heal Self to recoupe a fair amount of health, and also the option to cast Smite, to cause the enemy a large amount of damage. Undead-type enemies being the most vulnerable to your holy magic and blessed weapons. The paladin is trained in maces and axes, and will see a greater damage bonus if he chooses these weapons over others.");
                    break;
                case "huntsman":
                    Console.WriteLine("The Huntsman is a man of nature, living reclusively on the mountain, living off the fertile land and streams. he is a master of all beasts, but recent dark activity have corrupted the beast, deforming them and turning them violent and unworldly. He has set upon the dark academy to destroy the source of nature's corruption. The huntsman is a balanced class, with high health and high determination. He has offensive and defensive magical abilites. In combat, he can cast Stun, which causes the enemy to lose a turn. In combat with beasts, he can cast Cure Beast, which has a chance to cure the beast of its magical corruption, causing it to run away with no further harm to the hunter. Spell Power increases the effectiveness of Stun, and the likelihood that Cure Beast is sucessfull. The hunter has a strong damage bonus against beasts. He is adept at staves, axes, and daggers.");
                    break;
                case "warrior":
                    Console.WriteLine("The Warrior is a combatantant trained in all manner of weapons, and has come to the Scholomanarie academy as revenge for the corruption of Earth on his father's farm, at the foot of the mountain. The dry and rotting soil, corrupted by the dark magic of the school has rotted his families crops and drained the area of life. The warrior has high health and high strength, meaning he can take a lot of damage, and deal out a lot of damage as well. He lacks magical abilities, but makes up for this with his vast weapon specialization - meaning he gets a damage buff from axes, swords, maces, and daggers. He also has high determination, meaning he is more likely to land a critical strike.");
                    break;
                case "sorcerer":
                    Console.WriteLine("The Sorcerer is an agent of great magical ability, but was banished from his studies after the head priest of his village wrongfully accused him of studying dark magic at the Scholomanarie. To clear his name and return home, he has set upon the dark academy with the intent to destroy it and release its fearful hold on the population of Gravothos. The sorcerer has strong magical abilities, each of which consume an amount of regenerable wisdom when cast. The effectiveness of each spell he weilds is determined by his spell power stat. His wisdom stat and his spell power stat are the highest of any class, but he has low health and medium strength. He can cast Fireball, Frostbolt, Arcanae Beam, and the defensive Nether Shield, which reduces damage dealth to the sorcerer temporarily. The sorcerer is most effective against ghost-type enemies, and will earn a damage bonus when fighting against them. The sorcerer also has the ability to attack physically, and will have a damage bonus for staves, swords and daggers.");
                    break;
                case "rogue":
                    Console.WriteLine("The Rogue is a man of great cunning, an assassin that can move through the night undetected. It is known that there is great treasure in this cursed academy and was hired to take it by a mysterious patron. What the Rogue lacks in health and magic, he makes up in strength and determination, meaning that he can land huge critical strikes. He is also able to weild two weapons at the same time, as long as one is a dagger.  A passive stealth ability means his has a very high chance of always attacking first in combat against any enemy besides beasts. His only magical ability is to Distract, which subdues the enemy, if it is human or undead, and allows the rogue to escape unscathed. He has a strong damage bonus with daggers, and a fair damage bonus with swords.");
                    break;
                default:
                    break;
            }
        }

        private static void ParseInput(string input)
        {
            CheckLevel();
            int _currentLevel = _player.Level;
            Console.ResetColor();
            if (input.Contains("help") || input == "?")
            {
                DisplayHelpText();
            }
            else if (input == "stats")
            {
                DisplayPlayerStats();
            }
            else if (input == "look")
            {
                DisplayCurrentLocation();
            }
            else if (input.Contains("north"))
            {
                if (_player.CurrentLocation.LocationToNorth == null)
                {
                    Console.WriteLine("You cannot move North");
                }
                else
                {
                    _player.MoveNorth();
                    DisplayCurrentLocation();
                }
            }
            else if (input.Contains("east"))
            {
                if (_player.CurrentLocation.LocationToEast == null)
                {
                    Console.WriteLine("You cannot move East");
                }
                else
                {
                    _player.MoveEast();
                    DisplayCurrentLocation();
                }
            }
            else if (input.Contains("south"))
            {
                if (_player.CurrentLocation.LocationToSouth == null)
                {
                    Console.WriteLine("You cannot move South");
                }
                else
                {
                    _player.MoveSouth();
                    DisplayCurrentLocation();
                }
            }
            else if (input.Contains("west"))
            {
                if (_player.CurrentLocation.LocationToWest == null)
                {
                    Console.WriteLine("You cannot move West");
                }
                else
                {
                    _player.MoveWest();
                    DisplayCurrentLocation();
                }
            }
            else if ((input == "inventory") || (input == "inv") || (input == "i"))
            {
                string spacer = " ";
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  Weapons");
                Console.ResetColor();
                foreach (Weapon wep in _player.Weapons)
                {
                    if ((_player.CurrentWeapon == _player.CurrentOffhand) && (_player.CurrentOffhand != null))
                    {
                        spacer = "                          ";
                    }
                    Console.Write(" - {0} - {1}", wep.Name, wep.Type);
                    try
                    {
                        if (wep.Name == _player.CurrentWeapon.Name) { Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine(" (Currently Equipped)"); }
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine("");
                        EquipWeapon("gnarlegnarled stick");
                        if (wep.Name == _player.CurrentWeapon.Name) { Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine(" (Currently Equipped)"); }
                    }
                    try
                    {
                        if (wep.Name == _player.CurrentOffhand.Name) { Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("{0}(Current Offhand)", spacer); }
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.Write("");
                    }
                    
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("     dmg: {0}-{1}", wep.MinDamage, wep.MaxDamage); //minDamage+1 because technically a roll of min damage = a miss
                    Console.ResetColor();
                    if (wep.Stat != null)
                    {

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("     +{0} {1}", wep.StatInt, wep.Stat);
                        Console.ResetColor();

                        if (wep.Stat2 != null)
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("     +{0} {1}", wep.StatInt2, wep.Stat2);
                            Console.ResetColor();
                            Console.WriteLine("");
                        }
                    }
                    Console.WriteLine("");

                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("");
                Console.Write("  Food");
                Console.ResetColor();

                foreach (InventoryItem inventoryItem in _player.Inventory.Where(inventoryItem => inventoryItem.Details is Food))
                {

                    Console.WriteLine("");
                    Console.WriteLine(" - {0}: {1}", inventoryItem.Details.Name, inventoryItem.Quantity);


                }
                Console.WriteLine("");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  Items");
                Console.ResetColor();

                foreach (InventoryItem inventoryItem in _player.Inventory.Where(inventoryItem => !(inventoryItem.Details is Food) && !(inventoryItem.Details is Weapon)))
                {

                    Console.WriteLine("");
                    if (!inventoryItem.Details.Name.ToLower().Contains("key"))
                    {
                        Console.Write(" - {0}: {1}", inventoryItem.Details.Name, inventoryItem.Quantity);
                    }
                    
                    
                }
                Console.WriteLine("");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  Keys");
                Console.ResetColor();
                foreach (InventoryItem inventoryItem in _player.Inventory.Where(inventoryItem => (inventoryItem.Details.Name.ToLower().Contains("key"))))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" - {0}", inventoryItem.Details.Name);
                    Console.ResetColor();
                
                }
                Console.ResetColor();
                Console.WriteLine("----------------");
            }
            else if (input.Contains("attack"))
            {
                AttackMob();
            }
            else if (input.Contains("cast"))
            {
                CastSpell(input);
            }
            else if (input.StartsWith("equip "))
            {
                EquipWeapon(input);
            }
            else if (input.StartsWith("offhand "))
            {
                if (_player.Class.ToLower() != "rogue")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Only Rogues can equip off-hand weapons,");
                    Console.ResetColor();
                }
                else
                {
                    EquipOffhand(input);
                }
                
            }
            else if (input.StartsWith("eat "))
            {
                EatFood(input);
            }
            else if (input.StartsWith("info"))
            {
                ClassInfo();
            }
            else
            {
                Console.WriteLine("I do not understand");
                Console.WriteLine("Type 'Help' to see a list of available commands");
            }
            Console.WriteLine("");
        }
        private static void DisplayHelpText()
        {
            Console.WriteLine("Available commands");
            Console.WriteLine("====================================");
            Console.WriteLine("Stats - Display player information");
            Console.WriteLine("Look - Get the description of your location");
            Console.WriteLine("Inventory - Display your inventory");
            Console.WriteLine("Attack - Fight the monster");
            Console.WriteLine("Equip <weapon name> - Set your current weapon");
            Console.WriteLine("Offhand <weapon> - Set your current Offhand (rogues only)");
            Console.WriteLine("Eat <potion name> - Drink a potion");
            Console.WriteLine("Cast <spell> - Cast a spell. Check your class info to find out which spells you can cast");
            Console.WriteLine("Info - Class information and class-specific commands");
            Console.WriteLine("North - Move North");
            Console.WriteLine("South - Move South");
            Console.WriteLine("East - Move East");
            Console.WriteLine("West - Move West");
            Console.WriteLine("Exit - Save the game and exit");
            _player.AddItemToInventory(World.ItemByID(World.ITEM_ID_WOLF_PAW), 12);
            
        }
        private static void DisplayPlayerStats()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("Name:  {0}", _player.Name);
            Console.WriteLine("Level {0} {1}", _player.Level, _player.Class);
            Console.Write("Current Weapon: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (_player.CurrentHealth > _player.Health) { _player.CurrentHealth = _player.Health; }
            try
            {
                Console.WriteLine(_player.CurrentWeapon.Name + " - (" + _player.CurrentWeapon.Type + ")");
            }
            catch (NullReferenceException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Weapon Equipped.");
                Console.ResetColor();
            }
            if (_player.Class.ToLower() == "rogue")
            {
                Console.ResetColor();
                Console.Write("Offhand Weapon: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    Console.WriteLine(_player.CurrentOffhand.Name + " - (" + _player.CurrentOffhand.Type + ")");
                    Console.ResetColor();
                }
                catch (NullReferenceException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No Weapon Equipped.");
                    Console.ResetColor();
                }
            }
            if (_player.Class.ToLower() == "huntsman")
            {
                Console.ResetColor();
                Console.Write("Tamed Beast: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    Console.Write(_player.CurrentPet.Name);
                    Console.WriteLine(" - (dmg: {0}-{1})", _player.CurrentPet.MinDamage, _player.CurrentPet.MaxDamage);
                    Console.ResetColor();
                }
                catch (NullReferenceException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No beast tamed.");
                    Console.ResetColor();
                }
            }
            Console.ResetColor();
            Console.WriteLine("Current health: {0}/{1}", _player.CurrentHealth, _player.Health);
            Console.WriteLine("Current Wisdom: {0}/{1}", _player.CurrentWisdom, _player.Wisdom);
            Console.WriteLine("Experience Points: {0}/{1}", _player.Experience, _player.Level * 35);

            Console.WriteLine("Wisdom: {0}", _player.Wisdom);
            Console.WriteLine("Strength {0}", _player.Strength);
            Console.WriteLine("Spell Power {0}", _player.SpellPower);
            Console.WriteLine("Determination {0}", _player.Determination);
            Console.WriteLine("========================");
            //_player.AddItemToInventory(World.ItemByID(World.ITEM_ID_BONE_HANDLED_STILETTO), 2);
        }
        public static void CheckLevel(int _currentLevel = 0)
        {
            //if ()
            //if (_player.Level > _currentlevel)
        }
        private static void CastSpell(string input)
        {
            string inputSpellName = input.Substring(5).Trim();

            





            if (string.IsNullOrEmpty(inputSpellName))
            {
                Console.WriteLine("You must enter the name of a spell to cast it.");
            }
            else
            {
                switch (inputSpellName.ToLower())
                {
                    case " ":
                        Console.WriteLine("Hunters can cast:");
                        Console.WriteLine(" - Cleanse: a small self heal with low wisdom cost.");
                        Console.WriteLine(" - Tame: cast tame on an beast-type mob to have it be your pet and serve you in battle.");
                        Console.WriteLine("    - To tame a Rat, you must have 3 Rat Tails in your inventory.");
                        Console.WriteLine("    - To tame a Serpent, you must have 8 Snake Fangs in your inventory.");
                        Console.WriteLine("    - To tame a Wolf, you must have 10 Wolf Pars in your inventory.");
                        Console.WriteLine(" - Cure Animal: cast Cure Animal on any beast for a chance to have it run away during battle, dropping its loot.");
                        Console.WriteLine("Paladins can cast:");
                        Console.WriteLine(" - Smite: a strong attack with medium wisdom cost, and a small chance to miss.");
                        Console.WriteLine(" - Heal: a strong self heal with medium wisdom cost.");
                        Console.WriteLine("Sorcerers can cast:");
                        Console.WriteLine(" - Fireball: a strong attack that incurs a high wisdom cost.");
                        Console.WriteLine(" - Frostbolt: a weak attack with very low wisdom cost, and has no chance to miss");
                        Console.WriteLine(" - Nethershield: a defensive spell that reduces damage taken by the sorcerer by 75% for 4 turns, but also prevents him from using physical attacks and reduces magical attack damage by 25%.");
                        Console.WriteLine("Rogues can cast:");
                        Console.WriteLine(" - Distract: a spell that has a small chance of distracting a human enemy, causing him to leave, but does not drop loot.");
                        Console.WriteLine(" - ");
                        break;
                    case "heal":
                        if (_player.Class.ToLower() != "paladin")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can not cast Heal.");
                            Console.ResetColor();
                            break;
                        }
                        else { _player.CastHeal(); }
                        break;
                    case "smite":
                        if (_player.Class.ToLower() != "paladin")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can not cast Smite.");
                            Console.ResetColor();
                            break;
                        }
                        else { _player.CastSmite(); }
                        break;
                    case "cleanse":
                        if (_player.Class.ToLower() != "huntsman")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can not cast Cleanse.");
                            Console.ResetColor();
                            break;
                        }
                        else { _player.CastCleanse(); }
                        break;
                    case "cure animal":
                        if (_player.Class.ToLower() == "huntsman")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("You attempt to Cure Beast...");
                            _player.CureBeast();
                            Console.ResetColor();
                            break;
                            
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can not cast ;Cure Beast.;");
                            Console.ResetColor();
                            break;
                        }
                        break;
                    case "tame":
                        if(_player.Class.ToLower() == "huntsman")
                        {
                            Console.WriteLine("You attempt to tame the beast");
                            _player.TameAnimal();
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can not cast ;Tame Beast.;");
                            Console.ResetColor();
                            break;
                        }
                    case "fireball":
                        if (_player.Class.ToLower() != "sorcerer")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can not cast Fireball.");
                            Console.ResetColor();
                            break;
                        }
                        else
                        {
                            _player.CastFireball();
                        }
                        break;
                    case "frostbolt":
                        if (_player.Class.ToLower() != "sorcerer")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can not cast Frostbolt.");
                            Console.ResetColor();
                            break;
                        }
                        else
                        {
                            _player.CastFrostbolt();
                        }
                        break;
                    case "nethershield":
                        if (_player.Class.ToLower() != "sorcerer")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can not cast Nethersheild.");
                            Console.ResetColor();
                            break;
                        }
                        else
                        {
                            _player.CastNethershield();
                        }
                        break;
                    default:
                        Console.WriteLine("You did not enter a valid command. Try doing 'cast <spell>', and type 'class' to learn which spells your class can cast.");
                        break;
                }


            }
            if (!_player.CurrentLocation.HasMob)
            {
                Console.WriteLine("There is no monster here to cast on.");
            }
            else
            {
                if (_player.Class.ToLower() == "paladin")
                {
                    Console.WriteLine("You can cast either a heal or a smite. The effectiveness of either is determined by your SpellPower and both consume Wisdom.");
                }
            }
        }
        private static void AttackMob()
        {
            if (!_player.CurrentLocation.HasMob) //|| (_player.CurrentLocation.)isDead)
            {
                Console.WriteLine("There is nothing here to attack");
            }
            else
            {
                if (_player.CurrentWeapon == null)
                {
                    // Select the first weapon in the player's inventory 
                    // (or 'null', if they do not have any weapons)
                    _player.CurrentWeapon = _player.Weapons.FirstOrDefault();
                }

                if (_player.CurrentWeapon == null)
                {
                    Console.WriteLine("You do not have any weapons");
                }
                else
                {
                    try
                    {
                        
                        if (_player.Class.ToLower() == "rogue")
                        {

                            //_player.UseWeapon(_player.CurrentWeapon);
                            try
                            {
                                _player.UseWeapon(_player.CurrentOffhand);
                            }
                            catch (NullReferenceException ex) { }
                            
                        }
                        if(_player.Class.ToLower() == "huntsman")
                        {
                            _player.UseWeapon(_player.CurrentWeapon);
                            try
                            {
                                _player.UseWeapon(_player.CurrentPet);
                            }
                            catch (NullReferenceException ex) { }
                            
                        }
                        else
                        {
                            _player.UseWeapon(_player.CurrentWeapon);
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("This monster is already dead.");
                        Console.ResetColor();
                    }
                    //_player.UseWeapon(_player.CurrentWeapon);northhhh
                }
            }
        }

        private static void EquipWeapon(string input)
        {
            //somehow adapt this so rogues get two. Best practices would be to make it the same method instead of EquipWeapon + nearly-identical equipOffhand
            

            //    int currHealth = _player.Health;
            //    int currWisdom = _player.Wisdom;
            //    int currStrength = _player.Strength;
            //    int currSpellPower = _player.SpellPower;
            //    int currdetermination = _player.Determination;

            string inputWeaponName = input.Substring(6).Trim();

            if (string.IsNullOrEmpty(inputWeaponName))
            {
                Console.WriteLine("You must enter the name of the weapon to equip");
            }
            else
            {
                Weapon weaponToEquip =
                    _player.Weapons.SingleOrDefault(
                        x => x.Name.ToLower() == inputWeaponName || x.NamePlural.ToLower() == inputWeaponName);

                if (weaponToEquip == null)
                {
                    Console.WriteLine("You do not have the weapon: {0}", inputWeaponName);
                }
                if (weaponToEquip.Type.ToLower() == "pet")
                {
                    // cannot equip pet
                }
                else
                {
                    RemoveWeapon();
                    _player.CurrentWeapon = weaponToEquip;

                    Console.WriteLine("You equip your {0}", _player.CurrentWeapon.Name);
                    if (weaponToEquip.Stat != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" - Your {0} has increased by {1}", weaponToEquip.Stat, weaponToEquip.StatInt);
                        Console.ResetColor();
                        switch (weaponToEquip.Stat.ToLower())
                        {
                            case "health":
                                _player.Health += weaponToEquip.StatInt;
                                _player.CurrentHealth++;
                                //_player.Health -= weaponToRemove.StatInt;
                                break;
                            case "wisdom":
                                _player.Wisdom += weaponToEquip.StatInt;
                                _player.CurrentWisdom++;
                                break;
                            case "strength":
                                _player.Strength += weaponToEquip.StatInt;
                                break;
                            case "spellpower":
                                _player.SpellPower += weaponToEquip.StatInt;
                                break;
                            case "determination":
                                _player.Determination += weaponToEquip.StatInt;
                                break;
                            default:
                                Console.WriteLine("ERROR ASSIGNING BUFFS!!!");
                                break;
                        }


                    }
                    if (weaponToEquip.Stat2 != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" - Your {0} has increased by {1}", weaponToEquip.Stat2, weaponToEquip.StatInt2);
                        Console.ResetColor();
                        switch (weaponToEquip.Stat2.ToLower())
                        {
                            case "health":
                                _player.Health += weaponToEquip.StatInt2;
                                break;
                            case "wisdom":
                                _player.Wisdom += weaponToEquip.StatInt2;
                                break;
                            case "strength":
                                _player.Strength += weaponToEquip.StatInt2;
                                break;
                            case "spellpower":
                                _player.SpellPower += weaponToEquip.StatInt2;
                                break;
                            case "determination":
                                _player.Determination += weaponToEquip.StatInt2;
                                break;
                            default:
                                Console.WriteLine("ERROR ASSIGNING BUFFS!!! (2)");
                                break;
                        }



                    }
                }
            }
            //}
        }

        private static void RemoveWeapon()
        {
            Weapon weaponToRemove = _player.CurrentWeapon;

            if (_player.CurrentWeapon != null)
            {
                if (_player.CurrentWeapon.Stat != null)
                {
                    switch (weaponToRemove.Stat.ToLower())
                    {
                        case "health":
                            _player.Health -= weaponToRemove.StatInt;
                            if (_player.CurrentHealth >= _player.Health) { _player.CurrentHealth = _player.Health; }
                            break;
                        case "wisdom":
                            _player.Wisdom -= weaponToRemove.StatInt;
                            if (_player.CurrentWisdom >= _player.Wisdom) { _player.CurrentWisdom = _player.Wisdom; }
                            break;
                        case "strength":
                            _player.Strength -= weaponToRemove.StatInt;
                            break;
                        case "spellpower":
                            _player.SpellPower -= weaponToRemove.StatInt;
                            break;
                        case "determination":
                            _player.Determination -= weaponToRemove.StatInt;
                            break;
                        default:
                            Console.WriteLine("ERROR ASSIGNING BUFFS!!!");
                            break;
                    }
                }
                if (weaponToRemove.Stat2 != null)
                {
                    switch (weaponToRemove.Stat2.ToLower())
                    {
                        case "health":
                            _player.Health -= weaponToRemove.StatInt2;
                            if (_player.CurrentHealth >= _player.Health) { _player.CurrentHealth = _player.Health; }
                            //_player.Health -= weaponToRemove.StatInt;
                            break;
                        case "wisdom":
                            _player.Wisdom -= weaponToRemove.StatInt2;
                            if (_player.CurrentWisdom >= _player.Wisdom) { _player.CurrentWisdom = _player.Wisdom; }
                            break;
                        case "strength":
                            _player.Strength -= weaponToRemove.StatInt2;
                            break;
                        case "spellpower":
                            _player.SpellPower -= weaponToRemove.StatInt2;
                            break;
                        case "determination":
                            _player.Determination -= weaponToRemove.StatInt2;
                            break;
                        default:
                            Console.WriteLine("ERROR ASSIGNING BUFFS!!! (2)");
                            break;
                    }
                }
            }
        }


        private static void EquipOffhand(string input)
        {

            string inputWeaponName = input.Substring(8).Trim();

            if (string.IsNullOrEmpty(inputWeaponName))
            {
                Console.WriteLine("You must enter the name of the weapon to equip");
            }
            else
            {
                Weapon weaponToEquip =
                    _player.Weapons.SingleOrDefault(
                        x => x.Name.ToLower() == inputWeaponName || x.NamePlural.ToLower() == inputWeaponName);
                Console.ForegroundColor = ConsoleColor.Red;
                if (weaponToEquip == null)
                {
                    try
                    {
                        Console.WriteLine("You do not have the weapon: {0}", inputWeaponName);
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine("You do not have the weapon: {0}", inputWeaponName);
                    }

                    Console.ResetColor();
                }
                else
                {
                    if (weaponToEquip.Type == "dagger")
                    {


                        Console.ResetColor();
                        RemoveOffhand();
                        _player.CurrentOffhand = weaponToEquip;
                        if (_player.CurrentWeapon == weaponToEquip)
                        {
                            RemoveWeapon();
                        }

                        Console.WriteLine("You equip your {0}", _player.CurrentOffhand.Name);
                        if (weaponToEquip.Stat != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" - Your {0} has increased by {1}", weaponToEquip.Stat, weaponToEquip.StatInt);
                            Console.ResetColor();
                            switch (weaponToEquip.Stat.ToLower())
                            {
                                case "health":
                                    _player.Health += weaponToEquip.StatInt;
                                    _player.CurrentHealth++;
                                    //_player.Health -= weaponToRemove.StatInt;
                                    break;
                                case "wisdom":
                                    _player.Wisdom += weaponToEquip.StatInt;
                                    _player.CurrentWisdom++;
                                    break;
                                case "strength":
                                    _player.Strength += weaponToEquip.StatInt;
                                    break;
                                case "spellpower":
                                    _player.SpellPower += weaponToEquip.StatInt;
                                    break;
                                case "determination":
                                    _player.Determination += weaponToEquip.StatInt;
                                    break;
                                default:
                                    Console.WriteLine("ERROR ASSIGNING BUFFS!!!");
                                    break;
                            }



                        }
                        if (weaponToEquip.Stat2 != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" - Your {0} has increased by {1}", weaponToEquip.Stat2, weaponToEquip.StatInt2);
                            Console.ResetColor();
                            switch (weaponToEquip.Stat2.ToLower())
                            {
                                case "health":
                                    _player.Health += weaponToEquip.StatInt2;
                                    break;
                                case "wisdom":
                                    _player.Wisdom += weaponToEquip.StatInt2;
                                    break;
                                case "strength":
                                    _player.Strength += weaponToEquip.StatInt2;
                                    break;
                                case "spellpower":
                                    _player.SpellPower += weaponToEquip.StatInt2;
                                    break;
                                case "determination":
                                    _player.Determination += weaponToEquip.StatInt2;
                                    break;
                                default:
                                    Console.WriteLine("ERROR ASSIGNING BUFFS!!! (2)");
                                    break;
                            }



                        }
                    }
                    else
                    {
                        Console.WriteLine("You can only equip daggers in your off-hand slot.");
                        Console.ResetColor();
                    }
                }
            }
            //}
        }

        private static void RemoveOffhand()
        {
            Weapon weaponToRemove = _player.CurrentOffhand;

            if (_player.CurrentOffhand != null)
            {
                if (_player.CurrentOffhand.Stat != null)
                {
                    switch (weaponToRemove.Stat.ToLower())
                    {
                        case "health":
                            _player.Health -= weaponToRemove.StatInt;
                            if (_player.CurrentHealth >= _player.Health) { _player.CurrentHealth = _player.Health; }
                            break;
                        case "wisdom":
                            _player.Wisdom -= weaponToRemove.StatInt;
                            if (_player.CurrentWisdom >= _player.Wisdom) { _player.CurrentWisdom = _player.Wisdom; }
                            break;
                        case "strength":
                            _player.Strength -= weaponToRemove.StatInt;
                            break;
                        case "spellpower":
                            _player.SpellPower -= weaponToRemove.StatInt;
                            break;
                        case "determination":
                            _player.Determination -= weaponToRemove.StatInt;
                            break;
                        default:
                            Console.WriteLine("ERROR ASSIGNING BUFFS!!!");
                            break;
                    }
                }
                if (weaponToRemove.Stat2 != null)
                {
                    switch (weaponToRemove.Stat2.ToLower())
                    {
                        case "health":
                            _player.Health -= weaponToRemove.StatInt2;
                            if (_player.CurrentHealth >= _player.Health) { _player.CurrentHealth = _player.Health; }
                            //_player.Health -= weaponToRemove.StatInt;
                            break;
                        case "wisdom":
                            _player.Wisdom -= weaponToRemove.StatInt2;
                            if (_player.CurrentWisdom >= _player.Wisdom) { _player.CurrentWisdom = _player.Wisdom; }
                            break;
                        case "strength":
                            _player.Strength -= weaponToRemove.StatInt2;
                            break;
                        case "spellpower":
                            _player.SpellPower -= weaponToRemove.StatInt2;
                            break;
                        case "determination":
                            _player.Determination -= weaponToRemove.StatInt2;
                            break;
                        default:
                            Console.WriteLine("ERROR ASSIGNING BUFFS!!! (2)");
                            break;
                    }
                }
            }
        }

        private static void EatFood(string input)
        {
            string inputFoodName = input.Substring(4).Trim();

            if (string.IsNullOrEmpty(inputFoodName))
            {
                Console.WriteLine("You must enter the name of the food to eat it.");
            }
            else
            {
                Food foodToEat =
                    _player.Foods.SingleOrDefault(
                        x => x.Name.ToLower() == inputFoodName || x.NamePlural.ToLower() == inputFoodName);

                if (foodToEat == null)
                {
                    Console.WriteLine("You can not eat {0}", inputFoodName);
                }
                else
                {
                    _player.EatFood(foodToEat);
                }
            }
        }
        private static void DisplayCurrentLocation()
        {
            Console.WriteLine("You are at: {0}", _player.CurrentLocation.Name);

            if (_player.CurrentLocation.Description != "")
            {
                Console.WriteLine(_player.CurrentLocation.Description);
            }
            try
            {
                if ((_player.CurrentLocation.HasMob) && (_player.CurrentLocation.MobLivingHere.IsDead))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The " + _player.CurrentLocation.MobLivingHere.Name + " is dead.");
                    Console.ResetColor();
                }
            }
            catch (NullReferenceException ex) { Console.Write(""); }
            Console.WriteLine("");
            try
            {
                Console.Write("  West: {0}  |  " , _player.CurrentLocation.LocationToWest.Name);
            }
            catch (NullReferenceException)
            {
                Console.Write("  West: Can't go West  |  ");
            }

            //north
            try
            {
                Console.Write("North: {0}  |  ", _player.CurrentLocation.LocationToNorth.Name);
            }
            catch (NullReferenceException)
            {
                Console.Write("North: Can't go North  |  ");
            }
            //south
            try
            {
                Console.Write("South: {0}  |  ", _player.CurrentLocation.LocationToSouth.Name);
            }
            catch (NullReferenceException)
            {
                Console.Write("South: Can't go South  |  ");
            }
            //east
            try
            {
                Console.Write("East: {0}   ", _player.CurrentLocation.LocationToEast.Name);
            }
            catch (NullReferenceException)
            {
                Console.Write("Wast: Can't go East   ");
            }
            //Console.WriteLine("West: {0}               North: {1}              South: {2}          East: {3}", _player.CurrentLocation.LocationToWest.Name, _player.CurrentLocation.LocationToNorth.Name, _player.CurrentLocation.LocationToSouth.Name, _player.CurrentLocation.LocationToEast.Name);
            Console.WriteLine("");
                //if (_player.CurrentLocation.HasMob)
            //{
            //    Console.WriteLine("The " + _player.CurrentLocation.MobLivingHere.Name + "is ready to strike!");
            //}
        }
        public static Player CreateNewPlayer(string name, string characterClass, int health, int wisdom, int strength, int spellPower, int determination, int currentWisdom, int Health, int exp, int level)
        {
            Player _player = Player.CreatePlayer(name, characterClass, health, wisdom, strength, spellPower, determination, currentWisdom, Health, exp, level);
            return _player;
        }









        public static int GetRandomNumber(int minimum, int maximum)
        {
            Random random = new Random();
            return Convert.ToInt32(random.NextDouble() * (maximum - minimum) + minimum);
        }

        public class Player : LivingCreature
        {

            private int _experiencePoints;
            private int _currentWisdom;
            private int _currentLevel = 1;

            public string Name { get; set; }
            public string Class { get; set; }
            public int Health { get; set; }
            public int Wisdom { get; set; }

            public int CurrentWisdom { get { return _currentWisdom; } set { _currentWisdom = value; } }
            public int Strength { get; set; }
            public int SpellPower { get; set; }
            public int Determination { get; set; }
            public int Experience { get; set; }
            public int Level { get { return ((Experience / (_currentLevel *35)) + 1); } }
            public Location CurrentLocation { get; set; }
            public Weapon CurrentWeapon { get; set; }
            public Weapon CurrentOffhand { get; set; }
            public Weapon CurrentPet { get; set; }

            public BindingList<InventoryItem> Inventory { get; set; }

            public List<Weapon> Weapons
            {
                get { return Inventory.Where(x => x.Details is Weapon).Select(x => x.Details as Weapon).ToList(); }
            }
            public List<Food> Foods
            {
                get { return Inventory.Where(x => x.Details is Food).Select(x => x.Details as Food).ToList(); }
            }
            public List<int> LocationsVisited { get; set; }
            private Mob CurrentMob { get; set; }
            public Player(string name, string characterClass, int health, int wisdom, int strength, int spellPower, int determination, int currentHealth, int currentWisdom, int experience, int level) : base(currentHealth, health)
            {
                Name = name;
                Class = characterClass;
                Health = health;
                Wisdom = wisdom;
                Strength = strength;
                SpellPower = spellPower;
                Determination = determination;
                CurrentHealth = currentHealth;
                CurrentWisdom = currentWisdom;
                Experience = experience;

                Inventory = new BindingList<InventoryItem>();
                LocationsVisited = new List<int>();
            }
            public static Player CreatePlayer(string name, string characterClass, int health, int wisdom, int strength, int spellPower, int determination, int currentHealth, int maxHealth, int exp, int level)
            {
                Player player = new Player(name, characterClass, health, wisdom, strength, spellPower, determination, health, wisdom, 0, 1);
                player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_GNARLED_STICK), 1));
                player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_BREAD), 4));
                player.CurrentLocation = World.LocationByID(World.LOCATION_ID_EMPTY_FIELD);
                return player;
            }
            public void MoveTo(Location location)
            {
                int i = GetRandomNumber(1, 3);
                if (PlayerDoesNotHaveTheRequiredItemToEnter(location))
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("You must have a ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(location.ItemRequiredToEnter.Name);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" to enter this location.");
                    Console.WriteLine("");
                    Console.ResetColor();
                    return;
                }
                if (location.ItemRequiredToEnter != null && !PlayerDoesNotHaveTheRequiredItemToEnter(location))
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Unlocked ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(location.Name);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" with ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(location.ItemRequiredToEnter.Name);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("!");
                    Console.ResetColor();
                }

                // The player can enter this location
                CurrentLocation = location;

                if (!LocationsVisited.Contains(CurrentLocation.ID))
                {
                    LocationsVisited.Add(CurrentLocation.ID);
                }
                SetTheCurrentMobForTheCurrentLocation(location);
                HealPlayer(1, 3);

                //SetTheCurrentMobForTheCurrentLocation(location);
            }
            public void MoveNorth() { if (CurrentLocation.LocationToNorth != null) { MoveTo(CurrentLocation.LocationToNorth); } }

            public void MoveEast() { if (CurrentLocation.LocationToEast != null) { MoveTo(CurrentLocation.LocationToEast); } }

            public void MoveSouth() { if (CurrentLocation.LocationToSouth != null) { MoveTo(CurrentLocation.LocationToSouth); } }

            public void MoveWest() { if (CurrentLocation.LocationToWest != null) { MoveTo(CurrentLocation.LocationToWest); } }

            public void CastSmite()
            {
                int wisdomCost = (5 * (1 - (Determination / 10)));
                if (CurrentWisdom < wisdomCost)
                {
                    Console.WriteLine("You do not have enough wisdom to cast this spell.  Required: {0}  Current Wisdom: ({1}/{2})", wisdomCost, CurrentWisdom, Wisdom);
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                else
                {


                    CurrentWisdom -= wisdomCost;
                    int criticalMultiplier = (Determination / 50) + 1;
                    int maxDamage = (6 * ((SpellPower / 10) + 1));
                    int damage = GetRandomNumber(5, maxDamage);
                    if (CurrentMob.Type == "beast") { damage = (damage / 2); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Smite is weak against beasts!"); }
                    int rand = GetRandomNumber(1, 4);
                    if ((damage == 5) && (rand == 1))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Your smite missed the " + CurrentMob.Name + ". You used " + wisdomCost + " wisdom.");
                        Console.ResetColor();
                    }
                    else
                    {
                        if ((damage == maxDamage))
                        {
                            double dmg = (damage * criticalMultiplier);
                            damage = Convert.ToInt32(dmg);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            CurrentMob.CurrentHealth -= damage;
                            Console.WriteLine("Critical Strike!");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("You smite the " + CurrentMob.Name + " for " + damage + "! You used " + wisdomCost + " wisdom.");
                            Console.ResetColor();
                            Console.WriteLine("");
                        }
                        else
                        {
                            CurrentMob.CurrentHealth -= damage;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You smite the " + CurrentMob.Name + " for " + damage + ". You used " + wisdomCost + " wisdom.");
                            Console.ResetColor();
                            Console.WriteLine("");
                        }



                    }
                    if (CurrentMob.IsDead)
                    {
                        LootTheCurrentMob();
                        CurrentLocation.HasMob = false;
                        //DespawnMob(_player.CurrentLocation);

                        // "Move" to the current location, to refresh the current monster
                        DisplayCurrentLocation();
                    }
                    else
                    {


                        LetTheMobAttack();
                        Console.ResetColor();
                    }
                }
            }
            public void CastNethershield()
            {
                int wisdomCost = (4);
                if (CurrentWisdom < wisdomCost)
                {
                    Console.WriteLine("You do not have enough wisdom to cast this spell.  Required: {0}  Current Wisdom: ({1}/{2})", wisdomCost, CurrentWisdom, Wisdom);
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                else
                {
                    //something like a fixed cost reduction of damage. If nethershield is active, all mob attacks = mobattacks/2, only lasts for four turns. Might have to have a counter in LetTheMovAttacl
                    //thats probably a poor implementation
                    CurrentWisdom -= wisdomCost;
                    int startHealth = CurrentHealth;
                    //_player.




                }
            }
            public void CastFireball()
            {
                int wisdomCost = (7 * (1 - (Determination / 35)));
                if (CurrentWisdom < wisdomCost)
                {
                    Console.WriteLine("You do not have enough wisdom to cast this spell.  Required: {0}  Current Wisdom: ({1}/{2})", wisdomCost, CurrentWisdom, Wisdom);
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                else
                {
                    CurrentWisdom -= wisdomCost;
                    int criticalMultiplier = (Determination / 50) + 1;
                    int maxDamage = (10 * ((SpellPower / 50) + 1));
                    int damage = GetRandomNumber(4, maxDamage);
                    if (CurrentMob.Type == "ghost")
                    {
                        damage += (damage / 2);
                    }
                    if (damage == 6)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Your Fireball missed the " + CurrentMob.Name + ". You used " + wisdomCost + " wisdom.");
                        Console.ResetColor();
                    }
                    else
                    {
                        if ((damage == maxDamage))
                        {
                            double dmg = (damage * criticalMultiplier);
                            damage = Convert.ToInt32(dmg);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            CurrentMob.CurrentHealth -= damage;
                            Console.WriteLine("Critical Strike!");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("You blast the " + CurrentMob.Name + " for " + damage + "! you used " + wisdomCost + " wisdom.");
                            Console.ResetColor();
                            Console.WriteLine("");
                        }
                        else
                        {
                            CurrentMob.CurrentHealth -= damage;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("You blast the " + CurrentMob.Name + " for " + damage + ". You used " + wisdomCost + " wisdom.");
                            Console.ResetColor();
                        }



                    }
                    if (CurrentMob.IsDead)
                    {
                        LootTheCurrentMob();
                        CurrentLocation.HasMob = false;
                        //DespawnMob(_player.CurrentLocation);

                        // "Move" to the current location, to refresh the current monster
                        DisplayCurrentLocation();
                    }
                    else
                    {

                        LetTheMobAttack();
                    }

                }
            }
            public void CastFrostbolt()
            {
                int wisdomCost = (2 * (1 - (Determination / 35)))-1;
                if (CurrentWisdom < wisdomCost)
                {
                    Console.WriteLine("You do not have enough wisdom to cast this spell.  Required: {0}  Current Wisdom: ({1}/{2})", wisdomCost, CurrentWisdom, Wisdom);
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                else
                {
                    CurrentWisdom -= wisdomCost;
                    int criticalMultiplier = (Determination / 50) + 1;
                    int maxDamage = (3 * ((SpellPower / 50) + 1));
                    int damage = GetRandomNumber(2, maxDamage);
                    if (CurrentMob.Type == "ghost")
                    {
                        damage += (damage / 3);
                    }
                    else
                    {
                        if ((damage == maxDamage))
                        {
                            double dmg = (damage * criticalMultiplier);
                            damage = Convert.ToInt32(dmg);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            CurrentMob.CurrentHealth -= damage;
                            Console.WriteLine("Critical Strike!");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("You blast the " + CurrentMob.Name + " for " + damage + "! you used " + wisdomCost + " wisdom.");
                            Console.ResetColor();
                            Console.WriteLine("");
                        }
                        else
                        {
                            CurrentMob.CurrentHealth -= damage;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("You blast the " + CurrentMob.Name + " for " + damage + ". You used " + wisdomCost + " wisdom.");
                            Console.ResetColor();
                        }



                    }
                    if (CurrentMob.IsDead)
                    {
                        LootTheCurrentMob();
                        CurrentLocation.HasMob = false;
                        //DespawnMob(_player.CurrentLocation);

                        // "Move" to the current location, to refresh the current monster
                        DisplayCurrentLocation();
                    }
                    else
                    {

                        LetTheMobAttack();
                    }

                }
            }
            public void CastHeal()
            {
                int wisdomCost = (3 * (1 - (Determination / 35)));
                if (CurrentWisdom < wisdomCost)
                {
                    Console.WriteLine("You do not have enough wisdom to cast this spell.  Required: {0}  Current Wisdom: ({1}/{2})", wisdomCost, CurrentWisdom, Wisdom);
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                else
                {
                    double healMultiplier = ((SpellPower / 10.0) + 1.0);
                    int totalHeal = Convert.ToInt32((5.0 * healMultiplier));
                    Console.WriteLine("healMulitplier:  " + healMultiplier);
                    Console.WriteLine("total heal: " + totalHeal);
                    if (CurrentHealth > Health) { CurrentHealth = Health; }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    CurrentHealth += totalHeal;
                    if (CurrentHealth < Health) { CurrentHealth = Health; }
                    Console.WriteLine("You heal yourself for {0} health points. Health: {1}/{2}", totalHeal, CurrentHealth, Health);
                    CurrentHealth += totalHeal;
                    Console.ResetColor();
                    CurrentWisdom -= wisdomCost;
                    if (CurrentHealth > Health) { CurrentHealth = Health; }

                }
            }
            public void CastCleanse()
            {
                int wisdomCost = (3 * (1 - (Determination / 35)));
                if (CurrentWisdom < wisdomCost)
                {
                    Console.WriteLine("You do not have enough wisdom to cast this spell.  Required: {0}  Current Wisdom: ({1}/{2})", wisdomCost, CurrentWisdom, Wisdom);
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                else
                {
                    double healMultiplier = ((_player.SpellPower / 35.0) + 1.0);
                    int totalHeal = Convert.ToInt32((5.0 * healMultiplier));
                    Console.WriteLine("healMulitplier:  " + healMultiplier);
                    Console.WriteLine("total heal: " + totalHeal);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("You cleanse yourself for {0} health points", (totalHeal / 2));
                    _player.CurrentHealth += (totalHeal / 2);
                    _player.CurrentWisdom -= wisdomCost;
                    Console.ResetColor();
                    if(_player.CurrentMob != null)
                    {
                        LetTheMobAttack();
                    }
                }

            }
            public void TameAnimal()
            {
                int wisdomCost = (5 - (Determination / 10));
                if ((CurrentMob != null) && (CurrentMob.Type == "beast"))
                {
                    if (CurrentWisdom < wisdomCost)
                    {
                        Console.WriteLine("You do not have enough wisdom to cast this spell.  Required: {0}  Current Wisdom: ({1}/{2})", wisdomCost, CurrentWisdom, Wisdom);
                        Console.WriteLine("");
                        Console.WriteLine("");
                    }
                    else
                    {
                        CurrentWisdom -= wisdomCost;
                        if (CurrentWisdom < 0) { CurrentWisdom = 0; }
                        try
                        {


                            if ((CurrentMob.Name.ToLower() == "wolf") && (Inventory.Any(ii => ii.Details.ID == World.ITEM_ID_WOLF_PAW && ii.Quantity >= 10)))
                            {
                                Console.WriteLine("You attempt to tame beast...");
                                int f = (1 + (Determination * 2));
                                int i = GetRandomNumber(f, 100);
                                Console.WriteLine("Chance: f {0} - roll i: {1}", f, i);
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Thread.Sleep(200);
                                Console.WriteLine(" ... ");
                                Thread.Sleep(200);
                                Console.WriteLine(" ... ");
                                Thread.Sleep(1200);
                                Console.WriteLine(" ... ");
                                Thread.Sleep(800);
                                if (i > 50)
                                {
                                    AddItemToInventory(World.ItemByID(World.PET_ID_WOLF));
                                    RemoveItemFromInventory(World.ItemByID(World.ITEM_ID_WOLF_PAW), 10);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("You sucessfully tamed the Wolf!");
                                    Console.ResetColor();
                                    // See if the player has the required item in their inventory
                                    Console.WriteLine("You tame {0}", _player.CurrentMob.Name);
                                    //Weapon newPet = World.ItemByID(World.PET_ID_WOLF);
                                    Weapon newPet = _player.Weapons.SingleOrDefault(x => x.Name.ToLower() == "wolf" || x.NamePlural.ToLower() == "wolves");
                                    EquipPet(newPet);
                                    LootTheCurrentMob();

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Tame failed. You do not tame the {0}. You need 10 Wolf Paws in your inventory to tame a wolf.", _player.CurrentMob.Name);
                                    Console.ResetColor();
                                    LetTheMobAttack();
                                }
                            }
                            if ((CurrentMob.Name.ToLower() == "rat") && (Inventory.Any(ii => ii.Details.ID == World.ITEM_ID_RAT_TAIL && ii.Quantity >= 5)))
                            {
                                Console.WriteLine("You attempt to tame beast...");
                                int f = (1 + (Determination * 2));
                                int i = GetRandomNumber(f, 100);
                                Console.WriteLine("Chance: f {0} - roll i: {1}", f, i);
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Thread.Sleep(200);
                                Console.WriteLine(" ... ");
                                Thread.Sleep(200);
                                Console.WriteLine(" ... ");
                                Thread.Sleep(1200);
                                Console.WriteLine(" ... ");
                                Thread.Sleep(800);
                                if (i > 50)
                                {
                                    AddItemToInventory(World.ItemByID(World.PET_ID_RAT));
                                    RemoveItemFromInventory(World.ItemByID(World.ITEM_ID_RAT_TAIL), 5);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("You sucessfully tamed the Rat!");
                                    Console.ResetColor();
                                    // See if the player has the required item in their inventory
                                    Console.WriteLine("You tame {0}", _player.CurrentMob.Name);
                                    //Weapon newPet = World.ItemByID(World.PET_ID_WOLF);
                                    Weapon newPet = _player.Weapons.SingleOrDefault(x => x.Name.ToLower() == "rat" || x.NamePlural.ToLower() == "rat");
                                    EquipPet(newPet);
                                    LootTheCurrentMob();

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Tame failed. You do not tame the {0}. You need 5 Rat Tails in your inventory to tame a Rat.", _player.CurrentMob.Name);
                                    Console.ResetColor();
                                    LetTheMobAttack();
                                }
                            }
                            if ((CurrentMob.Name.ToLower() == "serpent") && (Inventory.Any(ii => ii.Details.ID == World.ITEM_ID_SNAKE_FANG && ii.Quantity >= 8)))
                            {
                                Console.WriteLine("You attempt to tame beast...");
                                int f = (1 + (Determination * 2));
                                int i = GetRandomNumber(f, 100);
                                Console.WriteLine("Chance: f {0} - roll i: {1}", f, i);
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Thread.Sleep(200);
                                Console.WriteLine(" ... ");
                                Thread.Sleep(200);
                                Console.WriteLine(" ... ");
                                Thread.Sleep(1200);
                                Console.WriteLine(" ... ");
                                Thread.Sleep(800);
                                if (i > 50)
                                {
                                    AddItemToInventory(World.ItemByID(World.PET_ID_SERPENT));
                                    RemoveItemFromInventory(World.ItemByID(World.ITEM_ID_SNAKE_FANG), 8);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("You sucessfully tamed the Serpent!");
                                    Console.ResetColor();
                                    // See if the player has the required item in their inventory
                                    Console.WriteLine("You tame {0}", _player.CurrentMob.Name);
                                    //Weapon newPet = World.ItemByID(World.PET_ID_WOLF);
                                    Weapon newPet = _player.Weapons.SingleOrDefault(x => x.Name.ToLower() == "serpent" || x.NamePlural.ToLower() == "serpents");
                                    EquipPet(newPet);
                                    LootTheCurrentMob();

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Tame failed. You do not tame the {0} You need 8 Snake Fangs in your inventory to tame Serpent.", _player.CurrentMob.Name);
                                    Console.ResetColor();
                                    LetTheMobAttack();
                                }
                            }
                            else
                            {
                                Console.WriteLine("You could not tame beast. You need 5 Rat Tails to tame Rat, 10 Wolf Paws to tame wolf, and 8 Snake Fangs to tame serpent.");
                            }
                        }
                        catch (NullReferenceException ex) { }
                    }


                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("There is no beast here to tame.");
                    Console.ResetColor();
                }
            }
            public void EquipPet(Weapon newPet)
            {
                _player.CurrentPet = newPet;
                if (newPet.Stat != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" - Your {0} has increased by {1}", newPet.Stat, newPet.StatInt);
                    Console.ResetColor();
                    switch (newPet.Stat.ToLower())
                    {
                        case "health":
                            _player.Health += newPet.StatInt;
                            _player.CurrentHealth++;
                            //_player.Health -= weaponToRemove.StatInt;
                            break;
                        case "wisdom":
                            _player.Wisdom += newPet.StatInt;
                            _player.CurrentWisdom++;
                            break;
                        case "strength":
                            _player.Strength += newPet.StatInt;
                            break;
                        case "spellpower":
                            _player.SpellPower += newPet.StatInt;
                            break;
                        case "determination":
                            _player.Determination += newPet.StatInt;
                            break;
                        default:
                            Console.WriteLine("ERROR ASSIGNING BUFFS!!!");
                            break;
                    }
                }
                if (newPet.Stat2 != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" - Your {0} has increased by {1}", newPet.Stat2, newPet.StatInt2);
                    Console.ResetColor();
                    switch (newPet.Stat2.ToLower())
                    {
                        case "health":
                            _player.Health += newPet.StatInt2;
                            break;
                        case "wisdom":
                            _player.Wisdom += newPet.StatInt2;
                            break;
                        case "strength":
                            _player.Strength += newPet.StatInt2;
                            break;
                        case "spellpower":
                            _player.SpellPower += newPet.StatInt2;
                            break;
                        case "determination":
                            _player.Determination += newPet.StatInt2;
                            break;
                        default:
                            Console.WriteLine("ERROR ASSIGNING BUFFS!!! (2)");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("ELSE");
                }
            }


            
            public void CureBeast()
            {
                int wisdomCost = (3 * (1 - (Determination / 35)));
                while (CurrentMob != null)
                {
                    if (CurrentWisdom < wisdomCost)
                    {

                        Console.WriteLine("You do not have enough wisdom to cast this spell.  Required: {0}  Current Wisdom: ({1}/{2})", wisdomCost, CurrentWisdom, Wisdom);
                        Console.WriteLine("");
                        Console.WriteLine("");
                    }
                    else
                    {
                        int fulcrum = 25 * ((8 / 35) + 1);
                        int chance = GetRandomNumber(fulcrum, 100);
                        Console.WriteLine("fulcrum: {0}     chance(f, 100):  {1}", fulcrum, chance);
                        //Console.ForegroundColor = ConsoleColor.DarkBlue;

                        Thread.Sleep(300);
                        if (CurrentMob != null)
                        {
                            if ((chance >= 50) && (CurrentMob.Type == "beast"))
                            {
                                //sucess
                                CurrentWisdom -= 6;
                                if (CurrentWisdom < 0) { CurrentWisdom = 0; }
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Cure Beast is successful. " + CurrentMob.Name + "runs away. You used {0} wisdom.", wisdomCost);
                                Console.ResetColor();
                                LootTheCurrentMob();

                                //CurrentLocation.HasMob = false;
                                DisplayCurrentLocation();
                            }
                            else if ((chance < 50) && (CurrentMob.Type == "beast"))
                            {
                                //fail
                                CurrentWisdom -= 6;
                                if (CurrentWisdom < 0) { CurrentWisdom = 0; }
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Cure Beast failed. You used {0} wisdom.", wisdomCost);
                                Console.ResetColor();
                                LetTheMobAttack();
                            }
                            else
                            {
                                // not a beast
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Can't cast Cure Beast. This mob is not a beast");
                                Console.ResetColor();
                                LetTheMobAttack();
                            }
                        }
                    }
                }
                
                    Console.WriteLine("There is no monster here.");
                
            }
            public void UseWeapon(Weapon weapon)
            {
                if (!CurrentMob.IsDead)
                {


                    int criticalMultiplier = (Determination / 35) + 1;
                    int damage = (GetRandomNumber(weapon.MinDamage, weapon.MaxDamage + ((Strength / 10) + 1)));

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if ((Class.ToLower() == "paladin") && (weapon.Type == "mace")) { damage += (damage / 6); Console.WriteLine("+damage due to class advantage with {0}", weapon.Type); }
                    if ((Class.ToLower() == "huntsman") && ((weapon.Type == "stave") || (weapon.Type == "dagger") || (weapon.Type == "axe"))) { damage += (damage / 6); Console.WriteLine("+damage due to class advantage with {0}", weapon.Type); }
                    if ((Class.ToLower() == "warrior") && (weapon.Type != "stave")) { damage += damage / 6; Console.WriteLine("+damage due to class advantage with {0}", weapon.Type); }
                    if ((Class.ToLower() == "sorcerer") && ((weapon.Type == "stave") || (weapon.Type == "dagger"))) { damage += (damage / 6); Console.WriteLine("+damage due to class advantage with {0}", weapon.Type); }
                    if ((Class.ToLower() == "rogue") && (weapon.Type == "dagger")) { damage += (damage / 6); Console.WriteLine("+damage due to class advantage with {0}", weapon.Type); }

                    if ((Class.ToLower() == "sorcerer") && (CurrentMob.Type == "ghost")) { damage += (damage / 6); Console.WriteLine("+damage due to class advantage over ghost"); }
                    if ((Class.ToLower() == "huntsman") && (CurrentMob.Type == "beast") && (CurrentWeapon.Type.ToLower() != "pet")) { damage += (damage / 6); Console.WriteLine("+damage due to class advantage over beast"); }
                    if ((Class.ToLower() == "paladin") && (CurrentMob.Type == "undead")) { damage += (damage / 6); Console.WriteLine("+damage due to class advantage over undead"); }
                    if ((Class.ToLower() == "rogue") && (CurrentMob.Type == "human") && (weapon != CurrentOffhand)) { damage += (damage / 6); Console.WriteLine("+damage due to class advantage over humans"); }
                    Console.ResetColor();

                    //be nice to noobs
                    if ((weapon.MinDamage == 0)) { damage++; }
                    string yourPet;
                    if(weapon == CurrentPet)
                    {
                        yourPet = "r pet " + CurrentPet.Name;
                    }
                    else
                    {
                        yourPet = "";
                    }
                    if ((damage == weapon.MinDamage))
                    {
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You{0} missed the " + CurrentMob.Name, yourPet);
                        Console.ResetColor();
                    }
                    else
                    {
                        if ((CurrentOffhand == weapon)) { damage = (damage / 2); }
                        if ((damage == weapon.MaxDamage) && (weapon.MaxDamage > 4) && (weapon.Type != "pet")) // || (damage == (weapon.MaxDamage - 1)
                        {
                            double dmg = (damage * criticalMultiplier);
                            damage = Convert.ToInt32(dmg);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            CurrentMob.CurrentHealth -= damage;
                            Console.WriteLine("Critical Strike!");
                            Console.ResetColor();
                            Console.Write("You{0} hit the " + CurrentMob.Name + " for " + damage + " points with " + weapon.Name + "!", yourPet);
                            Console.WriteLine("");

                        }
                        else
                        {
                            CurrentMob.CurrentHealth -= damage;
                            Console.WriteLine("You{0} hit the " + CurrentMob.Name + " for " + damage + " points with " + weapon.Name + ".", yourPet);

                        }
                    }



                    if (CurrentMob.IsDead)
                    {
                        LootTheCurrentMob();
                        CurrentLocation.HasMob = false;
                        //DespawnMob(_player.CurrentLocation);

                        // "Move" to the current location, to refresh the current monster
                        //MoveTo(CurrentLocation);
                        Console.WriteLine("");
                        DisplayCurrentLocation();
                    }
                    else
                    {
                        if ((weapon != _player.CurrentOffhand) && (_player.CurrentOffhand != _player.CurrentWeapon))
                        {
                            LetTheMobAttack();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("{0} Health: {1}/{2}", CurrentMob.Name, CurrentMob.CurrentHealth, CurrentMob.Health);
                            Console.ResetColor();
                            Console.WriteLine("");
                            //Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Health: ");
                            if (CurrentHealth < 0)
                            {
                                CurrentHealth = 0;
                            }
                            if (CurrentHealth >= (Health - 4))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            if (((CurrentHealth > (Health / 3)) && ((CurrentHealth < (Health / 3) * 2))))
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.Write(CurrentHealth);
                            Console.ResetColor();
                            Console.Write("/" + Health);
                            //Console.WriteLine("");
                            Console.Write("        Wisdom: ");
                            if (CurrentWisdom > (Wisdom / 2))
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.Write(CurrentWisdom);
                            Console.ResetColor();
                            Console.Write("/" + Wisdom);
                            Console.ResetColor();
                            ///{1})
                            //Wisdom: ({2}/{3})", CurrentHealth, Health, CurrentWisdom, Wisdom);
                            Console.WriteLine("");
                            Console.Write("STR: {0}    SPW: {1}    DTR: {2}", Strength, SpellPower, Determination);
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.ResetColor();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("MOB DEAD");
                }
            }
            private void LootTheCurrentMob()
            {
                int keyCount;
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("You defeated the " + CurrentMob.Name + "!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You receive " + CurrentMob.Experience + " experience points.");
                Console.ResetColor();

                //CurrentLocation.CurrentMob = null;

                AddExperiencePoints(CurrentMob.Experience);
                //InventoryItem existingItemInInventory = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToAdd.ID);
                // Give monster's loot items to the player
                foreach (InventoryItem inventoryItem in CurrentMob.LootItems)
                {
                    if ((_player.Inventory.Any(x => x.ItemID == inventoryItem.Details.ID)) && ((inventoryItem is Weapon) || (inventoryItem.Details.Name.ToLower().Contains("key")))){
                        //Console.ResetColor();
                        Console.WriteLine("NOT PRINTING - {0}", inventoryItem.Description);
                        //Console.WriteLine(string.Format("You loot {0} {1}", inventoryItem.Quantity, inventoryItem.Description));
                    }
                    //if else ((_player.Inventory.Any(x => x.ItemID == inventoryItem.Details.ID)) &&
                    else
                    {


                        AddItemToInventory(inventoryItem.Details);
                        if (inventoryItem.Description.ToLower().Contains("key"))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nYou found the " + inventoryItem.Description + "!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ResetColor();
                            Console.WriteLine(string.Format("You loot {0} {1}", inventoryItem.Quantity, inventoryItem.Description));
                        }
                    }
                    
                }
                CurrentMob = null;
                CurrentLocation.HasMob = false;
                CurrentLocation.MobLivingHere = null;
                Console.WriteLine("");
            }
            public void AddItemToInventory(Item itemToAdd, int quantity = 1)
            {
                InventoryItem existingItemInInventory = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToAdd.ID);

                if (existingItemInInventory == null)
                {
                    Inventory.Add(new InventoryItem(itemToAdd, quantity));
                }
                else
                {
                    existingItemInInventory.Quantity += quantity;
                }

            }
            public void EatFood(Food food)
            {
                if (CurrentLocation.MobLivingHere == null)
                {
                    Console.WriteLine("You eat " + food.Name);
                    HealPlayer(food.AmountToHeal, 1);
                    Console.WriteLine("You recovered " + food.AmountToHeal + " health points.  ({0}/{1})", CurrentHealth, Health);
                    RemoveItemFromInventory(food);
                }
                else
                {
                    Console.WriteLine("You eat " + food.Name);
                    HealPlayer(food.AmountToHeal, 3);
                    Console.WriteLine("You recovered " + food.AmountToHeal + " health points.  ({0}/{1})", CurrentHealth, Health);
                    RemoveItemFromInventory(food);

                    // The player used their turn to drink the potion, so let the monster attack now
                    LetTheMobAttack();
                }
            }
            public void LevelUp()
            {
                int level = _player.Level;
                int currentLevel = _player._currentLevel;
                if (Experience > (Experience * 35)){
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Level up!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    _player._currentLevel++;
                    if (Class.ToLower() == "paladin")
                    {
                        if (Level % 2 == 1)
                        {
                            Health += 2;
                            Console.WriteLine(" You gained 2 health");
                            Wisdom += 1;
                            Console.WriteLine(" You gained 1 wisdom");
                        }
                        else
                        {
                            Determination += 1;
                            Console.WriteLine(" You gained 1 Determination");
                            SpellPower += 1;
                            Console.WriteLine(" You gained 1 Spell Power");
                            Strength += 1;
                            Console.WriteLine(" You gained 1 Strength");
                        }
                    }

                }
            }


            public void RemoveItemFromInventory(Item itemToRemove, int quantity = 1)
            {
                InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToRemove.ID && ii.Quantity >= quantity);

                if (item != null)
                {
                    item.Quantity -= quantity;

                    if (item.Quantity == 0)
                    {
                        Inventory.Remove(item);
                    }

                }
            }

            private bool HasRequiredItemToEnterThisLocation(Location location)
            {
                if (location.DoesNotHaveAnItemRequiredToEnter)
                {
                    return true;
                }

                // See if the player has the required item in their inventory
                return Inventory.Any(ii => ii.Details.ID == location.ItemRequiredToEnter.ID);
            }
            private void DespawnMob(Location location)
            {
                if (_player.CurrentLocation.HasMob)
                {
                    _player.CurrentLocation.HasMob = false;
                }
            }

            private void SetTheCurrentMobForTheCurrentLocation(Location location)
            {
                // Populate the current monster with this location's monster (or null, if there is no monster here)
                CurrentMob = location.NewInstanceOfMobLivingHere();

                if (CurrentMob != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("");
                    Console.Write("You see a ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(CurrentMob.Name);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Thread.Sleep(500);
                    if (_player.Class.ToLower() != "rogue")
                    {
                        LetTheMobAttack();
                    }
                    else
                    {
                        AttackMob();
                    }
                }
            }
            private bool PlayerDoesNotHaveTheRequiredItemToEnter(Location location)
            {
                return !HasRequiredItemToEnterThisLocation(location);
            }

            private void AddExperiencePoints(int experiencePointsToAdd)
            {
                Experience += experiencePointsToAdd;
                //Health = (Level * 10);  // should be "health = level * (strength/50)+1 or soemthing 
                //also needs to notify when a level is earned and what stats increase with that level
            }

            private void LetTheMobAttack()
            {
                int i = 0;
                if (CurrentMob.Name.ToLower() == "solomonari")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    i = 4;
                    Console.WriteLine("  Insolent wretch who intrudes upon the sacred Scholomance... Prepare to pay for your trespasses!");
                    Console.ResetColor();
                    
                }
                if (CurrentMob.Name.ToLower() == "death knight arbutus")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    i = 4;
                    Console.WriteLine("  Insolent wretch who intrudes upon the sacred Scholomance... Prepare to pay for your trespasses!");
                    Console.ResetColor();

                }

                int damageToPlayer = GetRandomNumber(i, CurrentMob.MaxDamage);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The {0} attacks!", CurrentMob.Name);
                Console.ResetColor();
                Thread.Sleep(100);
                Console.WriteLine("The " + CurrentMob.Name + " did " + damageToPlayer + " points of damage.");
                Thread.Sleep(200);

                if (damageToPlayer == 0)
                {
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The " + CurrentMob.Name + " missed!");
                    Console.ResetColor();
                    Thread.Sleep(200);
                }

                CurrentHealth -= damageToPlayer;

               
                if (CurrentHealth > Health) { CurrentHealth = Health; }
                if (CurrentWisdom > Wisdom) { CurrentWisdom = Wisdom; }
                // battle display
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("{0} Health: {1}/{2}", CurrentMob.Name, CurrentMob.CurrentHealth, CurrentMob.Health);
                Console.ResetColor();
                Console.WriteLine("");
                //Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Health: ");
                if (CurrentHealth < 0)
                {
                    CurrentHealth = 0;
                }
                if (CurrentHealth >= (Health - 4))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                if (((CurrentHealth > (Health / 3)) && ((CurrentHealth < (Health / 3) * 2))))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(CurrentHealth);
                Console.ResetColor();
                Console.Write("/" + Health);
                //Console.WriteLine("");
                Console.Write("        Wisdom: ");
                if (CurrentWisdom > (Wisdom / 2))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(CurrentWisdom);
                Console.ResetColor();
                Console.Write("/" + Wisdom);
                Console.ResetColor();
                //CurrentHealth++;
                CurrentWisdom++;
                if (CurrentHealth > Health) { CurrentHealth = Health; }
                if (CurrentWisdom > Wisdom) { CurrentWisdom = Wisdom; }
                ///{1})
                //Wisdom: ({2}/{3})", CurrentHealth, Health, CurrentWisdom, Wisdom);
                Console.WriteLine("");
                Console.Write("STR: {0}    SPW: {1}    DTR: {2}", Strength, SpellPower, Determination);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ResetColor();

                if (IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine("The " + CurrentMob.Name + " killed you.");
                    Console.WriteLine("\n ~ GAME OVER ~ \n");
                    Console.ResetColor();
                    _player.MoveHome();
                    //// SOLUTION +++ MAKE A NEW PLAYER FROM SCRATCH
                    //_player = new Player(name, characterClass, health, wisdom, strength, spellPower, determination, health, wisdom, wisdom, 0, 1);
                    DisplayCurrentLocation();
                    //foreach(InventoryItem item in _player.Inventory)
                    //{
                    //    Inventory.Remove(item);
                    //}
                    //


                    //MoveHome();
                    _player.CurrentHealth = 0;
                    HealPlayer(Health, Wisdom);

                    // Somehow dump inventory.

                    /*foreach (InventoryItem inventoryItem in _player.Inventory)
                    {
                        Item existingItemInInventory = Inventory.SingleOrDefault(ii => ii.Details.ID == inventoryItem.ID);
                        _player.RemoveItemFromInventory(existingItemInInventory);
                    }
                    */

                    //DisplayCurrentLocation();
                }
            }
            private void HealPlayer(int hitPointsToHeal, int wisdomToHeal)
            {
                CurrentHealth = Math.Min(CurrentHealth + hitPointsToHeal + (Strength / 10), Health); //strength healing only applies while WALKING not in all casts, and espeically not in spell healing
                CurrentWisdom = Math.Min(CurrentWisdom + wisdomToHeal + (SpellPower / 10), Wisdom);
            }
            private void MoveHome()
            {
                MoveTo(World.LocationByID(World.LOCATION_ID_EMPTY_FIELD));
            }




        }
        public class Item
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string NamePlural { get; set; }
            public Item(int id, string name, string namePlural)
            {
                ID = id;
                Name = name;
                NamePlural = namePlural;
            }
        }
        public class Food : Item
        {
            public int AmountToHeal { get; set; }
            public int BuffInt { get; set; }
            public string BuffStat { get; set; }
            public Food(int id, string name, string namePlural, int amountToHeal, int buffInt = 0, string buffStat = null) : base(id, name, namePlural)
            {
                AmountToHeal = amountToHeal;
                BuffInt = buffInt;
                BuffStat = BuffStat;
            }


        }
        public class InventoryItem
        {
            private Item _details;
            private int _quantity;
            public Item Details { get { return _details; } set { _details = value; } }
            public int Quantity { get { return _quantity; } set { _quantity = value; } }
            public int ItemID { get { return Details.ID; } }
            public string Type { get; set; }
            public string Description { get { return Quantity > 1 ? Details.NamePlural : Details.Name; } }
            public InventoryItem(Item details, int quantity)
            {
                Details = details;
                Quantity = quantity;

            }

        }
        public class LootItem
        {
            public Item Details { get; set; }
            public int DropPercentage { get; set; }
            public bool IsDefaultItem { get; set; }

            public LootItem(Item details, int dropPercentage, bool isDefaultItem)
            {
                Details = details;
                DropPercentage = dropPercentage;
                IsDefaultItem = isDefaultItem;
            }
        }
        public class Key : Item
        {
            public Key(int id, string name, string namePlural) : base(id, name, namePlural)
            {

            }

        }
        public class Weapon : Item
        {
            public int MinDamage { get; set; }
            public int MaxDamage { get; set; }
            public string Type { get; set; }
            public string Stat { get; set; }
            public int StatInt { get; set; }
            public string Stat2 { get; set; }
            public int StatInt2 { get; set; }
            public Weapon(int id, string type, string name, string namePlural, int minDamage, int maxDamage, int statInt = 0, string stat = null, int statInt2 = 0, string stat2 = null) : base(id, name, namePlural)
            {
                MaxDamage = maxDamage;
                MinDamage = minDamage;
                Type = type;
                StatInt = statInt;
                Stat = stat;
                StatInt2 = statInt2;
                Stat2 = stat2;
            }
        }
        public class Location
        {
            private bool _hasMob;
            private readonly SortedList<int, int> _mobAtLocation = new SortedList<int, int>();
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Item ItemRequiredToEnter { get; set; }
            public Mob MobLivingHere { get; set; }
            public Location LocationToNorth { get; set; }
            public Location LocationToEast { get; set; }
            public Location LocationToSouth { get; set; }
            public Location LocationToWest { get; set; }
            //public NPC NPChere { get; set}

            public bool HasMob { get { return _mobAtLocation.Count > 0; } set { _hasMob = value; } }
            public bool DoesNotHaveAnItemRequiredToEnter { get { return ItemRequiredToEnter == null; } }


            public Location(int id, string name, string description, Item itemRequiredToEnter = null, Mob mobLivingHere = null)
            {
                ID = id;
                Name = name;
                Description = description;
                ItemRequiredToEnter = itemRequiredToEnter;
                MobLivingHere = mobLivingHere;
            }
            public void AddMob(int MobID, int chanceOfAppearance)
            {
                if (_mobAtLocation.ContainsKey(MobID))
                {
                    _mobAtLocation[MobID] = chanceOfAppearance;
                }
                else
                {
                    _mobAtLocation.Add(MobID, chanceOfAppearance);
                }

            }
            public Mob NewInstanceOfMobLivingHere()
            {
                if (!HasMob) { return null; }
                int totalPercentages = _mobAtLocation.Values.Sum();
                int randomNumber = GetRandomNumber(1, totalPercentages);
                int total = 0;
                foreach (KeyValuePair<int, int> mobKeyValuePair in _mobAtLocation)
                {
                    total += mobKeyValuePair.Value;
                    if (randomNumber <= total)
                    {
                        return World.MobByID(mobKeyValuePair.Key).NewInstanceOfMob();
                    }
                }
                return World.MobByID(_mobAtLocation.Keys.Last()).NewInstanceOfMob();
            }
            /* public bool HasItemRequiredToEnter()
             {
                 if (ItemRequiredToEnter = null)
                 {
                     return true;
                 }
             }*/


        }
        public class LivingCreature
        {
            private int _currentHealth;

            public int Health { get; set; }
            public int CurrentHealth { get { return _currentHealth; } set { _currentHealth = value; } }
            public bool IsDead { get { return CurrentHealth <= 0; } }
            public LivingCreature(int currentHealth, int health)
            {
                CurrentHealth = currentHealth;
                Health = health;
            }
        }
        public class Mob : LivingCreature
        {
            public int ID { get; set; }
            public string Name { get; set; }
            //public int MaxHealth { get; set; }
            //public int CurrentHealth { get; set; }
            public string Type { get; set; }
            public int MaxDamage { get; set; }
            public int Experience { get; set; }
            public List<LootItem> LootTable { get; set; }
            internal List<InventoryItem> LootItems { get; }
            public Mob(int id, string name, string type, int maxDamage, int experience, int currentHealth, int health) : base(currentHealth, health)
            {
                ID = id;
                Name = name;
                Type = type;
                MaxDamage = maxDamage;
                Experience = experience;
                LootTable = new List<LootItem>();
                LootItems = new List<InventoryItem>();

            }
            internal Mob NewInstanceOfMob()
            {
                Mob NewMob = new Mob(ID, Name, Type, MaxDamage, Experience, CurrentHealth, Health);
                foreach (LootItem lootItem in LootTable.Where(lootItem => GetRandomNumber(1, 100) <= lootItem.DropPercentage))
                {
                    NewMob.LootItems.Add(new InventoryItem(lootItem.Details, 1));
                }
                if (NewMob.LootItems.Count == 0)
                {
                    foreach (LootItem lootItem in LootTable.Where(x => x.IsDefaultItem))
                    {
                        NewMob.LootItems.Add(new InventoryItem(lootItem.Details, 1));
                    }
                }
                return NewMob;
            }

        }

        public class World
        {
            public static readonly List<Item> Items = new List<Item>();
            public static readonly List<Mob> Mobs = new List<Mob>();
            public static readonly List<Location> Locations = new List<Location>();

            // warriors like maces, swords, axes
            // paladins like maces, swords, axes
            // huntsman like daggers, axes, staves
            // scorercers like daggers, swords, staves
            // rogues like daggers

            // daggers are usually high damage and you can have 2 at a time, way higher crit rate
            // swords are standard - some give str, some give spw
            // maces are standard - some give wisdom, some give health
            // staves give buffs to wisdom and spell power
            // axes give buff to dtm

            // weapons      -   warrior 10  -  paladins 8  -  huntsman 8  -  sorcerer 7  -  rogue 6
            public const int ITEM_ID_GNARLED_STICK = 1;  // Favor warrior and palladin
            public const int ITEM_ID_RUSTY_SWORD = 2; /// favor warrior and sorcerer
            public const int ITEM_ID_FIREPLACE_POKER = 3; // favor warrior and huntsman
            public const int ITEM_ID_SHINY_SWORD = 4;  // favor warrior and palladin
            public const int ITEM_ID_WOOD_HANDLED_HATCHET = 5;  // favor huntsman and rogues
            public const int ITEM_ID_CHAMPION_BROADSWORD = 6; // favor huntsman  and rogue
            public const int ITEM_ID_SHINY_DAGGER = 7; // favor huntsman and rogue
            public const int ITEM_ID_SACRIFICIAL_DAGGER = 8; // favor sorcerer and rogue
            public const int ITEM_ID_STONE_MALLET = 9; // favor palladin and warrior
            public const int ITEM_ID_BIG_MIGHTY_MACE = 10; // favor warriors and paladins
            public const int ITEM_ID_FARMERS_PITCHFORK = 11; // favor warriors and huntsman
            public const int ITEM_ID_CEREMONIAL_HALBERD = 12; // favor warriors and paladins
            public const int ITEM_ID_LETTER_OPENER = 13; // favor rogues and sorcerers
            public const int ITEM_ID_GARDEN_SCYTHE = 14; // favor huntsman and scorcerer
            public const int ITEM_ID_RAZOR_SWORD = 15; // favors scorcerers and warriors
            public const int ITEM_ID_HEAVY_CHAIN_WHIP = 16; // favors paladins
            public const int ITEM_ID_HEAVY_MAUL = 17; //favors paladins and warriors
            public const int ITEM_ID_LONG_FELLING_AXE = 18; // favor Paladins and huntsman
            public const int ITEM_ID_RUNED_STAVE = 19; //favors scorcerer
            public const int ITEM_ID_BONE_HANDLED_STILETTO = 20; // favors rogues and scorcerers and huntsman

            //pets
            public const int PET_ID_WOLF = 42;
            public const int PET_ID_RAT = 43;
            public const int PET_ID_SERPENT = 44;
            public const int PET_ID_SPIDER = 45;
            public const int PET_ID_BAT = 46;

            //items

            // vendor trash
            public const int ITEM_ID_RAT_TAIL = 41;
            public const int ITEM_ID_WOLF_PAW = 36;
            public const int ITEM_ID_WOLF_FUR = 37;
            public const int ITEM_ID_NEOPHYTES_EAR = 38;
            public const int ITEM_ID_GOLD_THREADED_CLOTH = 39;
            public const int ITEM_ID_ROTTING_FEMUR = 40;
            public const int ITEM_ID_SNAKE_FANG = 47;
            //food
            public const int ITEM_ID_BUGS = 21; //restors 1 hp
            public const int ITEM_ID_BERRIES = 22; //restores 2-3 hp
            public const int ITEM_ID_BREAD = 23; //restors 4-6 hp
            public const int ITEM_ID_MEAT = 24; //restores 6-9 hp
            public const int ITEM_ID_PIE = 25; //restores 10-15 hp

            //food special
            public const int ITEM_ID_MARYS_BERRY_PRESERVE = 26; // buffs dtr by 10 for next 4 turns; restores 10 hp
            public const int ITEM_ID_LOUS_SPUD_STEW = 27; // buffs str by 10 for next 4 turns, restores 10 hp
            public const int ITEM_ID_LOUISES_PLATTER_OF_CHEESES = 28; // buffs spw by 10 for next 4 turns, restores 10 hp
            public const int ITEM_ID_TRISHES_SMOKED_FISHES = 29; // restores 10 wis

            //keys
            public const int ITEM_ID_STONE_KEY = 30;
            public const int ITEM_ID_IRON_KEY = 31;
            public const int ITEM_ID_COPPER_KEY = 32;
            public const int ITEM_ID_SILVER_KEY = 35;
            public const int ITEM_ID_GOLD_KEY = 33;
            public const int ITEM_ID_CRYSTAL_KEY = 36;
            public const int ITEM_ID_ORB_OF_THE_TOWER = 34;

            //LOCATIONS
            public const int LOCATION_ID_EMPTY_FIELD = 1; //where you find the stone key glinting in the grass.
            public const int LOCATION_ID_STONE_GATE = 2;
            public const int LOCATION_ID_DARK_WOODS = 3; //going backwards at empty field goes to dark woods, any direction goes to empty field. Going off path in scary path goes to dark woods
            public const int LOCATION_ID_SCARY_PATH = 4;
            public const int LOCATION_ID_MANOR_YARD = 5;
            public const int LOCATION_ID_MANOR_DOOR = 6;
            public const int LOCATION_ID_FOYER = 7;
            public const int LOCATION_ID_GREAT_ROOM = 8;
            public const int LOCATION_ID_PANTRY = 9;
            public const int LOCATION_ID_CELLAR = 10;
            public const int LOCATION_ID_WITCHES_DEN = 11;
            public const int LOCATION_ID_STUDY = 12; //
            public const int LOCATION_ID_TREASURE_ROOM = 13; //
            public const int LOCATION_ID_RICKETY_SHED = 14;
            public const int LOCATION_ID_GHOUL_PIT = 15;
            public const int LOCATION_ID_PARLOR = 16;
            public const int LOCATION_ID_UPSTAIRS_HALLWAY = 17;
            public const int LOCATION_ID_LIBRARY = 18;
            public const int LOCATION_ID_ALCHEMY_LAB = 20;
            public const int LOCATION_ID_ARBUTUS_CHAMBERS = 21;
            public const int LOCATION_ID_ROOF = 22;
            public const int LOCATION_ID_DUNGEON1 = 23;
            public const int LOCATION_ID_DUNGEON2 = 24;
            public const int LOCATION_ID_DUNGEON3 = 24;
            public const int LOCATION_ID_DUNGEON4 = 24;
            public const int LOCATION_ID_DUNGEON5 = 24;
            public const int LOCATION_ID_DUNGEON6 = 24;
            public const int LOCATION_ID_DUNGEON7 = 24;
            public const int LOCATION_ID_RICKETY_SHACK_INSIDE = 25;
            public const int LOCATION_ID_DROP_TO_PIT = 25;
            public const int LOCATION_ID_DARK_WOODS_2 = 26;



            public const int MOB_ID_RAT = 1;
            public const int MOB_ID_WOLF = 2;
            public const int MOB_ID_NEOPHYTE = 3;
            public const int MOB_ID_ACOLYTE = 4;
            public const int MOB_ID_SOLOMONARI = 5;
            public const int MOB_ID_SHAMBLING_CORPSE = 6;
            public const int MOB_ID_ANIMATED_REMAINS = 7;
            public const int MOB_ID_WITCH = 8;
            public const int MOB_ID_CORRUPTED_SPIRIT = 9;
            public const int MOB_ID_ROTTING_GHOUL = 10;
            public const int MOB_ID_DEATH_KNIGHT_ARBUTUS = 11;
            public const int MOB_ID_WEATHERMAKER_VRITRONIA = 12;
            public const int MOB_ID_TORTURED_SUBJECT = 13;
            public const int MOB_ID_WISP = 14;
            public const int MOB_ID_SERPENT = 15;
            public const int MOB_ID_INTERROGATOR_WRISTH = 16;


            static World()
            {
                PopulateItems();
                PopulateMobs();
                PopulateLocations();
            }

            private static void PopulateItems()
            {

                // first level weps
                Items.Add(new Weapon(ITEM_ID_GNARLED_STICK, "mace", "Gnarled Stick", "Gnarled Sticks", 1, 3));
                Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "sword", "Rusty Sword", "Rusty Swords", 2, 4));
                Items.Add(new Weapon(ITEM_ID_LETTER_OPENER, "dagger", "Rusty Dagger", "Rusty Daggers", 1, 2));

                // second level weps
                Items.Add(new Weapon(ITEM_ID_FIREPLACE_POKER, "stave", "Fireplace Poker", "Fireplace Pokers", 3, 5, 1, "wisdom"));
                Items.Add(new Weapon(ITEM_ID_SHINY_SWORD, "sword", "Shiny Sword", "Shiny Swords", 4, 6, 1, "strength"));
                Items.Add(new Weapon(ITEM_ID_WOOD_HANDLED_HATCHET, "axe", "Wood Handled Hatchet", "Wood Handled Hatchets", 4, 5, 2, "health"));
                Items.Add(new Weapon(ITEM_ID_SHINY_DAGGER, "dagger", "Shiny Dagger", "Shiny Daggers", 2, 4, 1, "determination"));
                Items.Add(new Weapon(ITEM_ID_STONE_MALLET, "mace", "Stone Mallet", "Stone Mallets", 4, 6, 1, "health"));

                // mid game
                Items.Add(new Weapon(ITEM_ID_BIG_MIGHTY_MACE, "mace", "Big Mighy Mace", "Big Mighty Maces", 8, 12, 1, "health"));
                Items.Add(new Weapon(ITEM_ID_SACRIFICIAL_DAGGER, "dagger", "Sacrificial Dagger", "Sacrificial Daggers", 5, 6, 2, "determination"));
                Items.Add(new Weapon(ITEM_ID_FARMERS_PITCHFORK, "stave", "Farmer's Pitchfork", "Farmer's Pitchforks", 4, 8, 2, "strength"));
                Items.Add(new Weapon(ITEM_ID_RAZOR_SWORD, "sword", "Razor Sword", "Razor Swords", 5, 8, 2, "strength"));
                Items.Add(new Weapon(ITEM_ID_LONG_FELLING_AXE, "axe", "Long Felling Axe", "Long Felling Axes", 8, 11, 3, "health", 1, "strength"));

                // end game
                Items.Add(new Weapon(ITEM_ID_BONE_HANDLED_STILETTO, "dagger", "Bone-Handled Stiletto", "Bone-Handled Stilettos", 10, 12, 4, "wisdom", 2, "determination"));
                Items.Add(new Weapon(ITEM_ID_RUNED_STAVE, "stave", "Runed Stave", "Runed Staves", 5, 6, 4, "wisdom", 5, "spellPower"));
                Items.Add(new Weapon(ITEM_ID_HEAVY_CHAIN_WHIP, "mace", "Heavy Chains", "Heavy Chains", 16, 22, 5, "strength", 4, "spellPower"));
                Items.Add(new Weapon(ITEM_ID_CHAMPION_BROADSWORD, "sword", "Champion's Broadsword", "Champion's Broadswords", 17, 21, 5, "strength", 5, "health"));
                Items.Add(new Weapon(ITEM_ID_HEAVY_MAUL, "axe", "Heavy Maul", "Heavy Mauls", 18, 20, 8, "strength", 2, "health"));
                //Items.Add(new Weapon())

                // rare
                Items.Add(new Weapon(ITEM_ID_GARDEN_SCYTHE, "stave", "Garden Scythe", "Garden Scythes", 22, 26, 10, "spellPower", 3, "determination"));
                Items.Add(new Weapon(ITEM_ID_CEREMONIAL_HALBERD, "axe", "Ceremonial Halberd", "Ceremonial Halberd", 24, 27, 10, "stregnth", 3, "determination"));


                // pets
                Items.Add(new Weapon(PET_ID_RAT, "pet", "Rat", "Rats", 3, 5, 2, "spellPower", 2, "wisdom"));
                Items.Add(new Weapon(PET_ID_WOLF, "pet", "Wolf", "Wolves", 5, 7, 2, "strength"));
                Items.Add(new Weapon(PET_ID_SERPENT, "pet", "Serpent", "Serpents", 6, 8, 2, "health"));


                // food
                Items.Add(new Food(ITEM_ID_BUGS, "Bugs", "Bugs", 2));
                Items.Add(new Food(ITEM_ID_BERRIES, "Berries", "Berries", 3));
                Items.Add(new Food(ITEM_ID_BREAD, "Bread", "Bread", 5));
                Items.Add(new Food(ITEM_ID_MEAT, "Meat", "Meat", 8));
                Items.Add(new Food(ITEM_ID_PIE, "Pie", "Pies", 10));
                Items.Add(new Food(ITEM_ID_MARYS_BERRY_PRESERVE, "Mary's Berry Preserves", "Mary's Berry Preserves", 10, 10, "determination"));
                Items.Add(new Food(ITEM_ID_LOUS_SPUD_STEW, "Lou's Spud Stew", "Lou's Spud Stew", 10, 10, "strength"));
                Items.Add(new Food(ITEM_ID_LOUISES_PLATTER_OF_CHEESES, "Louise's Platter of Cheeses", "Louise's Platter of Cheeses", 10, 10, "spellPower"));
                Items.Add(new Food(ITEM_ID_TRISHES_SMOKED_FISHES, "Trish's Smoked Fishes", "Trish's Smoked Fishes", 10, 10, "wisdom"));
                // TODO : maybe add water? For wisdom regen


                //vendor trash
                Items.Add(new Item(ITEM_ID_RAT_TAIL, "Rat Tail", "Rat Tails"));
                Items.Add(new Item(ITEM_ID_WOLF_FUR, "Wolf Fur", "Wolf Fur"));
                Items.Add(new Item(ITEM_ID_WOLF_PAW, "Wolf Paw", "Wolf Paws"));
                Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Snake Fang", "Snake Fangs"));
                
                Items.Add(new Item(ITEM_ID_ROTTING_FEMUR, "Rotting Femur", "Rotting Femurs"));
                Items.Add(new Item(ITEM_ID_NEOPHYTES_EAR, "Neophyte's Ear", "Neophyte's Ears"));
                Items.Add(new Item(ITEM_ID_GOLD_THREADED_CLOTH, "Gold Threaded Cloth", "Gold Threaded CLoth"));


                Items.Add(new Key(ITEM_ID_STONE_KEY, "Stone Key", "Stone Keys"));
                Items.Add(new Key(ITEM_ID_IRON_KEY, "Iron Key", "Iron Keys"));
                Items.Add(new Key(ITEM_ID_COPPER_KEY, "Copper Key", "Copper Keys"));
                Items.Add(new Key(ITEM_ID_SILVER_KEY, "Silver Key", "Silver Keys"));
                Items.Add(new Key(ITEM_ID_GOLD_KEY, "Gold Key", "Gold Keys"));

            }
            private static void PopulateMobs()
            {

                Mob rat = new Mob(MOB_ID_RAT, "Rat", "beast", 2, 5, 3, 3);
                rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BUGS), 50, false));
                rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAT_TAIL), 75, true));
                rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BERRIES), 15, false));
                rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LETTER_OPENER), 75, false));
                rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_STONE_KEY), 50, false));

                Mob wolf = new Mob(MOB_ID_WOLF, "Wolf", "beast", 4, 3, 5, 5);
                wolf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_WOLF_FUR), 75, true));
                wolf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_WOLF_PAW), 25, false));
                wolf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RUSTY_SWORD), 70, false));
                wolf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LETTER_OPENER), 30, false));
                wolf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BUGS), 55, true));
                wolf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_STONE_KEY), 40, false));


                Mob wisp = new Mob(MOB_ID_WISP, "Wisp", "ghost", 5, 5, 5, 5);
                wisp.LootTable.Add(new LootItem(ItemByID(ITEM_ID_STONE_KEY), 10, false));

                Mob neophyte = new Mob(MOB_ID_NEOPHYTE, "Neophyte", "human", 5, 5, 7, 7);
                neophyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BREAD), 50, false));
                neophyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_FIREPLACE_POKER), 25, false));
                neophyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_IRON_KEY), 75, false));
                neophyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RUSTY_SWORD), 60, false));
                neophyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_WOOD_HANDLED_HATCHET), 15, false));
                neophyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GOLD_THREADED_CLOTH), 15, false));
                neophyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LOUS_SPUD_STEW), 25, false));
                neophyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_NEOPHYTES_EAR), 75, false));

                Mob acolyte = new Mob(MOB_ID_ACOLYTE, "Acolyte", "human", 5, 15, 18, 18);
                acolyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BREAD), 50, false));
                acolyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_FIREPLACE_POKER), 25, false));
                acolyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SHINY_DAGGER), 25, false));
                acolyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SACRIFICIAL_DAGGER), 5, false));
                acolyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SHINY_SWORD), 25, false));
                acolyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_STONE_MALLET), 25, false));
                acolyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GOLD_THREADED_CLOTH), 15, false));
                acolyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LOUS_SPUD_STEW), 25, false));
                acolyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LOUISES_PLATTER_OF_CHEESES), 10, false));
                acolyte.LootTable.Add(new LootItem(ItemByID(ITEM_ID_IRON_KEY), 70, false));

                Mob torturedSubject = new Mob(MOB_ID_TORTURED_SUBJECT, "Tortured Subject", "human", 3, 5, 2, 5);
                torturedSubject.LootTable.Add(new LootItem(ItemByID(ITEM_ID_STONE_MALLET), 50, false));
                torturedSubject.LootTable.Add(new LootItem(ItemByID(ITEM_ID_NEOPHYTES_EAR), 50, false));
                torturedSubject.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LOUS_SPUD_STEW), 15, false));
                torturedSubject.LootTable.Add(new LootItem(ItemByID(ITEM_ID_TRISHES_SMOKED_FISHES), 15, false));
                torturedSubject.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SHINY_DAGGER), 25, false));


                Mob shamblingCorpse = new Mob(MOB_ID_SHAMBLING_CORPSE, "Shambling Corpse", "undead", 8, 8, 6, 12);
                shamblingCorpse.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ROTTING_FEMUR), 50, true));
                shamblingCorpse.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BUGS), 50, true));
                shamblingCorpse.LootTable.Add(new LootItem(ItemByID(ITEM_ID_WOOD_HANDLED_HATCHET), 45, true));
                shamblingCorpse.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SHINY_DAGGER), 45, true));
                shamblingCorpse.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SACRIFICIAL_DAGGER), 5, true));
                shamblingCorpse.LootTable.Add(new LootItem(ItemByID(ITEM_ID_STONE_MALLET), 25, false));
                shamblingCorpse.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BREAD), 85, false));

                Mob reanimatedRemains = new Mob(MOB_ID_ANIMATED_REMAINS, "Reanimated Remains", "undead", 4, 8, 8, 8);
                reanimatedRemains.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ROTTING_FEMUR), 50, true));
                reanimatedRemains.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BUGS), 80, true));
                reanimatedRemains.LootTable.Add(new LootItem(ItemByID(ITEM_ID_WOOD_HANDLED_HATCHET), 25, true));
                reanimatedRemains.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SHINY_DAGGER), 25, true));
                //reanimatedRemains.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SACRIFICIAL_DAGGER), 5, true));
                reanimatedRemains.LootTable.Add(new LootItem(ItemByID(ITEM_ID_STONE_MALLET), 65, false));
                //reanimatedRemains.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAZOR_SWORD), 5, false));
                reanimatedRemains.LootTable.Add(new LootItem(ItemByID(ITEM_ID_TRISHES_SMOKED_FISHES), 30, false));

                Mob witch = new Mob(MOB_ID_WITCH, "Witch", "human", 7, 12, 27, 27);
                witch.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BREAD), 75, false));
                witch.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LONG_FELLING_AXE), 50, false));
                witch.LootTable.Add(new LootItem(ItemByID(ITEM_ID_FARMERS_PITCHFORK), 50, false));
                witch.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GARDEN_SCYTHE), 15, false));
                witch.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GOLD_THREADED_CLOTH), 50, false));
                witch.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LOUISES_PLATTER_OF_CHEESES), 50, false));
                witch.LootTable.Add(new LootItem(ItemByID(ITEM_ID_MEAT), 25, false));
                witch.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SACRIFICIAL_DAGGER), 75, false));
                witch.LootTable.Add(new LootItem(ItemByID(ITEM_ID_COPPER_KEY), 100, true));

                Mob rottingGhoul = new Mob(MOB_ID_ROTTING_GHOUL, "Rotting Ghoul", "undead", 7, 8, 18, 20);
                rottingGhoul.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ROTTING_FEMUR), 50, true));
                rottingGhoul.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PIE), 40, false));
                rottingGhoul.LootTable.Add(new LootItem(ItemByID(ITEM_ID_FARMERS_PITCHFORK), 40, false));

                Mob solomonari = new Mob(MOB_ID_SOLOMONARI, "Solomonari", "human", 7, 20, 35, 35);
                solomonari.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SILVER_KEY), 100, true));
                solomonari.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BIG_MIGHTY_MACE), 25, false));
                solomonari.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAZOR_SWORD), 25, false));
                solomonari.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SACRIFICIAL_DAGGER), 25, false));
                solomonari.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LONG_FELLING_AXE), 25, false));
                solomonari.LootTable.Add(new LootItem(ItemByID(ITEM_ID_MARYS_BERRY_PRESERVE), 40, false));

                Mob corruptedSpirit = new Mob(MOB_ID_CORRUPTED_SPIRIT, "Corrupted Spirit", "ghost", 9, 10, 7, 7);

                Mob deathKnightArbutus = new Mob(MOB_ID_DEATH_KNIGHT_ARBUTUS, "Death Knight Arbutus", "undead", 9, 30, 40, 40);
                deathKnightArbutus.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GOLD_KEY), 100, true));
                deathKnightArbutus.LootTable.Add(new LootItem(ItemByID(ITEM_ID_HEAVY_CHAIN_WHIP), 40, false));
                deathKnightArbutus.LootTable.Add(new LootItem(ItemByID(ITEM_ID_HEAVY_MAUL), 40, false));
                deathKnightArbutus.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CEREMONIAL_HALBERD), 10, false));
                deathKnightArbutus.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GARDEN_SCYTHE), 10, false));
                deathKnightArbutus.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CHAMPION_BROADSWORD), 40, false));
                deathKnightArbutus.LootTable.Add(new LootItem(ItemByID(ITEM_ID_MARYS_BERRY_PRESERVE), 40, false));
                deathKnightArbutus.LootTable.Add(new LootItem(ItemByID(ITEM_ID_NEOPHYTES_EAR), 40, false));
                deathKnightArbutus.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAZOR_SWORD), 40, false));
                deathKnightArbutus.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RUNED_STAVE), 40, false));
                deathKnightArbutus.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PIE), 40, false));
                deathKnightArbutus.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LOUISES_PLATTER_OF_CHEESES), 40, false));


                Mob serpent = new Mob(MOB_ID_SERPENT, "Serpent", "beast", 4, 8, 8, 8);
                serpent.LootTable.Add(new LootItem(ItemByID(ITEM_ID_MEAT), 30, false));
                serpent.LootTable.Add(new LootItem(ItemByID(ITEM_ID_NEOPHYTES_EAR), 40, false));
                serpent.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SHINY_DAGGER), 50, false));
                serpent.LootTable.Add(new LootItem(ItemByID(ITEM_ID_IRON_KEY), 10, false));
                serpent.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 80, true));
                serpent.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SHINY_SWORD), 60, false));

                Mob weathermakerVritronia = new Mob(MOB_ID_WEATHERMAKER_VRITRONIA, "Weathermaker Vritronia", "human", 18, 50, 65, 65);
                weathermakerVritronia.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CEREMONIAL_HALBERD), 25, false));
                weathermakerVritronia.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CHAMPION_BROADSWORD), 25, false));
                weathermakerVritronia.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GARDEN_SCYTHE), 25, false));
                weathermakerVritronia.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CEREMONIAL_HALBERD), 25, false));
                weathermakerVritronia.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ORB_OF_THE_TOWER), 100, true));


                Mobs.Add(rat);
                Mobs.Add(wolf);
                Mobs.Add(wisp);
                Mobs.Add(neophyte);
                Mobs.Add(acolyte);
                Mobs.Add(serpent);
                Mobs.Add(shamblingCorpse);
                Mobs.Add(reanimatedRemains);
                Mobs.Add(witch);
                Mobs.Add(torturedSubject);
                Mobs.Add(rottingGhoul);
                Mobs.Add(solomonari);
                Mobs.Add(corruptedSpirit);
                Mobs.Add(deathKnightArbutus);
                Mobs.Add(weathermakerVritronia);



            }

            public static Item ItemByID(int id)
            {
                return Items.SingleOrDefault(x => x.ID == id);
            }
            public static Mob MobByID(int id)
            {
                return Mobs.SingleOrDefault(x => x.ID == id);
            }
            public static Location LocationByID(int id)
            {
                return Locations.SingleOrDefault(x => x.ID == id);
            }
            public static void PopulateLocations()
            {
                int i = GetRandomNumber(1, 3);
                Location field = new Location(LOCATION_ID_EMPTY_FIELD, "Empty Field", "You are in an empty field, standing on dead grass with short brown bushes and dead trees around you, at the base of a tall mountain.There stands before you an immense stone gate.");
                /*int i = GetRandomNumber(1, 3);
                switch (i)
                {
                    case 1:
                        field.AddMob(MOB_ID_RAT, 100);
                        break;
                    case 2:
                        field.AddMob(MOB_ID_WOLF, 100);
                        break;
                    case 3:
                        field.AddMob(MOB_ID_WISP, 33);
                        break;
                }*/
                Location darkWoods = new Location(LOCATION_ID_DARK_WOODS, "Dark Woods", "You find yourself lost in dark woods. Dense thickets of brush obstruct your path. The howls of beasts and the stirrings of night cloud your senses. You don't remember how you ended up here again. But the North Star always points you to your destination.");
                darkWoods.AddMob(MOB_ID_WOLF, 33);
                darkWoods.AddMob(MOB_ID_WISP, 33);
                darkWoods.AddMob(MOB_ID_RAT, 33);
                darkWoods.AddMob(MOB_ID_RAT, 100);
                darkWoods.AddMob(MOB_ID_WOLF, 100);
                darkWoods.AddMob(MOB_ID_WISP, 33);
                
                Location stoneGate = new Location(LOCATION_ID_STONE_GATE, "Stone Gate", "You unlock the great and looming stone gate, passing through the pillars, underneath chiseled gargoyles and creeping brown vines stands. A dark wooded path lay before you.", ItemByID(ITEM_ID_STONE_KEY));

                Location scaryPath = new Location(LOCATION_ID_SCARY_PATH, "Frightful Path", "You pass through the stone gate, into a dark grove. The grass had withered long ago, and you tread on dusty dirt towards a dim light up ahead. The woods on either side of the path seem to be calling to you.");
                scaryPath.AddMob(MOB_ID_SERPENT, 22);
                scaryPath.AddMob(MOB_ID_NEOPHYTE, 22);
                scaryPath.AddMob(MOB_ID_ANIMATED_REMAINS, 11);
                scaryPath.AddMob(MOB_ID_ACOLYTE, 5);
                
                Location darkWoods2 = new Location(LOCATION_ID_DARK_WOODS_2, "Darker Forest", "You've wandered off the path. The woods seem darker here. Thicket so dense that you can hardly walk through it. Not even moonlight reaches the forest floor. You are lost again.");
                darkWoods2.AddMob(MOB_ID_ANIMATED_REMAINS, 30);
                darkWoods2.AddMob(MOB_ID_NEOPHYTE, 30);

                Location manorYard = new Location(LOCATION_ID_MANOR_YARD, "Manor Yard", "You stand now before a dilapidated stone castle. The wooden roof is collapsing in on itself. The great stone walls stretch around your view. Great twisting spires covered in creeping dead vines adorn the structure. It stood immense on the side of pined mountain, and it overlooked an unfamiliar and still lake below. Dark woods loom on either side.");
                manorYard.AddMob(MOB_ID_NEOPHYTE, 40);
                manorYard.AddMob(MOB_ID_WOLF, 33);
                manorYard.AddMob(MOB_ID_WISP, 33);
                       

                Location manorDoor = new Location(LOCATION_ID_MANOR_DOOR, "Manor Entrance", "You come upon a large wooden door, reinforced with bars of iron, set into the grey stone wall. There is a greening copper lock on this door. Above the frame, in script, is the word: \"Scholomonarie\"", ItemByID(ITEM_ID_IRON_KEY));

                Location manorFoyer = new Location(LOCATION_ID_FOYER, "The Castle's Foyer", "A once immaculate vestibule into the academy, the wood in the floors have begun to rot and the paiting on the walls appear to be degrading from the corners. A large ornate candle chanedlier hangs from the ceiling and globules of solid wax cling to it grotesquely. Before you is a great archway that leads to a more well lit room. A man with black, sunken eyes comes around a corner and appears shocked that you are here. \n 'You will make a fine specimen', he cackles, as he begins summoning black nether around him.");
                manorFoyer.AddMob(MOB_ID_ACOLYTE, 100);


                Location ricketyShack = new Location(LOCATION_ID_RICKETY_SHED, "Rickety Shed", "Near the tree line stands an old rickety wooden shack. It is locked from the inside. It sounds like something is moving inside");

                Location ricketyShackInside = new Location(LOCATION_ID_RICKETY_SHACK_INSIDE, "Inside the Rickety Shed", "You climb a short ladder up a stone well, and through the tattered wooden roof you can see the night sky. You place the Gold Key into the lock on the inside of the shack door, and step out into the night.", ItemByID(ITEM_ID_GOLD_KEY));



                Location greatRoom = new Location(LOCATION_ID_GREAT_ROOM, "The Great Room", "A huge central room, where the wooden floor is sinking into the basement. Candelabras hang on the walls and dark materials litter the tables and shelves. Soulless students of the devil shamble among each other silently. At the west of the room is the pantry, at the east is the parlor, and at the north is a great staircase, covered in a makeshift wrought-iron fence, with a large copper lock sealing it.");
                greatRoom.AddMob(MOB_ID_NEOPHYTE, 44);
                greatRoom.AddMob(MOB_ID_ACOLYTE, 100);
                greatRoom.AddMob(MOB_ID_SHAMBLING_CORPSE, 44);
                
                Location pantry = new Location(LOCATION_ID_PANTRY, "Castle Pantry", "You come into the pantry, long neglected, its pots and pans and utensils long ago converted to instruments of witchcraft or alchemy. At the south of the room, you notice a small stone doorway that leads to stairs going into a cellar.");
                pantry.AddMob(MOB_ID_RAT, 100);
                pantry.AddMob(MOB_ID_ACOLYTE, 100);
                pantry.AddMob(MOB_ID_CORRUPTED_SPIRIT, 33);
                
                Location ghoulPit = new Location(LOCATION_ID_GHOUL_PIT, "Cellar Ghoul Pit", "You descend the stairs to see a stone cellar illuminated by candles. In the center is a pile of discarded yellowing bones, and on top of it wrestles two reanimated corpses, with a Witch, deformed and cackling, orchestrating the battle. When she sees you, she shreiks and casts the two reanimated corpses to you and barricades herself in her den at the west end of the room.");
                ghoulPit.AddMob(MOB_ID_ANIMATED_REMAINS, 100);
                ghoulPit.AddMob(MOB_ID_ANIMATED_REMAINS, 100);

                Location witchesDen = new Location(LOCATION_ID_WITCHES_DEN, "The Witches Den", "On a nest build of body parts and bones rests the Witch. She is disfigured from her abuse of black magic, and her nervous cackling as she paces towards you with her blood-stained knife in her impossibly long fingers.");
                witchesDen.AddMob(MOB_ID_WITCH, 100); 

                Location parlor = new Location(LOCATION_ID_PARLOR, "Scholomanarie Parlor", "You step into the parlor. There are dried and cracked leather chairs, tables that have been stained by years of alchemic spills, and what looks to have been at one time a man, dressed in a suit. He now shambles, his rotting green flesh bloated and sloughing and the once-fine linen of his suit stained a dark yellow from his decaying body. His lower jaw missing, teeth perpetually bared, he charges you.");
                parlor.AddMob(MOB_ID_ROTTING_GHOUL, 100);

                Location upstairsHallway = new Location(LOCATION_ID_UPSTAIRS_HALLWAY, "Upstairs Hallway", "You step onto a long red carpet, matted and threadbare, stretches from the west side of the cold corridor to the east. Heavy wooden doors at both ends.");
                upstairsHallway.AddMob(MOB_ID_NEOPHYTE, 100);
                upstairsHallway.AddMob(MOB_ID_ACOLYTE, 33);
                upstairsHallway.AddMob(MOB_ID_WISP, 33);
                
                Location study = new Location(LOCATION_ID_STUDY, "Study", "You open the great wooden door that leads into the study, and you step in to the cleanest room in the castle so far. Volumes of books, on wall to wall shelves, reach 30 feet up. A great wooden desk sits in the middle of the room and a man sits with his back to you in a wooden chair at the end of the desk. He appears to be starting down out of his window, into the night. \n \"Nice of you to finally pay me a visit, {0}\", he says. He slowly stands up, great purple robes fall about him, and he turns to you. Black magic has corrupted his soul, his hair had withered, his skin greyed, and in his eye sockets there burned two green flames. This was the Solomonari - a professor at the Scholomanarie school. He brough his hands together, and drew them back out, materializing from dark energy a large, thin blade made of nether energy. He drew it towards you and before you could take your first step, he silently glided towards you without even a single step", ItemByID(ITEM_ID_COPPER_KEY));
                study.AddMob(MOB_ID_SOLOMONARI, 100);

                Location library = new Location(LOCATION_ID_LIBRARY, "Library", "In the library are great many book shelves, writing tables, and bubbling alchemical vials and pots with sprawled-open notebooks open next to them, illegible arahmaic script and demonic symbology littering the pages. To the north stands an immense iron door, adorned with rivulates of gold inlay.", ItemByID(ITEM_ID_SILVER_KEY));
                library.AddMob(MOB_ID_ACOLYTE, 100);

                Location arbutusChambers = new Location(LOCATION_ID_ARBUTUS_CHAMBERS, "Arbutus's Chambers", "The giant metal and gold door swings inwards to a silent and dark room. There appears to be a large throne in the center with an exit on both the west and the east sides. The room was freezing and you can see your own breath now as you stare about the room. You grab a torch off the wall and step inside, and cast it over the room. You star into the dark, when two blue glowing eyes appear in front of you. The slumbering Death Knight awakes, and this monstrous lich drags its mace on the floor as it shambles over to you. He is like a golem, standing far taller than you, his face a white skull with a black crown and inexplicably long white hair below the crow that went down the back of his blue iron carapice. Huge spiked spaulders of matching blue iron and a black cloak in tatters that covered the his of his body. His gauntlets clanked as he raced his mace above his head and brough the weight of it smashing down to where you were.", ItemByID(ITEM_ID_SILVER_KEY));
                arbutusChambers.AddMob(MOB_ID_DEATH_KNIGHT_ARBUTUS, 100);

                Location dropToPit = new Location(LOCATION_ID_DROP_TO_PIT, "Falling down", "You step onto a wooden floor, but the rotted boards collapse, and you tumble down a great distance until you land on pile of hay. The room is dark and you can hear nothing excepot for the frequent dripping of a pipe or a wellstone onto the wet floor. There is a green stone archway in the east of this room, and what lies beyond it is covered in absolute dark.");

                Location dungeon1 = new Location(LOCATION_ID_DUNGEON1, "Dank Dungeon", "You are in a dank dungeon. The sound of pipes dripping to the wet cobblestone floor echo through these tunnels. A large S in carved into the floor.");
                dungeon1.AddMob(MOB_ID_SHAMBLING_CORPSE, 100);
                dungeon1.AddMob(MOB_ID_SERPENT, 100);
                dungeon1.AddMob(MOB_ID_ROTTING_GHOUL, 100);
                
                Location dungeon2 = new Location(LOCATION_ID_DUNGEON3, "Dank Dungeon", "You are in a dank dungeon. The sound of pipes dripping to the wet cobblestone floor echo through these tunnels. A large S in carved into the floor. The S seems to be tilted diagonally.");
                dungeon2.AddMob(MOB_ID_RAT, 100);
                dungeon2.AddMob(MOB_ID_CORRUPTED_SPIRIT, 100);
                dungeon2.AddMob(MOB_ID_TORTURED_SUBJECT, 33);
                
                Location dungeon3 = new Location(LOCATION_ID_DUNGEON3, "Dank Dungeon", "You are in a dank dungeon. The sound of pipes dripping to the wet cobblestone floor echo through these tunnels. A large S in carved into the floor. You can hear far-away laughing coming from the east.");
                dungeon3.AddMob(MOB_ID_TORTURED_SUBJECT, 100);
                dungeon3.AddMob(MOB_ID_CORRUPTED_SPIRIT, 33);
                dungeon3.AddMob(MOB_ID_RAT, 33);
                
                Location dungeon4 = new Location(LOCATION_ID_DUNGEON4, "Dank Dungeon", "You are in a dank dungeon. The sound of pipes dripping to the wet cobblestone floor echo through these tunnels. A large S in carved into the floor. It seems to be getting brighter in here.");
                dungeon4.AddMob(MOB_ID_TORTURED_SUBJECT, 100);

                Location dungeon5 = new Location(LOCATION_ID_DUNGEON5, "Dank Dungeon", "You are in a dank dungeon. The sound of pipes dripping to the wet cobblestone floor echo through these tunnels. A large S in carved into the floor. It's definitely brighter now. The laughing is getting closer.");
                dungeon5.AddMob(MOB_ID_TORTURED_SUBJECT, 100);

                Location dungeon6 = new Location(LOCATION_ID_DUNGEON6, "Dank Dungeon", "You step into the next identical room and are greeted with the razor sharp smile of a hooded man. Long white teeth and tiny eyes that squint when he giggles. \n \"What secrets do you have? Will you tell me?\", he asks. He discards his hood and robe is a vulgar display of speed as he grips a large executioners battle axe and charges at you, still smiling.");
                dungeon6.AddMob(MOB_ID_INTERROGATOR_WRISTH, 100);
                Location dungeon7 = new Location(LOCATION_ID_DUNGEON7, "Dank Dungeon", "You are in a dank dungeon. The sound of pipes dripping to the wet cobblestone floor echo through these tunnels. A large S in carved into the floor. There is bright moonlight coming out of the south tunnel, and the cool breeze draws you nearer to the exit.");

                Location roof = new Location(LOCATION_ID_ROOF, "Roof", "This is where Vritronia, the demon weathermaker, is riding a giant bat. Killing her gives you the Orb of the Tower, which you can destroy to free the tormented souls of The Sholomanarie.", ItemByID(ITEM_ID_CRYSTAL_KEY));
                roof.AddMob(MOB_ID_WEATHERMAKER_VRITRONIA, 100);

                field.LocationToNorth = stoneGate;
                field.LocationToEast = darkWoods;
                field.LocationToSouth = darkWoods;
                field.LocationToWest = darkWoods;

                darkWoods.LocationToNorth = field;
                darkWoods.LocationToWest = darkWoods;
                darkWoods.LocationToSouth = darkWoods;
                darkWoods.LocationToEast = darkWoods;

                stoneGate.LocationToNorth = scaryPath;
                stoneGate.LocationToEast = darkWoods;
                stoneGate.LocationToSouth = field;
                stoneGate.LocationToWest = darkWoods;

                scaryPath.LocationToNorth = manorYard;
                scaryPath.LocationToEast = darkWoods2;
                scaryPath.LocationToSouth = darkWoods;
                scaryPath.LocationToWest = darkWoods2;

                darkWoods2.LocationToNorth = darkWoods2;
                darkWoods2.LocationToEast = darkWoods2;
                darkWoods2.LocationToSouth = darkWoods2;
                darkWoods2.LocationToWest = scaryPath;

                manorYard.LocationToNorth = manorDoor;
                manorYard.LocationToEast = darkWoods2;
                manorYard.LocationToSouth = scaryPath;
                manorYard.LocationToWest = darkWoods2;

                manorDoor.LocationToNorth = manorFoyer;
                //manorDoor.LocationToEast = darkWoods;
                manorDoor.LocationToSouth = manorYard;
                //manorDoor.LocationToWest = darkWoods;

                

                manorFoyer.LocationToNorth = greatRoom;
                manorFoyer.LocationToSouth = manorDoor;

                greatRoom.LocationToNorth = upstairsHallway;
                greatRoom.LocationToEast = parlor;
                greatRoom.LocationToSouth = manorFoyer;
                greatRoom.LocationToWest = pantry;

                parlor.LocationToWest = greatRoom;

                pantry.LocationToSouth = ghoulPit;
                pantry.LocationToEast = greatRoom;

                ghoulPit.LocationToNorth = pantry;
                ghoulPit.LocationToWest = witchesDen;

                witchesDen.LocationToEast = ghoulPit;

                upstairsHallway.LocationToEast = library;
                upstairsHallway.LocationToSouth = greatRoom;
                upstairsHallway.LocationToWest = study;

                study.LocationToEast = upstairsHallway;

                library.LocationToNorth = arbutusChambers;
                library.LocationToWest = upstairsHallway;

                arbutusChambers.LocationToEast = roof;
                arbutusChambers.LocationToWest = dropToPit;

                dropToPit.LocationToWest = dungeon1;





                // after fall into dungeon

                dungeon1.LocationToNorth = dungeon1;
                dungeon1.LocationToEast = dungeon1;
                dungeon1.LocationToSouth = dungeon1;
                dungeon1.LocationToWest = dungeon2;

                dungeon2.LocationToNorth = dungeon1;
                dungeon2.LocationToEast = dungeon1;
                dungeon2.LocationToSouth = dungeon3;
                dungeon2.LocationToWest = dungeon1;

                dungeon3.LocationToNorth = dungeon1;
                dungeon3.LocationToEast = dungeon4;
                dungeon3.LocationToSouth = dungeon3;
                dungeon3.LocationToWest = dungeon1;

                dungeon4.LocationToNorth = dungeon1;
                dungeon4.LocationToEast = dungeon5;
                dungeon4.LocationToSouth = dungeon1;
                dungeon4.LocationToWest = dungeon1;

                dungeon5.LocationToNorth = dungeon1;
                dungeon5.LocationToEast = dungeon1;
                dungeon5.LocationToSouth = dungeon6;
                dungeon5.LocationToWest = dungeon1;

                dungeon6.LocationToNorth = dungeon1;
                dungeon6.LocationToEast = dungeon1;
                dungeon6.LocationToSouth = dungeon1;
                dungeon6.LocationToWest = dungeon7;

                dungeon7.LocationToNorth = dungeon1;
                dungeon7.LocationToEast = dungeon1;
                dungeon7.LocationToSouth = ricketyShackInside;
                dungeon7.LocationToWest = dungeon1;

                ricketyShackInside.LocationToSouth = manorYard;


                Locations.Add(field);
                Locations.Add(stoneGate);
                Locations.Add(scaryPath);
                Locations.Add(darkWoods);
                Locations.Add(manorDoor);
                Locations.Add(manorYard);
                Locations.Add(manorFoyer);
                Locations.Add(ricketyShack);
                Locations.Add(greatRoom);
                Locations.Add(pantry);
                Locations.Add(ghoulPit);
                Locations.Add(witchesDen);
                Locations.Add(parlor);
                Locations.Add(upstairsHallway);
                Locations.Add(study);
                Locations.Add(library);
                Locations.Add(arbutusChambers);
                Locations.Add(dropToPit);
                Locations.Add(dungeon1);
                Locations.Add(dungeon2);
                Locations.Add(dungeon3);
                Locations.Add(dungeon4);
                Locations.Add(dungeon5);
                Locations.Add(dungeon6);
                Locations.Add(dungeon7);
                Locations.Add(ricketyShackInside);




            }




        }
    }
}
