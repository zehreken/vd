Shader "Voodoo/DoubleSidedUnlit" {
    Properties
    {
        _MainTex ("Diffuse Map", 2D) = "white" {}
    }
    SubShader {
         Cull off   
         Pass {
             ColorMaterial AmbientAndDiffuse
         }

    }
}
