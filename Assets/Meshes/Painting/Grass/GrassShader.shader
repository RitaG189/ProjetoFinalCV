Shader "Custom/WindEffect"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _WindStrength("Wind Strength", Float) = 1.0
        _WindSpeed("Wind Speed", Float) = 1.0
        _WindDirection("Wind Direction", Vector) = (1, 0, 0, 0)
        _WaveScale("Wave Scale", Float) = 0.5
        _TintColor("Tint Color", Color) = (0.5, 1.0, 0.5, 1.0)
        _AmbientIntensity("Ambient Intensity", Float) = 0.3
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
                #include "Lighting.cginc"

                sampler2D _MainTex;
                float _WindStrength;
                float _WindSpeed;
                float4 _WindDirection;
                float _WaveScale;
                fixed4 _TintColor;
                float _AmbientIntensity;

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
                    float3 worldNormal : TEXCOORD1;
                    float3 worldPos : TEXCOORD2;
                };

                v2f vert(appdata v)
                {
                    UNITY_SETUP_INSTANCE_ID(v);
                    v2f o;

                    // Transform position to world space
                    float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

                    // Calculate local height for gradient
                    float heightFactor = saturate(v.vertex.y);

                    // Add displacement based on X and Z coordinates to create waves
                    float waveOffset = sin((worldPos.x + worldPos.z) * _WaveScale + _Time.y * _WindSpeed) * _WindStrength;

                    // Apply height gradient to displacement
                    waveOffset *= heightFactor;

                    // Apply displacement in wind direction
                    float3 windDisplacement = normalize(_WindDirection.xyz) * waveOffset;

                    // Convert back to local space
                    v.vertex.xyz += mul(unity_WorldToObject, float4(windDisplacement, 0.0)).xyz;

                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;

                    // Pass world position and normal for lighting calculations
                    o.worldPos = worldPos;
                    o.worldNormal = normalize(mul(unity_ObjectToWorld, float4(v.normal, 0.0)).xyz);

                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    // Normalize the world normal
                    float3 worldNormal = normalize(i.worldNormal);

                    // Sample the texture
                    fixed4 texColor = tex2D(_MainTex, i.uv);

                    // Calculate lighting
                    // Unity's built-in light calculations
                    fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * _AmbientIntensity;
                    fixed3 lightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));
                    fixed3 diffuse = max(0.0, dot(worldNormal, lightDir)) * _LightColor0.rgb;

                    // Combine ambient and diffuse lighting
                    fixed3 lighting = ambient + diffuse;

                    // Apply the lighting to the texture and tint
                    fixed4 finalColor = texColor * _TintColor * fixed4(lighting, 1.0);

                    return finalColor;
                }
                ENDCG
            }
        }
}












