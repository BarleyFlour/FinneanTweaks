using HarmonyLib;
using JetBrains.Annotations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Localization;
using Kingmaker.UI.MVVM._VM.ServiceWindows.CharacterInfo.Sections.Progression.ChupaChupses;
using Kingmaker.UI.MVVM._VM.ServiceWindows.CharacterInfo.Sections.Progression.Feats;
using Kingmaker.UI.MVVM._VM.ServiceWindows.CharacterInfo.Sections.Progression.Main;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.Localization;
using UnityEngine;
using System.IO;

namespace FinneanTweaks
{
    class AssetLoader
    {
        public static Sprite one
        {
            get
            {
                if (m_one == null)
                {
                   m_one = LoadInternal("icons", "One.png", new Vector2Int(128, 128));
                }
                return m_one;
            }
        }
        public static Sprite m_one;
        public static Sprite two
        {
            get
            {
                if (m_two == null)
                {
                   m_two = LoadInternal("icons", "Two.png", new Vector2Int(128, 128));
                }
                return m_two;
            }
        }
        public static Sprite m_two;
        public static Sprite LoadInternal(string folder, string file, Vector2Int size)
        {
            return Image2Sprite.Create($"{Main.ModEntry.Path}Assets{Path.DirectorySeparatorChar}{folder}{Path.DirectorySeparatorChar}{file}", size);
        }
        // Loosely based on https://forum.unity.com/threads/generating-sprites-dynamically-from-png-or-jpeg-files-in-c.343735/
        public static class Image2Sprite
        {
            public static string icons_folder = "";
            public static Sprite Create(string filePath, Vector2Int size)
            {
                Main.logger.Log("Creating sprite");
                var bytes = File.ReadAllBytes(icons_folder + filePath);
                var texture = new Texture2D(size.x, size.y, TextureFormat.ARGB32, false);
                _ = texture.LoadImage(bytes);
                return Sprite.Create(texture, new Rect(0, 0, size.x, size.y), new Vector2(0, 0));
            }
        }
    }
}
