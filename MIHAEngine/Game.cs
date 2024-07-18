using System;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using WindowState = OpenTK.Windowing.Common.WindowState;
using MIHAEngine.Objects;

namespace MIHAEngine
{
    public class MainWindow : GameWindow
    {
        public Action GameLoad;
        public Camera Camera { get; private set; }
        public EngineRenderer Engine { get; private set; }
        public InputController InputController { get; private set; }
        public Scene Scene { get; private set; }
        public MainWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings) 
        {
            InputController = new InputController(MouseState, KeyboardState);
            Engine = new EngineRenderer();
            Scene = new Scene();
            Camera = new Camera(Size, 75, 0.1f, 1000f);
        }
        protected override void OnLoad()
        {
            base.OnLoad();
            //Engine.Initialization(Color4.SkyBlue);
            //Engine.Initialization(new Color4(0.031f, 0.051f, 0.031f, 1f));
            Engine.Initialization(new Color4(0.031f, 0.031f, 0.062f, 1f));
            Engine.SetCullFace(true);
            Engine.SetLight(true);

            CursorState = CursorState.Grabbed;

            Camera.Transform.Position = new Vector3(0, 10f, -5f);
            Camera.Transform.Rotation = new Vector3(0, 0, 0);

            ModelMaterial material = new ModelMaterial()
            {
                emission = new[] { 0f, 0f, 0f },
                specular = new[] { 0.25f, 0.25f, 0.25f },
                diffuse = new[] { 0f, 0f, 0f },
                shininess = new[] { 0f, 0f, 0f },
                ambient = new[] { 1f, 1f, 1f},
                colorIndexes = new[] { 0f, 1f, 1f }
            };
            ModelMaterial material1 = new ModelMaterial()
            {
                emission = new[] { 0f, 0f, 0f },
                specular = new[] { 0.25f, 0.25f, 0.25f },
                diffuse = new[] { 0f, 0f, 0f },
                shininess = new[] { 0f, 0f, 0f },
                ambient = new[] { 1f, 1f, 1f },
                colorIndexes = new[] { 0f, 1f, 1f }
            };
            ModelMaterial material2 = new ModelMaterial()
            {
                emission = new[] { 0f, 0f, 0f },
                specular = new[] { 0.25f, 0.25f, 0.25f },
                diffuse = new[] { 0f, 0f, 0f },
                shininess = new[] { 0f, 0f, 0f },
                ambient = new[] { 1f, 1f, 1f },
                colorIndexes = new[] { 0f, 1f, 1f }
            };
            ModelMaterial material3 = new ModelMaterial()
            {
                emission = new[] { 0f, 0f, 0f },
                specular = new[] { 0.25f, 0.25f, 0.25f },
                diffuse = new[] { 0f, 0f, 0f },
                shininess = new[] { 0f, 0f, 0f },
                ambient = new[] { 1f, 1f, 1f },
                colorIndexes = new[] { 0f, 1f, 1f }
            };
            ModelMaterial material4 = new ModelMaterial()
            {
                emission = new[] { 0f, 0f, 0f },
                specular = new[] { 0.25f, 0.25f, 0.25f },
                diffuse = new[] { 0f, 0f, 0f },
                shininess = new[] { 0f, 0f, 0f },
                ambient = new[] { 1f, 1f, 1f },
                colorIndexes = new[] { 0f, 1f, 1f }
            };
            ModelMaterial material5 = new ModelMaterial()
            {
                emission = new[] { 0f, 0f, 0f },
                specular = new[] { 0.25f, 0.25f, 0.25f },
                diffuse = new[] { 0f, 0f, 0f },
                shininess = new[] { 0f, 0f, 0f },
                ambient = new[] { 1f, 1f, 1f },
                colorIndexes = new[] { 0f, 1f, 1f }
            };
            ModelMaterial materialLight = new ModelMaterial()
            {
                emission = new[] { 0f, 0f, 0f },
                specular = new[] { 0.25f, 0.25f, 0.25f },
                diffuse = new[] { 0f, 0f, 0f },
                shininess = new[] { 0f, 0f, 0f },
                ambient = new[] { 1f, 1f, 1f },
                colorIndexes = new[] { 0f, 1f, 1f }
            };
            ModelMaterial materialGLight = new ModelMaterial()
            {
                emission = new[] { 0f, 0f, 0f },
                specular = new[] { 0.25f, 0.25f, 0.25f },
                diffuse = new[] { 0f, 0f, 0f },
                shininess = new[] { 0f, 0f, 0f },
                ambient = new[] { 1f, 1f, 1f },
                colorIndexes = new[] { 0f, 1f, 1f }
            };
            ModelMaterial materialSky = new ModelMaterial()
            {
                emission = new[] { 1f, 1f, 1f },
                specular = new[] { 0f, 0f, 0f },
                diffuse = new[] { 0f, 0f, 0f },
                shininess = new[] { 0f, 0f, 0f },
                ambient = new[] { 0f, 0f, 0f },
                colorIndexes = new[] { 0f, 0f, 0f }
            };
            ModelMaterial materialSky2 = new ModelMaterial()
            {
                emission = new[] { 1f, 1f, 1f },
                specular = new[] { 0f, 0f, 0f },
                diffuse = new[] { 0f, 0f, 0f },
                shininess = new[] { 0f, 0f, 0f },
                ambient = new[] { 0f, 0f, 0f },
                colorIndexes = new[] { 0f, 0f, 0f }
            };
            ModelMaterial material6 = new ModelMaterial()
            {
                emission = new[] { 0f, 0f, 0f },
                specular = new[] { 0.25f, 0.25f, 0.25f },
                diffuse = new[] { 0f, 0f, 0f },
                shininess = new[] { 0f, 0f, 0f },
                ambient = new[] { 1f, 1f, 1f },
                colorIndexes = new[] { 0f, 1f, 1f }
            };
            ModelMaterial materialBroke = new ModelMaterial()
            {
                emission = new[] { 0f, 0f, 0f },
                specular = new[] { 0.25f, 0.25f, 0.25f },
                diffuse = new[] { 0f, 0f, 0f },
                shininess = new[] { 0f, 0f, 0f },
                ambient = new[] { 1f, 1f, 1f },
                colorIndexes = new[] { 0f, 1f, 1f }
            };
            ModelMaterial materialWater = new ModelMaterial()
            {
                emission = new[] { 0f, 0f, 0f },
                specular = new[] { 0.25f, 0.25f, 0.25f },
                diffuse = new[] { 0f, 0f, 0f },
                shininess = new[] { 0f, 0f, 0f },
                ambient = new[] { 1f, 1f, 1f },
                colorIndexes = new[] { 0f, 1f, 1f },
                cullMode = 0
            };
            materialWater.SetTexture(@"D:\Visual Studio Projects\MIHAEngine v.0.0.1 Norm\MIHAEngine\bin\Debug\net5.0-windows\WaterTexture.png");
            materialBroke.SetTexture(@"D:\Visual Studio Projects\MIHAEngine v.0.0.1 Norm\MIHAEngine\bin\Debug\net5.0-windows\BrokeLampTexture.png");
            materialLight.SetTexture(@"D:\Visual Studio Projects\MIHAEngine v.0.0.1 Norm\MIHAEngine\bin\Debug\net5.0-windows\LampTexture.png");
            material.SetTexture(@"D:\Visual Studio Projects\MIHAEngine v.0.0.1 Norm\MIHAEngine\bin\Debug\net5.0-windows\PlaneTexture.png");
            material6.SetTexture(@"D:\Visual Studio Projects\MIHAEngine v.0.0.1 Norm\MIHAEngine\bin\Debug\net5.0-windows\StreetTexture.png");
            material1.SetTexture(@"D:\Visual Studio Projects\MIHAEngine v.0.0.1 Norm\MIHAEngine\bin\Debug\net5.0-windows\Lamp_2Texture.png");
            material2.SetTexture(@"D:\Visual Studio Projects\MIHAEngine v.0.0.1 Norm\MIHAEngine\bin\Debug\net5.0-windows\FontainTexture.png");
            material3.SetTexture(@"D:\Visual Studio Projects\MIHAEngine v.0.0.1 Norm\MIHAEngine\bin\Debug\net5.0-windows\SkameykaTexture.png");
            material4.SetTexture(@"D:\Visual Studio Projects\MIHAEngine v.0.0.1 Norm\MIHAEngine\bin\Debug\net5.0-windows\KustTexture.png");
            material5.SetTexture(@"D:\Visual Studio Projects\MIHAEngine v.0.0.1 Norm\MIHAEngine\bin\Debug\net5.0-windows\TreeTexture.png");
            materialSky.SetTexture(@"D:\Visual Studio Projects\MIHAEngine v.0.0.1 Norm\MIHAEngine\bin\Debug\net5.0-windows\SkyboxTexture.png");
            materialSky2.SetTexture(@"D:\Visual Studio Projects\MIHAEngine v.0.0.1 Norm\MIHAEngine\bin\Debug\net5.0-windows\SkyboxDayTexture.png");
            materialGLight.SetTexture(@"D:\Visual Studio Projects\MIHAEngine v.0.0.1 Norm\MIHAEngine\bin\Debug\net5.0-windows\LampTexture.png");
            ModelData lamp_2 = ModelImporter.ImportOBJModel("Models/Lamp_2.obj");
            ModelData kust = ModelImporter.ImportOBJModel("Models/Kust.obj");
            ModelData skameyka = ModelImporter.ImportOBJModel("Models/Skameyka.obj");
            ModelData lamp = ModelImporter.ImportOBJModel("Models/Lamp.obj");
            ModelData tree = ModelImporter.ImportOBJModel("Models/Tree.obj");
            ModelData street = ModelImporter.ImportOBJModel("Models/Street.obj");
            ModelData water = ModelImporter.ImportOBJModel("Models/Water.obj");
            #region Lamp
            GameObject Lamp1 = new GameObject("Lamp1", lamp_2, material1);
            Lamp1.Transform.Position = new Vector3(0f, 0f, -21f);
            GameObject Lamp2 = new GameObject("Lamp2", lamp_2, material1);
            Lamp2.Transform.Position = new Vector3(0f, 0f, 21f);
            GameObject Lamp3 = new GameObject("Lamp3", lamp_2, material1);
            Lamp3.Transform.Position = new Vector3(0f, 0f, 47f);
            GameObject Lamp4 = new GameObject("Lamp4", lamp_2, material1);
            Lamp4.Transform.Position = new Vector3(0f, 0f, -47f);
            GameObject Lamp5 = new GameObject("Lamp5", lamp_2, material1);
            Lamp5.Transform.Position = new Vector3(-21f, 0f, 0f);
            Lamp5.Transform.Rotation = new Vector3(0f, 90f, 0f);
            GameObject Lamp6 = new GameObject("Lamp6", lamp_2, material1);
            Lamp6.Transform.Position = new Vector3(21f, 0f, 0f);
            Lamp6.Transform.Rotation = new Vector3(0f, 90f, 0f);
            GameObject Lamp7 = new GameObject("Lamp7", lamp_2, material1);
            Lamp7.Transform.Position = new Vector3(47f, 0f, 0f);
            Lamp7.Transform.Rotation = new Vector3(0f, 90f, 0f);
            GameObject Lamp8 = new GameObject("Lamp8", lamp_2, material1);
            Lamp8.Transform.Position = new Vector3(-47f, 0f, 0f);
            Lamp8.Transform.Rotation = new Vector3(0f, 90f, 0f);
            #endregion
            #region Kust
            GameObject Kust1 = new GameObject("Kust1", kust, material4);
            Kust1.Transform.Position = new Vector3(-10f, 0f, -10f);
            GameObject Kust2 = new GameObject("Kust2", kust, material4);
            Kust2.Transform.Position = new Vector3(-10f, 0f, 10f);
            Kust2.Transform.Rotation = new Vector3(0f, 90f, 0f);
            GameObject Kust3 = new GameObject("Kust3", kust, material4);
            Kust3.Transform.Position = new Vector3(10f, 0f, 10f);
            Kust3.Transform.Rotation = new Vector3(0f, 180f, 0f);
            GameObject Kust4 = new GameObject("Kust4", kust, material4);
            Kust4.Transform.Position = new Vector3(10f, 0f, -10f);
            Kust4.Transform.Rotation = new Vector3(0f, 270f, 0f);
            #endregion
            #region Skameiki
            GameObject Skameyka1 = new GameObject("Skameyka1", skameyka, material3);
            Skameyka1.Transform.Position = new Vector3(14f, 0f, -8.4f);
            GameObject Skameyka2 = new GameObject("Skameyka2", skameyka, material3);
            Skameyka2.Transform.Position = new Vector3(28f, 0f, -8.4f);
            GameObject Skameyka3 = new GameObject("Skameyka3", skameyka, material3);
            Skameyka3.Transform.Position = new Vector3(42f, 0f, -8.4f);
            GameObject Skameyka4 = new GameObject("Skameyka4", skameyka, material3);
            Skameyka4.Transform.Position = new Vector3(-14f, 0f, -8.4f);
            GameObject Skameyka5 = new GameObject("Skameyka5", skameyka, material3);
            Skameyka5.Transform.Position = new Vector3(-28f, 0f, -8.4f);
            GameObject Skameyka6 = new GameObject("Skameyka6", skameyka, material3);
            Skameyka6.Transform.Position = new Vector3(-42f, 0f, -8.4f);
            GameObject Skameyka7 = new GameObject("Skameyka7", skameyka, material3);
            Skameyka7.Transform.Position = new Vector3(8.4f, 0f, 14f);
            Skameyka7.Transform.Rotation = new Vector3(0f, -90f, 0f);
            GameObject Skameyka8 = new GameObject("Skameyka8", skameyka, material3);
            Skameyka8.Transform.Position = new Vector3(8.4f, 0f, 28f);
            Skameyka8.Transform.Rotation = new Vector3(0f, -90f, 0f);
            GameObject Skameyka9 = new GameObject("Skameyka9", skameyka, material3);
            Skameyka9.Transform.Position = new Vector3(8.4f, 0f, 42f);
            Skameyka9.Transform.Rotation = new Vector3(0f, -90f, 0f);
            GameObject Skameyka10 = new GameObject("Skameyka10", skameyka, material3);
            Skameyka10.Transform.Position = new Vector3(8.4f, 0f, -14f);
            Skameyka10.Transform.Rotation = new Vector3(0f, -90f, 0f);
            GameObject Skameyka11 = new GameObject("Skameyka1", skameyka, material3);
            Skameyka11.Transform.Position = new Vector3(8.4f, 0f, -28f);
            Skameyka11.Transform.Rotation = new Vector3(0f, -90f, 0f);
            GameObject Skameyka12 = new GameObject("Skameyka12", skameyka, material3);
            Skameyka12.Transform.Position = new Vector3(8.4f, 0f, -42f);
            Skameyka12.Transform.Rotation = new Vector3(0f, -90f, 0f);
            #endregion
            #region Light
            LightObject Light = new LightObject("Light0", lamp, materialLight, Engine.FindFreeLight());
            Light.Transform.Position = new Vector3(0, 10.5f, 21f);
            Light.Transform.Rotation = new Vector3(0, 0, 180f);
            Light.direction = new[] { 0f, -1f, 0f };
            Light.diffuse = new[] { 2f, 2f, 2f };
            Light.specular = new[] { 2f, 2f, 2f };
            Light.ambient = new[] { 2f, 2f, 1f };
            Light.quadraticAttenuation = 0.25f;
            Light.spotAngle = 90f;
            Light.spotExponent = 1f;

            LightObject Light1 = new LightObject("Light1", lamp, materialLight, Engine.FindFreeLight());
            Light1.Transform.Position = new Vector3(0, 10.5f, 47f);
            Light1.Transform.Rotation = new Vector3(0, 0, 180f);
            Light1.direction = new[] { 0f, -1f, 0f };
            Light1.diffuse = new[] { 2f, 2f, 2f };
            Light1.specular = new[] { 2f, 2f, 2f };
            Light1.ambient = new[] { 2f, 2f, 1f };
            Light1.quadraticAttenuation = 0.25f;
            Light1.spotAngle = 90f;
            Light1.spotExponent = 4f;

            LightObject Light2 = new LightObject("Light2", lamp, materialLight, Engine.FindFreeLight());
            Light2.Transform.Position = new Vector3(0, 10.5f, -21f);
            Light2.Transform.Rotation = new Vector3(0, 0, 180f);
            Light2.direction = new[] { 0f, -1f, 0f };
            Light2.diffuse = new[] { 2f, 2f, 2f };
            Light2.specular = new[] { 2f, 2f, 2f };
            Light2.ambient = new[] { 2f, 2f, 1f };
            Light2.quadraticAttenuation = 0.25f;
            Light2.spotAngle = 90f;
            Light2.spotExponent = 1f;

            //LightObject Light3 = new LightObject("Light3", lamp, materialLight, Engine.FindFreeLight());
            //Light3.Transform.Position = new Vector3(0, 10.5f, -47f);
            //Light3.Transform.Rotation = new Vector3(0, 0, 180f);
            //Light3.direction = new[] { 0f, -1f, 0f };
            //Light3.diffuse = new[] { 2f, 2f, 2f };
            //Light3.specular = new[] { 2f, 2f, 2f };
            //Light3.ambient = new[] { 2f, 2f, 1f };
            //Light3.quadraticAttenuation = 0.25f;
            //Light3.spotAngle = 90f;
            //Light3.spotExponent = 4f
            LightObject Light3 = new LightObject("GL", null, materialGLight, Engine.FindFreeLight());
            Light3.Transform.Position = new Vector3(0, 50f, 0f);
            Light3.Transform.Rotation = new Vector3(0, 0, 0f);
            Light3.direction = new[] { 0f, -1f, 0f };
            Light3.diffuse = new[] { 1f, 1f, 1f };
            Light3.specular = new[] { 1f, 1f, 1f };
            Light3.ambient = new[] { 1f, 1f, 1f };
            Light3.quadraticAttenuation = 0.015f;
            Light3.spotAngle = 90f;
            Light3.spotExponent = 1f;

            LightObject Light4 = new LightObject("Light4", lamp, materialLight, Engine.FindFreeLight());
            Light4.Transform.Position = new Vector3(-21f, 10.5f, 0f);
            Light4.Transform.Rotation = new Vector3(0, 0, 180f);
            Light4.direction = new[] { 0f, -1f, 0f };
            Light4.diffuse = new[] { 2f, 2f, 2f };
            Light4.specular = new[] { 2f, 2f, 2f };
            Light4.ambient = new[] { 2f, 2f, 1f };
            Light4.quadraticAttenuation = 0.25f;
            Light4.spotAngle = 90f;
            Light4.spotExponent = 4f;

            LightObject Light5 = new LightObject("Light5", lamp, materialLight, Engine.FindFreeLight());
            Light5.Transform.Position = new Vector3(-47f, 10.5f, 0f);
            Light5.Transform.Rotation = new Vector3(0, 0, 180f);
            Light5.direction = new[] { 0f, -1f, 0f };
            Light5.diffuse = new[] { 2f, 2f, 2f };
            Light5.specular = new[] { 2f, 2f, 2f };
            Light5.ambient = new[] { 2f, 2f, 1f };
            Light5.quadraticAttenuation = 0.25f;
            Light5.spotAngle = 90f;
            Light5.spotExponent = 4f;

            LightObject Light6 = new LightObject("Light6", lamp, materialLight, Engine.FindFreeLight());
            Light6.Transform.Position = new Vector3(21f, 10.5f, 0f);
            Light6.Transform.Rotation = new Vector3(0, 0, 180f);
            Light6.direction = new[] { 0f, -1f, 0f };
            Light6.diffuse = new[] { 2f, 2f, 2f };
            Light6.specular = new[] { 2f, 2f, 2f };
            Light6.ambient = new[] { 2f, 2f, 1f };
            Light6.quadraticAttenuation = 0.25f;
            Light6.spotAngle = 90f;
            Light6.spotExponent = 4f;

            LightObject Light7 = new LightObject("Light7", lamp, materialLight, Engine.FindFreeLight());
            Light7.Transform.Position = new Vector3(47f, 10.5f, 0f);
            Light7.Transform.Rotation = new Vector3(0, 0, 180f);
            Light7.direction = new[] { 0f, -1f, 0f };
            Light7.diffuse = new[] { 2f, 2f, 2f };
            Light7.specular = new[] { 2f, 2f, 2f };
            Light7.ambient = new[] { 2f, 2f, 1f };
            Light7.quadraticAttenuation = 0.25f;
            Light7.spotAngle = 90f;
            Light7.spotExponent = 4f;
            #endregion
            #region Tree
            GameObject Tree1 = new GameObject("Tree1", tree, material5);
            Tree1.Transform.Position = new Vector3(-20f, 0f, -20f);
            Tree1.Transform.Rotation = new Vector3(0f, -45f, 0f);
            GameObject Tree2 = new GameObject("Tree2", tree, material5);
            Tree2.Transform.Position = new Vector3(-25f, 0f, -45f);
            Tree2.Transform.Rotation = new Vector3(4f, 0f, 0f);
            Tree2.Transform.Scale = new Vector3(1.5f, 2f, 1.5f);
            GameObject Tree3 = new GameObject("Tree3", tree, material5);
            Tree3.Transform.Position = new Vector3(-46f, 0f, -20f);
            Tree3.Transform.Rotation = new Vector3(6f, -60f, 5f);
            Tree3.Transform.Scale = new Vector3(1.25f, 1.5f, 1.25f);
            GameObject Tree4 = new GameObject("Tree4", tree, material5);
            Tree4.Transform.Position = new Vector3(18f, 0f, -17f);
            Tree4.Transform.Rotation = new Vector3(0f, 0f, 4f);
            Tree4.Transform.Scale = new Vector3(1.5f, 1.5f, 1.5f);
            GameObject Tree5 = new GameObject("Tree5", tree, material5);
            Tree5.Transform.Position = new Vector3(20f, 0f, -46f);
            Tree5.Transform.Rotation = new Vector3(0f, -45f, 5f);
            Tree5.Transform.Scale = new Vector3(1.25f, 1.25f, 1.25f);
            GameObject Tree6 = new GameObject("Tree6", tree, material5);
            Tree6.Transform.Position = new Vector3(44f, 0f, -17f);
            Tree6.Transform.Rotation = new Vector3(0f, 60f, 4f);
            Tree6.Transform.Scale = new Vector3(1.5f, 1.75f, 1.5f);
            GameObject Tree7 = new GameObject("Tree7", tree, material5);
            Tree7.Transform.Position = new Vector3(20f, 0f, 20f);
            Tree7.Transform.Rotation = new Vector3(0f, -45f, 0f);
            GameObject Tree8 = new GameObject("Tree8", tree, material5);
            Tree8.Transform.Position = new Vector3(25f, 0f, 45f);
            Tree8.Transform.Rotation = new Vector3(4f, 0f, 0f);
            Tree8.Transform.Scale = new Vector3(1.5f, 2f, 1.5f);
            GameObject Tree9 = new GameObject("Tree9", tree, material5);
            Tree9.Transform.Position = new Vector3(46f, 0f, 20f);
            Tree9.Transform.Rotation = new Vector3(6f, -60f, 5f);
            Tree9.Transform.Scale = new Vector3(1.25f, 1.5f, 1.25f);
            GameObject Tree10 = new GameObject("Tree10", tree, material5);
            Tree10.Transform.Position = new Vector3(-18f, 0f, 17f);
            Tree10.Transform.Rotation = new Vector3(0f, 0f, 4f);
            Tree10.Transform.Scale = new Vector3(1.5f, 1.5f, 1.5f);
            GameObject Tree11 = new GameObject("Tree11", tree, material5);
            Tree11.Transform.Position = new Vector3(-20f, 0f, 46f);
            Tree11.Transform.Rotation = new Vector3(0f, -45f, 5f);
            Tree11.Transform.Scale = new Vector3(1.25f, 1.25f, 1.25f);
            GameObject Tree12 = new GameObject("Tree12", tree, material5);
            Tree12.Transform.Position = new Vector3(-44f, 0f, 17f);
            Tree12.Transform.Rotation = new Vector3(0f, 60f, 4f);
            Tree12.Transform.Scale = new Vector3(1.5f, 1.75f, 1.5f);
            #endregion
            #region Water
            GameObject Water1 = new GameObject("Water1", water, materialWater);
            Water1.Transform.Position = new Vector3(0f, 7.8f, 0f);
            Water1.Transform.Rotation = new Vector3(0f, 0f, 0f);
            Water1.Transform.Scale = new Vector3(1f, 1f, 1f);
            GameObject Water2 = new GameObject("Water2", water, materialWater);
            Water2.Transform.Position = new Vector3(0f, 7.8f, 0f);
            Water2.Transform.Rotation = new Vector3(0f, 90f, 0f);
            Water2.Transform.Scale = new Vector3(1f, 1f, 1f);
            GameObject Water3 = new GameObject("Water3", water, materialWater);
            Water3.Transform.Position = new Vector3(0f, 7.8f, 0f);
            Water3.Transform.Rotation = new Vector3(0f, 180f, 0f);
            Water3.Transform.Scale = new Vector3(1f, 1f, 1f);
            GameObject Water4 = new GameObject("Water4", water, materialWater);
            Water4.Transform.Position = new Vector3(0f, 7.8f, 0f);
            Water4.Transform.Rotation = new Vector3(0f, 270f, 0f);
            Water4.Transform.Scale = new Vector3(1f, 1f, 1f);
            GameObject Water5 = new GameObject("Water5", water, materialWater);
            Water5.Transform.Position = new Vector3(0.6f, 5.7f, 0f);
            Water5.Transform.Rotation = new Vector3(0f, 0f, 0f);
            Water5.Transform.Scale = new Vector3(1.5f, 1.5f, 2.5f);
            GameObject Water6 = new GameObject("Water6", water, materialWater);
            Water6.Transform.Position = new Vector3(0f, 5.7f, -0.6f);
            Water6.Transform.Rotation = new Vector3(0f, 90f, 0f);
            Water6.Transform.Scale = new Vector3(1.5f, 1.5f, 2.5f);
            GameObject Water7 = new GameObject("Water7", water, materialWater);
            Water7.Transform.Position = new Vector3(-0.6f, 5.7f, 0f);
            Water7.Transform.Rotation = new Vector3(0f, 180f, 0f);
            Water7.Transform.Scale = new Vector3(1.5f, 1.5f, 2.5f);
            GameObject Water8 = new GameObject("Water8", water, materialWater);
            Water8.Transform.Position = new Vector3(0f, 5.7f, 0.6f);
            Water8.Transform.Rotation = new Vector3(0f, 270f, 0f);
            Water8.Transform.Scale = new Vector3(1.5f, 1.5f, 2.5f);

            GameObject Water9 = new GameObject("Water9", water, materialWater);
            Water9.Transform.Position = new Vector3(2f, 3f, 0f);
            Water9.Transform.Rotation = new Vector3(0f, 0f, 0f);
            Water9.Transform.Scale = new Vector3(1.75f, 2f, 3.5f);
            GameObject Water10 = new GameObject("Water10", water, materialWater);
            Water10.Transform.Position = new Vector3(0f, 3f, -2f);
            Water10.Transform.Rotation = new Vector3(0f, 90f, 0f);
            Water10.Transform.Scale = new Vector3(1.75f, 2f, 3.5f);
            GameObject Water11 = new GameObject("Water11", water, materialWater);
            Water11.Transform.Position = new Vector3(-2f, 3f, 0f);
            Water11.Transform.Rotation = new Vector3(0f, 180f, 0f);
            Water11.Transform.Scale = new Vector3(1.75f, 2f, 3.5f);
            GameObject Water12 = new GameObject("Water12", water, materialWater);
            Water12.Transform.Position = new Vector3(0f, 3f, 2f);
            Water12.Transform.Rotation = new Vector3(0f, 270f, 0f);
            Water12.Transform.Scale = new Vector3(1.75f, 2f, 3.5f);
            #endregion
            GameObject LampBroke = new GameObject("LampBroke", lamp, materialBroke);
            LampBroke.Transform.Position = new Vector3(0f, -0.2f, -47f);
            LampBroke.Transform.Rotation = new Vector3(-25f, 34f, 90f);
            GameObject Street1= new GameObject("Street1", street, material6);
            Street1.Transform.Position = new Vector3(-87.9f, 0f, 0f);
            GameObject Street2 = new GameObject("Street2", street, material6);
            Street2.Transform.Position = new Vector3(137.9f, 0f, 0f);
            GameObject Squre = new GameObject("Squre", ModelImporter.ImportOBJModel("Models/Squre.obj"), material);
            GameObject Fontain = new GameObject("Fontain", ModelImporter.ImportOBJModel("Models/Fontain.obj"), material2);
            GameObject SkyboxNight = new GameObject("SkyboxNight", ModelImporter.ImportOBJModel("Models/Skybox.obj"), materialSky);
            GameObject SkyboxDay = new GameObject("SkyboxDay", ModelImporter.ImportOBJModel("Models/Skybox.obj"), materialSky2);
            SkyboxNight.Transform.Scale = new Vector3(1.3f, 1.1f, 1.3f);
            Scene.AddObject(new[] { Squre, Fontain,SkyboxNight, SkyboxDay, Street1, Street2,LampBroke,
                                    Water1, Water2, Water3, Water4, Water5, Water6, Water7, Water8, Water9, Water10, Water11, Water12,   
                                    Lamp1, Lamp2, Lamp3, Lamp4, Lamp5, Lamp6, Lamp7, Lamp8,
                                    Tree1, Tree2, Tree3, Tree4, Tree5, Tree6, Tree7, Tree8, Tree9, Tree10, Tree11, Tree12,
                                    Skameyka1, Skameyka2, Skameyka3, Skameyka4, Skameyka5, Skameyka6, Skameyka7, Skameyka8,Skameyka9, Skameyka10, Skameyka11, Skameyka12,
                                    Kust1, Kust2, Kust3, Kust4,
                                    Light2, Light1, Light, Light3, Light4, Light5, Light6, Light7 });
            GameLoad?.Invoke();
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            Matrix4 persp = Camera.GetViewMatrix() * Camera.GetPerspectiveMatrix();
            Engine.SetProjection(persp);
            Engine.Render(Scene.ObjectsArray, (float)args.Time);

            SwapBuffers();
        }
        double totalTime = 0f;
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            #region anim
            var waters = Scene.FindAllObject("Water");
            totalTime += args.Time;
            Vector3 nightrot = (Vector3.UnitY + Vector3.UnitX) * (float)args.Time * 0.5f;
            Vector3 dayrot = Vector3.UnitY * (float)args.Time * 0.5f;
            if (Scene.FindObject("SkyboxDay") is GameObject obj)
            {
                obj.Transform.Rotation += dayrot;
                obj.Material.alpha = (float)Math.Abs(Math.Pow(Math.Sin(totalTime * 0.05), 2));
                if (obj.Material.alpha >= 0.98f)
                {
                    obj.Material.alpha = 1f;
                }
                else if (obj.Material.alpha <= 0.01f)
                {
                    obj.Material.alpha = 0f;
                }
                if (obj.Material.alpha >= 0.5f)
                {
                    var lights = Scene.FindAllObject("Light");
                    foreach (var light in lights)
                    {
                        light.Material.emission[0] = 0f;
                        light.Material.emission[1] = 0f;
                        light.Material.emission[2] = 0f;

                        ((LightObject)light).spotAngle = 0f;
                    }
                    foreach(var wat in waters)
                    {
                        wat.enable = true;
                    }
                }
                else
                {
                    var lights = Scene.FindAllObject("Light");
                    foreach (var light in lights)
                    {
                        light.Material.emission[0] = 1f;
                        light.Material.emission[1] = 1f;
                        light.Material.emission[2] = 1f;

                        ((LightObject)light).spotAngle = 90f;
                    }
                    foreach (var wat in waters)
                    {
                        wat.enable = false;
                    }
                }
            }
            if (Scene.FindObject("SkyboxNight") is GameObject obj1)
            {
                obj1.Transform.Rotation += nightrot;
            }
            if (Scene.FindObject("GL") is LightObject obj2)
            {
                Vector3 pos = new Vector3((float)(Math.Cos(totalTime * 0.05) * 150), (float)Math.Abs(Math.Pow(Math.Sin(totalTime * 0.05), 2)) * 150, 0f);
                if (pos.Y <= 0.0003f) totalTime = 0f;
                obj2.Transform.Position = pos;
                 
            }
            if (waters.Length > 0)
            {
                var water = waters[0];
                #region animwater
                water.ModelData.verticesСoordinates[0, 1] += (float)Math.Sin(totalTime * 5) * 0.02f;
                water.ModelData.verticesСoordinates[1, 1] += (float)Math.Sin(totalTime * 5) * 0.02f;
                water.ModelData.verticesСoordinates[2, 1] += (float)Math.Sin(totalTime * 5) * 0.02f;
                water.ModelData.verticesСoordinates[3, 1] += (float)Math.Sin(totalTime * 5) * 0.01f;
                water.ModelData.verticesСoordinates[5, 1] += (float)Math.Sin(totalTime * 5) * 0.01f;
                water.ModelData.verticesСoordinates[8, 1] += (float)Math.Sin(totalTime * 5) * 0.01f;
                water.ModelData.verticesСoordinates[10, 1] += (float)Math.Sin(totalTime * 5) * 0.02f;
                water.ModelData.verticesСoordinates[11, 1] += (float)Math.Sin(totalTime * 5) * 0.02f;
                water.ModelData.verticesСoordinates[12, 1] += (float)Math.Sin(totalTime * 5) * 0.02f;

                water.ModelData.verticesСoordinates[0, 0] += (float)Math.Sin(totalTime * 5) * 0.005f;
                water.ModelData.verticesСoordinates[1, 0] += (float)Math.Sin(totalTime * 5) * 0.005f;
                water.ModelData.verticesСoordinates[2, 0] += (float)Math.Sin(totalTime * 5) * 0.005f;
                water.ModelData.verticesСoordinates[10, 0] += (float)Math.Sin(totalTime * 5) * 0.005f;
                water.ModelData.verticesСoordinates[11, 0] += (float)Math.Sin(totalTime * 5) * 0.005f;
                water.ModelData.verticesСoordinates[12, 0] += (float)Math.Sin(totalTime * 5) * 0.005f;

                water.ModelData.verticesСoordinates[3, 2] -= (float)Math.Sin(totalTime * 5) * 0.007f;
                water.ModelData.verticesСoordinates[5, 2] += (float)Math.Sin(totalTime * 5) * 0.007f;
                water.ModelData.verticesСoordinates[8, 0] += (float)Math.Cos(totalTime * 5) * 0.005f;

                water.ModelData.verticesСoordinates[6, 2] -= (float)Math.Cos(totalTime * 5) * 0.01f;
                water.ModelData.verticesСoordinates[7, 2] += (float)Math.Cos(totalTime * 5) * 0.01f;
                water.ModelData.verticesСoordinates[9, 0] += (float)Math.Cos(totalTime * 5) * 0.02f;
            }
            #endregion
            #endregion
            if (InputController.KeyPressed(Keys.Escape))
            {
                CursorState = CursorState.Normal;
            }
            if (CursorState == CursorState.Normal) return;

            Vector3 input = InputController.GetInputAxis();
            Vector2 mouseDelta = InputController.MouseDelta;
 
            Camera.Move(input, (float)args.Time);
            Camera.Rotate(mouseDelta.X, mouseDelta.Y);
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            Camera.Size = Size;
            Engine.SetViewport(0, 0, Size.X, Size.Y);
        }
        protected override void OnUnload()
        {
            CursorState = CursorState.Normal;
            base.OnUnload();
        }
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if(e.Button == MouseButton.Left)
            {
                CursorState = CursorState.Grabbed;
            }
        }
        
    }
    public static class Game
    {
        public static MainWindow Current;

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();
        public static void Initialization()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(1280, 720),
                APIVersion = new Version(4, 6),
                Flags = ContextFlags.Default,
                Profile = ContextProfile.Compatability,
                API = ContextAPI.OpenGL,
                WindowState = WindowState.Normal,
                WindowBorder = WindowBorder.Resizable,
                Vsync = VSyncMode.On
            };
            //AllocConsole();
            Current = new MainWindow(GameWindowSettings.Default, nativeWindowSettings);
        }
        public static void Start()
        {
            Current.Run();
            Current.Dispose();
            Current = null;
        }
    }
}
