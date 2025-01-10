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
    }
        SubShader
        {
            Tags { "Queue" = "Geometry" "RenderType" = "Opaque" }
            LOD 200

            CGPROGRAM
            #pragma surface surf Standard fullforwardshadows vertex:vert

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _WindStrength;
            float _WindSpeed;
            float4 _WindDirection;
            float _WaveScale;
            fixed4 _TintColor;

            struct Input
            {
                float2 uv_MainTex;
                float3 worldPos;
                float3 worldNormal;
                INTERNAL_DATA // Required for WorldNormalVector
            };

            void vert(inout appdata_full v, out Input o)
            {
                UNITY_INITIALIZE_OUTPUT(Input, o);

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

                // Guard against zero wind direction
                if (dot(_WindDirection.xyz, _WindDirection.xyz) < 0.001)
                {
                    windDisplacement = float3(0, 0, 0); // No displacement
                }

                // Convert back to local space
                v.vertex.xyz += mul(unity_WorldToObject, float4(windDisplacement, 0.0)).xyz;
            }

            void surf(Input IN, inout SurfaceOutputStandard o)
            {
                // Sample the texture and apply tint
                fixed4 texColor = tex2D(_MainTex, IN.uv_MainTex);
                o.Albedo = texColor.rgb * _TintColor.rgb;

                // Safe normalization of world normal
                float3 safeWorldNormal = IN.worldNormal;
                if (dot(safeWorldNormal, safeWorldNormal) < 0.001)
                {
                    safeWorldNormal = float3(0, 1, 0); //up vector
                }

                o.Normal = WorldNormalVector(IN, safeWorldNormal);

                // Specular setup
                o.Metallic = 0.0;
                o.Smoothness = 0.2;

                // Lighting reaction
                o.Alpha = texColor.a; // Alpha from the texture
            }
            ENDCG
        }
            FallBack "Diffuse"
}



















