using UnityEngine;

public class ObjectTransform : MonoBehaviour
{
    private float rotateSpeed = 0.5f;
    private float zoomSpeed = 0.01f;

    void Update()
    {
        // 1. LOGIC ROTASI (Satu Jari / Klik Kiri Mouse)
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDelta = Input.GetTouch(0).deltaPosition;
            transform.Rotate(0, -touchDelta.x * rotateSpeed, 0, Space.World);
        }
        // Support testing di PC pake mouse klik kanan buat muter
        else if (Input.GetMouseButton(0)) 
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(0, -mouseX * 100, 0, Space.World);
        }

        // 2. LOGIC ZOOM (Dua Jari / Pinch)
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 t0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 t1PrevPos = touch1.position - touch1.deltaPosition;

            float prevMagnitude = (t0PrevPos - t1PrevPos).magnitude;
            float currentMagnitude = (touch0.position - touch1.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            float newScale = transform.localScale.x + (difference * zoomSpeed);
            newScale = Mathf.Clamp(newScale, 0.001f, 0.05f); // Biar nggak kekecilan/kegedean banget

            transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }
}