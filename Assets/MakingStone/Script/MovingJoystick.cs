using UnityEngine;
using UnityEngine.EventSystems;

public class MovingJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] RectTransform lever;
    [SerializeField, Range(10f, 150f)] float leverRange = 30f;
    [SerializeField] RectTransform crossHair;
    [SerializeField] float moveSpeed = 100f;

    private RectTransform rectTransform;
    private Vector2 inputVector;
    private bool isInput;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (isInput)
        {
            Vector2 pos = inputVector * moveSpeed * Time.deltaTime;

            crossHair.anchoredPosition += pos;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);  // �߰�
        isInput = true;    // �߰�
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
    }

    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;

        var clampedDir = inputDir.magnitude < leverRange ? inputDir
            : inputDir.normalized * leverRange;
        lever.anchoredPosition = clampedDir;

        inputVector = clampedDir / leverRange;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
    }
}
