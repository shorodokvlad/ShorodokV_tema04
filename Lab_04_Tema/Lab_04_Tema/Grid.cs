using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace Lab_04_Tema
{
    class Grid
    {
        private readonly Color colorisation;
        private bool visibility;

        // CONST
        private readonly Color GRIDCOLOR = Color.WhiteSmoke;
        private const int GRIDSTEP = 10;
        private const int UNITS = 50;
        private const int POINT_OFFSET = GRIDSTEP * UNITS;
        private const int MICRO_OFFSET = 1; // usefeul because otherwise the axes will be "drown" in overlapping grid lines...

        // Constructor – initializeaza culoarea si vizibilitatea
        public Grid()
        {
            colorisation = GRIDCOLOR;
            visibility = true;
        }

        // Afiseaza grila
        public void Show()
        {
            visibility = true;
        }

         // Ascunde grila
        public void Hide()
        {
            visibility = false;
        }

        // Comuta vizibilitatea grilei
        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

         // Deseneaza grila pe planul XZ
        public void Draw()
        {
            if (visibility)
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(colorisation);
                for (int i = -1 * GRIDSTEP * UNITS; i <= GRIDSTEP * UNITS; i += GRIDSTEP)
                {
                    // XZ plan drawing: parallel with Oz
                    GL.Vertex3(i + MICRO_OFFSET, 0, POINT_OFFSET);
                    GL.Vertex3(i + MICRO_OFFSET, 0, -1 * POINT_OFFSET);

                    // XZ plan drawing: parallel with Ox
                    GL.Vertex3(POINT_OFFSET, 0, i + MICRO_OFFSET);
                    GL.Vertex3(-1 * POINT_OFFSET, 0, i + MICRO_OFFSET);
                }
                GL.End();
            }
        }
    }
}
