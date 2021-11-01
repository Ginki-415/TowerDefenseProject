// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/BuildGridShader"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
    }
        SubShader
    {
        Pass
        {
            Tags{ "LightMode" = "ForwardBase" "RenderType"="Opaque" "Queue"="Transparent" }

            CGPROGRAM

            #include "Lighting.cginc"

            #pragma vertex vert
            #pragma fragment frag

            fixed4 _Color;

            struct a2v
            {
            	float4 vertex : POSITION;
            	float4 normal : NORMAL;
            };

            struct v2f
            {
            	float4 pos : SV_POSITION;
            	float3 worldNormal : TEXCOORD0;
            };

            v2f vert (a2v v)
            {
            	v2f o;
            	o.pos = UnityObjectToClipPos(v.vertex);

            	o.worldNormal = normalize(mul(v.normal, (fixed3x3)unity_WorldToObject));

            	return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
            	fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;

            	fixed3 worldNormal = normalize(i.worldNormal);
            	fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);

            	fixed3 diffuse = _LightColor0.rgb * saturate(dot(worldNormal, worldLightDir)) * _Color.rgb;

            	fixed3 color = ambient + diffuse;

            	return fixed4(color, 0.5);
            }

            ENDCG
        }
    }
        FallBack "Diffuse"
}
