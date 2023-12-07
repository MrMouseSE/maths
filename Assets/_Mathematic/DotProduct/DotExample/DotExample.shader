Shader "DotExample"
{
    Properties
    {
        _MainColor ("Main Color", color) = (1,1,1,1)
        _CounterColor ("Counter Color", color) = (1,1,1,1)
        _SpecPower ("Specular Power", range(1,8)) = 1
        [Toggle] _VertexLight ("Vertex Light", float) = 1
        _FresnelColor ("Fresnel Color", color) = (1,1,1,1)
        [Toggle] _Fresnel ("Fresnel", float) = 1
        _FresnelPower ("Fresnel Power", range(0.1,10)) = 1
        _FresnelOffset ("Fresnel Offset", range(-1,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile __ _VERTEXLIGHT_ON
            #pragma multi_compile __ _FRESNEL_ON

            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float dotValue : TEXCOORD1;
                float3 reflection : COLOR1;
                float3 cameraDirection : COLOR0;
            };

            float _SpecPower, _FresnelPower, _FresnelOffset;
            float4 _MainColor, _CounterColor, _FresnelColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                #ifdef _VERTEXLIGHT_ON
                    o.dotValue = max(0,dot(v.normal, _WorldSpaceLightPos0.rgb));
                #else
                    o.normal = v.normal;
                    o.reflection = reflect(-_WorldSpaceLightPos0.rgb, v.normal);
                    o.cameraDirection.rgb = normalize(ObjSpaceViewDir(v.vertex));
                #endif                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = _MainColor;
                #ifdef _VERTEXLIGHT_ON
                    col *= i.dotValue;
                #else
                    float dotValue = dot(i.normal, _WorldSpaceLightPos0.rgb);
                    col *= _LightColor0 * max(0,dotValue) + pow(max(0,dot(i.reflection,i.cameraDirection.rgb)), _SpecPower) + unity_AmbientSky;
                    col += lerp(float4(0,0,0,0), _CounterColor, saturate(-dotValue));
                    #ifdef _FRESNEL_ON
                        col.rgb += lerp(_FresnelColor, 0, pow(saturate(dot(i.normal,i.cameraDirection.rgb)+_FresnelOffset),_FresnelPower));
                    #endif                    
                #endif
                
                return col;
            }
            ENDCG
        }
    }
}
