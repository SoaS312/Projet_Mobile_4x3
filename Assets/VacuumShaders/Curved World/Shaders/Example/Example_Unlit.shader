Shader "Custom/Example_Unlit"
{
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}

	SubShader 
	{
		//CurvedWorld rendertype, used by image effects
		Tags { "RenderType"="CurvedWorld_Opaque" }

        Pass 
		{
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
#pragma multi_compile_instancing   

            #include "UnityCG.cginc"

			//CurvedWorld shader API
			#include "../cginc/CurvedWorld_Base.cginc"



			sampler2D _MainTex;		
			fixed4 _Color;


            struct vertexInput 
			{
                float4 vertex : POSITION;
                float4 texcoord0 : TEXCOORD0;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct fragmentInput
			{
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
            };

            fragmentInput vert(vertexInput i)
			{
				UNITY_SETUP_INSTANCE_ID(i);
                fragmentInput o;
				UNITY_INITIALIZE_OUTPUT(fragmentInput,o); 
				UNITY_TRANSFER_INSTANCE_ID(i, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				//CurvedWorld vertex transform
				V_CW_TransformPoint(i.vertex);


                o.position = UnityObjectToClipPos(i.vertex);
                o.uv = i.texcoord0.xy;
                return o;
            }

            fixed4 frag(fragmentInput i) : SV_Target 
			{
                return tex2D(_MainTex, i.uv) * _Color;
            }
            ENDCG
        }
    }
}
