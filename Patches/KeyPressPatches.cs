using GorillaNetworking;
using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace ComputerPlusPlus.Patches
{
    [HarmonyPatch(typeof(GorillaKeyboardButton), "OnTriggerEnter")]
    class KeyPressPatches
    {
        private static void Prefix(GorillaKeyboardButton __instance, Collider collider)
        {
            if (collider.GetComponentInParent<GorillaTriggerColliderHandIndicator>() == null)
                return;
            ComputerManager.Instance.OnKeyPressed(__instance);
        }
    }
}
