using MIHAEngine.Objects;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing.Imaging;
using System.Windows.Media.Media3D;

namespace MIHAEngine
{
    public class EngineRenderer
    {
        public Action OnRender;
        public EngineRenderer() { }
        public void Initialization(Color4 color)
        {
            GL.ClearColor(color);
            GL.LineWidth(3);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.ColorMaterial);
            
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);
        }
        public LightName FindFreeLight()
        {
            LightName lightName = LightName.Light0;
            int maxLight = GL.GetInteger(GetPName.MaxLights);
            for (int i = 0; i < maxLight; i++)
            {
                lightName = LightName.Light0 + i;
                if (!GL.IsEnabled(EnableCap.Light0 + i))
                {
                    return lightName;
                }
            }
            return 0;
        }
        public void SetPolygonMode(PolygonMode polygonMode)
        {
            GL.PolygonMode(MaterialFace.FrontAndBack, polygonMode);
        }
        public void SetLight(bool enable)
        { 
            switch (enable)
            {
                case false:
                    GL.Disable(EnableCap.Lighting);
                    break;
                case true:
                    GL.Enable(EnableCap.Lighting);
                    break;
            }
        }
        public void SetCullFace(bool enable)
        {
            switch (enable)
            {
                case false:
                    GL.Disable(EnableCap.CullFace);
                    break;
                case true:
                    GL.Enable(EnableCap.CullFace);
                    break;
            }
        }
        public void SetViewport(int x, int y, int width, int height)
        {
            GL.Viewport(x, y, width, height);
        }
        public void SetProjection(Matrix4 projection)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void Render(GameObject[] gameObjects, double deltaTime) 
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);

            foreach (var obj in gameObjects)
            {
                if (!obj.enable) continue;
                GL.PushMatrix();
                DrawObject(obj.Transform, obj.ModelData, obj.Material);
                var light = obj as LightObject;
                if (light != null)
                {
                    GL.PushMatrix();
                    DrawLight(light);
                    GL.PopMatrix();
                }
                GL.PopMatrix();
            }

            OnRender?.Invoke();
        }

        public void DrawObject(Transform transform, ModelData modelData, ModelMaterial material)
        {
            GL.Translate(transform.Position);
            GL.Rotate(transform.Rotation.X, 1f, 0f, 0f);
            GL.Rotate(transform.Rotation.Y, 0f, 1f, 0f);
            GL.Rotate(transform.Rotation.Z, 0f, 0f, 1f);
            GL.Scale(transform.Scale);

            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, material.specular);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Diffuse, material.diffuse);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Ambient, material.ambient);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, material.shininess);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Emission, material.emission);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.ColorIndexes, material.colorIndexes);

            if (modelData == null) return;
            if (material.textureID != 0)
            {
                GL.BindTexture(TextureTarget.Texture2D, material.textureID);
                GL.Enable(EnableCap.Texture2D);
            }
            if (material.cullMode <= 0) SetCullFace(false);
            GL.CullFace(material.cullMode);
            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < modelData.edgesIndex.GetLength(0); i++)
            {
                if(modelData.normalsСoordinates.Length != 0)
                    GL.Normal3(modelData.normalsСoordinates[i, 0], modelData.normalsСoordinates[i, 1], modelData.normalsСoordinates[i, 2]);
                for (int j = 0; j < 3; j++)
                {
                    int vertIndex = modelData.edgesIndex[i, j];
                    int textIndex = modelData.texturesIndex[i, j];
                    GL.TexCoord2(modelData.texturesСoordinates[textIndex, 0], modelData.texturesСoordinates[textIndex, 1]);
                    GL.Color4(modelData.colors[vertIndex, 0], modelData.colors[vertIndex, 1], modelData.colors[vertIndex, 2], material.alpha);
                    GL.Vertex3(modelData.verticesСoordinates[vertIndex, 0], modelData.verticesСoordinates[vertIndex, 1], modelData.verticesСoordinates[vertIndex, 2]);
                }
            }
            GL.End();
            SetCullFace(true);
            GL.Disable(EnableCap.Texture2D);
        }
        public void DrawLight(LightObject light) 
        {
            GL.LoadIdentity();
            GL.Light(light.lightName, LightParameter.Position, new float[] { light.Transform.Position.X, light.Transform.Position.Y, light.Transform.Position.Z, 1f });
            GL.Light(light.lightName, LightParameter.Diffuse, light.diffuse);
            GL.Light(light.lightName, LightParameter.Ambient, light.ambient);
            GL.Light(light.lightName, LightParameter.Specular, light.specular);
            GL.Light(light.lightName, LightParameter.LinearAttenuation, light.quadraticAttenuation);
            GL.Light(light.lightName, LightParameter.SpotDirection, light.direction);
            GL.Light(light.lightName, LightParameter.SpotCutoff, light.spotAngle);
            GL.Light(light.lightName, LightParameter.SpotExponent, light.spotExponent);
        }
    }
}
