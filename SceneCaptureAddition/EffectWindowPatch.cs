using CM3D2.SceneCapture.Plugin;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace COM3D2.SceneCaptureAddition.Plugin
{
    internal static class EffectWindowPatch
    {
        static public int FontSize = 0;
        static internal List<string> NewPane = new List<string> { nameof(newHdrPane), nameof(newBeautifyPane) };
        static internal Dictionary<string, Type> PaneToDef = new Dictionary<string, Type> {
            { nameof(hdrPane), typeof(HDRDef) },
            { nameof(beautifyPane), typeof(BeautifyDef) }
        };
        static public HDRPane hdrPane { get; set; }
        static public BeautifyPane beautifyPane { get; set; }
        static public HDRPane newHdrPane
        {
            get
            {
                hdrPane = new HDRPane(FontSize);
                return hdrPane;
            }
        }

        static public BeautifyPane newBeautifyPane
        {
            get
            {
                beautifyPane = new BeautifyPane(FontSize);
                return beautifyPane;
            }
        }

        [HarmonyPatch(typeof(CM3D2.SceneCapture.Plugin.EffectWindow), nameof(CM3D2.SceneCapture.Plugin.EffectWindow.Awake))]
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> AwakeTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            CodeMatcher codeMatcher = new CodeMatcher(instructions);
            codeMatcher.MatchForward(false, new[] { new CodeMatch(OpCodes.Stloc_0) }).MatchBack(false, new[] { new CodeMatch(OpCodes.Callvirt) }).Advance(1);
            codeMatcher.InsertAndAdvance(new[] {
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(ControlBase), nameof(ControlBase.FontSize))),
                new CodeInstruction(OpCodes.Stsfld, typeof(EffectWindowPatch).GetField(nameof(FontSize)))
            });
            foreach (var p in NewPane)
            {
                codeMatcher.InsertAndAdvance(new[] {
                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(ControlBase), "ChildControls")),
                    new CodeInstruction(OpCodes.Call, AccessTools.PropertyGetter(typeof(EffectWindowPatch), p)),
                    new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(List<ControlBase>), "Add"))
                });
            }
            return codeMatcher.InstructionEnumeration();
        }

        [HarmonyPatch(typeof(CM3D2.SceneCapture.Plugin.EffectWindow), nameof(CM3D2.SceneCapture.Plugin.EffectWindow.Update))]
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> UpdateTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            CodeMatcher codeMatcher = new CodeMatcher(instructions);
            codeMatcher.MatchForward(false, new[] { new CodeMatch(OpCodes.Stloc_1) }).Advance(-1);
            foreach (var p in PaneToDef)
            {
                codeMatcher.InsertAndAdvance(new[] {
                    new CodeInstruction(OpCodes.Call, AccessTools.PropertyGetter(typeof(EffectWindowPatch), p.Key)),
                    new CodeInstruction(OpCodes.Call, AccessTools.Method(p.Value, "Update"))
                });
            }
            return codeMatcher.InstructionEnumeration();
        }

        [HarmonyPatch(typeof(CM3D2.SceneCapture.Plugin.EffectWindow), nameof(CM3D2.SceneCapture.Plugin.EffectWindow.ShowPane))]
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> ShowPaneTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            CodeMatcher codeMatcher = new CodeMatcher(instructions);
            codeMatcher.End().MatchBack(true, new[] {
                new CodeMatch(OpCodes.Ldarg_0),
                new CodeMatch(OpCodes.Ldfld),
                new CodeMatch(OpCodes.Call),
            }).Advance(1);
            string lastGetter = "";
            MethodInfo addGUICheckbox = AccessTools.Method(
                typeof(GUIUtil),
                nameof(GUIUtil.AddGUICheckbox),
                new[] { typeof(ControlBase), typeof(ControlBase), typeof(ControlBase) }
            );
            foreach (var p in PaneToDef)
            {
                if (string.IsNullOrEmpty(lastGetter))
                {
                    var loadlastPane = codeMatcher.InstructionsWithOffsets(-5, -4);
                    codeMatcher.InsertAndAdvance(new[] {
                        new CodeInstruction(OpCodes.Ldarg_0),
                        new CodeInstruction(OpCodes.Call, AccessTools.PropertyGetter(typeof(EffectWindowPatch), p.Key)),
                    }).InsertAndAdvance(loadlastPane).InsertAndAdvance(
                        new CodeInstruction(OpCodes.Call, addGUICheckbox)
                    );
                }
                else
                {
                    codeMatcher.InsertAndAdvance(new[] {
                        new CodeInstruction(OpCodes.Ldarg_0),
                        new CodeInstruction(OpCodes.Call, AccessTools.PropertyGetter(typeof(EffectWindowPatch), p.Key)),
                        new CodeInstruction(OpCodes.Call, AccessTools.PropertyGetter(typeof(EffectWindowPatch), lastGetter)),
                        new CodeInstruction(OpCodes.Call, addGUICheckbox)
                    });
                }
                lastGetter = p.Key;
            }
            return codeMatcher.InstructionEnumeration();
        }
    }
}
