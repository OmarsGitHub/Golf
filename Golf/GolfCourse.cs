using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class GolfCourse
    {
        //Ny
        double DistanceToGoal;

        /// <summary>
        /// Generates a "course" by giving a random distance to goal
        /// </summary>
        public void GenerateCourse()
        {
            DistanceToGoal = Random();
            GenerateRound();
        }

        /// <summary>
        /// Generates a new round on the newly created Course
        /// </summary>
        public void GenerateRound()
        {
            GolfClub newRound = new GolfClub();
            newRound.DoSwing(ref DistanceToGoal);
        }

        /// <summary>
        /// Creates a random number
        /// </summary>
        /// <returns></returns>
        public int Random()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(250, 650);
        }
    }
}
