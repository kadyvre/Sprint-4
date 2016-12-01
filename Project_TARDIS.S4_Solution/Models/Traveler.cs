using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Traveler : Character
    {
        #region FIELDS

        private List<Item> _travelersItems;
        private List<Treasure> _travelersTreasures;
        private int _health;
        private int _lives;
        private int _battleIndex;
        
        #endregion

        #region PROPERTIES

        public List<Item> TravelersItems
        {
            get { return _travelersItems; }
            set { _travelersItems = value; }
        }

        public List<Treasure> TravelersTreasures
        {
            get { return _travelersTreasures; }
            set { _travelersTreasures = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public int BattleIndex
        {
            get { return _battleIndex; }
            set { _battleIndex = value; }
        }

        #endregion


        #region CONSTRUCTORS

        public Traveler()
        {
            _travelersItems = new List<Item>();
            _travelersTreasures = new List<Treasure>();
        }

        public Traveler(string name, RaceType race, int spaceTimeLocationID) : base(name, race, spaceTimeLocationID)
        {

        }

        #endregion


        #region METHODS

        /// <summary>
        /// determine if all lives are gone
        /// </summary>
        /// <returns>true if no lives left</returns>
        public bool NoLives()
        {
            return (_lives < 1);
        }

        #endregion
    }
}
