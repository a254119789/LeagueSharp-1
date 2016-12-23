namespace DrunkLee
{
    using System;

    using LeagueSharp;
    using LeagueSharp.Common;

    internal class Program
    {
        #region Methods

        private static void Game_OnGameLoad(EventArgs args)
        {
            if (ObjectManager.Player.ChampionName == "LeeSin")
            {
                LeeSin.Init();
            }
        }

        private static void Main()
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        #endregion
    }
}