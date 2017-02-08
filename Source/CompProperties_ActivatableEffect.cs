﻿using System;
using Verse;

namespace ProjectJedi
{
    internal class CompProperties_ActivatableEffect : CompProperties
    {
        public GraphicData graphicData;

        public AltitudeLayer altitudeLayer;

        public string ActivateLabel;
        public string DeactivateLabel;

        public string uiIconPathActivate;
        public string uiIconPathDeactivate;

        public bool gizmosOnEquip = false;

        public float Altitude
        {
            get
            {
                return Altitudes.AltitudeFor(this.altitudeLayer);
            }
        }

        public CompProperties_ActivatableEffect()
        {
            this.compClass = typeof(CompActivatableEffect);
        }
    }
}