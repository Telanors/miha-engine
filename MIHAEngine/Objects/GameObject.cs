using MIHAEngine.Objects;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MIHAEngine
{
    public class GameObject
    {
        private static int autoID = 0;
        public bool enable = true;
        public int ID { get; private set; }
        public string Name { get; set; }
        public Transform Transform { get; private set; } = new Transform();
        public ModelData ModelData { get; private set; }
        public ModelMaterial Material { get; private set; }
        public GameObject(string Name, ModelData ModelData, ModelMaterial Material)
        {
            this.ID = autoID++;
            this.Name = Name;
            this.ModelData = ModelData;
            this.Material = Material;
        }
        public virtual void Destroy() { }
    }
}
