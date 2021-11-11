using HarmonyLib;
using Kingmaker;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Root;
using Kingmaker.Cheats;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.Common;
using Kingmaker.UI.MVVM._VM.ServiceWindows.Spellbook.Metamagic;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Class.LevelUp.Actions;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Groups;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Utility;
using Kingmaker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.UI;
using Kingmaker.UI.MVVM._PCView.InGame;
using UnityEngine;
using UnityModManagerNet;
using static UnityModManagerNet.UnityModManager;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Items;
using Kingmaker.Blueprints.Items.Ecnchantments;

namespace FinneanTweaks
{
#if DEBUG
    [EnableReloading]
#endif
    public class Main
    {
        public static UnityModManager.ModEntry ModEntry;
        public static bool IsEnabled = false;
        public static UnityModManager.ModEntry.ModLogger logger;
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                ModEntry = modEntry;
                logger = modEntry.Logger;
                var harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll();
#if DEBUG
                modEntry.OnGUI = OnGui;
#endif
                modEntry.OnUnload = Unload;
                modEntry.OnToggle = OnToggle;
                IsEnabled = ModEntry.Enabled;
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value /* active or inactive */)
        {
            IsEnabled = value;
            return true; // Permit or not.
        }
        static bool Unload(UnityModManager.ModEntry modEntry)
        {
            new Harmony(modEntry.Info.Id).UnpatchAll(modEntry.Info.Id);
            return true;
        }
#if DEBUG
        static void OnGui(ModEntry modentry)
        {
            if(GUILayout.Button("Generate Enchant List"))
            {
                foreach(var enchantbp in Utilities.GetAllBlueprints().Entries.Where(b => b.Type == typeof(BlueprintWeaponEnchantment)).Select(a => ResourcesLibrary.TryGetBlueprint<BlueprintItemEnchantment>(a.Guid)))
                {
                    if(enchantbp.Description.Length > 0)
                    Main.logger.Log("m_EnchantsÄ[\""+enchantbp.Name+"\"] = \""+ enchantbp.AssetGuidThreadSafe+ "\";");
                }
            }
        }
#endif
    }
}