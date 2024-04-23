using ComputerPlusPlus.Tools;
using GorillaNetworking;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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

#if DEBUG
        [HarmonyDebug]
#endif
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = instructions.ToList();

            int startIndex = codes.FindIndex(code => code.opcode == OpCodes.Callvirt && code.operand is MethodBase method && method.Name == "Invoke");
            const int removeInstructionCount = 4; // exclusive
            codes.RemoveRange(startIndex - removeInstructionCount + 1, removeInstructionCount);

            return codes;
        }
    }
}
/*
//         GameEvents.OnGorrillaKeyboardButtonPressedEvent.Invoke(this.Binding);
IL_0018: ldsfld    class [UnityEngine.CoreModule]UnityEngine.Events.UnityEvent`1<valuetype GorillaNetworking.GorillaKeyboardBindings> GameEvents::OnGorrillaKeyboardButtonPressedEvent
IL_001D: ldarg.0
IL_001E: ldfld     valuetype GorillaNetworking.GorillaKeyboardBindings GorillaNetworking.GorillaKeyboardButton::Binding
IL_0023: callvirt  instance void class [UnityEngine.CoreModule]UnityEngine.Events.UnityEvent`1<valuetype GorillaNetworking.GorillaKeyboardBindings>::Invoke(!0)
*/