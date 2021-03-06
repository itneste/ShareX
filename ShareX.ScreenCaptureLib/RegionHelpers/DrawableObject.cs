﻿#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2017 ShareX Team

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using System.Drawing;
using System.Windows.Forms;

namespace ShareX.ScreenCaptureLib
{
    internal abstract class DrawableObject
    {
        public event MouseEventHandler MousePressed;
        public event MouseEventHandler MouseReleased;

        public bool Visible { get; set; }
        public bool HandleMouseInput { get; set; } = true;
        public Rectangle Rectangle { get; set; }
        public bool IsCursorHover { get; set; }
        public bool IsDragging { get; protected set; }
        public int Order { get; set; }

        public virtual void OnDraw(Graphics g)
        {
            if (IsDragging)
            {
                g.FillRectangle(Brushes.Blue, Rectangle);
            }
            else if (IsCursorHover)
            {
                g.FillRectangle(Brushes.Green, Rectangle);
            }
            else
            {
                g.FillRectangle(Brushes.Red, Rectangle);
            }
        }

        public virtual void OnMousePressed(Point position)
        {
            IsDragging = true;

            if (MousePressed != null)
            {
                MousePressed(this, new MouseEventArgs(MouseButtons.Left, 1, position.X, position.Y, 0));
            }
        }

        public virtual void OnMouseReleased(Point position)
        {
            IsDragging = false;

            if (MouseReleased != null)
            {
                MouseReleased(this, new MouseEventArgs(MouseButtons.Left, 1, position.X, position.Y, 0));
            }
        }
    }
}