using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

// A mix of:
// https://stackoverflow.com/questions/2416748/how-do-you-simulate-mouse-click-in-c
// https://discussions.unity.com/t/move-set-mouse-cursor-position/746496/10
namespace ChristmasLearningProject.Tests.Runtime
{
    public static class MouseOperations
    {
        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public static IEnumerator ClickInWorld(Vector2 worldPoint)
        {
            ClickAt(Camera.main.WorldToScreenPoint(worldPoint));
            yield return null;
        }

        public static void ClickAt(Vector2 point)
        {
            SetCursorPosition(point);
            MouseEvent(MouseEventFlags.LeftUp | MouseEventFlags.LeftDown);
        }

        public static void SetCursorPosition(Vector2 point)
        {
            UnityEngine.InputSystem.Mouse.current.WarpCursorPosition(point);
        }

        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }

        public static void MouseEvent(MouseEventFlags value)
        {
            MousePoint position = GetCursorPosition();

            mouse_event
                ((int)value,
                    position.X,
                    position.Y,
                    0,
                    0)
                ;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}