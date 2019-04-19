#ifndef TCCG_SURF_UNIT_DECAL_LAYER
#define TCCG_SURF_UNIT_DECAL_LAYER

#if defined(_DECAL_LAYER_1) || defined(_DECAL_LAYER_2) || defined(_DECAL_LAYER_3)

	#include "../CGUtils/TCCG_Util_LayerBlend.cginc"

	// uv ---------------------------------------------
	#ifndef _DECAL_LAYER_1_UV2_ON
		#define UV_DECAL1 uv_DecalTex1
	#else
		#define UV_DECAL1 uv2_DecalTex1
	#endif
	#ifndef _DECAL_LAYER_2_UV2_ON
		#define UV_DECAL2 uv_DecalTex2
	#else
		#define UV_DECAL2 uv2_DecalTex2
	#endif
	#ifndef _DECAL_LAYER_3_UV2_ON
		#define UV_DECAL3 uv_DecalTex3
	#else
		#define UV_DECAL3 uv2_DecalTex3
	#endif

	#ifdef _DECAL_LAYER_1

		// datas --------------------------------------
		#ifndef TC_SURF_INPUTDATA_DECAL_LAYER
			#define TC_SURF_INPUTDATA_DECAL_LAYER half2 UV_DECAL1;
		#endif

		// properties ---------------------------------
		sampler2D _DecalTex1;

		// functions ----------------------------------
		#ifndef TC_SURF_DECAL_LAYER
			#define TC_SURF_DECAL_LAYER(_IN, _mainTex) \
				fixed4 decal1 = tex2D (_DecalTex1, _IN.UV_DECAL1); \
				_mainTex.rgb = blend_layer1 (_mainTex.rgb, decal1.rgb, decal1.a);
		#endif

	#elif _DECAL_LAYER_2

		// datas --------------------------------------
		#ifndef TC_SURF_INPUTDATA_DECAL_LAYER
			#define TC_SURF_INPUTDATA_DECAL_LAYER half2 UV_DECAL1; half2 UV_DECAL2;
		#endif

		// properties ---------------------------------
		sampler2D _DecalTex1;
		sampler2D _DecalTex2;

		// functions ----------------------------------
		#ifndef TC_SURF_DECAL_LAYER
			#define TC_SURF_DECAL_LAYER(_IN, _mainTex) \
				fixed4 decal1 = tex2D (_DecalTex1, _IN.UV_DECAL1); \
				fixed4 decal2 = tex2D (_DecalTex2, _IN.UV_DECAL2); \
				_mainTex.rgb = blend_layer2 (_mainTex.rgb, decal1.rgb, decal1.a, decal2.rgb, decal2.a);
		#endif

	#else   // defined _DECAL_LAYER_3

		// datas --------------------------------------
		#ifndef TC_SURF_INPUTDATA_DECAL_LAYER
			#define TC_SURF_INPUTDATA_DECAL_LAYER half2 UV_DECAL1; half2 UV_DECAL2; half2 UV_DECAL3;
		#endif

		// properties ---------------------------------
		sampler2D _DecalTex1;
		sampler2D _DecalTex2;
		sampler2D _DecalTex3;

		// functions ----------------------------------
		#ifndef TC_SURF_DECAL_LAYER
			#define TC_SURF_DECAL_LAYER(_IN, _mainTex) \
				fixed4 decal1 = tex2D (_DecalTex1, _IN.UV_DECAL1); \
				fixed4 decal2 = tex2D (_DecalTex2, _IN.UV_DECAL2); \
				fixed4 decal3 = tex2D (_DecalTex3, _IN.UV_DECAL3); \
				_mainTex.rgb = blend_layer3 (_mainTex.rgb, decal1.rgb, decal1.a, decal2.rgb, decal2.a, decal3.rgb, decal3.a);
		#endif

	#endif  // #ifdef _DECAL_LAYER_1

#endif  // #if defined(_DECAL_LAYER_1) || defined(_DECAL_LAYER_2) || defined(_DECAL_LAYER_3)

#endif  // #ifndef TCCG_SURF_UNIT_DECAL_LAYER
