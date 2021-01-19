using System;
using Harmony;


namespace InsulatedManualPressureDoor_Loc
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
            Type ObjectType = Type.GetType("InsulatedManualPressureDoor_Loc", false, false);
            string ObjectID = InsulatedManualPressureDoorConfig.ID.ToUpperInvariant();
            Localization.Locale locale = Localization.GetLocale();

            if (locale != null && locale.Code == "ru")
            {
                // Translation by ME.XAH
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                    "<link=\"InsulatedManualPressureDoor\">Изолированный Ручной Шлюз</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "Пониженная термопроводность изолированной двери замедляет прохождение тепла через нее.");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "Сохраняет температуру с обоих сторон двери");
            }

            if (locale != null && locale.Code == "zh")
            {
                
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                    "<link=\"InsulatedManualPressureDoor\">隔热手动气闸</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "隔热门的导热系数降低，减慢热量通过它们的速度。");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "保持门两侧的温度");
            }

            else
            {

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT");

            }
        }
    }
}

namespace TinyInsulatedManualPressureDoor_Loc
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
            Type ObjectType = Type.GetType("TinyInsulatedManualPressureDoor_Loc", false, false);
            string ObjectID = TinyInsulatedManualPressureDoorConfig.ID.ToUpperInvariant();
            Localization.Locale locale = Localization.GetLocale();

            if (locale != null && locale.Code == "ru")
            {
                // Translation by ME.XAH
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                    "<link=\"TinyInsulatedManualPressureDoor\">Изолированный Ручной Мини Шлюз</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "Пониженная термопроводность изолированной двери замедляет прохождение тепла через нее.");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "Сохраняет температуру с обоих сторон двери");
            }

            if (locale != null && locale.Code == "zh")
            {
                
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                    "<link=\"InsulatedManualPressureDoor\">微型隔热手动气闸</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "隔热门的导热系数降低，减慢热量通过它们的速度。");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "保持门两侧的温度");
            }

            else
            {

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT");

            }
        }
    }
}

namespace TinyInsulatedPressureDoor_Loc
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
            Type ObjectType = Type.GetType("TinyInsulatedPressureDoor_Loc", false, false);
            string ObjectID = TinyInsulatedPressureDoorConfig.ID.ToUpperInvariant();
            Localization.Locale locale = Localization.GetLocale();

            if (locale != null && locale.Code == "ru")
            {
                // Translation by ME.XAH
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                    "<link=\"TinyInsulatedPressureDoor\">Изолированный Авто Мини Шлюз</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "Пониженная термопроводность изолированной двери замедляет прохождение тепла через нее.");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "Сохраняет температуру с обоих сторон двери");
            }

            if (locale != null && locale.Code == "zh")
            {
                
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                    "<link=\"InsulatedManualPressureDoor\">微型隔热机械气闸</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "隔热门的导热系数降低，减慢热量通过它们的速度。");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "隔热门的导热系数降低，减慢热量通过它们的速度。");
            }

            else
            {

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT");

            }
        }
    }
}

namespace InsulatedPressureDoor_Loc
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
            Type ObjectType = Type.GetType("InsulatedPressureDoor_Loc", false, false);
            string ObjectID = InsulatedPressureDoorConfig.ID.ToUpperInvariant();
            Localization.Locale locale = Localization.GetLocale();

            if (locale != null && locale.Code == "ru")
            {
                // Translation by ME.XAH
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                    "<link=\"InsulatedPressureDoor\">Изолированный Авто Шлюз</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "Пониженная термопроводность изолированной двери замедляет прохождение тепла через нее.");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "Сохраняет температуру с обоих сторон двери");
            }

            if (locale != null && locale.Code == "zh")
            {
                
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                    "<link=\"InsulatedManualPressureDoor\">隔热机械气闸</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "隔热门的导热系数降低，减慢热量通过它们的速度。");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "隔热门的导热系数降低，减慢热量通过它们的速度。");
            }

            else
            {

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT");

            }
        }
    }
}