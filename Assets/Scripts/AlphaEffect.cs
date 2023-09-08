using System.Collections;
using UnityEngine;

public class AlphaEffect : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float minAlpha = 0.2f;
    public float maxAlpha = 1.0f;
    public float fluctuationSpeed = 1.0f;
    public float fluctuationMagnitude = 0.1f;

    private void Start()
    {
        StartCoroutine(AlphaFluctuation());
    }

    private IEnumerator AlphaFluctuation()
    {
        while (true)
        {
            float targetAlpha = Random.Range(minAlpha, maxAlpha);
            float currentAlpha = spriteRenderer.color.a;
            float t = 0;
            while (t < 1)
            {
                t += Time.deltaTime * fluctuationSpeed;
                float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, t);
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);

                yield return null;
            }
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
        }
    }
}
