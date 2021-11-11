using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Items;
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
        public static Dictionary<int, string> OptionsToText = new Dictionary<int, string>();
        public static Dictionary<int, string> OptionsToText2 = new Dictionary<int, string>();
        public static Dictionary<string, int> OptionsToTextOpposite = new Dictionary<string, int>();
        public static Dictionary<string, int> OptionsToTextOpposite2 = new Dictionary<string, int>();
        public static void Postfix(InventorySmartItemPCView __instance)
        {
            try
            {
                //var finnean = Kingmaker.Game.Instance?.RootUiContext?.InGameVM?.StaticPartVM?.ServiceWindowsVM?.InventoryVM?.Value?.SmartItemVM?.Value?.PolymorphItems?.First();
                int level = 0;
                {
                    //2 levelup
                    if (Kingmaker.Game.Instance.Player.EtudesSystem.EtudeIsStarted(ResourcesLibrary.TryGetBlueprint<BlueprintEtude>("bb2b5d935bca4c247b1898bfb52a5cfc")) || Kingmaker.Game.Instance.Player.EtudesSystem.EtudeIsStarted(ResourcesLibrary.TryGetBlueprint<BlueprintEtude>("63805e1f15af4c22a51101253a3d0e21")))
                    {
                        level = 5;
                    }
                    //1 levelup
                    else if(Kingmaker.Game.Instance.Player.EtudesSystem.EtudeIsStarted(ResourcesLibrary.TryGetBlueprint<BlueprintEtude>("4b4ac9276eff5ce48a52d65e09806ca9")))
                    {
                        level = 3;
                    }
                    //0 Levelup
                    else
                    {
                        level = 1;
                        FinneanSettings.Instance.Enchantment2GUID = "";
                    }
                }
                if (level == 5 || level == 3)
                {
                    {
                        var oldtransform = __instance.m_Dropdown.transform.localPosition;
                        var newtransform = new Vector3(oldtransform.x, oldtransform.y + 45, oldtransform.z);
                        __instance.m_Dropdown.transform.localPosition = newtransform;
                        var oldtransform2 = __instance.m_StartDialogButton.transform.localPosition;
                        var newtransform2 = new Vector3(oldtransform2.x, oldtransform2.y + 11, oldtransform2.z);
                        __instance.m_StartDialogButton.transform.localPosition = newtransform2;
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
                            var optiondata = new TMPro.TMP_Dropdown.OptionData(enchant1.Key, AssetLoader.one);
                            enchant.options.Add(optiondata);
                            if (!OptionsToText.Keys.Contains(i)) OptionsToText.Add(i, enchant1.Key);
                            if (enchant1.Value == FinneanSettings.Instance.Enchantment1GUID)
                            {
                                enchant.value = i;
                            }
                            i++;
                        }
                        var oldtransform = __instance.m_Dropdown.transform.localPosition;
                        var newtransform = new Vector3(oldtransform.x, oldtransform.y - 35, oldtransform.z);
                        enchant.transform.localPosition = newtransform;
                        enchant.onValueChanged.RemoveAllListeners();
                        enchant.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>((int i2) =>
                        {
                            FinneanSettings.Instance.Enchantment1GUID = FinneanEnchantmentHandler.EnchantsTier1[OptionsToText[i2]];
                            Kingmaker.Game.Instance?.RootUiContext?.InGameVM?.StaticPartVM?.ServiceWindowsVM?.InventoryVM?.Value?.SmartItemVM?.Value?.RefreshFinneanItems();
                        }));
                    }
                    //No.2
                    {
                        var enchant = UnityEngine.Object.Instantiate(__instance.m_Dropdown);
                        enchant.transform.SetParent(__instance.transform);
                        enchant.transform.localScale = __instance.m_Dropdown.transform.localScale;
                        enchant.ClearOptions();
                        int i = 0;
                        foreach (var enchant2 in FinneanEnchantmentHandler.EnchantsTier2)
                        {
                            var optiondata = new TMPro.TMP_Dropdown.OptionData(enchant2.Key, AssetLoader.two);
                            enchant.options.Add(optiondata);
                            if (!OptionsToText2.Keys.Contains(i)) OptionsToText2.Add(i, enchant2.Key);
                            if (enchant2.Value == FinneanSettings.Instance.Enchantment2GUID)
                            {
                                enchant.value = i;
                            }
                            i++;
                        }
                        var oldtransform = __instance.m_Dropdown.transform.localPosition;
                        var newtransform = new Vector3(oldtransform.x, oldtransform.y - 70, oldtransform.z);
                        enchant.transform.localPosition = newtransform;
                        enchant.onValueChanged.RemoveAllListeners();
                        enchant.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>((int i2) =>
                        {
                            FinneanSettings.Instance.Enchantment2GUID = FinneanEnchantmentHandler.EnchantsTier2[OptionsToText2[i2]];
                            Kingmaker.Game.Instance?.RootUiContext?.InGameVM?.StaticPartVM?.ServiceWindowsVM?.InventoryVM?.Value?.SmartItemVM?.Value?.RefreshFinneanItems();

                        }));

                    }
                }
                else if (level == 1)
                {
                    {
                        var oldtransform = __instance.m_Dropdown.transform.localPosition;
                        var newtransform = new Vector3(oldtransform.x, oldtransform.y + 45, oldtransform.z);
                        __instance.m_Dropdown.transform.localPosition = newtransform;
                        var oldtransform2 = __instance.m_StartDialogButton.transform.localPosition;
                        var newtransform2 = new Vector3(oldtransform2.x, oldtransform2.y + 11, oldtransform2.z);
                        __instance.m_StartDialogButton.transform.localPosition = newtransform2;
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
                            var optiondata = new TMPro.TMP_Dropdown.OptionData(enchant1.Key, AssetLoader.one);
                            enchant.options.Add(optiondata);
                            if (!OptionsToText.Keys.Contains(i)) OptionsToText.Add(i, enchant1.Key);
                            if (enchant1.Value == FinneanSettings.Instance.Enchantment1GUID)
                            {
                                enchant.value = i;
                            }
                            i++;
                        }
                        var oldtransform = __instance.m_Dropdown.transform.localPosition;
                        var newtransform = new Vector3(oldtransform.x, oldtransform.y - 35, oldtransform.z);
                        enchant.transform.localPosition = newtransform;
                        enchant.onValueChanged.RemoveAllListeners();
                        enchant.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>((int i2) =>
                        {
                            FinneanSettings.Instance.Enchantment1GUID = FinneanEnchantmentHandler.EnchantsTier1[OptionsToText[i2]];
                            Kingmaker.Game.Instance?.RootUiContext?.InGameVM?.StaticPartVM?.ServiceWindowsVM?.InventoryVM?.Value?.SmartItemVM?.Value?.RefreshFinneanItems();
                        }));
                    }
                }
                //FinneanEnchantmentHandler.AddEnchantments(__instance.);
            }
            catch (Exception e)
            {
                Main.logger.Error(e.ToString());
            }

        }
    }
}
