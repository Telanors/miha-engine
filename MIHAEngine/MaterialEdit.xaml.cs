using Microsoft.Win32;
using MIHAEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MIHAEngine
{
    /// <summary>
    /// Логика взаимодействия для MaterialEdit.xaml
    /// </summary>
    public partial class MaterialEdit : Window
    {
        public ModelMaterial material;
        public MaterialEdit()
        {
            InitializeComponent();
        }
        public bool TransformTextBoxCheck(string text, out float number)
        {
            number = 0;
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }
            if (!Regex.IsMatch(text, @"^?[0-9]+([,.][0-9]+)?$"))
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
        public void SetMaterial(ModelMaterial material)
        {
            this.material = material;
            AlphaBox.Text = material.alpha.ToString();
            Emission1.Text = material.emission[0].ToString();
            Emission2.Text = material.emission[1].ToString();
            Emission3.Text = material.emission[2].ToString();

            Diffuse1.Text = material.diffuse[0].ToString();
            Diffuse2.Text = material.diffuse[1].ToString();
            Diffuse3.Text = material.diffuse[2].ToString();

            Specular1.Text = material.specular[0].ToString();
            Specular2.Text = material.specular[1].ToString();
            Specular3.Text = material.specular[2].ToString();

            Ambient1.Text = material.ambient[0].ToString();
            Ambient2.Text = material.ambient[1].ToString();
            Ambient3.Text = material.ambient[2].ToString();

            Shininess1.Text = material.shininess[0].ToString();
            Shininess2.Text = material.shininess[1].ToString();
            Shininess3.Text = material.shininess[2].ToString();

            ColorIndexes1.Text = material.colorIndexes[0].ToString();
            ColorIndexes2.Text = material.colorIndexes[1].ToString();
            ColorIndexes3.Text = material.colorIndexes[2].ToString();
        }
        private void Emission1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Emission1.Text, out float number))
            {
                Emission1.Text = number.ToString();
                material.emission[0] = number;
            }
        }

        private void Emission2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Emission2.Text, out float number))
            {
                Emission2.Text = number.ToString();
                material.emission[1] = number;
            }
        }

        private void Emission3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Emission3.Text, out float number))
            {
                Emission3.Text = number.ToString();
                material.emission[2] = number;
            }
        }

        private void Shininess1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Shininess1.Text, out float number))
            {
                Shininess1.Text = number.ToString();
                material.shininess[0] = number;
            }
        }

        private void Shininess2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Shininess2.Text, out float number))
            {
                Shininess2.Text = number.ToString();
                material.shininess[1] = number;
            }
        }

        private void Shininess3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Shininess3.Text, out float number))
            {
                Shininess3.Text = number.ToString();
                material.shininess[2] = number;
            }
        }

        private void ColorIndexes1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(ColorIndexes1.Text, out float number))
            {
                ColorIndexes1.Text = number.ToString();
                material.colorIndexes[0] = number;
            }
        }

        private void ColorIndexes2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(ColorIndexes2.Text, out float number))
            {
                ColorIndexes2.Text = number.ToString();
                material.colorIndexes[1] = number;
            }
        }

        private void ColorIndexes3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(ColorIndexes3.Text, out float number))
            {
                ColorIndexes3.Text = number.ToString();
                material.colorIndexes[2] = number;
            }
        }

        private void Diffuse1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Diffuse1.Text, out float number))
            {
                Diffuse1.Text = number.ToString();
                material.diffuse[0] = number;
            }
        }

        private void Diffuse2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Diffuse2.Text, out float number))
            {
                Diffuse2.Text = number.ToString();
                material.diffuse[1] = number;
            }
        }

        private void Diffuse3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Diffuse3.Text, out float number))
            {
                Diffuse3.Text = number.ToString();
                material.diffuse[2] = number;
            }
        }

        private void Specular1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Specular1.Text, out float number))
            {
                Specular1.Text = number.ToString();
                material.specular[0] = number;
            }
        }

        private void Specular2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Specular2.Text, out float number))
            {
                Specular2.Text = number.ToString();
                material.specular[1] = number;
            }
        }

        private void Specular3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Specular3.Text, out float number))
            {
                Specular3.Text = number.ToString();
                material.specular[2] = number;
            }
        }

        private void Emission1_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Emission1.Text, out float number))
            {
                Emission1.Text = number.ToString();
                material.emission[0] = number;
            }
        }

        private void Emission2_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Emission2.Text, out float number))
            {
                Emission2.Text = number.ToString();
                material.emission[1] = number;
            }
        }

        private void Emission3_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Emission3.Text, out float number))
            {
                Emission3.Text = number.ToString();
                material.emission[2] = number;
            }
        }

        private void Ambient1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Ambient1.Text, out float number))
            {
                Ambient1.Text = number.ToString();
                material.ambient[0] = number;
            }
        }

        private void Ambient2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Ambient2.Text, out float number))
            {
                Ambient2.Text = number.ToString();
                material.ambient[1] = number;
            }
        }

        private void Ambient3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Ambient3.Text, out float number))
            {
                Ambient3.Text = number.ToString();
                material.ambient[2] = number;
            }
        }

        private void LoadTextureButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Png files (*.png)|*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                material.SetTexture(selectedFilePath);
                Keyboard.ClearFocus();
            }
        }

        private void DeleteTextureButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            material.DeleteTexture();
        }

        private void AlphaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(AlphaBox.Text, out float number))
            {
                AlphaBox.Text = number.ToString();
                material.alpha = number;
            }
        }
    }
}
