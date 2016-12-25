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
    using System.Linq;

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
            var textColor = MenuManager.Menu.Item("drawText").GetValue<Circle>().Color;
            var rangeColor = MenuManager.Menu.Item("drawRange").GetValue<Circle>().Color;
            var range = MenuManager.Menu.Item("drawRange").GetValue<Circle>().Radius;

            if (!MenuManager.Enabled)
            {
                return;
            }
            Render.Circle.DrawCircle(ObjectManager.Player.Position, range, rangeColor);

            if (!MenuManager.Menu.Item("drawText").GetValue<Circle>().Active)
            {
                return;
            }

            foreach (var champion in HeroManager.AllHeroes.ToList())
            {
                if (!champion.IsVisible || champion.IsDead || !MenuManager.Menu.Item("drawFor" + champion.ChampionName).GetValue<bool>())
                {
                    return;
                }

                var expTillLevel = Math.Ceiling(PlayerManager.ReturnNextLevelExp(champion.Level) - champion.Experience);
                var pos = Drawing.WorldToScreen(champion.Position);
                var stringText = string.Format(
                    "{0}: Current EXP: {1} | EXP For Next Level: {2}",
                    champion.ChampionName,
                    champion.Experience,
                    expTillLevel);

                var numberOfMelee = (int)Math.Ceiling(expTillLevel / (Minion.ExperienceMelee));
                var numberOfRanged = (int)Math.Ceiling(expTillLevel / (Minion.ExperienceRanged));
                var numberOfCannons = (int)Math.Ceiling(expTillLevel / (Minion.ExperienceCannon));
                var numberOfSupers = (int)Math.Ceiling(expTillLevel / (Minion.ExperienceSuper));

                Drawing.DrawText(
                    pos.X - 165,
                    pos.Y + MenuManager.Menu.Item("yOffset").GetValue<Slider>().Value,
                    textColor,
                    stringText);

                Drawing.DrawText(
                    pos.X - 150,
                    pos.Y + MenuManager.Menu.Item("yOffset").GetValue<Slider>().Value + 20,
                    textColor,
                    string.Format(
                        "Minions till level: {0} Melee or {1} Ranged or {2} Cannons",
                        numberOfMelee,
                        numberOfRanged,
                        numberOfCannons));
            }
        }

        #endregion
    }
}