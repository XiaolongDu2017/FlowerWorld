#ifndef TCCG_SURF_UNIT_NORMALMAP
#define TCCG_SURF_UNIT_NORMALMAP

#ifdef _NORMALMAP_ON

	// datas ------------------------------------------
	#ifndef TC_SURF_INPUTDATA_NORMALMAP
		#define TC_SURF_INPUTDATA_NORMALMAP float2 uv_BumpMap;
	#endif

	// properties -------------------------------------
	sampler2D _BumpMap;

	// functions --------------------------------------
	#ifndef TC_SURF_NORMALMAP
		#define TC_SURF_NORMALMAP(_IN, _OUT, _blendFactor) \
			fixed3 normal = UnpackNormal (tex2D (_BumpMap, _IN.uv_BumpMap)); \
			_OUT.Normal = lerp (fixed3 (0, 0, 1), normal, ceil (_blendFactor));
	#endif
	
#endif  // #ifdef _NORMALMAP_ON

#endif  // #ifndef TCCG_SURF_UNIT_NORMALMAP
