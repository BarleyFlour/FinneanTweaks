using HarmonyLib;
using Kingmaker;
using Kingmaker.EntitySystem.Persistence;
using Newtonsoft.Json;
using System;
using System.IO;

namespace FinneanTweaks
{
    [HarmonyPatch]
    internal static class SaveHooker
    {
        [HarmonyPatch(typeof(ZipSaver))]
        [HarmonyPatch("SaveJson"), HarmonyPostfix]
        private static void Zip_Saver(string name, ZipSaver __instance)
        {
            DoSave(name, __instance);
        }

        [HarmonyPatch(typeof(FolderSaver))]
        [HarmonyPatch("SaveJson"), HarmonyPostfix]
        private static void Folder_Saver(string name, FolderSaver __instance)
        {
            DoSave(name, __instance);
        }

        private static void DoSave(string name, ISaver saver)
        {
            if (name != "header")
                return;

            try
            {
                var serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                var writer = new StringWriter();
                serializer.Serialize(writer, FinneanSettings.Instance);
                writer.Flush();
                saver.SaveJson(LoadHooker.FileName, writer.ToString());
            }
            catch (Exception e)
            {
                Main.logger.Log(e.ToString());
            }
        }
    }

    [HarmonyPatch(typeof(Game))]
    internal static class LoadHooker
    {
        public const string FileName = "header.json.barley_finneansettings";

        [HarmonyPatch("LoadGame"), HarmonyPostfix]
        private static void LoadGame(SaveInfo saveInfo)
        {
            try
            {
                using (saveInfo)
                {
                    using (saveInfo.GetReadScope())
                    {
                        ThreadedGameLoader.RunSafelyInEditor((Action)(() =>
                        {
                            string raw;
                            using (ISaver saver = saveInfo.Saver.Clone())
                            {
                                raw = saver.ReadJson(FileName);
                            }
                            if (raw != null)
                            {
                                var serializer = new JsonSerializer();
                                var rawReader = new StringReader(raw);
                                var jsonReader = new JsonTextReader(rawReader);
                                FinneanSettings.Instance = serializer.Deserialize<FinneanSettings>(jsonReader);
                            }
                            else
                            {
                                FinneanSettings.Instance = new FinneanSettings();
                            }
                        })).Wait();
                    }
                }
            }
            catch (Exception e)
            {
                Main.logger.Error(e.ToString());
            }
        }
    }

    public class FinneanSettings
    {
        public static FinneanSettings Instance = new FinneanSettings();
        public string Enchantment1GUID;
        public string Enchantment2GUID;
    }
}