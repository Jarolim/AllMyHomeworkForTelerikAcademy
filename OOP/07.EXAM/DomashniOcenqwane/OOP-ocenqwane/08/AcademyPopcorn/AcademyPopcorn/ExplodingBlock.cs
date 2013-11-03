using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
  class ExplodingBlock : Block
  {
      public ExplodingBlock(MatrixCoords topLeft) : base(topLeft)
      {
          body = new char [,] {{'E'}};
      }

      public override IEnumerable<GameObject> ProduceObjects()
      {                   	     
          List<GameObject> list = new List<GameObject>();
          if(IsDestroyed) {
              list.Add(new Explosion(new MatrixCoords(this.TopLeft.Row - 1, this.TopLeft.Col - 1)));
              list.Add(new Explosion(new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col - 1)));
              list.Add(new Explosion(new MatrixCoords(this.TopLeft.Row - 1, this.TopLeft.Col + 1)));
              list.Add(new Explosion(new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col + 1)));
              list.Add(new Explosion(new MatrixCoords(this.TopLeft.Row    , this.TopLeft.Col - 1)));
              list.Add(new Explosion(new MatrixCoords(this.TopLeft.Row    , this.TopLeft.Col + 1)));
              list.Add(new Explosion(new MatrixCoords(this.TopLeft.Row - 1, this.TopLeft.Col    )));
              list.Add(new Explosion(new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col    )));

          }          
          return list;
      }

      public override void RespondToCollision(CollisionData collisionData)
      {
        IsDestroyed = true;
      }        
  }
}
