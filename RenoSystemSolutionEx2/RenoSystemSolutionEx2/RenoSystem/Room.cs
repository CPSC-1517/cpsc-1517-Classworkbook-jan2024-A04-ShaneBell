using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenoSystem
{
    public class Room
    {
        //data members

        private string _Name;

        //properties

        public string Flooring
        {
            get;
            set;
        }
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name is missing! Please provide a name for the room.");
                }

                _Name = value.Trim();
            }
        }
        public int TotalWalls
        {
            get
            {
                return Walls.Count;
            }
        }
        public List<Wall> Walls
        {
            get;
            private set;
        }

        //behaviours

        public Room(string name, string flooring, List<Wall> walls)
        {
            Name = name;
            Flooring = flooring;

            if (walls != null)
            {
                Walls = walls;
            }

            else
            {
                Walls = new List<Wall>();
            }
        }
        public void AddWall(Wall wall)
        {
            if (wall is null)
            {
                throw new ArgumentNullException("Wall required!.");
            }

            //looking for a duplicate in list.

            bool wallexist = false;

            foreach (var item in Walls)
            {
                if (item.PlanId == wall.PlanId)
                {
                    wallexist = true;
                }
            }

            //students can use Linq query
            //wallexist = Walls.Any(x => x.PlanId.Equals(wall.PlanId));

            if (wallexist)
            {
                throw new ArgumentException($"Duplicate plan identifier: {wall.PlanId} Please choose another PlanId");
            }


            Walls.Add(wall);
        }
        public void RemoveWall(string planid)
        {
            if (string.IsNullOrWhiteSpace(planid))
            {
                throw new ArgumentNullException("Plan Id required!.");
            }
            //looking for a duplicate in list.

            Wall wallexist = null;

            foreach (var item in Walls)
            {
                if (item.PlanId.Equals(planid))
                {
                    wallexist = item;
                }
            }

            //students can use Linq query
            //wallexist = Walls.FirstOrDefault(x => x.PlanId.Equals(planid));

            if (wallexist == null)
            {
                throw new ArgumentException($"Plan {planid} does not exist for room. Please choose another PlanId");
            }


            Walls.Remove(wallexist);
        }
    }
}
