using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
  class UnpassableBlock : Block
  {
      public new const string CollisionGroupString = "unpassableblock";
      public UnpassableBlock(MatrixCoords topLeft) : base(topLeft)
      {
        body = new char[1,1] {{'U'}};
      }

      public override bool CanCollideWith(string otherCollisionGroupString)
      {
        return base.CanCollideWith(otherCollisionGroupString) || otherCollisionGroupString == "unstopableball";
      }

      public override void RespondToCollision(CollisionData collisionData)
      {
        IsDestroyed = false;
      }

      public override string GetCollisionGroupString()
      {
        return CollisionGroupString;
      }

  }
}
