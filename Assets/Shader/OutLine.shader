// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "Custom/OutlineShader" {
	Properties{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_OutLineWidth("width", float) = 1.2//定义一个变量
		_TestColor("Test color", Color) = (1, 1, 1, 1)
	}
		SubShader{

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				struct appdata {
					float4 vertex:POSITION;
					float2 uv:TEXCOORD0;
				};

				struct v2f
				{
					float2 uv :TEXCOORD0;
					float4 vertex:SV_POSITION;
				};


				float _OutLineWidth;//设置变量
				v2f vert(appdata v)
				{
					v2f o;
					//设置一下xy
					//v.vertex.xy *= 1.1;
					v.vertex.xy *= _OutLineWidth;//乘上变量
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				}

				sampler2D _MainTex;
				float4 _TestColor;
				fixed4 frag(v2f i) :SV_Target
				{
					fixed4 col = tex2D(_MainTex, i.uv);
				//return col;
				return _TestColor;;
			}
			ENDCG
		}


		Pass
			{
				ZTest Always
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				struct appdata {
				float4 vertex:POSITION;
				float2 uv:TEXCOORD0;
			};

			struct v2f
			{
				float2 uv :TEXCOORD0;
				float4 vertex:SV_POSITION;
			};


			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;

			fixed4 frag(v2f i) :SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
			return col;
		}
			ENDCG
		}
		}
			FallBack "Diffuse"
}