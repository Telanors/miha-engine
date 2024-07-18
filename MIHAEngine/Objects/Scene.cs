using MIHAEngine.Objects;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIHAEngine
{
    public class Scene
    {
        private List<GameObject> objectsList;
        private GameObject[] objectsArray;
        public GameObject[] ObjectsArray => objectsArray;
        public Scene(params GameObject[] Objects)
        {
            objectsList = new List<GameObject>();
            objectsList.AddRange(Objects);
            objectsArray = objectsList.ToArray();
        }
        public void AddObject(GameObject gameObject)
        {
            objectsList.Add(gameObject);
            objectsArray = objectsList.ToArray();
        }
        public void AddObject(GameObject[] gameObjects)
        {
            objectsList.AddRange(gameObjects);
            objectsArray = objectsList.ToArray();
        }
        public void DestroyObject(GameObject gameObject)
        {
            objectsList.Remove(gameObject);
            gameObject.Destroy();
            objectsArray = objectsList.ToArray();
        }
        public GameObject FindObject(int ID)
        {
            foreach (GameObject obj in objectsList)
            {
                if (obj.ID == ID) return obj;
            }
            return null;
        }
        public GameObject FindObject(string Name)
        {
            foreach (GameObject obj in objectsList)
            {
                if (obj.Name == Name) return obj;
            }
            return null;
        } 
        public GameObject[] FindAllObject(string Name) 
        { 
            return  objectsList.FindAll(x => x.Name.StartsWith(Name)).ToArray();
        }
    }
}
