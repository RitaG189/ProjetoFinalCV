Shader "Custom/WindEffect"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _WindStrength("Wind Strength", Float) = 1.0
        _WindSpeed("Wind Speed", Float) = 1.0
        _WindDirection("Wind Direction", Vector) = (1, 0, 0, 0)
        _WaveScale("Wave Scale", Float) = 0.5
        _TintColor("Tint Color", Color) = (0.5, 1.0, 0.5, 1.0) // Default to a greenish tint
    }
        SubShader
        {
            Tags { "Queue" = "Geometry" "RenderType" = "Opaque" }
            LOD 200

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile_instancing

                #include "UnityCG.cginc"

                sampler2D _MainTex;
                float _WindStrength;
                float _WindSpeed;
                float4 _WindDirection;
                float _WaveScale;
                fixed4 _TintColor;

                struct appdata
                {
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                    float2 uv : TEXCOORD0;
                    UNITY_VERTEX_INPUT_INSTANCE_ID
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata v)
                {
                    UNITY_SETUP_INSTANCE_ID(v);
                    v2f o;

                    // Transforma a posição para o espaço mundial
                    float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

                    // Calcula a altura local para o gradiente
                    float heightFactor = saturate(v.vertex.y);

                    // Adiciona um deslocamento baseado nas coordenadas X e Z para criar ondas
                    float waveOffset = sin((worldPos.x + worldPos.z) * _WaveScale + _Time.y * _WindSpeed) * _WindStrength;

                    // Aplica o gradiente de altura ao deslocamento
                    waveOffset *= heightFactor;

                    // Aplica o deslocamento na direção do vento
                    float3 windDisplacement = normalize(_WindDirection.xyz) * waveOffset;

                    // Converte de volta para o espaço local
                    v.vertex.xyz += mul(unity_WorldToObject, float4(windDisplacement, 0.0)).xyz;

                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    // Sample the texture and apply the tint
                    fixed4 texColor = tex2D(_MainTex, i.uv);
                    return texColor * _TintColor;
                }
                ENDCG
            }
        }
}








