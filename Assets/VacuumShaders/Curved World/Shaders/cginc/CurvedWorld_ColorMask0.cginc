#ifndef VACUUM_CURVEDWORLD_COLORMASK0_CGINC
#define VACUUM_CURVEDWORLD_COLORMASK0_CGINC

#include "UnityCG.cginc"
#include "../cginc/CurvedWorld_Base.cginc"
 

struct v2f   
{  
	float4 pos : SV_POSITION;	

	UNITY_VERTEX_INPUT_INSTANCE_ID
	UNITY_VERTEX_OUTPUT_STEREO
};
	 
v2f vert(appdata_base v)
{
	UNITY_SETUP_INSTANCE_ID(v);
	v2f o;
	UNITY_INITIALIZE_OUTPUT(v2f, o);
	UNITY_TRANSFER_INSTANCE_ID(v, o);
	UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
	
	V_CW_TransformPoint(v.vertex);
	o.pos = UnityObjectToClipPos(v.vertex);

	return o;
}

fixed4 frag () : SV_Target 
{
	return 0;
}

	
#endif