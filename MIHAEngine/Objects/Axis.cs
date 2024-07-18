using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MIHAEngine.Objects
{
    public class Axis
    {
        public float objectAxisLength = 10f;
        public float globalAxisLength = 100f;
        public float normalAxisLength = 1f;
        public Axis() { }
        public void DrawGlobalAxis()
        {
            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Lighting);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();

            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(globalAxisLength, 0, 0);

            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, globalAxisLength, 0);

            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, globalAxisLength);
            for (float i = 1; i < globalAxisLength; i += 1)
            {
                GL.Color3(Color.Red);
                GL.Vertex3(i, 0, -0.25);
                GL.Vertex3(i, 0, 0.25);

                GL.Color3(Color.Green);
                GL.Vertex3(-0.25, i, 0);
                GL.Vertex3(0.25, i, 0);

                GL.Color3(Color.Blue);
                GL.Vertex3(-0.25, 0, i);
                GL.Vertex3(0.25, 0, i);
            }
            GL.End();

            GL.PopMatrix();
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.DepthTest);
        }
        public void DrawObjectAxis(Transform transform)
        {
            if(transform == null) return;
            GL.Disable(EnableCap.Lighting);
            GL.Disable(EnableCap.DepthTest);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();

            GL.Translate(transform.Position);
            GL.Rotate(transform.Rotation.X, 1f, 0f, 0f);
            GL.Rotate(transform.Rotation.Y, 0f, 1f, 0f);
            GL.Rotate(transform.Rotation.Z, 0f, 0f, 1f);
            GL.Scale(transform.Scale);

            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(objectAxisLength, 0, 0);

            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, objectAxisLength, 0);

            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, objectAxisLength);
            GL.End();

            GL.PopMatrix();
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.DepthTest);
        }
        public void DrawObjectNormals(GameObject gameObject)
        {
            if (gameObject == null || gameObject.ModelData.normalsСoordinates.Length == 0) return;
            GL.Disable(EnableCap.Lighting);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();

            GL.Translate(gameObject.Transform.Position);
            GL.Rotate(gameObject.Transform.Rotation.X, 1f, 0f, 0f);
            GL.Rotate(gameObject.Transform.Rotation.Y, 0f, 1f, 0f);
            GL.Rotate(gameObject.Transform.Rotation.Z, 0f, 0f, 1f);
            GL.Scale(gameObject.Transform.Scale);

            var modelData = gameObject.ModelData;

            GL.Color3(Color.DarkMagenta);
            for (int i = 0; i < modelData.edgesIndex.GetLength(0); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int vertIndex = modelData.edgesIndex[i, j];
                    GL.PushMatrix();
                    GL.Translate(modelData.verticesСoordinates[vertIndex, 0], modelData.verticesСoordinates[vertIndex, 1], modelData.verticesСoordinates[vertIndex, 2]);
                    
                    GL.Begin(PrimitiveType.Lines);
                    GL.Vertex3(0f, 0f, 0f);
                    GL.Vertex3(modelData.normalsСoordinates[i, 0] * normalAxisLength, modelData.normalsСoordinates[i, 1] * normalAxisLength, modelData.normalsСoordinates[i, 2] * normalAxisLength);
                    GL.End();

                    GL.PopMatrix();
                }
            }
            GL.PopMatrix();
            GL.Enable(EnableCap.Lighting);
        }
    }
}
