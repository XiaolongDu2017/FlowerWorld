Shader "Coco/Custom/T4M Lightmap" {
	Properties {
        _Splat0 ("Layer 1", 2D) = "white" {}
	    _Splat1 ("Layer 2", 2D) = "white" {}
	    _Splat2 ("Layer 3", 2D) = "white" {}
	    _Splat3 ("Layer 4", 2D) = "white" {}
	    _Control ("Control (RGBA)", 2D) = "white" {}

		_Lightmap ("lightmap", 2D) = "white" {}
		_LightColor ("lightcolor", Color) = (1, 1, 1, 1)
		_DarkColor ("darkcolor", Color) = (0, 0, 0, 1)
		_LightmapIntensity ("lightmapintensity", Range(0, 5)) = 0
	}

	SubShader {
		Tags {
			"RenderType"="Opaque"
			"SplatCount" = "4"
		}

		Pass {
			Name "FORWARD"
			Tags {
				"LightMode"="ForwardBase"
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//#define UNITY_PASS_FORWARDBASE
			#include "UnityCG.cginc"
			#pragma multi_compile_fwdbase_fullshadows
			#pragma multi_compile_fog
			#pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2
			#pragma target 2.0

            // splat
            sampler2D _Splat0;
			float4 _Splat0_ST;
			sampler2D _Splat1;
			float4 _Splat1_ST;
			sampler2D _Splat2;
			float4 _Splat2_ST;
			sampler2D _Splat3;
			float4 _Splat3_ST;
			sampler2D _Control;
			float4 _Control_ST;

            // lightmap
			sampler2D _Lightmap;
			float4 _Lightmap_ST;
			float4 _LightColor;
			float4 _DarkColor;
			float _LightmapIntensity;

			struct VertexInput {
				float4 vertex : POSITION;
				float2 texcoord0 : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
			};
			struct VertexOutput {
				float4 pos : SV_POSITION;
				float2 uv0 : TEXCOORD0;
				float2 uv1 : TEXCOORD1;
				UNITY_FOG_COORDS(2)
			};

			VertexOutput vert (VertexInput v) {
				VertexOutput o;
				o.uv0 = v.texcoord0;
				o.uv1 = v.texcoord1;

				o.pos = UnityObjectToClipPos (v.vertex);
				UNITY_TRANSFER_FOG(o,o.pos);
				return o;
			}

			float4 frag(VertexOutput i) : COLOR {
			    // splat
			    fixed3 splat0 = tex2D(_Splat0, TRANSFORM_TEX(i.uv0, _Splat0));
			    fixed3 splat1 = tex2D(_Splat1, TRANSFORM_TEX(i.uv0, _Splat1));
			    fixed3 splat2 = tex2D(_Splat2, TRANSFORM_TEX(i.uv0, _Splat2));
			    fixed3 splat3 = tex2D(_Splat3, TRANSFORM_TEX(i.uv0, _Splat3));
			    fixed4 control = tex2D(_Control, TRANSFORM_TEX(i.uv0, _Control));
			    float3 splat = splat0 * control.r + splat1 * control.g + splat2 * control.b + splat3 * control.a;

				// lightmap
				float4 lightmap = tex2D(_Lightmap, TRANSFORM_TEX(i.uv1, _Lightmap));
				float3 light = lerp(_LightColor.rgb, _DarkColor.rgb, 2.0 - lightmap.rgb * 2.0) * _LightmapIntensity;

                // final
				float3 finalColor = light * splat;
				fixed4 finalRGBA = fixed4(finalColor, 1);
				UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
				return finalRGBA;
			}
			ENDCG
		}

		Pass {
			Name "ShadowCaster"
			Tags {
				"LightMode"="ShadowCaster"
			}
			Offset 1, 1

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//#define UNITY_PASS_SHADOWCASTER
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma multi_compile_shadowcaster
			#pragma multi_compile_fog
			#pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2
			#pragma target 2.0

			struct VertexInput {
				float4 vertex : POSITION;
				float2 texcoord0 : TEXCOORD0;
			};
			struct VertexOutput {
				V2F_SHADOW_CASTER;
				float2 uv0 : TEXCOORD1;
			};

			VertexOutput vert (VertexInput v) {
				VertexOutput o;
				o.uv0 = v.texcoord0;
				o.pos = UnityObjectToClipPos(v.vertex);
				TRANSFER_SHADOW_CASTER(o)
				return o;
			}

			float4 frag(VertexOutput i) : COLOR {
				SHADOW_CASTER_FRAGMENT(i)
			}
			ENDCG
		}
	}

	FallBack "Diffuse"
}
