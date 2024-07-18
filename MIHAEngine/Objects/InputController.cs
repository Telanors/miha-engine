using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace MIHAEngine
{
    public class InputController
    {
        private MouseState mouse;
        private KeyboardState keyboard;
        public InputController(MouseState mouse, KeyboardState keyboard) 
        { 
            this.mouse = mouse;
            this.keyboard = keyboard;
        }
        public Vector2 MouseDelta => mouse.Delta;
        public Vector2 MousePosition=> mouse.Position;
        public bool MouseKeyPressed(MouseButton button) => mouse.IsButtonPressed(button);
        public bool KeyPressed(Keys key) => keyboard.IsKeyPressed(key);
        public Vector3 GetInputAxis()
        {
            Vector3 inputDirection = Vector3.Zero;
            if (keyboard.IsKeyDown(Keys.W))
            {
                inputDirection += Vector3.UnitZ;
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                inputDirection -= Vector3.UnitZ;
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                inputDirection -= Vector3.UnitX;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                inputDirection += Vector3.UnitX;
            }
            if (keyboard.IsKeyDown(Keys.Space))
            {
                inputDirection += Vector3.UnitY;
            }
            if (keyboard.IsKeyDown(Keys.LeftShift))
            {
                inputDirection -= Vector3.UnitY;
            }

            return inputDirection.LengthSquared > 0.0f ? inputDirection.Normalized() : inputDirection;
        }

    }
}
