namespace DrunkLee
{
    using System.Drawing;

    using LeagueSharp.Common;

    using Orbwalker = LeagueSharp.Common.Orbwalking;

    /// <summary>
    ///     Class containing all Menu configuration
    /// </summary>
    internal class Config
    {
        #region Static Fields

        /// <summary>
        ///     Combo Menu
        /// </summary>
        public static Menu Combo;

        /// <summary>
        ///     Draw Menu
        /// </summary>
        public static Menu Draw;

        /// <summary>
        ///     Jungle Clear Menu
        /// </summary>
        public static Menu JungleClear;

        /// <summary>
        ///     Lane Clear Menu
        /// </summary>
        public static Menu LaneClear;

        /// <summary>
        ///     DrunkLee Menu
        /// </summary>
        public static Menu Menu;

        /// <summary>
        ///     Orbwalker
        /// </summary>
        public static Orbwalking.Orbwalker Orbwalker;

        #endregion

        #region Methods

        /// <summary>
        ///     Initialize Config.cs
        /// </summary>
        internal static void Init()
        {
            // Initialize Menu, Orbwalker and Target Selector
            Menu = new Menu("DrunkLee", "drunklee", true);
            var orbwalkerMenu = Menu.AddSubMenu(new Menu("Orbwalking", "Orbwalking"));
            Orbwalker = new Orbwalking.Orbwalker(orbwalkerMenu);
            var ts = Menu.AddSubMenu(new Menu("Target Selector", "Target Selector"));
            TargetSelector.AddToMenu(ts);

            // Combo Menu
            Combo = Menu.AddSubMenu(new Menu("Combo", "combo"));
            Combo.AddItem(new MenuItem("comboQ1", "Use Q").SetValue(true));
            Combo.AddItem(new MenuItem("comboQ2", "Use Q2").SetValue(true));
            Combo.AddItem(new MenuItem("comboW", "Use W").SetValue(true));
            Combo.AddItem(new MenuItem("comboE", "Use E").SetValue(true));
            Combo.AddItem(new MenuItem("comboR", "Use R").SetValue(true));
            Combo.AddItem(new MenuItem("spacer", string.Empty));
            Combo.AddItem(new MenuItem("comboStar", "Star Combo in 1v1").SetValue(true));

            // LaneClear Menu
            LaneClear = Menu.AddSubMenu(new Menu("Lane Clear", "laneClear"));
            LaneClear.AddItem(new MenuItem("farmQ", "Use Q").SetValue(false));
            LaneClear.AddItem(new MenuItem("farmW", "Use W").SetValue(true));
            LaneClear.AddItem(new MenuItem("farmE", "Use E").SetValue(true));
            LaneClear.AddItem(new MenuItem("farmEnergy", "Energy").SetValue(new Slider(60)));

            // JungleClear Menu
            JungleClear = Menu.AddSubMenu(new Menu("Jungle Clear", "jungleClear"));
            JungleClear.AddItem(new MenuItem("jungleQ", "Use Q").SetValue(true));
            JungleClear.AddItem(new MenuItem("jungleQ", "Use W").SetValue(true));
            JungleClear.AddItem(new MenuItem("jungleQ", "Use E").SetValue(true));
            JungleClear.AddItem(new MenuItem("jungleEnergy", "Energy").SetValue(new Slider(60)));
            JungleClear.AddItem(new MenuItem("spacer", string.Empty));
            JungleClear.AddItem(new MenuItem("q2Smite", "Smite -> Q2").SetValue(true));

            // Draw Menu
            Draw = Menu.AddSubMenu(new Menu("Draw", "draw"));
            Draw.AddItem(
                new MenuItem("drawQ", "Draw Q").SetValue(
                    new Circle(true, Color.Cyan, SpellManager.Spells[SpellManager.SpellEnum.Q].Range)));

            Menu.AddToMainMenu();
        }

        #endregion
    }
}