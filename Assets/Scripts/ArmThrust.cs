using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ArmThrust : MonoBehaviour, IPointerMoveHandler, IPointerClickHandler
{
    [SerializeField] GameObject arm;
    [SerializeField] UnityEvent<PointerEventData> onPointerClicked;
    [SerializeField] UnityEvent<PointerEventData> onPointerMoved;
    Vector3 currentAngle;

    public void OnPointerClick(PointerEventData eventData) => onPointerClicked?.Invoke(eventData);

    public void OnPointerMove(PointerEventData eventData) => onPointerMoved?.Invoke(eventData);

    public void SetCurrentAngle(float angle) => currentAngle = new(0, 0, angle);

    void Update()
    {
        if (arm == null) return;
        arm.transform.rotation = Quaternion.Euler(currentAngle);
    }

    public void MoveArm(PointerEventData eventData)
    {
        if (arm == null) return;
        Vector2 screenCenter = new(Screen.width / 2, Screen.height / 2);
        float distance = Vector2.Distance(screenCenter, eventData.position);
        float remap = darcproducts.Utils.Remap(distance, 20, 1080, -85, -10);
        currentAngle = new Vector3(0, 0, remap);
    }

}
