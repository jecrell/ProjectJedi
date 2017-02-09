﻿using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI;
using System.Reflection;
using UnityEngine;

namespace CompExtraSounds
{
    [StaticConstructorOnStartup]
    static class HarmonyCompExtraSounds
    {
        static HarmonyCompExtraSounds()
        {

            HarmonyInstance harmony = HarmonyInstance.Create("rimworld.jecrell.compstwo");
           

            harmony.Patch(AccessTools.Method(typeof(Verb_MeleeAttack), "SoundMiss"), null, new HarmonyMethod(typeof(HarmonyCompExtraSounds), "SoundMissPrefix"));
            harmony.Patch(AccessTools.Method(typeof(Verb_MeleeAttack), "SoundHitPawn"), null, new HarmonyMethod(typeof(HarmonyCompExtraSounds), "SoundHitPawnPrefix"));
            harmony.Patch(AccessTools.Method(typeof(Verb_MeleeAttack), "SoundHitBuilding"), null, new HarmonyMethod(typeof(HarmonyCompExtraSounds), "SoundHitBuildingPrefix"));
        }

        //=================================== COMPEXTRASOUNDS
        public static void SoundHitPawnPrefix(ref SoundDef __result, Verb_MeleeAttack __instance)
        {
            Pawn pawn = __instance.caster as Pawn;
            if (pawn != null)
            {
                Pawn_EquipmentTracker pawn_EquipmentTracker = pawn.equipment;
                if (pawn_EquipmentTracker != null)
                {
                    //Log.Message("2");
                    ThingWithComps thingWithComps = (ThingWithComps)AccessTools.Field(typeof(Pawn_EquipmentTracker), "primaryInt").GetValue(pawn_EquipmentTracker);

                    if (thingWithComps != null)
                    {
                        //Log.Message("3");
                        CompExtraSounds CompExtraSounds = thingWithComps.GetComp<CompExtraSounds>();

                        if (CompExtraSounds != null)
                        {
                            if (CompExtraSounds.Props.soundHitPawn != null)
                            {
                                __result = CompExtraSounds.Props.soundHitPawn;
                                return;
                            }
                        }
                    }
                }
            }
        }

        public static void SoundMissPrefix(ref SoundDef __result, Verb_MeleeAttack __instance)
        {
            Pawn pawn = __instance.caster as Pawn;
            if (pawn != null)
            {
                Pawn_EquipmentTracker pawn_EquipmentTracker = pawn.equipment;
                if (pawn_EquipmentTracker != null)
                {
                    //Log.Message("2");
                    ThingWithComps thingWithComps = (ThingWithComps)AccessTools.Field(typeof(Pawn_EquipmentTracker), "primaryInt").GetValue(pawn_EquipmentTracker);

                    if (thingWithComps != null)
                    {
                        //Log.Message("3");
                        CompExtraSounds CompExtraSounds = thingWithComps.GetComp<CompExtraSounds>();
                        if (CompExtraSounds != null)
                        {
                            if (CompExtraSounds.Props.soundMiss != null)
                            {
                                Log.Message("Returned");
                                __result = CompExtraSounds.Props.soundMiss;
                                return;
                            }
                        }
                    }
                }
            }
        }

        public static void SoundHitBuildingPrefix(ref SoundDef __result, Verb_MeleeAttack __instance)
        {
            Pawn pawn = __instance.caster as Pawn;
            if (pawn != null)
            {
                Pawn_EquipmentTracker pawn_EquipmentTracker = pawn.equipment;
                if (pawn_EquipmentTracker != null)
                {
                    //Log.Message("2");
                    ThingWithComps thingWithComps = (ThingWithComps)AccessTools.Field(typeof(Pawn_EquipmentTracker), "primaryInt").GetValue(pawn_EquipmentTracker);

                    if (thingWithComps != null)
                    {
                        //Log.Message("3");
                        CompExtraSounds CompExtraSounds = thingWithComps.GetComp<CompExtraSounds>();
                        if (CompExtraSounds != null)
                        {
                            if (CompExtraSounds.Props.soundHitBuilding != null)
                            {
                                __result = CompExtraSounds.Props.soundHitBuilding;
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
