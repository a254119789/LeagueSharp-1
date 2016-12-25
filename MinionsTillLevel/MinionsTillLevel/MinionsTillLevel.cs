// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinionsTillLevel.cs" company="LeagueSharp">
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
    using System.Globalization;

    using Managers;

    using LeagueSharp;

    using Game = LeagueSharp.Game;

    #endregion

    internal class MinionsTillLevel
    {
        #region Static Fields

        public static double ExpTillNextLevel;

        public static string GlobalExpTillLevel;

        public static readonly Obj_AI_Hero Player = ObjectManager.Player;

        #endregion

        #region Public Methods and Operators

        public static void Init()
        {
            MenuManager.Init();
            PlayerManager.Init();
            Minion.Init();

            if (ObjectManager.Player.Level != 18)
            {
                ExpTillNextLevel = Math.Ceiling(PlayerManager.ReturnNextLevelExp(Player.Level) - Player.Experience);
                GlobalExpTillLevel = ExpTillNextLevel.ToString(CultureInfo.CurrentCulture);
            }

            Drawing.OnDraw += DrawingManager.OnDraw;
            Game.OnUpdate += Game_OnUpdate;
            Obj_AI_Base.OnLevelUp += Obj_AI_Base_OnLevelUp;
        }

        #endregion

        #region Methods

        private static void Game_OnUpdate(EventArgs args)
        {
            ExpTillNextLevel = Math.Ceiling(PlayerManager.ReturnNextLevelExp(Player.Level) - Player.Experience);
            GlobalExpTillLevel = ExpTillNextLevel.ToString(CultureInfo.CurrentCulture);
            Minion.GetMinions();
        }

        private static void Obj_AI_Base_OnLevelUp(Obj_AI_Base sender, EventArgs args)
        {
            if (!sender.IsMe)
            {
                return;
            }
            GlobalExpTillLevel =
                (PlayerManager.ReturnTotalExp(Player.Level) - PlayerManager.ReturnNextLevelExp(Player.Level)).ToString(
                    CultureInfo.CurrentCulture);
        }

        #endregion
    }
}