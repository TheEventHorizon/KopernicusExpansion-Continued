﻿using System;
using Kopernicus;
using Kopernicus.Configuration.ModLoader;
using UnityEngine;
using Kopernicus.Components;

namespace KopernicusExpansion
{
    namespace EmissiveFX
    {
        namespace Configuration
        {
            [RequireConfigType(ConfigType.Node)]
            public class EmissiveFX : ModLoader<PQSMod_EmissiveFX>, IParserEventSubscriber
            {
                // The color of the emission
                [ParserTarget("color", Optional = false)]
                private ColorParser PQScolor
                {
                    get { return mod.EmissiveMaterial.GetColor("_Color"); }
                    set { mod.EmissiveMaterial.SetColor("_Color", value); }
                }

                // How bright should the emission be?
                [ParserTarget("brightness")]
                private NumericParser<Single> PQSbrightness
                {
                    get { return mod.EmissiveMaterial.GetFloat("_Brightness"); }
                    set { mod.EmissiveMaterial.SetFloat("_Brightness", value); }
                }

                // How visible should the original texture be?
                [ParserTarget("transparency")]
                private NumericParser<Single> PQStransparency
                {
                    get { return mod.EmissiveMaterial.GetFloat("_Transparency"); }
                    set { mod.EmissiveMaterial.SetFloat("_Transparency", value); }
                }

                // Apply Event
                void IParserEventSubscriber.Apply(ConfigNode node)
                {
                    mod.EmissiveMaterial = new Material(ShaderLoader.GetShader("KopernicusExpansion/EmissiveFX"));
                    mod.EmissiveMaterial.SetColor("_Color", new Color(1f, 1f, 1f));
                    mod.EmissiveMaterial.SetFloat("_Brightness", 1.4f);
                    mod.EmissiveMaterial.SetFloat("_Transparency", 0.6f);
                }

                // PostApply Event
                void IParserEventSubscriber.PostApply(ConfigNode node) { }
            }
        }
    }
}