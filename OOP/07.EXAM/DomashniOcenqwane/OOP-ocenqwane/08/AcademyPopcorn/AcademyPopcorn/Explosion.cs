using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
  class Explosion : MovingObject
  {
      public new const string CollisionGroupString = "ball";
      public Explosion(MatrixCoords topLeft) : base(topLeft, new char[,] {{'*'}}, new MatrixCoords(0,0))
      {
      }

      public override bool CanCollideWith(string otherCollisionGroupString)
      {
          return otherCollisionGroupString == "block";
      }

      public override void RespondToCollision(CollisionData collisionData)
      {
        IsDestroyed = true;
      }

      public override void Update()
      {
        IsDestroyed = true;
      }

      public override string GetCollisionGroupString()
      {
        return CollisionGroupString;
      }
  }
}
