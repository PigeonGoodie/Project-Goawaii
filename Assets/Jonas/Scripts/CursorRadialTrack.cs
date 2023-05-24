using UnityEngine;
using UnityEngine.UI;

public class CursorRadialTrack : MonoBehaviour
{
    public Slider slider;

    [Range(0, 1)]
    public float centerDistance = 0;
    [Range(0, 1)]
    public float selectGive = 0;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 localMousePosition;

            // Convert mouse position to local position of UI element
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, mousePosition, null, out localMousePosition))
            {
                Vector2 center = rectTransform.rect.center;
                float radius = rectTransform.rect.width / 2;

                // Check if the mouse is within the boundaries of the UI element
                //if (Vector3.Distance(localMousePosition, center) > (rectTransform.rect.width / 2 * centerDistance) && rectTransform.rect.Contains(localMousePosition))
                if (Vector3.Distance(localMousePosition, center) < radius + (radius * -(centerDistance - 1) * selectGive) && Vector3.Distance(localMousePosition, center) > (radius * centerDistance) - (radius * -(centerDistance - 1) * selectGive))
                {
                    // Calculate the angle between the center of the UI element and the cursor
                    float angle = Mathf.Atan2(localMousePosition.y - center.y, localMousePosition.x - center.x) * Mathf.Rad2Deg;
                    float rotatedAngle = Mathf.Repeat(angle - 90f, 360f) - 180f;

                    // Normalize the angle to a value between 0 and 1
                    float normalizedAngle = rotatedAngle / 360f;
                    normalizedAngle = (normalizedAngle < 0) ? 1f + normalizedAngle : normalizedAngle;
                    normalizedAngle = 1f - normalizedAngle;

                    //if (normalizedAngle > .25f && normalizedAngle < .65f)
                    //    normalizedAngle = .25f;
                    //else if (normalizedAngle > .65f)
                    //    normalizedAngle = 0;

                    if (normalizedAngle > .25f)
                        return;

                    slider.value = normalizedAngle;
                }
            }
        }
    }
}
