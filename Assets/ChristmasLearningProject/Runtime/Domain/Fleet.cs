using System.Collections.Generic;

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

        public void Rewind(int deltaTime)
        {
        }
    }
}