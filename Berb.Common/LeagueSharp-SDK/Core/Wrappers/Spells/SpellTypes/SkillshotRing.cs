﻿namespace LeagueSharp.SDK
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using EloBuddy.SDK.Enumerations;
    using EloBuddy.SDK.Events;
    using EloBuddy.SDK.Menu.Values;
    using EloBuddy.SDK.Menu;
    using EloBuddy.SDK;
    using EloBuddy;
    using Enumerations;
    using LeagueSharp.SDK.Clipper;
    using LeagueSharp.SDK.Core.Utils;

    using SharpDX;
    using Polygons;
    using Data.DataTypes;
    public class SkillshotRing : SkillshotMissile
    {
        #region Constructors and Destructors

        public SkillshotRing(string spellName)
            : base(spellName)
        {
        }

        public SkillshotRing(SpellDatabaseEntry entry)
            : base(entry)
        {
        }

        #endregion

        public override string ToString()
        {
            return "SkillshotRing: Champion=" + this.SData.ChampionName + " SpellType=" + this.SData.SpellType + " SpellName=" + this.SData.SpellName;
        }

        #region Public Properties

        internal RingPoly Ring { get; set; }

        #endregion

        #region Public Methods and Operators

        internal override void UpdatePolygon()
        {
            if (this.Ring == null)
            {
                this.Ring = new RingPoly(this.EndPosition, this.SData.Radius, this.SData.RingRadius, 20);
                this.UpdatePath();
            }
        }

        internal override void UpdatePath()
        {
            this.Path = this.Ring.ToClipperPath();
        }

        #endregion
    }
}