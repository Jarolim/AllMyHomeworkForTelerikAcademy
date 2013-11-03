using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Engine
    {
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<GameObject> staticObjects;
        Racket playerRacket;

        public Engine(IRenderer renderer, IUserInterface userInterface)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
        }

        /* 02. The Engine class has a hardcoded sleep time (search for "System.Threading.Sleep(500)". 
         * Make the sleep time a field in the Engine and implement a constructor, which takes it as an additional parameter.
         */
        //field
        private int iSleepTime = 500;
        // property
        public int ISleepTime
        {
            get { return iSleepTime; }
            set { iSleepTime = value; }
        }
        //constructor
        public Engine(IRenderer renderer, IUserInterface userInterface, int iSleepTime)
            : this(renderer, userInterface)
        {
            this.iSleepTime = iSleepTime;
        }

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                if (obj is Racket)
                {
                    AddRacket(obj);

                }
                else
                {
                    this.AddStaticObject(obj);
                }
            }
        }

        private void AddRacket(GameObject obj)
        {
            //TODO: we should remove the previous racket from this.allObjects
           /* 03. Search for a "TODO" in the Engine class, regarding the AddRacket method. 
            * Solve the problem mentioned there. There should always be only one Racket. 
            * Note: comment in TODO not completely correct
            */

            this.playerRacket = obj as Racket;
            this.allObjects.RemoveAll(x => x is Racket); // should be always one racket
            this.AddStaticObject(obj);
        }

        public virtual void MovePlayerRacketLeft()
        {
            this.playerRacket.MoveLeft();
        }

        public virtual void MovePlayerRacketRight()
        {
            this.playerRacket.MoveRight();
        }

        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();

               // System.Threading.Thread.Sleep(500);
                System.Threading.Thread.Sleep(iSleepTime);

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }
            }
        }
    }
}
