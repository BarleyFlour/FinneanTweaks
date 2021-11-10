using Kingmaker.UI.MVVM._PCView.ServiceWindows.Inventory;
using Kingmaker.UI.MVVM._VM.ServiceWindows.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FinneanTweaks
{
    public static class FinneanUIInjector
    {

    }
    [HarmonyLib.HarmonyPatch(typeof(InventorySmartItemPCView), "Initialize")]
    public static class FinneanVM_Patch
    {
        public static Dictionary<int,string> OptionsToText = new Dictionary<int,string>();
        public static Dictionary<int, string> OptionsToText2 = new Dictionary<int, string>();
        public static void Postfix(InventorySmartItemPCView __instance)
        {
            try
            {
                {
                    var oldtransform = __instance.m_Dropdown.transform.localPosition;
                    var newtransform = new Vector3(oldtransform.x, oldtransform.y + 45, oldtransform.z);
                    __instance.m_Dropdown.transform.localPosition = newtransform;
                }
                // No.1
                {
                    var enchant = UnityEngine.Object.Instantiate(__instance.m_Dropdown);
                    enchant.transform.SetParent(__instance.transform);
                    enchant.transform.localScale = __instance.m_Dropdown.transform.localScale;
                    enchant.ClearOptions();
                    int i = 0;
                    foreach (var enchant1 in FinneanEnchantmentHandler.EnchantsTier1)
                    {
                        var optiondata = new TMPro.TMP_Dropdown.OptionData(enchant1.Key);
                        enchant.options.Add(optiondata);
                        OptionsToText.Add(i, enchant1.Key);
                        i++;
                    }
                    var oldtransform = __instance.m_Dropdown.transform.localPosition;
                    var newtransform = new Vector3(oldtransform.x, oldtransform.y - 30, oldtransform.z);
                    enchant.transform.localPosition = newtransform;
                    enchant.onValueChanged.RemoveAllListeners();
                    enchant.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>((int i2) => 
                    {
                        FinneanSettings.Instance.Enchantment1GUID = FinneanEnchantmentHandler.EnchantsTier1[OptionsToText[i2]];
                    }));
                }
                {
                    var enchant = UnityEngine.Object.Instantiate(__instance.m_Dropdown);
                    enchant.transform.SetParent(__instance.transform);
                    enchant.transform.localScale = __instance.m_Dropdown.transform.localScale;
                    enchant.ClearOptions();
                    int i = 0;
                    foreach (var enchant1 in FinneanEnchantmentHandler.EnchantsTier1)
                    {
                        var optiondata = new TMPro.TMP_Dropdown.OptionData(enchant1.Key);
                        enchant.options.Add(optiondata);
                        OptionsToText2.Add(i, enchant1.Key);
                        i++;
                    }
                    var oldtransform = __instance.m_Dropdown.transform.localPosition;
                    var newtransform = new Vector3(oldtransform.x, oldtransform.y - 60, oldtransform.z);
                    enchant.transform.localPosition = newtransform;
                    enchant.onValueChanged.RemoveAllListeners();
                    enchant.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>((int i2) =>
                    {
                        FinneanSettings.Instance.Enchantment1GUID = FinneanEnchantmentHandler.EnchantsTier2[OptionsToText2[i2]];
                    }));
                }
            }
            catch(Exception e)
            {
                Main.logger.Error(e.ToString());
            }

        }
    }
}
