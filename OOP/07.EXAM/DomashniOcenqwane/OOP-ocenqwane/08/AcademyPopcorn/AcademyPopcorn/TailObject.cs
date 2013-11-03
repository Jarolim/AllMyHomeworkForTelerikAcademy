using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
  class TailObject : GameObject
  {
      public int LifeTime { get; private set; }
      public TailObject(MatrixCoords topLeft, char[,] body, int lifetime) : base(topLeft, body)
      {
          LifeTime = lifetime;
      }

      public override void Update()
      {
        LifeTime--;
        if(LifeTime <= 0) IsDestroyed = true;
      }

      public override string GetCollisionGroupString()
      {
        return base.GetCollisionGroupString();
      }
  }
}
