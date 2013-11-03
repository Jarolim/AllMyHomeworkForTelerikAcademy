using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
  class Engine1 : Engine
  {
      public Engine1(IRenderer render, IUserInterface userInterface) : base(render, userInterface)
      {}
      public void ShootPlayerRocket()
      {
        throw new NotImplementedException();
      }
  }
}
