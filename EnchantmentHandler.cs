using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.ElementsSystem;
using Kingmaker.Items;
using Kingmaker.UI.MVVM._VM.ServiceWindows.Inventory;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using Owlcat.Runtime.Core.Logging;
using Owlcat.Runtime.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinneanTweaks
{
    public static class FinneanEnchantmentHandler
    {
        public static void RefreshFinneanItems(this InventorySmartItemVM SmartItemVM)
        {
            try
            {
                if (SmartItemVM != null && SmartItemVM.m_SmartItem != null)
                    FinneanEnchantmentHandler.AddEnchantments(SmartItemVM.m_SmartItem);
                if (SmartItemVM.PolymorphItems != null)
                    foreach (var iteme in SmartItemVM?.PolymorphItems)
                    {
                        FinneanEnchantmentHandler.AddEnchantments(iteme);
                    }
            }
            catch (Exception e)
            {
                Main.logger.Error(e.ToString());
            }
        }

        public static Dictionary<string, string> EnchantsTier1
        {
            get
            {
                if (m_Enchants1 == null)
                {
                    try
                    {
                        m_Enchants1 = new Dictionary<string, string>();
                        m_Enchants1["Agile"] = "a36ad92c51789b44fa8a1c5c116a1328";
                        m_Enchants1["Bleed"] = "ac0108944bfaa7e48aa74f407e3944e3";
                        m_Enchants1["Corrosive"] = "633b38ff1d11de64a91d490c683ab1c8";
                        m_Enchants1["Cruel"] = "629c383ffb407224398bb71d1bd95d14";
                        m_Enchants1["Cruel"] = "629c383ffb407224398bb71d1bd95d14";
                        m_Enchants1["Destructive"] = "5b1550c536bd09740bf43a6ddd1ad919";
                        m_Enchants1["Disruption"] = "0f20d79b7049c0f4ca54ca3d1ea44baa";
                        m_Enchants1["Flaming"] = "1daab3baedcd2db4e9f596ae91bff1c5";
                        m_Enchants1["Frost"] = "421e54078b7719d40915ce0672511d0b";
                        m_Enchants1["Furious"] = "b606a3f5daa76cc40add055613970d2a";
                        m_Enchants1["Heartseeker"] = "e252b26686ab66241afdf33f2adaead6";
                        m_Enchants1["Improved Critical Multiplier"] = "5b1550c536bd09740bf43a6ddd1ad919";
                        m_Enchants1["Keen"] = "102a9c8c9b7a75e4fb5844e79deaf4c0";
                        m_Enchants1["Necrotic"] = "7f727c7023be4854babc44d3ee756d31";
                        m_Enchants1["Nullifying"] = "efbe3a35fc7349845ac9f96b4c63312e";
                        m_Enchants1["Radiant"] = "5ac5c88157f7dde48a2a5b24caf40131";
                        m_Enchants1["Shock"] = "7bda5277d36ad114f9f9fd21d0dab658";
                        m_Enchants1["Speed"] = "f1c0c50108025d546b2554674ea1c006";
                        m_Enchants1["Thundering"] = "690e762f7704e1f4aa1ac69ef0ce6a96";
                        m_Enchants1["Vicious"] = "0f5c798466b1c2841b2cdc712ce86c27";
                    }
                    catch (Exception e)
                    {
                        Main.logger.Error(e.ToString());
                        throw;
                    }
                }

                return m_Enchants1;
            }
        }

        public static Dictionary<string, string> m_Enchants1;

        public static Dictionary<string, string> EnchantsTier2
        {
            get
            {
                if (m_Enchants2 == null)
                {
                    m_Enchants2 = new Dictionary<string, string>();
                    m_Enchants2["Anarchic"] = "57315bc1e1f62a741be0efde688087e9";
                    m_Enchants2["Axiomatic"] = "0ca43051edefcad4b9b2240aa36dc8d4";
                    m_Enchants2["Bleed"] = "ac0108944bfaa7e48aa74f407e3944e3";
                    m_Enchants2["Brilliant Energy"] = "66e9e299c9002ea4bb65b6f300e43770";
                    m_Enchants2["Caustic"] = "2becfef47bec13940b9ee71f1b14d2dd";
                    m_Enchants2["Corrosive Burst"] = "0cf34703e67e37b40905845ca14b1380";
                    m_Enchants2["Deteriorative"] = "bbe55d6e76b973d41bf5abeed643861d";
                    m_Enchants2["Flaming Burst"] = "3f032a3cd54e57649a0cdad0434bf221";
                    m_Enchants2["Freezing"] = "00049f6046b20394091b29702c6e9617";
                    m_Enchants2["Furyborn"] = "091e2f6b2fad84a45ae76b8aac3c55c3";
                    m_Enchants2["Greater Corrosive"] = "d0c3002b7efc3b647993df15b3bcb65d";
                    m_Enchants2["Greater Flaming"] = "5f2fdab15f558084494b83b48064a844";
                    m_Enchants2["Greater Flaming"] = "a6064c14629de6d48bec8e8e0460f661";
                    m_Enchants2["Greater Frost"] = "83e7559124cb78a4c9d61360d3a4c3c2";
                    m_Enchants2["Greater Necrotic"] = "c2229230ff9292048b07a8429d6536c6";
                    m_Enchants2["Greater Shock"] = "b1de8528121b80844bd7cf09d9e1cf00";
                    m_Enchants2["Holy"] = "28a9964d81fedae44bae3ca45710c140";
                    m_Enchants2["Icy Burst"] = "564a6924b246d254c920a7c44bf2a58b";
                    m_Enchants2["Incinerating"] = "5e0e5de297c229f42b00c5b1738b50fa";
                    m_Enchants2["Lethal"] = "b28d69b00bbd4e1438a3ca951ab8c860";
                    m_Enchants2["Necrotic Burst"] = "83612e733df422742818a69bf94f57fc";
                    m_Enchants2["Shocking Burst"] = "914d7ee77fb09d846924ca08bccee0ff";
                    m_Enchants2["Thundering Burst"] = "83bd616525288b34a8f34976b2759ea1";
                    m_Enchants2["Ultrasound"] = "582849db96824254ebcc68f0b7484e51";
                    m_Enchants2["Unholy"] = "d05753b8df780fc4bb55b318f06af453";
                }

                return m_Enchants2;
            }
        }

        public static Dictionary<string, string> m_Enchants2;

        public static Dictionary<int, string> EnhancementBoni
        {
            get
            {
                if (m_EnhancementBoni == null)
                {
                    m_EnhancementBoni = new Dictionary<int, string>();
                    m_EnhancementBoni[1] = "d42fc23b92c640846ac137dc26e000d4";
                    m_EnhancementBoni[2] = "eb2faccc4c9487d43b3575d7e77ff3f5";
                    m_EnhancementBoni[3] = "80bb8a737579e35498177e1e3c75899b";
                    m_EnhancementBoni[4] = "783d7d496da6ac44f9511011fc5f1979";
                    m_EnhancementBoni[5] = "bdba267e951851449af552aa9f9e3992";
                    m_EnhancementBoni[6] = "0326d02d2e24d254a9ef626cc7a3850f";
                }

                return m_EnhancementBoni;
            }
        }

        public static Dictionary<int, string> m_EnhancementBoni;

        /// <summary>
        /// Removes Brilliant energy & Heartseeker and adds enchants according to settings.
        /// </summary>
        public static void AddEnchantments(ItemEntity finnean) //, BlueprintItemEnchantment enchant)
        {
            try
            {
              // Main.logger.Log("TriedAddEnchants");
                if (finnean == null || finnean.GetType() != typeof(ItemEntityWeapon)) return;
                string enchantmentguid = EnhancementBoni[Kingmaker.Game.Instance.Player.Chapter];
                // Main.logger.Log("Adding Enchantments...");
                if (!FinneanSettings.Instance.Enchantment1GUID.IsNullOrEmpty() &&
                    FinneanSettings.Instance.Enchantment1GUID != "66e9e299c9002ea4bb65b6f300e43770" &&
                    !FinneanSettings.Instance.Enchantment2GUID.IsNullOrEmpty() &&
                    FinneanSettings.Instance.Enchantment2GUID != "66e9e299c9002ea4bb65b6f300e43770")
                {
                    var enchantment = finnean.GetEnchantment(
                        ResourcesLibrary.TryGetBlueprint<BlueprintItemEnchantment>("66e9e299c9002ea4bb65b6f300e43770"));
                    if (enchantment != null)
                    {
                        finnean.m_HasExternalEnchantments = true;
                        finnean.RemoveEnchantment(enchantment);
                    }
                }
               // Main.logger.Log("TriedAddEnchants2");
                if (!FinneanSettings.Instance.Enchantment1GUID.IsNullOrEmpty() &&
                    FinneanSettings.Instance.Enchantment1GUID != "e252b26686ab66241afdf33f2adaead6" &&
                    !FinneanSettings.Instance.Enchantment2GUID.IsNullOrEmpty() &&
                    FinneanSettings.Instance.Enchantment2GUID != "e252b26686ab66241afdf33f2adaead6")
                {
                    var enchantment = finnean.GetEnchantment(
                        ResourcesLibrary.TryGetBlueprint<BlueprintItemEnchantment>("e252b26686ab66241afdf33f2adaead6"));
                    if (enchantment != null)
                    {
                        finnean.m_HasExternalEnchantments = true;
                        finnean.RemoveEnchantment(enchantment);
                    }
                }
               // Main.logger.Log("TriedAddEnchants3");
                foreach (var enchantment in finnean.Enchantments.ToTempList())
                {
                    if ((EnchantsTier1.Values.Contains(enchantment.Blueprint.AssetGuidThreadSafe) &&
                         FinneanSettings.Instance.Enchantment1GUID != enchantment.Blueprint.AssetGuidThreadSafe) ||
                        (EnchantsTier2.Values.Contains(enchantment.Blueprint.AssetGuidThreadSafe) &&
                         FinneanSettings.Instance.Enchantment2GUID != enchantment.Blueprint.AssetGuidThreadSafe) ||
                        (enchantmentguid != enchantment.Blueprint.AssetGuidThreadSafe &&
                         EnhancementBoni.ContainsValue(enchantment.Blueprint.AssetGuidThreadSafe)))
                    {
                        finnean.RemoveEnchantment(enchantment);
                    }
                }

                if (enchantmentguid != "" &&
                    !finnean.Enchantments.Any(a => a.Blueprint.AssetGuidThreadSafe == enchantmentguid))
                {
                    finnean.AddEnchantment(
                        ResourcesLibrary.TryGetBlueprint<BlueprintWeaponEnchantment>(enchantmentguid),
                        new MechanicsContext(default));
                }
              //  Main.logger.Log("TriedAddEnchants4");
                //Ghost touch
                if (!finnean.Enchantments.Any(
                        a => a.Blueprint.AssetGuidThreadSafe == "47857e1a5a3ec1a46adf6491b1423b4f"))
                {
                  // Main.logger.Log("TriedAddGhostTouch");
                    finnean.AddEnchantment(
                        ResourcesLibrary.TryGetBlueprint<BlueprintItemEnchantment>("47857e1a5a3ec1a46adf6491b1423b4f"),
                        new MechanicsContext(default));
                }

                //Cold Iron
                if (!finnean.Enchantments.Any(
                        a => a.Blueprint.AssetGuidThreadSafe == "e5990dc76d2a613409916071c898eee8"))
                {
                  //  Main.logger.Log("TriedAddColdIron");
                    finnean.AddEnchantment(
                        ResourcesLibrary.TryGetBlueprint<BlueprintItemEnchantment>("e5990dc76d2a613409916071c898eee8"),
                        new MechanicsContext(default));
                }

                if (FinneanSettings.Instance.Enchantment1GUID != null && !finnean.Enchantments.Any(a => a.Blueprint.AssetGuidThreadSafe == FinneanSettings.Instance.Enchantment1GUID))
                finnean.AddEnchantment(
                    ResourcesLibrary.TryGetBlueprint<BlueprintWeaponEnchantment>(FinneanSettings.Instance
                        .Enchantment1GUID), new MechanicsContext(default));
                if (FinneanSettings.Instance.Enchantment2GUID != null && !finnean.Enchantments.Any(a =>
                        a.Blueprint.AssetGuidThreadSafe == FinneanSettings.Instance.Enchantment2GUID))
                    finnean.AddEnchantment(
                        ResourcesLibrary.TryGetBlueprint<BlueprintWeaponEnchantment>(FinneanSettings.Instance
                            .Enchantment2GUID), new MechanicsContext(default));
               // Main.logger.Log("TriedAddEnchants5");
                // Main.logger.Log("Sucessfully added enchantments.");
            }
            catch (Exception e)
            {
                Main.logger.Log(e.ToString());
                throw;
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(InventorySmartItemVM), "EquipItem")]
    public static class EquipItem_Patch
    {
        public static void Postfix(InventorySmartItemVM __instance, ItemEntity item)
        {
            __instance.RefreshFinneanItems();
            FinneanEnchantmentHandler.AddEnchantments(item);
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(InventorySmartItemVM), "EquipItemInSlot")]
    public static class EquipItemInSlot_Patch
    {
        public static void Postfix(InventorySmartItemVM __instance, ItemEntity item)
        {
            __instance.RefreshFinneanItems();
            FinneanEnchantmentHandler.AddEnchantments(item);
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(InventorySmartItemVM), "RefreshData")]
    public static class RefreshData_Patch
    {
        public static void Postfix(InventorySmartItemVM __instance)
        {
            __instance.RefreshFinneanItems();
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(InventorySmartItemVM), "SelectItem", new Type[] { typeof(int) })]
    public static class SelectItem_Patch
    {
        public static void Postfix(InventorySmartItemVM __instance)
        {
            __instance.RefreshFinneanItems();
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(ItemEntity), nameof(ItemEntity.ContainsEnchantmentFromBlueprint))]
    public static class ContainsEnchantmentFromBlueprint_patch
    {
        public static void Postfix(ItemEntity __instance, ref bool __result, BlueprintItemEnchantment enchantment)
        {
            try
            {
                //This is dirty but __instance seems to always be null so cant check that its finnean.
                if (enchantment.AssetGuidThreadSafe ==
                    "66e9e299c9002ea4bb65b6f300e43770") //if (__instance != null && __instance.Blueprint != null && __instance.Blueprint.NameForAcronym.Contains("Finnean"))
                {
                    __result = true;
                }
            }
            catch (Exception e)
            {
                Main.logger.Error(e.ToString());
            }
        }

        public static void Prefix(ItemEntity __instance, ref bool __result, BlueprintItemEnchantment enchantment)
        {
            try
            {
                if (__instance == null)
                {
                    Main.logger.Log("EnchantMentContainsNull");
                }
                else
                {
                    Main.logger.Log("not null " + __instance.ToString());
                }
            }
            catch (Exception e)
            {
                Main.logger.Error(e.ToString());
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(ItemEntity), nameof(ItemEntity.ApplyEnchantments))]
    public static class ApplyEnchantments_patch
    {
        /*public static void Postfix(ItemEntity __instance)
        {
            Main.logger.Log("dgsdsg");
        }*/
        public static void Postfix(ItemEntity __instance, bool onInitializeOrEquip)
        {
            try
            {
                //Main.logger.Log("dssadafs");
                if (!__instance.Blueprint.NameForAcronym.Contains("Finnean")) return;
                else
                {
                    FinneanEnchantmentHandler.AddEnchantments(__instance);
                    return;
                }

                /*if (!__instance.InstantiateEnchantments)
                {
                    return false;
                }*/
                ItemEnchantmentCollection itemEnchantmentCollection = __instance.m_Enchantments =
                    __instance.Facts.EnsureFactProcessor<ItemEnchantmentCollection>();
                List<ItemEnchantment> list = null;
                List<BlueprintItemEnchantment> list2 = null;
                if (!onInitializeOrEquip)
                {
                    foreach (ItemEnchantment itemEnchantment in itemEnchantmentCollection.RawFacts)
                    {
                        if (itemEnchantment.ParentContext == null &&
                            !__instance.Blueprint.Enchantments.HasItem(itemEnchantment.Blueprint))
                        {
                            list = (list ?? ListPool<ItemEnchantment>.Claim(5));
                            list.Add(itemEnchantment);
                            LogChannel @default = PFLog.Default;
                            ICanBeLogContext blueprint = __instance.Blueprint;
                            string format = "{0}: remove redunant enchantment '{1}' (owner: {2})";
                            object arg = itemEnchantment;
                            UnitDescriptor arg2;
                            if ((arg2 = __instance.Owner) == null)
                            {
                                ItemsCollection collection = __instance.Collection;
                                arg2 = ((collection != null) ? collection.OwnerUnit : null);
                            }

                            @default.Warning(blueprint, string.Format(format, __instance, arg, arg2),
                                Array.Empty<object>());
                        }
                    }
                }

                foreach (BlueprintItemEnchantment blueprintItemEnchantment in __instance.Blueprint.Enchantments)
                {
                    if (blueprintItemEnchantment.AssetGuidThreadSafe != "66e9e299c9002ea4bb65b6f300e43770" &&
                        !ItemEntity.ContainsEnchantmentFromBlueprint(itemEnchantmentCollection,
                            blueprintItemEnchantment))
                    {
                        list2 = (list2 ?? ListPool<BlueprintItemEnchantment>.Claim(5));
                        list2.Add(blueprintItemEnchantment);
                        if (!onInitializeOrEquip)
                        {
                            LogChannel default2 = PFLog.Default;
                            ICanBeLogContext blueprint2 = __instance.Blueprint;
                            string format2 = "{0}: restore missing enchantment '{1}' (owner: {2})";
                            object arg3 = blueprintItemEnchantment;
                            UnitDescriptor arg4;
                            if ((arg4 = __instance.Owner) == null)
                            {
                                ItemsCollection collection2 = __instance.Collection;
                                arg4 = ((collection2 != null) ? collection2.OwnerUnit : null);
                            }

                            default2.Warning(blueprint2, string.Format(format2, __instance, arg3, arg4),
                                Array.Empty<object>());
                        }
                    }
                }

                if (list != null)
                {
                    foreach (ItemEnchantment fact in list)
                    {
                        itemEnchantmentCollection.RemoveFact(fact);
                    }
                }

                if (list2 != null)
                {
                    using (ContextData<ItemEntity.BuiltInEnchantmentFlag>.Request())
                    {
                        foreach (BlueprintItemEnchantment blueprint3 in list2)
                        {
                            __instance.AddEnchantmentInternal(blueprint3, null, null);
                        }
                    }
                }

                if (list != null)
                {
                    ListPool<ItemEnchantment>.Release(list);
                }

                if (list2 != null)
                {
                    ListPool<BlueprintItemEnchantment>.Release(list2);
                }

               // return false;
            }
            catch (Exception e)
            {
                Main.logger.Error(e.ToString());
                //return true;
            }
        }
    }
}