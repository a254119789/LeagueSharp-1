namespace AlqoholicLeeSin
{
    using LeagueSharp;
    using LeagueSharp.Common;

    internal class LeeSin
    {
        #region Methods

        /// <summary>
        ///     Initialize Menu and Utilities
        /// </summary>
        internal static void Init()
        {
            Config.Init();
            Utils.Init();
        }

        private void Combo()
        {
            var qTarget = TargetSelector.GetTarget(
                SpellManager.Spells[SpellManager.SpellEnum.Q].Range,
                TargetSelector.DamageType.Physical);

            ComboQ(qTarget);
        }

        private static void CastW(Obj_AI_Base obj)
        {
        }

        /// <summary>
        ///     Cast Q on target
        /// </summary>
        /// <param name="target">Target Selector target</param>
        private static void ComboQ(Obj_AI_Base target)
        {
            var prediction = SpellManager.Spells[SpellManager.SpellEnum.Q].GetPrediction(target);

            if (!SpellManager.Spells[SpellManager.SpellEnum.Q].IsReady() || target == null
                || !Config.Combo.Item("comboQ").GetValue<bool>())
            {
                return;
            }

            if (prediction.Hitchance >= HitChance.High)
            {
                SpellManager.Spells[SpellManager.SpellEnum.Q].Cast(target);
            }
        }

        #endregion
    }
}