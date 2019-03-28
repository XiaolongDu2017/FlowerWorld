// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33246,y:32727,varname:node_3138,prsc:2|emission-1405-OUT,clip-3024-A;n:type:ShaderForge.SFN_TexCoord,id:9441,x:31527,y:32864,varname:node_9441,prsc:2,uv:1;n:type:ShaderForge.SFN_Tex2d,id:2361,x:31766,y:32829,ptovrint:False,ptlb:lightmap,ptin:_lightmap,varname:node_2361,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9441-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:9208,x:31958,y:32878,varname:node_9208,prsc:2,frmn:0,frmx:1,tomn:-0.1,tomx:1.5|IN-2361-RGB;n:type:ShaderForge.SFN_OneMinus,id:7479,x:32123,y:32878,varname:node_7479,prsc:2|IN-9208-OUT;n:type:ShaderForge.SFN_Lerp,id:1849,x:32336,y:32614,varname:node_1849,prsc:2|A-7730-RGB,B-7376-RGB,T-7479-OUT;n:type:ShaderForge.SFN_Color,id:7730,x:32123,y:32521,ptovrint:False,ptlb:lightcolor,ptin:_lightcolor,varname:node_7730,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:7376,x:32123,y:32689,ptovrint:False,ptlb:darkcolor,ptin:_darkcolor,varname:node_7376,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:4850,x:32631,y:32697,varname:node_4850,prsc:2|A-1849-OUT,B-8061-OUT;n:type:ShaderForge.SFN_Slider,id:8061,x:31902,y:33064,ptovrint:False,ptlb:lightmapintensity,ptin:_lightmapintensity,varname:node_8061,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Tex2d,id:3024,x:32315,y:33561,ptovrint:False,ptlb:diffiuse,ptin:_diffiuse,varname:node_3024,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6389,x:32126,y:33371,ptovrint:False,ptlb:detailmap,ptin:_detailmap,varname:node_6389,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-1966-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1966,x:31869,y:33315,varname:node_1966,prsc:2,uv:1;n:type:ShaderForge.SFN_Multiply,id:3679,x:33679,y:33854,varname:node_3679,prsc:2|A-3133-RGB,B-9530-OUT;n:type:ShaderForge.SFN_Color,id:3133,x:33449,y:33761,ptovrint:False,ptlb:node_6137_copy_copy_copy,ptin:_node_6137_copy_copy_copy,varname:_node_6137_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:9530,x:33430,y:34067,ptovrint:False,ptlb:node_8556_copy_copy,ptin:_node_8556_copy_copy,varname:_node_8556_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Blend,id:9541,x:33731,y:33599,varname:node_9541,prsc:2,blmd:6,clmp:False|SRC-3679-OUT;n:type:ShaderForge.SFN_ChannelBlend,id:1405,x:33030,y:32920,varname:node_1405,prsc:2,chbt:1|M-1134-OUT,R-6389-RGB,BTM-2924-OUT;n:type:ShaderForge.SFN_Slider,id:8486,x:32047,y:33169,ptovrint:False,ptlb:detailintensity,ptin:_detailintensity,varname:node_8486,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Multiply,id:1328,x:33743,y:33918,varname:node_1328,prsc:2|A-2247-RGB,B-2189-OUT;n:type:ShaderForge.SFN_Color,id:2247,x:33513,y:33825,ptovrint:False,ptlb:node_6137_copy_copy_copy_copy,ptin:_node_6137_copy_copy_copy_copy,varname:_node_6137_copy_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:2189,x:33494,y:34131,ptovrint:False,ptlb:node_8556_copy_copy_copy,ptin:_node_8556_copy_copy_copy,varname:_node_8556_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Blend,id:4455,x:33795,y:33663,varname:node_4455,prsc:2,blmd:6,clmp:False|SRC-1328-OUT;n:type:ShaderForge.SFN_Multiply,id:2195,x:33807,y:33982,varname:node_2195,prsc:2|A-9178-RGB,B-2775-OUT;n:type:ShaderForge.SFN_Color,id:9178,x:33577,y:33889,ptovrint:False,ptlb:node_6137_copy_copy_copy_copy_copy,ptin:_node_6137_copy_copy_copy_copy_copy,varname:_node_6137_copy_copy_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:2775,x:33558,y:34195,ptovrint:False,ptlb:node_8556_copy_copy_copy_copy,ptin:_node_8556_copy_copy_copy_copy,varname:_node_8556_copy_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Blend,id:339,x:33859,y:33727,varname:node_339,prsc:2,blmd:6,clmp:False|SRC-2195-OUT;n:type:ShaderForge.SFN_Multiply,id:1134,x:32587,y:33107,varname:node_1134,prsc:2|A-8486-OUT,B-6389-A;n:type:ShaderForge.SFN_Multiply,id:2924,x:32710,y:32850,varname:node_2924,prsc:2|A-4850-OUT,B-3024-RGB;proporder:2361-7730-7376-8061-3024-6389-8486;pass:END;sub:END;*/

Shader "Coco/Curved/lightmap_02" {
    Properties {
        _lightmap ("lightmap", 2D) = "white" {}
        _lightcolor ("lightcolor", Color) = (0.5,0.5,0.5,1)
        _darkcolor ("darkcolor", Color) = (0.5,0.5,0.5,1)
        _lightmapintensity ("lightmapintensity", Range(0, 5)) = 0
        _diffiuse ("diffiuse", 2D) = "white" {}
        //_detailmap ("detailmap", 2D) = "white" {}
        //_detailintensity ("detailintensity", Range(0, 5)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        //_QOffset ("Offset", Vector) = (0,0,0,0)
		//_Dist ("Distance", Float) = 3.0
		_angle ("Rotate Angle", Float) = 0
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
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
            #pragma exclude_renderers  d3d11_9x xbox360 xboxone ps3 ps4 psp2
            #pragma target 2.0
            uniform sampler2D _lightmap; uniform float4 _lightmap_ST;
            uniform float4 _lightcolor;
            uniform float4 _darkcolor;
            uniform float _lightmapintensity;
            uniform sampler2D _diffiuse; uniform float4 _diffiuse_ST;
            //uniform sampler2D _detailmap; uniform float4 _detailmap_ST;
            //uniform float _detailintensity;

            float _angle;

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
            //float4 _QOffset;
			//float _Dist;
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                //float4 vPos = mul (UNITY_MATRIX_MV, v.vertex);
			    //float zOff = vPos.z/_Dist;
			    //vPos += _QOffset*zOff*zOff;
			    //o.pos.xyz = mul (UNITY_MATRIX_P, vPos);
			    o.pos = UnityObjectToClipPos (v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }

            inline float2 rotateUv (float2 uv, float angle)
            {
                float2 targetUV = uv - 0.5;
                float len = length(targetUV);
                float targetAngle = atan2(targetUV.y, targetUV.x);

                targetAngle += angle * 3.14159265359;
                targetUV.x = cos(targetAngle) * len + 0.5;
                targetUV.y = sin(targetAngle) * len + 0.5;

                return targetUV;
            }

            float4 frag(VertexOutput i) : COLOR {
                float2 uv = rotateUv (i.uv0, _angle);
                float4 _diffiuse_var = tex2D(_diffiuse,TRANSFORM_TEX(uv, _diffiuse));
                clip(_diffiuse_var.a - 0.5);
////// Lighting:
////// Emissive:
                //float4 _detailmap_var = tex2D(_detailmap,TRANSFORM_TEX(i.uv1, _detailmap));
                //float node_1134 = (_detailintensity*_detailmap_var.a);
                float4 _lightmap_var = tex2D(_lightmap,TRANSFORM_TEX(i.uv1, _lightmap));
                //float3 node_4850 = (lerp(_lightcolor.rgb,_darkcolor.rgb,(1.0 - (_lightmap_var.rgb*1.6+-0.1)))*_lightmapintensity);
                //float3 node_1405 = (lerp( (node_4850*_diffiuse_var.rgb), _detailmap_var.rgb, node_1134.r ));
                //float3 emissive = node_1405;
                float3 node_4850 = (lerp(_lightcolor.rgb,_darkcolor.rgb,(2.0 - _lightmap_var.rgb*2.0))*_lightmapintensity);
                float3 finalColor = node_4850*_diffiuse_var.rgb;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            #pragma exclude_renderers  d3d11_9x xbox360 xboxone ps3 ps4 psp2
            #pragma target 2.0
            uniform sampler2D _diffiuse; uniform float4 _diffiuse_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _diffiuse_var = tex2D(_diffiuse,TRANSFORM_TEX(i.uv0, _diffiuse));
                clip(_diffiuse_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    //CustomEditor "ShaderForgeMaterialInspector"
}
