using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float panSped = 30f;
    [SerializeField] float zoomSpeed = 5f;
    [SerializeField] float minY = 10f;
    [SerializeField] float maxY = 80f;

    private void Update()
    {
        WhichKey();
        ZoomCamera();
    }
    void ZoomCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * zoomSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
    void WhichKey()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * panSped * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * panSped * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * panSped * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * panSped * Time.deltaTime, Space.World);
    }
}