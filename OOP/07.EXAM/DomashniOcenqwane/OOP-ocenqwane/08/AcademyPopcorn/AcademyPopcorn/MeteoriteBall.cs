using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
  class MeteoriteBall : Ball
  {
      public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed) : base(topLeft, speed)
      {
      }


      public override IEnumerable<GameObject> ProduceObjects()
      {
        List<GameObject> list = new List<GameObject>();
        list.Add(new TailObject(this.topLeft, new char[1,1]{{'.'}}, 3));
        return list;
      }        
  }
}
