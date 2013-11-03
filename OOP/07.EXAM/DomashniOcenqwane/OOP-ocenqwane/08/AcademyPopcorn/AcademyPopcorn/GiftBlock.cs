using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
  class GiftBlock : Block
  {
      public GiftBlock(MatrixCoords topLeft) : base(topLeft)
      {
           body = new char[1,1] {{'g'}};
      }

      public override void RespondToCollision(CollisionData collisionData)
      {
        IsDestroyed = true;
      }

      public override IEnumerable<GameObject> ProduceObjects()
      {
        List<Gift> gift = new List<Gift>();
        if(IsDestroyed)
        {
             gift.Add(new Gift(TopLeft));
        }
        return gift;
      }
  }
}
