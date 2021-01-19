using System;
using Harmony;


namespace InsulatedWireBridgeHighWattageLoc
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
            Type ObjectType = Type.GetType("InsulatedWireBridgeHighWattage_Loc", false, false);

            string ObjectID = InsulatedWireBridgeHighWattageConfig.ID.ToUpperInvariant();
            Localization.Locale locale = Localization.GetLocale();

            if (locale != null && locale.Code == "ru")
            {
                // Translation by ME.XAH
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                     "<link=\"InsulatedWireBridgeHighWattage\">Изолированная Соединительная Пластина</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "Сединительная пластина позволяет провести электричество через стены минуя газы, или жидкости.");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "Изолированная версия.Проводит ток через стены.Функционирует как и обычная версия.");
            }
            if (locale != null && locale.Code == "zh")
            {
                // Translation by 孤狼战魂
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                     "<link=\"InsulatedWireBridgeHighWattage\">隔热高负荷电线接合板</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "接合板可以使高负荷电线穿过墙壁，而不会泄漏气体或液体。");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "隔热型。 可让高负荷电线穿过墙壁和地砖，可作为常规砖块使用。");
            }
            if (locale != null && locale.Code == "es_ES")
            {
                
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                     "<link=\"InsulatedWireBridgeHighWattage\">Placa de unión de Heavi-Watt aislada</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "Las placas de unión pueden pasar cables Heavi-Watt a través de las paredes sin fugas de gas o líquido");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "Versión aislada. Permite pasar la pared y el piso. Funciona como un panel regular.");
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

namespace InsulatedWireRefinedBridgeHighWattageLoc
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
            Type ObjectType = Type.GetType("InsulatedWireRefinedBridgeHighWattage_Loc", false, false);

            string ObjectID = InsulatedWireRefinedBridgeHighWattageConfig.ID.ToUpperInvariant();
            Localization.Locale locale = Localization.GetLocale();

            if (locale != null && locale.Code == "ru")
            {
                // Translation by ME.XAH
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                     "<link=\"InsulatedWireRefinedBridgeHighWattage\">Изолированная Соединительная Пластина II</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "Изолированная версия. Сединительная пластина позволяет провести электричество через стены минуя газы, или жидкости.");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "Изолированная версия. Проводит больше тока чем обычная версия.");
            }

            if (locale != null && locale.Code == "zh")
            {
                // Translation by 孤狼战魂
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                     "<link=\"InsulatedWireRefinedBridgeHighWattage\">隔热高负荷导线接合板</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "隔热型。 接合板可以使高负荷电线穿过墙壁，而不会泄漏气体或液体。");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "隔热型.，可以运载比普通隔热高负荷电线接合板更大的功率而不会过载。");
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

namespace LongInsulatedWireBridgeHighWattageLoc
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
            Type ObjectType = Type.GetType("LongInsulatedWireBridgeHighWattage_Loc", false, false);

            string ObjectID = LongInsulatedWireBridgeHighWattageConfig.ID.ToUpperInvariant();
            Localization.Locale locale = Localization.GetLocale();

            if (locale != null && locale.Code == "ru")
            {
                // Translation by ME.XAH
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                     "<link=\"LongInsulatedWireBridgeHighWattage\">Длинная Изолированная Пластина</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "Сединительная пластина позволяет провести электричество через стены минуя газы, или жидкости.");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "Изолированная длинная версия. Проводит ток через стены. Функционирует как и обычная версия, только длинее.");
            }

            if (locale != null && locale.Code == "zh")
            {
                // Translation by 孤狼战魂
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                     "<link=\"LongInsulatedWireBridgeHighWattage\">长隔热电线接合板</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                    "接合板可以使高负荷电线穿过墙壁，而不会泄漏气体或液体。");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "加长隔热型， 可让高负荷电线穿过墙壁和地砖，可作为常规砖块使用。");
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

namespace LongInsulatedRefinedWireBridgeHighWattageLoc
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
            Type ObjectType = Type.GetType("LongInsulatedRefinedWireBridgeHighWattage_Loc", false, false);

            string ObjectID = LongInsulatedRefinedWireBridgeHighWattageConfig.ID.ToUpperInvariant();
            Localization.Locale locale = Localization.GetLocale();

            if (locale != null && locale.Code == "ru")
            {
                // Translation by ME.XAH
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                     "<link=\"LongInsulatedRefinedWireBridgeHighWattage\">Длинная Изолированная Пластина II</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                   "Изолированная длинная версия. Сединительная пластина позволяет провести электричество через стены минуя газы, или жидкости.");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "Изолированная длинная версия. Проводит больше тока чем обычная версия, только длинее.");
            }

            if (locale != null && locale.Code == "zh")
            {
                // Translation by 孤狼战魂
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.NAME",
                     "<link=\"LongInsulatedRefinedWireBridgeHighWattage\">长隔热导线接合板</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.DESC",
                   "加长隔热型。接合板可以使高负荷电线穿过墙壁，而不会泄漏气体或液体。");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{ObjectID}.EFFECT",
                    "加长隔热型， 可以运载比普通隔热高负荷电线接合板更大的功率而不会过载。");
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

