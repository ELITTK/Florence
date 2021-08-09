using System;
using UnityEngine;

public class PostEffectBasic : MonoBehaviour
{
    public Shader shader;	                                // ����shader
    protected Material mat;	                                // ���ʶ���
    public bool IsSupported { get; private set; }           // �ú����Ƿ�֧��
    public string UnsupportedMsg { get; private set; }      // ��֧�ֵ���Ϣ
    [Range(0.0001f, 0.1f)] public float PixelInterval = 0.1f;
    [Range(0, 1)] public float PixelItensity = 1f;
    protected virtual void Start()
    {
        try
        {
            IsSupported = CheckSupported(out string UnsupportedMsg);    // ����Ƿ�֧��
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
    // ���֧�����ĺ���
    protected virtual bool CheckSupported(out string unsupportedMsg)
    {
        unsupportedMsg = shader.isSupported ? null :
            $"post processing effect shader unsupported, shader name:{shader.name}";
        if (!string.IsNullOrEmpty(unsupportedMsg)) Debug.LogError(unsupportedMsg);
        return shader.isSupported;
    }
    // ������ں���
    protected virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        
        mat.SetFloat("_PixelInterval", PixelInterval);
        mat.SetFloat("_PixelItensity", PixelItensity);
        Graphics.Blit(source, destination, mat);
    }
}
