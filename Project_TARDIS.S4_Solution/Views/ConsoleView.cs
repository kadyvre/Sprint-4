using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    /// <summary>
    /// Console class for the MVC pattern
    /// </summary>
    public class ConsoleView
    {
        #region FIELDS

        //
        // declare a Universe and Traveler object for the ConsoleView object to use
        //
        Universe _gameUniverse;
        Traveler _gameTraveler;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Traveler gameTraveler, Universe gameUniverse)
        {
            _gameTraveler = gameTraveler;
            _gameUniverse = gameUniverse;

            InitializeConsole();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize all console settings
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "The TARDIS Project";
            ConsoleUtil.HeaderText = "The TARDIS Project";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.HeaderText = "Exit";
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            ConsoleUtil.DisplayMessage("Thank you for playing The TARDIS Project. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }

        /// <summary>
        /// display message indicating the traveler is out of lives
        /// </summary>
        public void DisplayOutOfLives()
        {
            ConsoleUtil.HeaderText = "Exit";
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            ConsoleUtil.DisplayMessage("It appears that you are out of lives in for this game. Pleaser return and play again.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("The TARDIS Project");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Written by John Velis");
            ConsoleUtil.DisplayMessage("Northwestern Michigan College");
            Console.WriteLine();

            //
            // TODO update opening screen
            //

            sb.Clear();
            sb.AppendFormat("You have been hired by the Norlon Corporation to participate ");
            sb.AppendFormat("in its latest endeavor, the TARDIS Project. Your mission is to ");
            sb.AppendFormat("test the limits of the new TARDIS Machine and report back to ");
            sb.AppendFormat("the Norlon Corporation.");
            ConsoleUtil.DisplayMessage(sb.ToString());
            Console.WriteLine();

            sb.Clear();
            sb.AppendFormat("Your first task will be to set up the initial parameters of your mission.");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new Traveler object
        /// </summary>
        public void DisplayMissionSetupIntro()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Mission Setup";
            ConsoleUtil.DisplayReset();

            //
            // display intro
            //
            ConsoleUtil.DisplayMessage("You will now be prompted to enter the starting parameters of your mission.");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a message confirming mission setup
        /// </summary>
        public void DisplayMissionSetupConfirmation()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Mission Setup";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.HeaderText = "Mission Setup";
            ConsoleUtil.DisplayReset();

            //
            // display confirmation
            //
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Your mission setup is complete.");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("To view your TARDIS traveler information use the Main Menu.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get player's name
        /// </summary>
        /// <returns>name as a string</returns>
        public string DisplayGetTravelersName()
        {
            string travelersName;

            //
            // display header
            //
            ConsoleUtil.HeaderText = "Traveler's Name";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("Enter your name: ");
            travelersName = Console.ReadLine();

            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($"You have indicated {travelersName} as your name.");

            DisplayContinuePrompt();

            return travelersName;
        }

        /// <summary>
        /// get and validate the player's race
        /// </summary>
        /// <returns>race as a RaceType</returns>
        public Traveler.RaceType DisplayGetTravelersRace()
        {
            bool validResponse = false;
            Traveler.RaceType travelersRace = Traveler.RaceType.None;

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "Traveler's Race";
                ConsoleUtil.DisplayReset();

                //
                // display all race types on a line
                //
                ConsoleUtil.DisplayMessage("Races");
                StringBuilder sb = new StringBuilder();
                foreach (Character.RaceType raceType in Enum.GetValues(typeof(Character.RaceType)))
                {
                    if (raceType != Character.RaceType.None)
                    {
                        sb.Append($" [{raceType}] ");
                    }

                }
                ConsoleUtil.DisplayMessage(sb.ToString());

                ConsoleUtil.DisplayPromptMessage("Enter your race: ");

                //
                // validate user response for race
                //
                if (Enum.TryParse<Character.RaceType>(Console.ReadLine(), out travelersRace))
                {
                    validResponse = true;
                    ConsoleUtil.DisplayReset();
                    ConsoleUtil.DisplayMessage($"You have indicated {travelersRace} as your race type.");
                }
                else
                {
                    ConsoleUtil.DisplayMessage("You must limit your race to the list above.");
                    ConsoleUtil.DisplayMessage("Please reenter your race.");
                }

                DisplayContinuePrompt();
            }

            return travelersRace;
        }

        /// <summary>
        /// get and validate the player's TARDIS destination
        /// </summary>
        /// <returns>space-time location</returns>
        public SpaceTimeLocation DisplayGetTravelersNewDestination()
        {
            bool validResponse = false;
            int locationID;
            SpaceTimeLocation nextSpaceTimeLocation = new SpaceTimeLocation();

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "TARDIS Destination";
                ConsoleUtil.DisplayReset();

                //
                // display a table of space-time locations
                //
                DisplayTARDISDestinationsTable();

                //
                // get and validate user's response for a space-time location
                //
                ConsoleUtil.DisplayPromptMessage("Choose the TARDIS destination by entering the ID: ");

                //
                // user's response is an integer
                //
                if (int.TryParse(Console.ReadLine(), out locationID))
                {
                    ConsoleUtil.DisplayMessage("");

                    try
                    {
                        nextSpaceTimeLocation = _gameUniverse.GetSpaceTimeLocationByID(locationID);

                        ConsoleUtil.DisplayReset();
                        ConsoleUtil.DisplayMessage($"You have indicated {nextSpaceTimeLocation.Name} as your TARDIS destination.");
                        ConsoleUtil.DisplayMessage("");

                        if (nextSpaceTimeLocation.Accessable == true)
                        {
                            validResponse = true;
                            ConsoleUtil.DisplayMessage("You will be transported immediately.");
                        }
                        else
                        {
                            ConsoleUtil.DisplayMessage("It appears this destination is not available to you at this time.");
                            ConsoleUtil.DisplayMessage("Please make another choice.");
                        }
                    }
                    //
                    // user's response was not in the correct range
                    //
                    catch (ArgumentOutOfRangeException ex)
                    {
                        ConsoleUtil.DisplayMessage("It appears you entered an invalid location ID.");
                        ConsoleUtil.DisplayMessage(ex.Message);
                        ConsoleUtil.DisplayMessage("Please try again.");
                    }
                }
                //
                // user's response was not an integer
                //
                else
                {
                    ConsoleUtil.DisplayMessage("It appears you did not enter a number for the location ID.");
                    ConsoleUtil.DisplayMessage("Please try again.");
                }

                DisplayContinuePrompt();
            }

            return nextSpaceTimeLocation;
        }

        /// <summary>
        /// generate a table of space-time location names and ids
        /// </summary>
        public void DisplayTARDISDestinationsTable()
        {
            //
            // table headings
            //
            ConsoleUtil.DisplayMessage("ID".PadRight(10) + "Name".PadRight(20));
            ConsoleUtil.DisplayMessage("---".PadRight(10) + "-------------".PadRight(20));

            //
            // location name and id
            //
            foreach (SpaceTimeLocation location in _gameUniverse.SpaceTimeLocations)
            {
                ConsoleUtil.DisplayMessage(location.SpaceTimeLocationID.ToString().PadRight(10) + location.Name.PadRight(20));
            }
        }

        /// <summary>
        /// generate a table of item names and ids
        /// </summary>
        public void DisplayItemTable(List<Item> items)
        {
            //
            // table headings
            //
            ConsoleUtil.DisplayMessage("ID".PadRight(10) + "Name".PadRight(20));
            ConsoleUtil.DisplayMessage("---".PadRight(10) + "-------------".PadRight(20));

            //
            // item name and id
            //
            foreach (Item item in items)
            {
                ConsoleUtil.DisplayMessage(item.GameObjectID.ToString().PadRight(10) + item.Name.PadRight(20));
            }
        }

        /// <summary>
        /// generate a table of treasure names and ids
        /// </summary>
        public void DisplayTreasureTable(List<Treasure> treasures)
        {
            //
            // table headings
            //
            ConsoleUtil.DisplayMessage("ID".PadRight(10) + "Name".PadRight(20));
            ConsoleUtil.DisplayMessage("---".PadRight(10) + "-------------".PadRight(20));

            //
            // treasure name and id
            //
            foreach (Treasure treasure in treasures)
            {
                ConsoleUtil.DisplayMessage(treasure.GameObjectID.ToString().PadRight(10) + treasure.Name.PadRight(20));
            }
        }

        /// <summary>
        /// generate a table of item names and ids
        /// </summary>
        public void DisplayDalekTable(List<Dalek> daleks)
        {
            //
            // table headings
            //
            ConsoleUtil.DisplayMessage("ID".PadRight(10) + "Name".PadRight(20));
            ConsoleUtil.DisplayMessage("---".PadRight(10) + "-------------".PadRight(20));

            //
            // item name and id
            //
            foreach (Dalek dalek in daleks)
            {
                ConsoleUtil.DisplayMessage(dalek.CharacterID.ToString().PadRight(10) + dalek.Name.PadRight(20));
            }
        }

        /// <summary>
        /// get the action choice from the user
        /// </summary>
        public TravelerAction DisplayGetTravelerActionChoice()
        {
            TravelerAction travelerActionChoice = TravelerAction.None;
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.HeaderText = "Traveler Action Choice";
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                DisplayGameStatus();

                //
                // display the menu
                //
                Console.WriteLine(
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Traveler Actions" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "A. Look Around" + Environment.NewLine +
                    "\t" + "B. Look At" + Environment.NewLine +
                    "\t" + "C. Talk To" + Environment.NewLine +
                    "\t" + "D. Pick Up Item" + Environment.NewLine +
                    "\t" + "E. Pick Up Treasure" + Environment.NewLine +
                    "\t" + "F. Put Down Item" + Environment.NewLine +
                    "\t" + "G. Put Down Treasure" + Environment.NewLine +
                    "\t" + "H. Travel" + Environment.NewLine +
                    "\t" + "I. Battle" + Environment.NewLine +
                    //
                    // commented out when not debugging
                    //
                    //"\t" + Environment.NewLine +
                    //"\t" + "**************************" + Environment..NewLine +
                    //"\t" + "Traveler Information" + Environment.NewLine +
                    //"\t" + "**************************" + Environment.NewLine +
                    //"\t" + "J. Display General Traveler Info" + Environment.NewLine +
                    //"\t" + "K. Display Traveler Inventory" + Environment.NewLine +
                    //"\t" + "L. Display Traveler Treasure" + Environment.NewLine +
                    //"\t" + Environment.NewLine +
                    //"\t" + "**************************" + Environment.NewLine +
                    //"\t" + "Game Information" + Environment.NewLine +
                    //"\t" + "**************************" + Environment.NewLine +
                    //"\t" + "M. Display All TARDIS Destinations" + Environment.NewLine +
                    //"\t" + "N. Display All Game Items" + Environment.NewLine +
                    //"\t" + "O. Display All Game Treasures" + Environment.NewLine +
                    //
                    "\t" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Q. Quit" + Environment.NewLine);

                ConsoleUtil.DisplayMessage("What would you like to do (Type Letter).");
                Console.WriteLine();

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case 'A':
                    case 'a':
                        travelerActionChoice = TravelerAction.LookAround;
                        usingMenu = false;
                        break;
                    case 'B':
                    case 'b':
                        travelerActionChoice = TravelerAction.LookAt;
                        usingMenu = false;
                        break;
                    case 'C':
                    case 'c':
                        travelerActionChoice = TravelerAction.TalkTo;
                        usingMenu = false;
                        break;
                    case 'D':
                    case 'd':
                        travelerActionChoice = TravelerAction.PickUpItem;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        travelerActionChoice = TravelerAction.PickUpTreasure;
                        usingMenu = false;
                        break;
                    case 'F':
                    case 'f':
                        travelerActionChoice = TravelerAction.PutDownItem;
                        usingMenu = false;
                        break;
                    case 'G':
                    case 'g':
                        travelerActionChoice = TravelerAction.PutDownTreasure;
                        usingMenu = false;
                        break;
                    case 'H':
                    case 'h':
                        travelerActionChoice = TravelerAction.Travel;
                        usingMenu = false;
                        break;
                    case 'I':
                    case 'i':
                        travelerActionChoice = TravelerAction.Battle;
                        usingMenu = false;
                        break;
                    case 'J':
                    case 'j':
                        travelerActionChoice = TravelerAction.TravelerInfo;
                        usingMenu = false;
                        break;
                    case 'K':
                    case 'k':
                        travelerActionChoice = TravelerAction.TravelerInventory;
                        usingMenu = false;
                        break;
                    case 'L':
                    case 'l':
                        travelerActionChoice = TravelerAction.TravelerTreasure;
                        usingMenu = false;
                        break;
                    case 'M':
                    case 'm':
                        travelerActionChoice = TravelerAction.ListTARDISDestinations;
                        usingMenu = false;
                        break;
                    case 'n':
                    case 'N':
                        travelerActionChoice = TravelerAction.ListItems;
                        usingMenu = false;
                        break;
                    case 'O':
                    case 'o':
                        travelerActionChoice = TravelerAction.ListTreasures;
                        usingMenu = false;
                        break;
                    case 'Q':
                    case 'q':
                        travelerActionChoice = TravelerAction.Exit;
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue or the ESC key to quit the application.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;

            return travelerActionChoice;
        }

        /// <summary>
        /// display the game status variables
        /// </summary>
        private void DisplayGameStatus()
        {
            Console.Write(
                "\t" + Environment.NewLine +
                "\t" + $"***************************"           + Environment.NewLine +
                "\t" + $"        Game Status "                  + Environment.NewLine +
                "\t" + $""                                      + Environment.NewLine +
                "\t" + $" Health: {_gameTraveler.Health}"       + Environment.NewLine +
                "\t" + $" Lives: {_gameTraveler.Lives}"         + Environment.NewLine +
                "\t" + $"***************************"           + Environment.NewLine);
            Console.WriteLine();
        }

        /// <summary>
        /// get the traveler's BattleAction choice
        /// </summary>
        /// <returns>BattleAction</returns>
        public BattleAction DisplayGetBattleActionChoice()
        {
            BattleAction battleActionChoice = BattleAction.None;

            ConsoleUtil.HeaderText = "Choose a Battle Action";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Enter one of the following actions.");
            ConsoleUtil.DisplayMessage("");
            foreach (BattleAction action in Enum.GetValues(typeof(BattleAction)))
            {
                ConsoleUtil.DisplayMessage(action.ToString());
            }

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayPromptMessage("Enter your battle action:");

            // TODO validate
            Enum.TryParse<BattleAction>(Console.ReadLine(), out battleActionChoice);

            DisplayContinuePrompt();

            return battleActionChoice;
        }

        /// <summary>
        /// display the results of the battle based on the BattleResult
        /// </summary>
        /// <param name="battleResult"></param>
        public void DisplayBattleResults(BattleResult battleResult)
        {
            ConsoleUtil.HeaderText = "Battle Results";
            ConsoleUtil.DisplayReset();

            switch (battleResult)
            {
                case BattleResult.TravelerWins:
                    ConsoleUtil.DisplayMessage("You have dispatched the Dalek! Congratulations!");
                    break;
                case BattleResult.NPCWins:
                    ConsoleUtil.DisplayMessage("I am sorry to say that the Dalek was too much for you.");
                    ConsoleUtil.DisplayMessage("You were quickly dispatched by the Dalek.");
                    break;
                case BattleResult.TravelerRetreats:
                    ConsoleUtil.DisplayMessage("The Dalek fires a burst of energy over your head as you retreat.");
                    ConsoleUtil.DisplayMessage("You run screaming like a little baby!");
                    break;
                case BattleResult.NPCRetreats:
                    ConsoleUtil.DisplayMessage("Frightened by your obvious fighting prowess, the Dalek retreats in fear!");
                    break;
                case BattleResult.Draw:
                    ConsoleUtil.DisplayMessage("The battle was fierce. You and the Dalek are spent, crawling away to fight another day.");
                    break;
                case BattleResult.BothRetreat:
                    ConsoleUtil.DisplayMessage("You are both cowards and the Gods watch as both of you run form each other yelling!");
                    break;
                default:
                    break;
            }

            DisplayContinuePrompt();
        }


        /// <summary>
        /// display information about the current space-time location
        /// </summary>
        public void DisplayLookAround()
        {
            ConsoleUtil.HeaderText = "Current Space-Time Location Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage(_gameUniverse.GetSpaceTimeLocationByID(_gameTraveler.SpaceTimeLocationID).Description);

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in current location.");
            foreach (Item item in _gameUniverse.GetItemtsBySpaceTimeLocationID(_gameTraveler.SpaceTimeLocationID))
            {
                ConsoleUtil.DisplayMessage(item.Name + " - " + item.Description);
            }

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Treasures in current location.");
            foreach (Treasure treasure in _gameUniverse.GetTreasuresBySpaceTimeLocationID(_gameTraveler.SpaceTimeLocationID))
            {
                ConsoleUtil.DisplayMessage(treasure.Name + " - " + treasure.Description);
            }

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Daleks in current location.");
            foreach (Dalek dalek in _gameUniverse.GetDaleksBySpaceTimeLocationID(_gameTraveler.SpaceTimeLocationID))
            {
                ConsoleUtil.DisplayMessage(dalek.Name);
            }

            DisplayContinuePrompt();
        }



        /// <summary>
        /// display information about items and treasures in the current space-time location
        /// </summary>
        public void DisplayLookAt()
        {
            int currentSptID = _gameTraveler.SpaceTimeLocationID;
            List<Item> itemsInSpt = new List<Item>();
            List<Treasure> treasuresInSpt = new List<Treasure>();
            Item itemToLookAt = new Item();
            Treasure treasureToLookAt = new Treasure();

            itemsInSpt = _gameUniverse.GetItemtsBySpaceTimeLocationID(currentSptID);
            treasuresInSpt = _gameUniverse.GetTreasuresBySpaceTimeLocationID(currentSptID);

            ConsoleUtil.HeaderText = "Look at a Game Items in Current Location";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage(_gameUniverse.GetSpaceTimeLocationByID(currentSptID).Name);

            if (itemsInSpt != null)
            {
                ConsoleUtil.DisplayMessage("");
                ConsoleUtil.DisplayMessage("Items in current location.");
                DisplayItemTable(itemsInSpt);

                ConsoleUtil.DisplayPromptMessage(
                    "Enter the item number to view or press the Enter key to move on. "
                    ); // TODO code in validation
                int itemIDChoice;

                if (int.TryParse(Console.ReadLine(), out itemIDChoice))
                {
                    itemToLookAt = _gameUniverse.GetItemtByID(itemIDChoice);
                    ConsoleUtil.DisplayMessage(itemToLookAt.Description);

                    DisplayContinuePrompt();
                }
            }

            if (treasuresInSpt != null)
            {
                ConsoleUtil.DisplayMessage("");
                ConsoleUtil.DisplayMessage("Treasures in current location.");
                DisplayTreasureTable(treasuresInSpt);

                ConsoleUtil.DisplayPromptMessage(
                    "Enter the treasure number to view or press the Enter key to move on. "
                    ); // TODO code in validation
                int treasureIDChoice;

                if (int.TryParse(Console.ReadLine(), out treasureIDChoice))
                {
                    treasureToLookAt = _gameUniverse.GetTreasureByID(treasureIDChoice);
                    ConsoleUtil.DisplayMessage(treasureToLookAt.Description);

                    DisplayContinuePrompt();
                }
            }
        }

        /// <summary>
        /// display information about items and treasures in the current space-time location
        /// </summary>
        public void DisplayTalkTo()
        {
            int currentSptID = _gameTraveler.SpaceTimeLocationID;
            int dalekIDChoice;
            List<Dalek> dalecksInSpt = new List<Dalek>();
            Dalek dalekToTalkTo = new Dalek();

            dalecksInSpt = _gameUniverse.GetDaleksBySpaceTimeLocationID(currentSptID);

            ConsoleUtil.HeaderText = "Talk to the Daleks in Current Location";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage(_gameUniverse.GetSpaceTimeLocationByID(currentSptID).Name);

            if (dalecksInSpt != null)
            {
                ConsoleUtil.DisplayMessage("");
                ConsoleUtil.DisplayMessage("Daleks in current location.");
                DisplayDalekTable(dalecksInSpt);

                ConsoleUtil.DisplayPromptMessage(
                    "Enter the item number to view or press the Enter key to move on. "
                    ); // TODO code in validation


                if (int.TryParse(Console.ReadLine(), out dalekIDChoice))
                {
                    dalekToTalkTo = _gameUniverse.GetDalekByID(dalekIDChoice);

                    if (dalekToTalkTo.HasMessage)
                    {
                        ConsoleUtil.DisplayMessage(dalekToTalkTo.Message);
                    }
                    else
                    {
                        ConsoleUtil.DisplayMessage($"This Dalek has nothing to say {_gameTraveler.Race}.");
                    }

                    DisplayContinuePrompt();
                }
            }
        }

        /// <summary>
        /// display information about items and treasures in the current space-time location
        /// </summary>
        public Dalek DisplayGetDalekToBattle()
        {
            int currentSptID = _gameTraveler.SpaceTimeLocationID;
            int dalekIDChoice;
            List<Dalek> dalecksInSpt = new List<Dalek>();
            Dalek dalekToBattle = null;

            dalecksInSpt = _gameUniverse.GetDaleksBySpaceTimeLocationID(currentSptID);

            ConsoleUtil.HeaderText = "Battle Daleks in Current Location";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage(_gameUniverse.GetSpaceTimeLocationByID(currentSptID).Name);

            if (dalecksInSpt != null)
            {
                ConsoleUtil.DisplayMessage("");
                ConsoleUtil.DisplayMessage("Daleks in current location.");
                DisplayDalekTable(dalecksInSpt);

                ConsoleUtil.DisplayPromptMessage(
                    "Enter the item number to view or press the Enter key to move on. "
                    ); // TODO code in validation


                if (int.TryParse(Console.ReadLine(), out dalekIDChoice))
                {
                    dalekToBattle = _gameUniverse.GetDalekByID(dalekIDChoice);

                    DisplayContinuePrompt();
                }
            }
            else
            {
                ConsoleUtil.DisplayMessage("");
                ConsoleUtil.DisplayMessage("It appears there are not Daleks in here to battle.");
            }

            return dalekToBattle;
        }

        /// <summary>
        /// display a list of all TARDIS destinations
        /// <summary>
        public void DisplayListAllTARDISDestinations()
        {
            ConsoleUtil.HeaderText = "Space-Time Locations";
            ConsoleUtil.DisplayReset();

            foreach (SpaceTimeLocation location in _gameUniverse.SpaceTimeLocations)
            {
                ConsoleUtil.DisplayMessage("ID: " + location.SpaceTimeLocationID);
                ConsoleUtil.DisplayMessage("Name: " + location.Name);
                ConsoleUtil.DisplayMessage("Description: " + location.Description);
                ConsoleUtil.DisplayMessage("Accessible: " + location.Accessable);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all game items
        /// <summary>
        public void DisplayListAllGameItems()
        {
            ConsoleUtil.HeaderText = "Game Items";
            ConsoleUtil.DisplayReset();

            foreach (Item item in _gameUniverse.Items)
            {
                ConsoleUtil.DisplayMessage("ID: " + item.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + item.Name);
                ConsoleUtil.DisplayMessage("Description: " + item.Description);

                //
                // all treasure in the traveler's inventory have a SpaceTimeLocationID of 0
                //
                if (item.SpaceTimeLocationID != 0)
                {
                    ConsoleUtil.DisplayMessage("Location: " + _gameUniverse.GetSpaceTimeLocationByID(item.SpaceTimeLocationID).Name);
                }
                else
                {
                    ConsoleUtil.DisplayMessage("Location: Traveler's Inventory");
                }


                ConsoleUtil.DisplayMessage("Value: " + item.Value);
                ConsoleUtil.DisplayMessage("Can Add to Inventory: " + item.CanAddToInventory.ToString().ToUpper());
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all game treasures
        /// <summary>
        public void DisplayListAllGameTreasures()
        {
            ConsoleUtil.HeaderText = "Game Treasures";
            ConsoleUtil.DisplayReset();

            foreach (Treasure treasure in _gameUniverse.Treasures)
            {
                ConsoleUtil.DisplayMessage("ID: " + treasure.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + treasure.Name);
                ConsoleUtil.DisplayMessage("Description: " + treasure.Description);

                //
                // all treasure in the traveler's inventory have a SpaceTimeLocationID of 0
                //
                if (treasure.SpaceTimeLocationID != 0)
                {
                    ConsoleUtil.DisplayMessage("Location: " + _gameUniverse.GetSpaceTimeLocationByID(treasure.SpaceTimeLocationID).Name);
                }
                else
                {
                    ConsoleUtil.DisplayMessage("Location: Traveler's Inventory");
                }

                ConsoleUtil.DisplayMessage("Value: " + treasure.Value);
                ConsoleUtil.DisplayMessage("Can Add to Inventory: " + treasure.CanAddToInventory.ToString().ToUpper());
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler information
        /// </summary>
        public void DisplayTravelerInfo()
        {
            ConsoleUtil.HeaderText = "Traveler Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage($"Traveler's Name: {_gameTraveler.Name}");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage($"Traveler's Race: {_gameTraveler.Race}");
            ConsoleUtil.DisplayMessage("");
            string spaceTimeLocationName = _gameUniverse.GetSpaceTimeLocationByID(_gameTraveler.SpaceTimeLocationID).Name;
            ConsoleUtil.DisplayMessage($"Traveler's Current Location: {spaceTimeLocationName}");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler inventory
        /// </summary>
        public void DisplayTravelerItems()
        {
            ConsoleUtil.HeaderText = "Traveler Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Traveler Items");
            ConsoleUtil.DisplayMessage("");

            foreach (Item item in _gameTraveler.TravelersItems)
            {
                ConsoleUtil.DisplayMessage("ID: " + item.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + item.Name);
                ConsoleUtil.DisplayMessage("Description: " + item.Description);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler's treasure
        /// </summary>
        public void DisplayTravelerTreasure()
        {
            ConsoleUtil.HeaderText = "Traveler Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Traveler Treasure");
            ConsoleUtil.DisplayMessage("");

            foreach (Treasure treasure in _gameTraveler.TravelersTreasures)
            {
                ConsoleUtil.DisplayMessage("ID: " + treasure.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + treasure.Name);
                ConsoleUtil.DisplayMessage("Description: " + treasure.Description);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the id of an item to add to inventory
        /// </summary>
        /// <returns>id of desired item</returns>
        public int DisplayPickUpItem()
        {
            ConsoleUtil.HeaderText = "Pick Up Item";
            ConsoleUtil.DisplayReset();

            int itemID = 0;

            int locationID;
            locationID = _gameTraveler.SpaceTimeLocationID;

            List<Item> itemsInCurrentLocation = new List<Item>();
            itemsInCurrentLocation = _gameUniverse.GetItemtsBySpaceTimeLocationID(locationID);

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in current Location");
            ConsoleUtil.DisplayMessage("");

            DisplayItemTable(itemsInCurrentLocation);

            ConsoleUtil.DisplayPromptMessage("Enter Item Number:");
            itemID = int.Parse(Console.ReadLine()); // TODO validate ID

            DisplayContinuePrompt();

            return itemID;
        }

        /// <summary>
        /// get the id of an item to remove from inventory
        /// </summary>
        /// <returns>id of desired item</returns>
        public int DisplayPutDownItem()
        {
            ConsoleUtil.HeaderText = "Put Down Item";
            ConsoleUtil.DisplayReset();

            int itemID = 0;

            int locationID;
            locationID = _gameTraveler.SpaceTimeLocationID;

            List<Item> itemsInInventory = new List<Item>();
            itemsInInventory = _gameTraveler.TravelersItems;

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in Your Inventory");
            ConsoleUtil.DisplayMessage("");

            DisplayItemTable(itemsInInventory);

            ConsoleUtil.DisplayPromptMessage("Enter Item Number:");
            itemID = int.Parse(Console.ReadLine()); // TODO validate ID

            DisplayContinuePrompt();

            return itemID;
        }

        /// <summary>
        /// get the id of a treasure to add to inventory
        /// </summary>
        /// <returns>id of desired treasure</returns>
        public int DisplayPickUpTreasure()
        {
            ConsoleUtil.HeaderText = "Pick Up Treasure";
            ConsoleUtil.DisplayReset();

            int treasureID = 0;

            int locationID;
            locationID = _gameTraveler.SpaceTimeLocationID;

            List<Treasure> treasuresInCurrentLocation = new List<Treasure>();
            treasuresInCurrentLocation = _gameUniverse.GetTreasuresBySpaceTimeLocationID(locationID);

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in current Location");
            ConsoleUtil.DisplayMessage("");

            DisplayTreasureTable(treasuresInCurrentLocation);

            ConsoleUtil.DisplayPromptMessage("Enter Treasure Number:");
            treasureID = int.Parse(Console.ReadLine()); // TODO validate ID

            DisplayContinuePrompt();

            return treasureID;
        }

        /// <summary>
        /// get the id of a treasure to remove from inventory
        /// </summary>
        /// <returns>id of desired treasure</returns>
        public int DisplayPutDownTreasure()
        {
            ConsoleUtil.HeaderText = "Put Down Treasure";
            ConsoleUtil.DisplayReset();

            int treasureID = 0;

            int locationID;
            locationID = _gameTraveler.SpaceTimeLocationID;

            List<Treasure> treasuresInInventory = new List<Treasure>();
            treasuresInInventory = _gameTraveler.TravelersTreasures;

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Treasures in Your Inventory");
            ConsoleUtil.DisplayMessage("");

            DisplayTreasureTable(treasuresInInventory);

            ConsoleUtil.DisplayPromptMessage("Enter Treasure Number:");
            treasureID = int.Parse(Console.ReadLine()); // TODO validate ID

            DisplayContinuePrompt();

            return treasureID;
        }
        #endregion
    }
}
