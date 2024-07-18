using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;

namespace MIHAEngine
{
    public class Camera
    {
        private float aspect;
        private Vector2i size;
        public Vector2i Size
        { 
            get => size;
            set
            {
                size = value;
                aspect = size.X / (float)size.Y;
            } 
        }
        public float FOV { get; set; } = 70f;
        public float NearPlane { get; set; } = 0.1f;
        public float FarPlane { get; set; } = 100f;
        public float MouseSensitivity { get; set; } = 0.15f;
        public float MovementSpeed { get; set; } = 15f;
        public float MaxAngle { get; set; } = 80f;
        public Transform Transform { get; private set; } = new Transform();

        public Camera(Vector2i Size, float FOV, float NearPlane, float FarPlane)
        {
            this.Size = Size;
            this.FOV = FOV;
            this.NearPlane = NearPlane;
            this.FarPlane = FarPlane;
        }

        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(Transform.Position, Transform.Position + Transform.Forward, Vector3.UnitY);
        }
        public Matrix4 GetPerspectiveMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(FOV), aspect, NearPlane, FarPlane);
        }
        public Matrix4 GetOrthographicMatrix()
        {
            return Matrix4.CreateOrthographic(100 * aspect, 100, NearPlane, FarPlane);
        }
        public void Move(Vector3 direction, float deltaTime)
        {
            Transform.Translate((Transform.Forward * direction.Z + Vector3.UnitY * direction.Y + Transform.Right * direction.X) * MovementSpeed * deltaTime);
        }
        public void Rotate(float xDelta, float yDelta, bool limit = true)
        {
            Vector3 additionalRotation = new Vector3(yDelta * MouseSensitivity, -xDelta * MouseSensitivity, 0.0f);

            if (limit)
            {
                if(Transform.Rotation.X + additionalRotation.X > MaxAngle)
                {
                    additionalRotation.X = MaxAngle - Transform.Rotation.X;
                }
                else if(Transform.Rotation.X + additionalRotation.X < -MaxAngle)
                {
                    additionalRotation.X = -MaxAngle - Transform.Rotation.X;
                }
            }

            Transform.Rotation += additionalRotation;
        }
    }
}
