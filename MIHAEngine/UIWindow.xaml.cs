using Microsoft.Win32;
using MIHAEngine.Objects;
using OpenTK.Audio.OpenAL.Extensions.Creative.EFX;
using OpenTK.Mathematics;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace MIHAEngine
{
    public partial class UIWindow : Window
    {
        private GameObject selectedObject;
        private LightEdit lightEdit;
        private MaterialEdit materialEdit;
        private Axis axisController;
        public UIWindow()
        {
            axisController = new Axis();
            InitializeComponent();
        }

        private void LoadSceneButton_Click(object sender, RoutedEventArgs e)
        {
            LoadSceneButton.IsEnabled = false;
            GlobalAxisButton.IsChecked = false;
            ObjectAxisButton.IsChecked = false;
            NormalAxisButton.IsChecked = false;
            Game.Initialization();
            Game.Current.GameLoad += UpdateHierarchyTree;
            Game.Start();

            if (lightEdit != null) 
            {
                lightEdit.Close();
                lightEdit = null;
            }
            if (materialEdit != null)
            {
                materialEdit.Close();
                materialEdit = null;
            }
            LoadSceneButton.IsEnabled = true;
            HierarchyTree.Items.Clear();
            IDLabel.Content = string.Empty;
        }

        private void AddObjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (Game.Current == null) return;
            OpenModel();
        }

        public GameObject OpenModel()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Obj files (*.obj)|*.obj";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                var model = new GameObject("GameObject", ModelImporter.ImportOBJModel(selectedFilePath), new ModelMaterial());
                Game.Current.Scene.AddObject(model);
                UpdateHierarchyTree();
                Keyboard.ClearFocus();
                return model;
            }
            return null;
        }
        private void DestroyObjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedObject == null || Game.Current == null) return;
            Game.Current.Scene.DestroyObject(selectedObject);
            UpdateHierarchyTree();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            if(materialEdit != null)
                materialEdit.Close();
            if(lightEdit != null)
                lightEdit.Close();
            Game.Current.Close();
        }

        private void HierarchyTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var item = HierarchyTree.SelectedItem as TreeViewItem;
            if (item != null)
            {
                selectedObject = Game.Current.Scene.FindObject((int)item.Tag);
                IDLabel.Content = $"ID:{selectedObject.ID}";
                TransformTextBoxesUpdate(selectedObject.Name, selectedObject.Transform.Position, selectedObject.Transform.Rotation, selectedObject.Transform.Scale);
                DebugTextBox.Text = $"F:{selectedObject.Transform.Forward} U:{selectedObject.Transform.Up} R:{selectedObject.Transform.Right}";
                if(materialEdit != null)
                {
                    materialEdit.SetMaterial(selectedObject.Material);
                }
                if(selectedObject is LightObject light) 
                {
                    if (lightEdit == null)
                    {
                        LightEditButton.IsEnabled = true;
                        return; 
                    }
                    lightEdit.SetLight(light);
                }
                else
                {
                    LightEditButton.IsEnabled = false;
                }
            }
        }
        public void UpdateHierarchyTree()
        {
            HierarchyTree.Items.Clear();
            var items = Game.Current.Scene.ObjectsArray;

            foreach (var item in items)
            {
                var treeItem = new TreeViewItem()
                {
                    Tag = item.ID,
                    Header = item.Name,
                };

                HierarchyTree.Items.Add(treeItem);
            }
        }

        private void TransformTextBoxesUpdate(string Name, Vector3 position, Vector3 rotation, Vector3 scale)
        {
            NameObjectTextBox.Text = Name;

            TrTBPositionX.Text = position.X.ToString();
            TrTBPositionY.Text = position.Y.ToString();
            TrTBPositionZ.Text = position.Z.ToString();

            TrTBRotationX.Text = rotation.X.ToString();
            TrTBRotationY.Text = rotation.Y.ToString();
            TrTBRotationZ.Text = rotation.Z.ToString();

            TrTBScaleX.Text = scale.X.ToString();
            TrTBScaleY.Text = scale.Y.ToString();
            TrTBScaleZ.Text = scale.Z.ToString();
        }
        public bool TransformTextBoxeCheck(string text, out float number)
        {
            number = 0;
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }
            if (selectedObject == null || !Regex.IsMatch(text, @"^-?[0-9]+([,.][0-9]+)?$"))
            {
                return false;
            }
            if (float.TryParse(text, out float num))
            {
                number = num;
                return true;
            }
            return false;
        }
        #region TextBoxes
        private void NameObjectTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (selectedObject == null || selectedObject.Name == NameObjectTextBox.Text || Game.Current == null) return;
            selectedObject.Name = NameObjectTextBox.Text;
            (HierarchyTree.SelectedItem as TreeViewItem).Header = selectedObject.Name;
        }

        private void TrTBPositionX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(TransformTextBoxeCheck(TrTBPositionX.Text, out float number))
            {
                TrTBPositionX.Text = number.ToString();
                Vector3 pos = selectedObject.Transform.Position;
                pos.X = number;
                selectedObject.Transform.Position = pos;
            }
        }

        private void TrTBPositionY_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxeCheck(TrTBPositionY.Text, out float number))
            {
                TrTBPositionY.Text = number.ToString();
                Vector3 pos = selectedObject.Transform.Position;
                pos.Y = number;
                selectedObject.Transform.Position = pos;
            }
        }

        private void TrTBPositionZ_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxeCheck(TrTBPositionZ.Text, out float number))
            {
                TrTBPositionZ.Text = number.ToString();
                Vector3 pos = selectedObject.Transform.Position;
                pos.Z = number;
                selectedObject.Transform.Position = pos;
            }
        }

        private void TrTBRotationX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxeCheck(TrTBRotationX.Text, out float number))
            {
                TrTBRotationX.Text = number.ToString();
                Vector3 rot = selectedObject.Transform.Rotation;
                rot.X = number;
                selectedObject.Transform.Rotation = rot;
                DebugTextBox.Text = $"F:{selectedObject.Transform.Forward} U:{selectedObject.Transform.Up} R:{selectedObject.Transform.Right}";
            }
        }

        private void TrTBRotationY_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxeCheck(TrTBRotationY.Text, out float number))
            {
                TrTBRotationY.Text = number.ToString();
                Vector3 rot = selectedObject.Transform.Rotation;
                rot.Y = number;
                selectedObject.Transform.Rotation = rot;
                DebugTextBox.Text = $"F:{selectedObject.Transform.Forward} U:{selectedObject.Transform.Up} R:{selectedObject.Transform.Right}";
            }
        }

        private void TrTBRotationZ_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxeCheck(TrTBRotationZ.Text, out float number))
            {
                TrTBRotationZ.Text = number.ToString();
                Vector3 rot = selectedObject.Transform.Rotation;
                rot.Z = number;
                selectedObject.Transform.Rotation = rot;
                DebugTextBox.Text = $"F:{selectedObject.Transform.Forward} U:{selectedObject.Transform.Up} R:{selectedObject.Transform.Right}";
            }
        }

        private void TrTBScaleX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxeCheck(TrTBScaleX.Text, out float number))
            {
                TrTBScaleX.Text = number.ToString();
                Vector3 scale = selectedObject.Transform.Scale;
                scale.X = number;
                selectedObject.Transform.Scale = scale;
            }
        }

        private void TrTBScaleY_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxeCheck(TrTBScaleY.Text, out float number))
            {
                TrTBScaleY.Text = number.ToString();
                Vector3 scale = selectedObject.Transform.Scale;
                scale.Y = number;
                selectedObject.Transform.Scale = scale;
            }
        }

        private void TrTBScaleZ_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxeCheck(TrTBScaleZ.Text, out float number))
            {
                TrTBScaleZ.Text = number.ToString();
                Vector3 scale = selectedObject.Transform.Scale;
                scale.Z = number;
                selectedObject.Transform.Scale = scale;
            }
        }
        #endregion
        public void ObjectAxisDraw()
        {
            if(selectedObject == null || Game.Current == null) return;
            axisController.DrawObjectAxis(selectedObject.Transform);
        }
        public void NormalAxisDraw()
        {
            if (selectedObject == null || Game.Current == null) return;
            axisController.DrawObjectNormals(selectedObject);
        }
        private void GlobalAxisButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Game.Current == null) return;
            if (GlobalAxisButton.IsChecked == true)
            {
                Game.Current.Engine.OnRender += axisController.DrawGlobalAxis;
            }
            else
            {
                Game.Current.Engine.OnRender -= axisController.DrawGlobalAxis;
            }
        }
        private void ObjectlAxisButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Game.Current == null) return;
            if (ObjectAxisButton.IsChecked == true)
            {
                Game.Current.Engine.OnRender += ObjectAxisDraw;
            }
            else
            {
                Game.Current.Engine.OnRender -= ObjectAxisDraw;
            }
        }
        private void NormalAxisButton_Click(object sender, RoutedEventArgs e)
        {
            if (Game.Current == null) return;
            if (NormalAxisButton.IsChecked == true)
            {
                Game.Current.Engine.OnRender += NormalAxisDraw;
            }
            else
            {
                Game.Current.Engine.OnRender -= NormalAxisDraw;
            }
        }
        private void ObjectAxisSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            axisController.objectAxisLength = (float)ObjectAxisSlider.Value;
            ObjectAxisLabel.Content = axisController.objectAxisLength;
        }
        private void GlobalAxisSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            axisController.globalAxisLength = (float)GlobalAxisSlider.Value;
            GlobalAxisLabel.Content = axisController.globalAxisLength;
        }
        private void NormalAxisSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            axisController.normalAxisLength = (float)NormalAxisSlider.Value;
            NormalAxisLabel.Content = axisController.normalAxisLength;
        }

        private void AddLightButton_Click(object sender, RoutedEventArgs e)
        {
            if (Game.Current == null) return;
            OpenTK.Graphics.OpenGL.LightName lightName = Game.Current.Engine.FindFreeLight();
            if (lightName != 0) 
            {
                LightObject Light = new LightObject($"New Light", ModelImporter.ImportOBJModel("Models/Lamp.obj"), new ModelMaterial(), lightName);
                Game.Current.Scene.AddObject(Light);
                UpdateHierarchyTree(); 
            }
            Keyboard.ClearFocus();
        }

        private void LightEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (Game.Current == null || selectedObject == null) return;
            LightEditButton.IsEnabled = false;
            lightEdit = new LightEdit();
            lightEdit.Show();
            lightEdit.Closed += (x, y) =>
            {
                lightEdit = null;
                if (selectedObject is LightObject light)
                    LightEditButton.IsEnabled = true;
                else
                    LightEditButton.IsEnabled = false;
            };
            if (selectedObject is LightObject light)
            {
                lightEdit.SetLight(light);
            }
        }

        private void MaterialEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (Game.Current == null || selectedObject == null) return;
            if (materialEdit == null)
            { 
                MaterialEditButton.IsEnabled = false;
                materialEdit = new MaterialEdit();
                materialEdit.Closed += (x, y) => 
                {
                    materialEdit = null;
                    MaterialEditButton.IsEnabled = true;
                };
            }
            materialEdit.SetMaterial(selectedObject.Material);
            materialEdit.Show();
        }
    }
}
