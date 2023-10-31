using CM3D2.SceneCapture.Plugin;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace COM3D2.SceneCaptureAddition.Plugin
{
    internal class SCInstancesPatch
    {
        static internal Dictionary<Type, Type> DefToEffect = new Dictionary<Type, Type> {
            { typeof(HDRDef), typeof(HDR) },
            { typeof(BeautifyDef), typeof(Beautify) }
        };

        [HarmonyPatch(typeof(Instances), "LoadEffects")]
        [HarmonyPostfix]
        private static void LoadEffectPostfix(XDocument xml)
        {
            try
            {
                XElement xelement = xml.Element("Preset").Element("Effects");
                if (xelement != null)
                {
                    SerializeStatic.LoadDef(xelement, typeof(HDRDef), typeof(HDR));
                    SerializeStatic.LoadDef(xelement, typeof(BeautifyDef), typeof(Beautify));
                }
            }
            catch (Exception ex)
            {
                SceneCaptureAddition.Logger.LogError(ex);
            }
        }

        [HarmonyPatch(typeof(Instances), "SaveEffects")]
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> SaveEffectsTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            CodeMatcher codeMatcher = new CodeMatcher(instructions);
            codeMatcher.MatchForward(false, new[] { new CodeMatch(OpCodes.Ldc_I4_S) });
            codeMatcher.SetInstruction(new CodeInstruction(OpCodes.Ldc_I4_S, DefToEffect.Count + (byte)(sbyte)codeMatcher.Instruction.operand));
            codeMatcher.End().MatchBack(true, new[] { new CodeMatch(OpCodes.Stelem_Ref) }).Advance(1);
            int index = (byte)(sbyte)codeMatcher.InstructionAt(-7).operand;
            foreach (var p in DefToEffect)
            {
                codeMatcher.InsertAndAdvance(
                    new CodeInstruction(OpCodes.Dup),
                    new CodeInstruction(OpCodes.Ldc_I4_S, ++index),
                    new CodeInstruction(OpCodes.Ldtoken, p.Key),
                    new CodeInstruction(OpCodes.Call, typeof(Type).GetMethod(nameof(Type.GetTypeFromHandle))),
                    new CodeInstruction(OpCodes.Ldtoken, p.Value),
                    new CodeInstruction(OpCodes.Call, typeof(Type).GetMethod(nameof(Type.GetTypeFromHandle))),
                    new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(SerializeStatic), nameof(SerializeStatic.SaveDef))),
                    new CodeInstruction(OpCodes.Stelem_Ref)
                );
            }
            return codeMatcher.InstructionEnumeration();
        }
    }
}
