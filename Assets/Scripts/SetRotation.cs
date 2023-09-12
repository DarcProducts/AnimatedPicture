using UnityEngine;

public class SetRotation : MonoBehaviour
{
    [SerializeField] Transform targetTransform;

    public void SetTargetRotation(float newRot)
    {
        if (targetTransform == null) return;
        targetTransform.eulerAngles = new(targetTransform.eulerAngles.x, targetTransform.eulerAngles.y, newRot);
    }
}
