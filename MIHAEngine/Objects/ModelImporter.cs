using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MIHAEngine
{
    public static class ModelImporter
    {
        public static ModelData ImportOBJModel(string path)
        {
            try
            {
                Console.WriteLine("Чтение файла...");
                var text = File.ReadAllLines(path).ToList();

                ModelData model = new ModelData();

                Console.WriteLine("Извлечение координат вертикалей...");
                var verticalCoordinates = text.FindAll(x => x.StartsWith("v ")).Select(x => x.Substring(2).Split(' ')).ToArray();
                Console.WriteLine("Извлечение атрибутов граней...");
                var edgesText = text.FindAll(x => x.First().Equals('f')).Select(x => x.Substring(2).Split(' ')).ToArray();
                Console.WriteLine("Извлечение координат текстур...");
                var texturesCoordinates = text.FindAll(x => x.StartsWith("vt")).Select(x => x.Substring(3).Split(' ')).ToArray();

                Console.WriteLine("Парсинг атрибутов граней...");
                
                string[] str;
                int length1 = edgesText[0].Length;
                int length0 = edgesText.Length;

                int[,] edges = new int[length0, length1];
                int[,] textures = new int[length0, length1];

                NumberFormatInfo formatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
                
                for (int i = 0; i < length0; i++)
                {
                    for (int j = 0; j < length1; j++)
                    {
                        str = edgesText[i][j].Split("/");

                        if (str.Length > 0 && int.TryParse(str[0], out int resultE)) 
                            edges[i, j] = resultE - 1;
                        if (str.Length > 1 && int.TryParse(str[1], out int resultT)) 
                            textures[i, j] = resultT - 1;
                    }
                }
                model.edgesIndex = edges;
                model.texturesIndex = textures;

                Console.WriteLine("Парсинг координат...");
                if (verticalCoordinates.Length > 0)
                {
                    float[,] verticesС = new float[verticalCoordinates.Length, verticalCoordinates[0].Length / 2];
                    float[,] verticesСol = new float[verticesС.GetLength(0), verticesС.GetLength(1)];
                    for (int i = 0; i < verticesС.GetLength(0); i++)
                        for (int j = 0; j < verticesС.GetLength(1); j++) 
                        {
                            verticesС[i, j] = float.Parse(verticalCoordinates[i][j], formatInfo);
                            verticesСol[i, j] = float.Parse(verticalCoordinates[i][j + 3], formatInfo);
                        }
                    model.verticesСoordinates = verticesС;
                    model.colors = verticesСol;
                }
                if (texturesCoordinates.Length > 0)
                {
                    float[,] texturesС = new float[texturesCoordinates.Length, texturesCoordinates[0].Length];
                    for (int i = 0; i < texturesС.GetLength(0); i++)
                        for (int j = 0; j < texturesС.GetLength(1); j++)
                            texturesС[i, j] = float.Parse(texturesCoordinates[i][j], formatInfo);
                    model.texturesСoordinates = texturesС;
                }
  
                model.CalculateNormals();
                Console.WriteLine("Модель импортирована!\n");
                return model;
            }
            catch
            {
                Console.WriteLine("Ошибка импорта модели!\n");
                var m = ImportOBJModel("Models/Error.obj");
                m.CalculateNormals();
                return m;
            }
        }
    }
}
