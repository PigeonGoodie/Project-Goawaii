using System.Collections;
using UnityEngine;

public class ObjectScaleAnimation : MonoBehaviour
{
    public AnimationCurve scaleCurve;
    public float animationDuration = 1f;
    public Vector3 startScale = Vector3.zero;
    public Vector3 targetScale = Vector3.one;

    private void Start()
    {
        transform.localScale = startScale;

        // Start the scale animation when the object is activated
        StartScaleAnimation();
    }

    private void StartScaleAnimation()
    {
        StartCoroutine(ScaleAnimation());
    }

    private IEnumerator ScaleAnimation()
    {
        Vector3 initialScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            // Calculate the current scale based on the animation curve
            float normalizedTime = elapsedTime / animationDuration;
            float scale = scaleCurve.Evaluate(normalizedTime);

            // Interpolate the scale between the initial and target scale
            Vector3 currentScale = Vector3.Lerp(initialScale, targetScale, scale);

            // Apply the current scale to the object
            transform.localScale = currentScale;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set the final scale to ensure accuracy
        transform.localScale = targetScale;
    }
}
