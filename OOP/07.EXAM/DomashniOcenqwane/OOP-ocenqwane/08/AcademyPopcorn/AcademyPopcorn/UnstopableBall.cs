using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnstopableBall : Ball
    {
        public new const string CollisionGroupString = "unstopableball";
        public UnstopableBall(MatrixCoords topLeft, MatrixCoords speed) : base(topLeft, speed)
        {
            body = new char[1,1]{{'O'}};
        }
    
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
          return otherCollisionGroupString == "unpassableblock" || base.CanCollideWith(otherCollisionGroupString);
        }

        public override string GetCollisionGroupString()
        {
          return CollisionGroupString;
        }
    
        public override void RespondToCollision(CollisionData collisionData)
        {
            IsDestroyed = false;
            foreach(var obj in collisionData.hitObjectsCollisionGroupStrings)
            {
                if(obj == "unpassableblock" || obj == "racket" || obj == "indestructibleblock")
                {
                    if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                    {
                        this.Speed.Row *= -1;
                    }
                    if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                    {
                        this.Speed.Col *= -1;
                    }
                }
            }
        }  
    }
}
