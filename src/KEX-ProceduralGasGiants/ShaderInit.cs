﻿using Kopernicus.Components;
using UnityEngine;

namespace KopernicusExpansion
{
    namespace ProceduralGasGiants
    {
        [KSPAddon(KSPAddon.Startup.Instantly, true)]
        public class ShaderInit : MonoBehaviour
        {
            void Awake()
            {
                ShaderLoader.LoadAssetBundle("KopernicusExpansion/Shaders", "proceduralgasgiants");
            }
        }
    }
}