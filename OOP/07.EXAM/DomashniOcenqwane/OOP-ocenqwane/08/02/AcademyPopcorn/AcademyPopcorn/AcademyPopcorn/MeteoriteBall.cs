using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        /* 06. Implement a MeteoriteBall. It should inherit the Ball class and should leave a trail of TrailObject objects. 
         *     Each trail objects should last for 3 "turns". 
         *     Other than that, the Meteorite ball should behave the same way as the normal ball. 
         *     You must NOT edit any existing .cs file.
         */
        List<GameObject> trail;
        public int TrailLife { get; set; }
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.TrailLife = 3;
        }

        public override void Update()
        {
            base.Update();
            trail = new List<GameObject>();
            trail.Add(new TrailObject(this.topLeft, new char[,] { { '.' } }, this.TrailLife));
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            return this.trail;
        }
    }
}
