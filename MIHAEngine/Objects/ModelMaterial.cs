using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace MIHAEngine.Objects
{
    public class ModelMaterial
    {
        public CullFaceMode cullMode = CullFaceMode.Back;
        public int textureID;
        public float alpha = 1f;
        public float[] diffuse = new float[] { 1.0f, 1.0f, 1.0f };
        public float[] ambient = new float[] { 1.0f, 1.0f, 1.0f };
        public float[] specular = new float[] { 1.0f, 1.0f, 1.0f };
        public float[] shininess = new float[] { 0.0f, 0.0f, 0.0f };
        public float[] emission = new float[] { 0.0f, 0.0f, 0.0f };
        public float[] colorIndexes = new float[] { 1.0f, 1.0f, 1.0f };

        public void SetTexture(string file)
        {
            
            Bitmap bitBox = new(new Bitmap(file));
            bitBox.RotateFlip(RotateFlipType.RotateNoneFlipY);
            BitmapData data = bitBox.LockBits(new Rectangle(0, 0, bitBox.Width, bitBox.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            if (textureID <= 0)
                textureID = GL.GenTexture();
            else
                GL.BindTexture(TextureTarget.Texture2D, textureID);
            bitBox.UnlockBits(data);
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitBox.Width, bitBox.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
        }
        public void DeleteTexture()
        {
            if (textureID <= 0) return;
            GL.DeleteTexture(textureID);
            textureID = 0;
        }
    }
}
