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

using ShareX.HelpersLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace ShareX.ScreenCaptureLib
{
    internal class ButtonObject : DrawableObject
    {
        public string Text { get; set; }
        public Color ButtonColor { get; set; }

        private int depth = 2;

        public override void OnDraw(Graphics g)
        {
            Rectangle rect = Rectangle;

            if (IsCursorHover)
            {
                rect = rect.LocationOffset(0, depth);
            }

            g.SmoothingMode = SmoothingMode.HighQuality;

            using (SolidBrush buttonBrush = new SolidBrush(ButtonColor))
            {
                g.PixelOffsetMode = PixelOffsetMode.Half;

                if (!IsCursorHover)
                {
                    g.DrawRoundedRectangle(Brushes.Black, rect.LocationOffset(0, depth), 5);
                }

                g.DrawRoundedRectangle(buttonBrush, rect, 5);

                g.PixelOffsetMode = PixelOffsetMode.Default;
            }

            g.SmoothingMode = SmoothingMode.None;

            using (Font font = new Font("Arial", 18))
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.DrawString(Text, font, Brushes.Black, rect.LocationOffset(0, 4), sf);
                g.DrawString(Text, font, Brushes.White, rect.LocationOffset(0, 2), sf);
            }
        }
    }
}