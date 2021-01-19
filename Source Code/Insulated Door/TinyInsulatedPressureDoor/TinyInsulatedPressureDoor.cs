using System.Collections.Generic;
using UnityEngine;

namespace TinyInsulatedPressureDoor
{
    internal class InsulatingDoor : KMonoBehaviour
    {
        [MyCmpGet]
        public Door door;

        public void SetInsulation(GameObject go, float insulation)
        {
            IList<int> placementCells = go.GetComponent<Building>().PlacementCells;
            for (int index = 0; index < placementCells.Count; ++index)
                SimMessages.SetInsulation(placementCells[index], insulation);
        }

        public InsulatingDoor()
        {
            base.OnPrefabInit();
        }
    }
}
