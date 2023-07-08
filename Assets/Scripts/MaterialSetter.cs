using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MaterialSetter
{
    [SerializeField] Color color;
    Renderer[] renderers;
    public void Setup(GameObject gameObject)
    {
        renderers = gameObject.GetComponentsInChildren<Renderer>();
    }
    public void SetAllRenderersColor()
    {
        foreach(Renderer renderer in renderers)
        {
            renderer.material.color = color;
        }
    }
    public void SetAllRenderersColor(bool useEmission, float intensity)
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = color;
            if (useEmission)
            {
                renderer.material.EnableKeyword("_EMISSION");
                renderer.material.SetColor("_EmissionColor", color * intensity);
            }
            else
            {
                renderer.material.DisableKeyword("_EMISSION");
            }
        }
    }
    public void SetAllRenderersColor(Color overrideColor)
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = overrideColor;
        }
    }
    public void SetAllRenderersColor(Color overrideColor, bool useEmission, float intensity)
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = overrideColor;
            if (useEmission)
            {
                renderer.material.EnableKeyword("_EMISSION");
                renderer.material.SetColor("_EmissionColor", color * intensity);
            }
            else
            {
                renderer.material.DisableKeyword("_EMISSION");
            }
        }
    }
    public void SetRendererAtIndex(int index)
    {
        renderers[index].material.color = color;
    }
    public void SetRendererAtIndex(int index, bool useEmission, float intensity)
    {
        renderers[index].material.color = color;
        if (useEmission)
        {
            renderers[index].material.EnableKeyword("_EMISSION");
            renderers[index].material.SetColor("_EmissionColor", color * intensity);
        }
        else
        {
            renderers[index].material.DisableKeyword("_EMISSION");
        }

    }
    public void SetRendererAtIndex(int index, Color overrideColor)
    {
        renderers[index].material.color = overrideColor;
    }
    public void SetRendererAtIndex(int index, Color overrideColor, bool useEmission, float intensity)
    {
        renderers[index].material.color = overrideColor;
        if (useEmission)
        {
            renderers[index].material.EnableKeyword("_EMISSION");
            renderers[index].material.SetColor("_EmissionColor", overrideColor * intensity);
        }
        else
        {
            renderers[index].material.DisableKeyword("_EMISSION");
        }
    }
}
