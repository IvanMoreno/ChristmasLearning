using System.Collections.Generic;
using System.Linq;

namespace ChristmasLearningProject.Runtime.Domain
{
    public class Fleet
    {
        readonly IList<Boat> members = new List<Boat>();
        
        public void Join(Boat member) => members.Add(member);

        public void Move(float deltaTime)
        {
            foreach (var boat in members)
            {
                boat.Move(deltaTime);
            }
        }

        public void Rewind(float deltaTime)
        {
            if (members.All(x => x.ReachedDeparture()))
                return;
            
            foreach (var boat in members)
            {
                boat.Rewind(deltaTime);
            }
        }

        public static Fleet FromBoats(params Boat[] members)
        {
            var result = new Fleet();
            foreach (var member in members)
            {
                result.Join(member);
            }
            return result;
        }
    }
}