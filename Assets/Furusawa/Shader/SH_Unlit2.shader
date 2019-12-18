Shader "Unlit/SH_Unlit_AlphaBlend"
{
	Properties
	{
		[Header(Main Settings)]
		[Space]
		[HDR]_Color("Color", Color) = (1,1,1,1)
		_MainTex("Main Texture", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0

		[Header(UV_Scroll)]
		[Space]
		_ScrollX("ScrollX",float) = 0.0
		_ScrollY("ScrollY",float) = 0.0

		[Header(DissolveCutout)]
		[Space]
		_DissolveTex("DissolveTex",2D) = "white"{}
		[Enum(0deg,0,90deg,1, 180deg,2, 270deg,3)] _RotType("Rotate Type", Float) = 0
		_DissolveCutoff("DissolveCutoff",Range(0,1)) = 0


		[Header(Blend Mode)]
		[Space]
		[HideInInspector]_BlendMode("Blend Mode", int) = 0	//他のプログラムからEnumで切り替えるための数値
		_BlendSrc("Blend Src", int) = 1	//BlendModeが切り替えられた時Enumにそれぞれ数値が保存されてて上書きされる
		_BlendDst("Blend Dst", int) = 0 //同文
		[KeywordEnum(Add, Blend, Mul)] _BlendMode("Blend Mode", Float) = 1

		[Space]
		[Header(Debug)]
		_Semantics("Semantics", Vector) = (0,0,0,0)


			//[Header(RimLighting)]
			//[Space]
			//_RimColor("RimColor",Color) = (1,1,1,1)
			//[MaterialToggle] _RimPower("RimPower",Range(0,5)) = 0
	}
		SubShader
		{
			Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }

			//Blend SrcAlpha Oneが通常の加算シェーダーらしい　
			//Blend One Oneは加算だけど重なると描画されてないところが後ろの画像を無視して奥を描画する


			Blend SrcAlpha OneMinusSrcAlpha
			//Blend[_BlendSrc][_BlendDst]

				/*ブレンドモード一覧
				Blend SrcAlpha OneMinusSrcAlpha // Alpha blending これ
				Blend One One // Additive
				Blend OneMinusDstColor One // Soft Additive　これ
				Blend DstColor Zero // Multiplicative
				Blend DstColor SrcColor // 2x Multiplicative
				*/

		BindChannels {
			Bind "Color", color
			Bind "Vertex", vertex
			Bind "TexCoord", texcoord
		}

			Cull Off Lighting Off ZWrite Off Fog { Color(0,0,0,0)}

			LOD 100

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				// make fog work
				#pragma multi_compile_fog


				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float4 color : COLOR;
					float4 uv : TEXCOORD0;	//uvという変数にTexcoord0を割り当ててる
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 color : COLOR;
					UNITY_FOG_COORDS(1)
					float4 vertex : SV_POSITION;

				};

				sampler2D _MainTex;
				float4 _MainTex_ST;
				half _ScrollX;
				half _ScrollY;
				fixed4 _Color;

				sampler2D _DissolveTex;
				float _DissolveCutoff;
				float _RotType;
				float _BlendMode;

				float4 _Semantics;


				//頂点
				v2f vert(appdata v)
				{
					v2f o;
					_Semantics = v.uv;
					o.color = v.color * _Color;
					o.vertex = UnityObjectToClipPos(v.vertex);
					float2 edtuv = TRANSFORM_TEX(v.uv, _MainTex);
					float tmp;
					//UVScroll
					v.uv.x += _ScrollX * _Time;
					v.uv.y += _ScrollY * _Time;
					_DissolveCutoff = v.uv.z;

					if (_RotType == 0) {}
					else if (_RotType == 1) { tmp = edtuv.x; edtuv.x = 1 - edtuv.y; edtuv.y = tmp; }
					else if (_RotType == 2) { edtuv.x = 1 - edtuv.x; edtuv.y = 1 - edtuv.y; }
					else if (_RotType == 3) { tmp = edtuv.x; edtuv.x = edtuv.y; edtuv.y = 1 - tmp; }
					//o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					UNITY_TRANSFER_FOG(o,o.vertex);
					o.uv = edtuv;
					return o;
				}

				//ここで色変えてる
				fixed4 frag(v2f i) : SV_Target
				{
					//画像と色を取得
					fixed4 col = tex2D(_MainTex, i.uv) * i.color * _Color;
				//dissolve用の画像系
				fixed4 dissolveColor = tex2D(_DissolveTex, i.uv);
				clip(dissolveColor.rgb - _DissolveCutoff);

				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
		}
			//CustomEditor "CustomShaderGUI"
}
