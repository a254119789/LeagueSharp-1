// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuManager.cs" company="LeagueSharp">
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

    using LeagueSharp.Common;

    #endregion

    internal class MenuManager
    {
        #region Static Fields

        public static bool Enabled;

        private static Menu menu;

        #endregion

        #region Public Methods and Operators

        public static void Init()
        {
            menu = new Menu("MinionsTillLevel", "minionsTillLevel", true);

            menu.AddItem(new MenuItem("enable", "MinionsTillLevel - Enabled").SetValue(true));
            Enabled = menu.Item("enable").GetValue<bool>();
            menu.AddToMainMenu();
        }

        #endregion
    }
}