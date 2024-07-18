using OpenTK.Mathematics;
using System;


namespace MIHAEngine
{
    public class Transform
    {
        private Vector3 forward = Vector3.UnitZ;
        private Vector3 right = Vector3.UnitX;
        private Vector3 up = Vector3.UnitY;
        public Vector3 Forward => forward;
        public Vector3 Right => right;
        public Vector3 Up => up;

        private Vector3 position = Vector3.Zero;
        private Vector3 rotation = Vector3.Zero;
        private Vector3 scale = Vector3.One;
        public Vector3 Position
        {
            get => position;
            set => position = value;
        }
        public Vector3 Rotation
        {
            get => rotation;
            set
            {
                rotation = value;
                UpdateVectors();
            }
        }
        public Vector3 Scale
        {
            get => scale;
            set => scale = value;
        }
        public Transform()
        {
            UpdateVectors();
        }
        public Transform(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            UpdateVectors();
        }
        public void Translate(Vector3 direction)
        {
            position += direction;
        }

        public void Rotate(float angle, int x, int y, int z)
        {
            x = Math.Clamp(x, 0, 1);
            y = Math.Clamp(y, 0, 1);
            z = Math.Clamp(z, 0, 1);

            rotation.X += angle * x;
            rotation.Y += angle * y;
            rotation.Z += angle * z;

            UpdateVectors();
        }
        private void UpdateVectors()
        {
            Matrix4 Rotation =
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotation.X)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Y)) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotation.Z));

            forward = Vector3.Normalize(Vector3.TransformVector(Vector3.UnitZ, Rotation));
            right = Vector3.Normalize(Vector3.TransformVector(Vector3.UnitX, Rotation));
            up = Vector3.Normalize(Vector3.TransformVector(Vector3.UnitY, Rotation));
        }
    }
}
