// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Minion.cs" company="LeagueSharp">
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

namespace MinionsTillLevel
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LeagueSharp;
    using LeagueSharp.Common;

    using Managers;

    #endregion

    #region Using Directives

    #endregion

    internal class Minion
    {
        #region Static Fields

        internal static float ExperienceCannon = 92f;

        internal static float ExperienceMelee = 58.88f;

        internal static float ExperienceRanged = 29.44f;

        internal static float ExperienceSuper = 97f;

        internal static int NumberOfMelee = 0;

        internal static int NumberOfRanged = 0;

        internal static int NumberOfCannons = 0;

        internal static int NumberOfSupers = 0;

        internal static List<Obj_AI_Base> Minions;

        internal static int NumberOfMinions;

        #endregion

        #region Public Methods and Operators

        public static void Init()
        {
            Minions = MinionManager.GetMinions(ObjectManager.Player.Position, 1600f).Where(x => !x.IsDead).ToList();
            NumberOfMinions = Minions.Count();
        }

        public static void GetMinions()
        {
            //NumberOfMelee = Convert.ToInt16(MinionsTillLevel.ExpTillNextLevel / ExperienceMelee);
            //NumberOfRanged = Convert.ToInt16(MinionsTillLevel.ExpTillNextLevel / ExperienceRanged);
            // NumberOfCannons = Convert.ToInt16(MinionsTillLevel.ExpTillNextLevel / ExperienceCannon);
            // NumberOfSupers = Convert.ToInt16(MinionsTillLevel.ExpTillNextLevel / ExperienceSuper);


            NumberOfMelee = (int)Math.Ceiling(MinionsTillLevel.ExpTillNextLevel / (ExperienceMelee));
            NumberOfRanged = (int)Math.Ceiling(MinionsTillLevel.ExpTillNextLevel / (ExperienceRanged));
        }

        #endregion
    }
}