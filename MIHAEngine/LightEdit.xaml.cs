using MIHAEngine.Objects;
using OpenTK.Graphics.OpenGL;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace MIHAEngine
{
    /// <summary>
    /// Логика взаимодействия для LightEdit.xaml
    /// </summary>
    public partial class LightEdit : Window
    {
        private LightObject lightObject;
        public LightEdit()
        {
            InitializeComponent();
        }
        public void SetLight(LightObject lightObject)
        {
            this.lightObject = lightObject;
            LightName.Content = lightObject.lightName;
            Direction1.Text = lightObject.direction[0].ToString();
            Direction2.Text = lightObject.direction[1].ToString();
            Direction3.Text = lightObject.direction[2].ToString();

            Diffuse1.Text = lightObject.diffuse[0].ToString();
            Diffuse2.Text = lightObject.diffuse[1].ToString();
            Diffuse3.Text = lightObject.diffuse[2].ToString();

            Specular1.Text = lightObject.specular[0].ToString();
            Specular2.Text = lightObject.specular[1].ToString();
            Specular3.Text = lightObject.specular[2].ToString();

            Ambient1.Text = lightObject.ambient[0].ToString();
            Ambient2.Text = lightObject.ambient[1].ToString();
            Ambient3.Text = lightObject.ambient[2].ToString();

            Attenuation.Text = lightObject.quadraticAttenuation.ToString();
            SpotAngle.Text = lightObject.spotAngle.ToString();
            SpotExponent.Text = lightObject.spotExponent.ToString();
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
        private void Diffuse1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Diffuse1.Text, out float number))
            {
                Diffuse1.Text = number.ToString();
                lightObject.diffuse[0] = number;
            }
        }

        private void Diffuse2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Diffuse2.Text, out float number))
            {
                Diffuse2.Text = number.ToString();
                lightObject.diffuse[1] = number;
            }
        }

        private void Diffuse3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Diffuse3.Text, out float number))
            {
                Diffuse3.Text = number.ToString();
                lightObject.diffuse[2] = number;
            }
        }

        private void Specular1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Specular1.Text, out float number))
            {
                Specular1.Text = number.ToString();
                lightObject.specular[0] = number;
            }
        }

        private void Specular2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Specular2.Text, out float number))
            {
                Specular2.Text = number.ToString();
                lightObject.specular[1] = number;
            }
        }

        private void Specular3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Specular3.Text, out float number))
            {
                Specular3.Text = number.ToString();
                lightObject.specular[2] = number;
            }
        }

        private void Attenuation_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Attenuation.Text, out float number))
            {
                Attenuation.Text = number.ToString();
                lightObject.quadraticAttenuation = number;
            }
        }

        private void SpotAngle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(SpotAngle.Text, out float number))
            {
                SpotAngle.Text = number.ToString();
                lightObject.spotAngle = number;
            }
        }

        private void SpotExponent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(SpotExponent.Text, out float number))
            {
                SpotExponent.Text = number.ToString();
                lightObject.spotExponent = number;
            }
        }

        private void Direction1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Direction1.Text, out float number))
            {
                Direction1.Text = number.ToString();
                lightObject.direction[0] = number;
            }
        }

        private void Direction2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Direction2.Text, out float number))
            {
                Direction2.Text = number.ToString();
                lightObject.direction[1] = number;
            }
        }

        private void Direction3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Direction3.Text, out float number))
            {
                Direction3.Text = number.ToString();
                lightObject.direction[2] = number;
            }
        }

        private void Ambient1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Ambient1.Text, out float number))
            {
                Ambient1.Text = number.ToString();
                lightObject.ambient[0] = number;
            }
        }

        private void Ambient2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Ambient2.Text, out float number))
            {
                Ambient2.Text = number.ToString();
                lightObject.ambient[1] = number;
            }
        }

        private void Ambient3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TransformTextBoxCheck(Ambient3.Text, out float number))
            {
                Ambient3.Text = number.ToString();
                lightObject.ambient[2] = number;
            }
        }
    }
}
