#ifndef TCCG_SURF_UNIT_BOTTOM_LAYER
#define TCCG_SURF_UNIT_BOTTOM_LAYER

#ifdef _BOTTOM_LAYER_ON

	// datas ------------------------------------------
	#ifndef TC_SURF_INPUTDATA_BOTTOM_LAYER
		#define TC_SURF_INPUTDATA_BOTTOM_LAYER float2 uv_BottomTex;
	#endif

	// properties -------------------------------------
	sampler2D _BottomTex;

	// functions --------------------------------------
	#ifndef TC_SURF_BOTTOM_LAYER
		#define TC_SURF_BOTTOM_LAYER(_IN, _mainTex, _mainColor, _colorFactor) \
			fixed4 botTex = tex2D (_BottomTex, _IN.uv_BottomTex) * _mainColor; \
			_mainTex.rgb = lerp (botTex.rgb, _mainTex.rgb, _colorFactor);
	#endif

#endif  // #ifdef _REFLECTION_ON

#endif  // #ifndef TCCG_SURF_UNIT_BOTTOM_LAYER
