using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnpassableBlocks : Block
    {
        /* 08.A) Implement an UnstoppableBall and an UnpassableBlock. 
         *     The UnstopableBall only bounces off UnpassableBlocks and will destroy any other block it passes through. 
         *     The UnpassableBlock should be indestructible. Hint: Take a look at the RespondToCollision method, 
         *     the GetCollisionGroupString method and the CollisionData class.
         *
         */
        public const char Symbol = ']';
        public new const string CollisionGroupString = "unpassableBlock";
 
        public UnpassableBlocks(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = UnpassableBlocks.Symbol;
 
        }
        public override string GetCollisionGroupString()
        {
            return UnpassableBlocks.CollisionGroupString;
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            //base.RespondToCollision(collisionData);
        }
   }
}
