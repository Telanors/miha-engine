using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MIHAEngine
{
    public class ModelData
    {
        public float[,] verticesСoordinates;
        public float[,] normalsСoordinates;
        public float[,] texturesСoordinates;

        public int[,] edgesIndex;
        public int[,] texturesIndex;
        public float[,] colors;

        public ModelData Copy() 
        {
            ModelData copyData = new ModelData();

            copyData.verticesСoordinates = new float[verticesСoordinates.GetLength(0), verticesСoordinates.GetLength(1)];
            copyData.normalsСoordinates = new float[normalsСoordinates.GetLength(0), normalsСoordinates.GetLength(1)];
            copyData.texturesСoordinates = new float[texturesСoordinates.GetLength(0), texturesСoordinates.GetLength(1)];
            copyData.edgesIndex = new int[edgesIndex.GetLength(0), edgesIndex.GetLength(1)];
            copyData.texturesIndex = new int[texturesIndex.GetLength(0), texturesIndex.GetLength(1)];
            copyData.colors = new float[colors.GetLength(0), colors.GetLength(1)];

            Array.Copy(verticesСoordinates, copyData.verticesСoordinates, verticesСoordinates.Length);
            Array.Copy(normalsСoordinates, copyData.normalsСoordinates, normalsСoordinates.Length);
            Array.Copy(texturesСoordinates, copyData.texturesСoordinates, texturesСoordinates.Length);
            Array.Copy(edgesIndex, copyData.edgesIndex, edgesIndex.Length);
            Array.Copy(texturesIndex, copyData.texturesIndex, texturesIndex.Length);
            Array.Copy(colors, copyData.colors, colors.Length);

            return copyData;
        }
        public void CalculateNormals()
        {
            List<Vector3> normalsСoordinates = new List<Vector3>();
            for (int i = 0; i < edgesIndex.GetLength(0); i++)
            {
                int indexV1 = edgesIndex[i, 0];
                int indexV2 = edgesIndex[i, 1];
                int indexV3 = edgesIndex[i, 2];

                Vector3 vertex1 = new Vector3(verticesСoordinates[indexV1, 0], verticesСoordinates[indexV1, 1], verticesСoordinates[indexV1, 2]);
                Vector3 vertex2 = new Vector3(verticesСoordinates[indexV2, 0], verticesСoordinates[indexV2, 1], verticesСoordinates[indexV2, 2]);
                Vector3 vertex3 = new Vector3(verticesСoordinates[indexV3, 0], verticesСoordinates[indexV3, 1], verticesСoordinates[indexV3, 2]);

                Vector3 dV1 = vertex2 - vertex1;
                Vector3 dV2 = vertex3 - vertex1;

                Vector3 normal = Vector3.Normalize(Vector3.Cross(dV1, dV2));

                normalsСoordinates.Add(normal);
            }
            this.normalsСoordinates = new float[normalsСoordinates.Count, 3];
            for (int i = 0; i < normalsСoordinates.Count; i++)
            {
                this.normalsСoordinates[i, 0] = normalsСoordinates[i].X;
                this.normalsСoordinates[i, 1] = normalsСoordinates[i].Y;
                this.normalsСoordinates[i, 2] = normalsСoordinates[i].Z;
            } 
        }
    }
}
