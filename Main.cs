using HarmonyLib;
using System;
using UnityModManagerNet;
using Kingmaker.Modding;
using System.Reflection;
#if UMM
using static UnityModManagerNet.UnityModManager;
#endif
namespace FinneanTweaks
{
#if DEBUG
    [EnableReloading]
#endif

    public class Main
    {




#if WrathMod
        public static OwlcatModification ModEntry;
        public static Owlcat.Runtime.Core.Logging.LogChannel logger => ModEntry.Logger;
        [OwlcatModificationEnterPoint]
        public static void EnterPoint(OwlcatModification modEntry)
        {
            try
            {
                ModEntry = modEntry;
                var harmony = new Harmony(modEntry.Manifest.UniqueName);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
               // settings = ModEntry.LoadData<Settings>();

                ///ModEntry.OnGUI += OnGUI;
                //modEntry.OnDrawGUI += OnGUI;
               // modEntry.OnGUI += OnGUI;
                IsEnabled = true;
                // if (!Main.haspatched)
                {
                    //   Main.PatchLibrary();
                }
            }
            catch (Exception e)
            {
                ModEntry.Logger.Log(e.ToString()); ;
                throw e;
            }
        }
#endif
        public static bool IsEnabled = false;
#if UMM
        public static UnityModManager.ModEntry ModEntry;
        public static UnityModManager.ModEntry.ModLogger logger;

        private static bool Load(UnityModManager.ModEntry modEntry)
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

        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value /* active or inactive */)
        {
            IsEnabled = value;
            return true; // Permit or not.
        }

        private static bool Unload(UnityModManager.ModEntry modEntry)
        {
            new Harmony(modEntry.Info.Id).UnpatchAll(modEntry.Info.Id);
            return true;
        }
#endif

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