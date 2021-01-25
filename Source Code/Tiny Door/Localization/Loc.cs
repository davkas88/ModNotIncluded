using Harmony;
using System;
using System.IO;
using System.Reflection;
using static Localization;

namespace TinyDoorsMod
{
    [HarmonyPatch(typeof(Localization), "Initialize")]
    public static class Loc_Initialize_Patch
    {
        public static void Postfix() => Translate(typeof(STRINGS));

        public static void Translate(Type root)
        {
            // Basic intended way to register strings, keeps namespace
            RegisterForTranslation(root);

            // Load user created translation files
            string mypath = LoadStrings();

            // Register strings without namespace
            // because we already loaded user translations, custom languages will overwrite these
            LocString.CreateLocStringKeys(root, null);

            // Creates template for users to edit
            GenerateStringsTemplate(root, mypath);
        }

        private static string LoadStrings()
        {
            // Figure out where the mod loaded from
            string myPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // translations in mod root
            int archivedMod = myPath.IndexOf("archived_versions");
            string modPath;
            if (archivedMod != -1)
            {
                modPath = myPath.Substring(0, archivedMod - 1);
            }
            else
            {
                modPath = myPath;
            }
            string path = Path.Combine(modPath, "translations");
            // Pick up game localization settings and match to mod translation files
            string file = Path.Combine(path, GetLocale()?.Code + ".po");
            if (File.Exists(file))
                OverloadStrings(LoadStringsFile(file, false));
            return path;
        }

    }
}