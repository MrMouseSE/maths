Shader "DotPresent"
{
    Properties
    {
        _BackTexture ("Back Texture", 2D) = "black"
        _StepTexture ("Step Texture", 2D) = "white"
        _Offset("Offset", vector) = (0,0,0,0)
        _Radius("Radius", float) = 1 
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
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 position : TEXCOORD1;
            };

            sampler2D _BackTexture, _StepTexture;
            float4 _Offset;
            float _Radius;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.position = mul(v.vertex - _Offset, unity_ObjectToWorld) / _Radius;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 back = tex2D(_BackTexture, i.uv);
                fixed4 step = tex2D(_StepTexture, i.uv);
                fixed3 mask = dot(i.position.rgb, i.position.rgb);

                fixed3 col = lerp(step, back, saturate(mask));

                return fixed4(col,1);
            }
            ENDCG
        }
    }
}
