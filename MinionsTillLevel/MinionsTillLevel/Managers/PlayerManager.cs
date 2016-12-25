// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerManager.cs" company="LeagueSharp">
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

    using System.Collections.Generic;
    using System;

    #endregion

    internal class PlayerManager
    {
        #region Static Fields

        internal static Dictionary<int, float> LevelExp = new Dictionary<int, float>();

        #endregion

        #region Public Methods and Operators

        public static void Init()
        {
            LevelExp.Add(1, 280);
            LevelExp.Add(2, 380);
            LevelExp.Add(3, 480);
            LevelExp.Add(4, 580);
            LevelExp.Add(5, 680);
            LevelExp.Add(6, 780);
            LevelExp.Add(7, 880);
            LevelExp.Add(8, 980);
            LevelExp.Add(9, 1080);
            LevelExp.Add(10, 1180);
            LevelExp.Add(11, 1280);
            LevelExp.Add(12, 1380);
            LevelExp.Add(13, 1480);
            LevelExp.Add(14, 1580);
            LevelExp.Add(15, 1680);
            LevelExp.Add(16, 1780);
            LevelExp.Add(17, 1880);
            LevelExp.Add(18, 0);
        }

        public static float ReturnNextLevelExp(int level)
        {
            float nextLevelExp = 0;

            for (var i = 1; i <= level; i++)
            {
                nextLevelExp = nextLevelExp + LevelExp[i];
            }

            return nextLevelExp;
        }

        public static float ReturnTotalExp(int level)
        {
            float totalExp = 0;

            for (var i = 1; i <= level; i++)
            {
                totalExp = totalExp + LevelExp[i];
            }

            return totalExp;
        }

        #endregion
    }
}