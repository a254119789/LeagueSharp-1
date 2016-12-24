// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DrawingManager.cs" company="LeagueSharp">
//   Copyright (C) 2016 LeagueSharp
//   
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//   
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MinionsTillLevel.Managers
{
    #region Using Directives

    using System;
    using System.Drawing;

    using LeagueSharp;
    using LeagueSharp.Common;

    using SharpDX;

    using Color = System.Drawing.Color;

    #endregion

    internal class DrawingManager
    {
        #region Static Fields

        public static string StringText;

        #endregion

        #region Enums

        internal enum DrawType
        {
            Circle,

            Line,

            Cone,

            Arc
        }

        #endregion

        #region Public Methods and Operators

        public static void OnDraw(EventArgs args)
        {
            StringText = string.Format(
            "Current EXP: {0} | EXP For Next Level: {1}",
            ObjectManager.Player.Experience,
            MinionsTillLevel.GlobalExpTillLevel);

            if (!MenuManager.Enabled)
            {
                return;
            }
            Render.Circle.DrawCircle(ObjectManager.Player.Position, 1600f, Color.Tomato);

            var heropos = Drawing.WorldToScreen(ObjectManager.Player.Position);
            Drawing.DrawText(heropos.X - 175, heropos.Y + 50, Color.Tomato, StringText);
            Drawing.DrawText(heropos.X - 160, heropos.Y + 75, Color.Coral, string.Format("Minions till level: {0} Melee or {1} Ranged or {2} Cannons", Minion.NumberOfMelee, Minion.NumberOfRanged, Minion.NumberOfCannons));
        }

        #endregion
    }
}