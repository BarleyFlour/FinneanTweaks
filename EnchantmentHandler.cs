using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Items;
using Kingmaker.UI.MVVM._VM.ServiceWindows.Inventory;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinneanTweaks
{
    public static class FinneanEnchantmentHandler
    {
        public static Dictionary<string, string> EnchantsTier1
        {
            get
            {
                if (m_Enchants1 == null)
                {
                    m_Enchants1 = new Dictionary<string, string>();
                    m_Enchants1["Brilliant Energy"] = "66e9e299c9002ea4bb65b6f300e43770";
                    m_Enchants1["Caustic"] = "2becfef47bec13940b9ee71f1b14d2dd";
                    m_Enchants1["Freezing"] = "00049f6046b20394091b29702c6e9617";
                    m_Enchants1["Greater Shock"] = "b1de8528121b80844bd7cf09d9e1cf00";
                    m_Enchants1["Greater Flaming"] = "a6064c14629de6d48bec8e8e0460f661";
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
                    m_Enchants2["Brilliant Energy"] = "66e9e299c9002ea4bb65b6f300e43770";
                    m_Enchants2["Caustic"] = "2becfef47bec13940b9ee71f1b14d2dd";
                    m_Enchants2["Freezing"] = "00049f6046b20394091b29702c6e9617";
                    m_Enchants2["Greater Shock"] = "b1de8528121b80844bd7cf09d9e1cf00";
                    m_Enchants2["Greater Flaming"] = "a6064c14629de6d48bec8e8e0460f661";
                }
                return m_Enchants2;
            }
        }
        public static Dictionary<string, string> m_Enchants2;
        public static void AddEnchantments(ItemEntity finnean)//, BlueprintItemEnchantment enchant)
        {
            Main.logger.Log("Adding Enchantments...");
            if(!FinneanSettings.Instance.Enchantment1GUID.IsNullOrEmpty() && FinneanSettings.Instance.Enchantment1GUID != "66e9e299c9002ea4bb65b6f300e43770" && !FinneanSettings.Instance.Enchantment2GUID.IsNullOrEmpty() && FinneanSettings.Instance.Enchantment2GUID != "66e9e299c9002ea4bb65b6f300e43770")
            {
                var enchantment = finnean.GetEnchantment(ResourcesLibrary.TryGetBlueprint<BlueprintItemEnchantment>("66e9e299c9002ea4bb65b6f300e43770"));
                if(enchantment != null)
                finnean.RemoveEnchantment(enchantment);
            }
            //   if (!FinneanSettings.Instance.Enchantment1GUID.IsNullOrEmpty())
            {
                //     finnean.RemoveEnchantment(finnean.GetEnchantment(ResourcesLibrary.TryGetBlueprint<BlueprintItemEnchantment>(FinneanSettings.Instance.Enchantment1GUID)));
            }
            //FinneanSettings.Instance.Enchantment1GUID = enchant.AssetGuidThreadSafe;
            if(FinneanSettings.Instance.Enchantment1GUID != null) finnean.AddEnchantment(ResourcesLibrary.TryGetBlueprint<BlueprintItemEnchantment>(FinneanSettings.Instance.Enchantment1GUID), new MechanicsContext(default));
            //  if (!FinneanSettings.Instance.Enchantment2GUID.IsNullOrEmpty())
            {
                //  finnean.RemoveEnchantment(finnean.GetEnchantment(ResourcesLibrary.TryGetBlueprint<BlueprintItemEnchantment>(FinneanSettings.Instance.Enchantment2GUID)));
            }
            // FinneanSettings.Instance.Enchantment2GUID = enchant.AssetGuidThreadSafe;
            if (FinneanSettings.Instance.Enchantment2GUID != null) finnean.AddEnchantment(ResourcesLibrary.TryGetBlueprint<BlueprintItemEnchantment>(FinneanSettings.Instance.Enchantment2GUID), new MechanicsContext(default));
            Main.logger.Log("Sucessfully added enchantments.");
        }
    }
    [HarmonyLib.HarmonyPatch(typeof(InventorySmartItemVM), "EquipItem")]
    public static class EquipItem_Patch
    {
        public static void Postfix(InventorySmartItemVM __instance)
        {
            if(__instance != null && __instance.m_SmartItem != null)
            FinneanEnchantmentHandler.AddEnchantments(__instance.m_SmartItem);
            foreach (var item in __instance.PolymorphItems)
            {
                FinneanEnchantmentHandler.AddEnchantments(item);
            }
        }
    }
}
