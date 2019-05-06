Shader "Unlit/NewCurved"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_BendAmount("Bend Amount", Vector) = (1,1,1,1)
		_BendOrigin("Bend Origin", Vector) = (0,0,0,0)
		_BendFallOff("Bend Falloff", float) = 1.0
		_BendFallOffStr("Bend Falloff Strength", Range(0.00001,10)) = 1.0
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 100

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				// make fog work
				#pragma multi_compile_fog

				#include "UnityCG.cginc"

				float3 _BendAmount;
				float3 _BendOrigin;
				float _BendFallOff;
				float _BendFallOffStr;
				
			float4 curveIt(float v)
			{
				const float4x4 world = mul(unity_ObjectToWorld, v);
				float dist = length(world.xyz - _BendOrigin.xyz);
				dist = max(0, dist - _BendFallOff);
				dist = pow(dist, _BendFallOffStr);
				world.xyz += dist * _BendAmount;
				return mul(unity_WorldToObject, world);
			}
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
				o.vertex = UnityObjectToClipPos(curveIt(v.vertex));
                o.uv = v.uv;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
			
			
            ENDCG
        }
    }
}
