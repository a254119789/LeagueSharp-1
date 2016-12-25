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

    using System;
    using System.Drawing;
    using System.Linq;

    using LeagueSharp;
    using LeagueSharp.Common;

    using Circle = LeagueSharp.Common.Circle;

    #endregion

    internal class MenuManager
    {
        #region Static Fields

        public static bool Enabled;

        public static Menu Menu;

        public static Menu AllyMenu;

        public static Menu EnemyMenu;

        #endregion

        #region Public Methods and Operators

        public static void Init()
        {
            Menu = new Menu("MinionsTillLevel", "minionsTillLevel", true);

            Menu.AddItem(new MenuItem("enable", "MinionsTillLevel - Enabled").SetValue(true));
            Menu.AddItem(new MenuItem("drawText", "Draw Text").SetValue(new Circle(true, Color.White, 0f)));
            Menu.AddItem(new MenuItem("drawRange", "Draw Exp Range").SetValue(new Circle(true, Color.White, 1600f)));
            Menu.AddItem(new MenuItem("yOffset", "Y Pos Offset").SetValue(new Slider(50, 0, 150)));

            AllyMenu = new Menu("Allies", "allyMenu");
            EnemyMenu = new Menu("Enemies", "enemyMenu");

            Console.WriteLine(ObjectManager.Player.Team.ToString());

            foreach (var champion in HeroManager.AllHeroes.ToList())
            {
                if (champion.Team == ObjectManager.Player.Team)
                {
                    AllyMenu.AddItem(
                        new MenuItem("drawFor" + champion.ChampionName, "Draw for " + champion.ChampionName).SetValue(
                            true));
                }
                else
                {
                    EnemyMenu.AddItem(
                        new MenuItem("drawFor" + champion.ChampionName, "Draw for " + champion.ChampionName).SetValue(true));
                }
            }

            Enabled = Menu.Item("enable").GetValue<bool>();
            Menu.AddSubMenu(AllyMenu);
            Menu.AddSubMenu(EnemyMenu);
            Menu.AddToMainMenu();
        }

        #endregion
    }
}