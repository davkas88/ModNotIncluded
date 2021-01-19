using Harmony;
using System;



namespace TinyDoorLoc
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
            Type TinyDoorType = Type.GetType("TinyDoor_Loc", false, false);
            
            string TinyDoorID = TinyDoorConfig.ID.ToUpperInvariant();
            Localization.Locale locale = Localization.GetLocale();

            if (locale != null && locale.Code == "it_IT")
            {
                // Translation by Davkas
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyDoorID}.NAME",
                    "<link=\"TinyDoor\">Porta Pneumatica Piccola</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyDoorID}.DESC",
                    "Una Porta Piccola fatta per Duplicanti veramente piccoli");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyDoorID}.EFFECT",
                    "Delimita due aree senza bloccare il flusso di <link=\"ELEMENTSLIQUID\">Liquidi</link> e <link=\"ELEMENTSGAS\">Gas</link>.\n\nLe <link=\"CRITTERS\">Creature</link> selvatiche non possono attraversare le porte.");
            }

            if (locale != null && locale.Code == "ru")
            {
                
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyDoorID}.NAME",
                    "<link=\"TinyDoor\">Пневматический люк</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyDoorID}.DESC",
                    "Управление дверью поможет предотвратить попадание дубликантов в запрещенные зоны.");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyDoorID}.EFFECT",
                    "Отгораживает зоны, не мешая течению <link=\"ELEMENTSLIQUID\">жидкостей</link> или <link=\"ELEMENTSGAS\">газов</link>.\n\nДикие <link=\"CRITTERS\">Существа</link> не могут проходить через люки.");
            }
            if (locale != null && locale.Code == "zh")
            {
                
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyDoorID}.NAME",
                    "<link=\"TinyDoor\">微型气动门</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyDoorID}.DESC",
                    "微型门，专为小型复制人设计");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyDoorID}.EFFECT",
                    "封闭区域，不能阻挡 <link=\"ELEMENTSLIQUID\">液体</link> 或 <link=\"ELEMENTSGAS>气体</link> 流动。\n\n野生 <link=\"CRITTERS\">小动物</link> 无法通过门。");
            }
            else
            {

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{TinyDoorID}.NAME");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{TinyDoorID}.DESC");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{TinyDoorID}.EFFECT");
                    
            }            
        }
    }
}

namespace TinyManualPressureDoorLoc
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
            Type TinyDoorType = Type.GetType("TinyDoorManual_Loc", false, false);

            string TinyManualPressureDoorID = TinyManualPressureDoorConfig.ID.ToUpperInvariant();
            Localization.Locale locale = Localization.GetLocale();

            if (locale != null && locale.Code == "it_IT")
            {
                // Translation by Davkas
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyManualPressureDoorID}.NAME",
                    "<link=\"TinyManualPressureDoor\">Porta Stagna Piccola</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyManualPressureDoorID}.DESC",
                    "Una Porta Stagna Piccola fatta per Duplicanti veramente piccoli");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyManualPressureDoorID}.EFFECT",
                    "Blocca il flusso di <link=\"ELEMENTSLIQUID\">Liquidi</link> e <link=\"ELEMENTSGAS\">Gas</link>, mantenendo invariati i livelli di pressione di aree diverse.\n\nLe <link=\"CRITTERS\">Creature</link> selvatiche non posso attraversare le porte.");
            }

            if (locale != null && locale.Code == "ru")
            {
                // Translation by Davkas
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyManualPressureDoorID}.NAME",
                    "<link=\"TinyManualPressureDoor\">Ручной люк</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyManualPressureDoorID}.DESC",
                    "Ручной люк позволяет отгородиться от опасных зон и предотвратить попадание газов в колонию.");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyManualPressureDoorID}.EFFECT",
                    "Позволяет поддерживать давление в зонах на прежнем уровне, блокируя <link=\"ELEMENTSLIQUID\">жидкости</link> и <link=\"ELEMENTSGAS\">газы</link>.\n\nДикие <link=\"CRITTERS\">существа</link> не могут проходить через люки.");
            }
            if (locale != null && locale.Code == "zh")
            {
                // Translation by Davkas
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyManualPressureDoorID}.NAME",
                    "<link=\"TinyManualPressureDoor\">微型手动气闸</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyManualPressureDoorID}.DESC",
                    "微型手动气闸，专为小型复制人设计");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyManualPressureDoorID}.EFFECT",
                    "阻挡 <link=\"ELEMENTSLIQUID\">液体</link> 和 <link=\"ELEMENTSGAS>气体</link> 流动，维持各区域间的压力。\n\n野生 <link=\"CRITTERS\">小动物</link> 无法通过门。");
            }

            else
            {

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{TinyManualPressureDoorID}.NAME");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{TinyManualPressureDoorID}.DESC");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{TinyManualPressureDoorID}.EFFECT");

            }
        }
    }
}

namespace TinyPressureDoorLoc
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    public static class Db_Initialize_Patch
    {
        public static void Prefix()
        {
            Type TinyDoorType = Type.GetType("TinyDoorPressure_Loc", false, false);

            string TinyPressureDoorID = TinyPressureDoorConfig.ID.ToUpperInvariant();
            Localization.Locale locale = Localization.GetLocale();

            if (locale != null && locale.Code == "it_IT")
            {
                // Translation by Davkas
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyPressureDoorID}.NAME",
                    "<link=\"TinyPressureDoor\">Porta Stagna Meccanizzata Piccola</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyPressureDoorID}.DESC",
                    "Una Porta Stagna Piccola fatta per Duplicanti veramente piccoli");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyPressureDoorID}.EFFECT",
                    "Blocca il flusso di<link=TinyPressureDoor\"ELEMENTSLIQUID\">Liquidi</link> e <link=\"ELEMENTSGAS\">Gas</link>, mantenendo invariati i livelli di pressione di aree diverse.\n\nFunziona come una <link=\"TinyManualPressureDoor\">Porta Stagna Piccola</link> quando non c'è <link=\"POWER\">Energia</link> disponibile.\n\nLe <link=\"CRITTERS\">Creature</link> selvatiche non posso attraversare le porte.");
            }

            if (locale != null && locale.Code == "ru")
            {
                // Translation by Davkas
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyPressureDoorID}.NAME",
                    "<link=\"TinyPressureDoor\">Механический люк</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyPressureDoorID}.DESC",
                    "Механические люки открываются и закрываются куда быстрее, чем обычные.");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyPressureDoorID}.EFFECT",
                    "Позволяет поддерживать давление в зонах на прежнем уровне, блокируя<link=\"ELEMENTSLIQUID\">жидкости</link> и <link=\"ELEMENTSGAS\">газы</link>.\n\nРаботает как <link=\"TinyManualPressureDoor\">ручной люк</link>, если нет доступной <link=\"POWER\">электроэнергии</link> Дикие.\n\nДикие <link=\"CRITTERS\">существа</link> не могут проходить через люки.");
            }
            if (locale != null && locale.Code == "zh")
            {
                // Translation by Davkas
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyPressureDoorID}.NAME",
                    "<link=\"TinyPressureDoor\">微型机械气闸</link>");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyPressureDoorID}.DESC",
                    "微型机械气闸，专为小型复制人设计的门");
                Strings.Add($"STRINGS.BUILDINGS.PREFABS.{TinyPressureDoorID}.EFFECT",
                    "阻挡 <link=\"ELEMENTSLIQUID\">液体</link> 和 <link=\"ELEMENTSGAS>气体</link> 流动， 维持各区域间的压力。\n\n没有<link=\"POWER\">电力</link>时作用与<link=\"TINYMANUALPRESSUREDOOR\">微型手动气闸</link>一致。\n\n野生<link=\"CRITTERS\">小动物</link> 无法通过门。");
            }

            else
            {

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{TinyPressureDoorID}.NAME");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{TinyPressureDoorID}.DESC");

                Strings.Get($"STRINGS.BUILDINGS.PREFABS.{TinyPressureDoorID}.EFFECT");

            }
        }
    }
}