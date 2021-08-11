using System;
using UnityEngine;

public class PostEffectBasic : MonoBehaviour
{
    public Shader shader;	                                // 后处理shader
    protected Material mat;	                                // 材质对象
    public bool IsSupported { get; private set; }           // 该后处理是否支持
    public string UnsupportedMsg { get; private set; }      // 不支持的消息
    [Range(0.0001f, 0.1f)] public float PixelInterval = 0.1f;
    [Range(0, 1)] public float PixelItensity = 1f;
    protected virtual void Start()
    {
        try
        {
            IsSupported = CheckSupported(out string UnsupportedMsg);    // 检测是否支持
            if (IsSupported) mat = new Material(shader);
        }
        catch (Exception er)
        {
            IsSupported = false;
            UnsupportedMsg = $"{GetType().Name} post processing init er:{er}";
            Debug.LogError(UnsupportedMsg);
        }
    }
    private void OnDestroy()
    {
        Destroy(mat);
    }
    // 检测支持与否的函数
    protected virtual bool CheckSupported(out string unsupportedMsg)
    {
        unsupportedMsg = shader.isSupported ? null :
            $"post processing effect shader unsupported, shader name:{shader.name}";
        if (!string.IsNullOrEmpty(unsupportedMsg)) Debug.LogError(unsupportedMsg);
        return shader.isSupported;
    }
    // 后处理入口函数
    protected virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // source 参数：是场景渲染后的图像渲染纹理
        // destination 参数：是经过我们的后处理后要填充的目标图像渲染纹理
        // if (!IsSupported) { Graphics.Blit(source, destination); return; } // 不支持
        // mat.SetFloat("paramName", xx);
        // mat.SetColor("paramName", xx);
        // Graphics.Blit(source, destination, mat);
        //if (!IsSupported) { Graphics.Blit(source, destination); return; } // 不支持
        mat.SetFloat("_PixelInterval", PixelInterval);
        mat.SetFloat("_PixelItensity", PixelItensity);
        //mat.SetColor("_EdgeColor", edgeColor);
        Graphics.Blit(source, destination, mat);
    }
}
