using UnityEngine;

public enum GrindingSpeed {
    fast,
    slow,
    perfect,
    none
}

public class StoneControl : MonoBehaviour
{
    [SerializeField] float fastGrindingVal = 10f;
    [SerializeField] float slowGrindingVal = 2.5f;

    ParticleSystem grindingParticle;

    bool isClicked = false;
    Vector3 mousePosition;
    GrindingSpeed currentSpeed = GrindingSpeed.none;

    void Start()
    {
        grindingParticle = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if(isClicked) // ���� Ŭ���Ǹ�
        {
            ProcessGrinding();
            Debug.Log(currentSpeed);
        }
        else
        {
            currentSpeed = GrindingSpeed.none;
        }
    }

    void ProcessGrinding()
    {
        RaycastHit hit;
        var emissionModule = grindingParticle.emission;

        if (Physics.Raycast(gameObject.transform.position, Vector3.forward, out hit, 1000)) // ������ z������ ������ �߻�
        {
            if (hit.transform.gameObject.name == "Tool_Grinding_Plate") // ���� �� ���� ������쿡��
            {
                Vector3 mouseDiff = GetMouseDiff();

                emissionModule.enabled = true;
                mousePosition = Input.mousePosition;

                DetectGrindingSpeed(mouseDiff); // ���� �ӵ� �Ǻ�
            }
        }
        else
        {
            emissionModule.enabled = false;
            currentSpeed = GrindingSpeed.none;
            return;
        }
    }

    public GrindingSpeed GetCurrentSpeed()
    {
        return currentSpeed;
    }

    void DetectGrindingSpeed(Vector3 mouseDiff)
    {
        if (mouseDiff.x > fastGrindingVal || mouseDiff.y > fastGrindingVal)
        {
            currentSpeed = GrindingSpeed.fast;
        }
        else if (mouseDiff.x < slowGrindingVal || mouseDiff.y < slowGrindingVal)
        {
            currentSpeed = GrindingSpeed.slow;
        }
        else
        {
            currentSpeed = GrindingSpeed.perfect;
        }
    }

    Vector3 GetMouseDiff()
    {
        float mouseDiffX;
        float mouseDiffY;

        mouseDiffX = Mathf.Abs(mousePosition.x - Input.mousePosition.x);
        mouseDiffY = Mathf.Abs(mousePosition.y - Input.mousePosition.y);

        return new Vector3(mouseDiffX, mouseDiffY, 0);
    }

    void OnMouseDown()
    {
        isClicked = true;
        mousePosition = Input.mousePosition;
    }

    void OnMouseUp()
    {
        isClicked = false;
    }

    void OnMouseDrag()
    {
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = objPos;
    }
}
