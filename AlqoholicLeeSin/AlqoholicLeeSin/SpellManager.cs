namespace AlqoholicLeeSin
{
    using System.Collections.Generic;

    using LeagueSharp;
    using LeagueSharp.Common;

    internal class SpellManager
    {
        #region Constants

        /// <summary>
        ///     Lee Sin R kick distance
        /// </summary>
        private const float RDistance = 700;

        /// <summary>
        ///     Lee Sin R kick width
        /// </summary>
        private const float Rwidth = 100;

        #endregion

        #region Static Fields

        /// <summary>
        ///     Flash
        /// </summary>
        public static SpellSlot Flash;

        public static Spell Smite = null;

        /// <summary>
        ///     Spells
        /// </summary>
        public static Dictionary<SpellEnum, Spell> Spells = new Dictionary<SpellEnum, Spell>
                                                                {
                                                                    { SpellEnum.Q, new Spell(SpellSlot.Q, 1100f) },
                                                                    { SpellEnum.W, new Spell(SpellSlot.W, 700f) },
                                                                    { SpellEnum.E, new Spell(SpellSlot.E, 425f) },
                                                                    { SpellEnum.R, new Spell(SpellSlot.R, 375f) },
                                                                    { SpellEnum.R2, new Spell(SpellSlot.R, 800f) }
                                                                };

        /// <summary>
        ///     BuffList
        /// </summary>
        private static readonly List<string> BuffList =
            new List<string>(
                new[]
                    {
                        "blindmonkqone", "blindmonkwone", "blindmonkeone", "blindmonkqtwo", "blindmonkwtwo",
                        "blindmonketwo", "blindmonkrkick"
                    });

        #endregion

        #region Enums

        internal enum SpellEnum
        {
            Q,

            W,

            E,

            R,

            R2
        }

        #endregion
    }
}