Shader "vd/UnlitRimDistance"
{
	Properties
	{
		_MainColor ("Main Color", Color) = (0, 0, 0, 0)
		_RimColor ("Rim Color", Color) = (0, 0, 0, 0)
		_Radius ("Radius", Float) = 0.5
	}
	
	SubShader
	{
		Tags
		{
		    "Queue" = "Geometry"
		    "RenderType" = "Opaque"
		}
		
		CGPROGRAM
		// Uses the Lambertian lighting model
		#pragma surface surf Lambert
		
		struct Input
		{
			float3 worldPos; // This is calculated by Unity
		};
		
		half4 _MainColor;
		half4 _RimColor;
		float _Radius;

		void surf (Input IN, inout SurfaceOutput o)
		{
		    float2 center = (0, 0);
			float d = distance(center, IN.worldPos);
			float dN = 1 - saturate(d / _Radius); // Distance is normalized
			
			if (dN > 0 && dN < 1)
				o.Emission = _RimColor;
			else
				o.Emission = _MainColor;
		}
		ENDCG
	} 
	Fallback "vd/UnlitColor"
}