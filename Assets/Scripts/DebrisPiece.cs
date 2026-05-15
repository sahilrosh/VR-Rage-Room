using UnityEngine;

public class DebrisPiece : MonoBehaviour
{
    public float fadeDelay = 2f;
    public float fadeDuration = 1.5f;

    private Renderer rend;
    private float timer = 0f;
    private bool fading = false;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // Make material support transparency
        if (rend != null)
        {
            Material mat = rend.material;
            mat.SetFloat("_Mode", 2);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.renderQueue = 3000;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!fading && timer >= fadeDelay)
            fading = true;

        if (fading && rend != null)
        {
            float t = (timer - fadeDelay) / fadeDuration;
            Color c = rend.material.color;
            c.a = Mathf.Lerp(1f, 0f, t);
            rend.material.color = c;
        }
    }
}