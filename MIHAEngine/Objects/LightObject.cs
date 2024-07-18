using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Media3D;

namespace MIHAEngine.Objects
{
    public class LightObject : GameObject
    {
        public LightName lightName { get; private set; }

        public float[] direction = new float[] { 0.0f, 1.0f, 0.0f, 0.0f };
        public float[] diffuse = new float[] { 1.0f, 1.0f, 1.0f };
        public float[] ambient = new float[] { 1.0f, 1.0f, 1.0f };
        public float[] specular = new float[] { 1.0f, 1.0f, 1.0f };
        public float quadraticAttenuation = 0.25f;
        public float spotAngle = 180f;
        public float spotExponent = 0f;

        public LightObject(string Name, ModelData ModelData, ModelMaterial Material, LightName lightName) : base(Name, ModelData, Material)
        {
            this.lightName = lightName;
            GL.Enable((EnableCap)lightName);
        }
        public override void Destroy()
        {
            base.Destroy();
            GL.Disable((EnableCap)lightName);
        }
    }
}
