using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Script Parameters
    public float PanSpeed = 30f;
    public float ScreenBorder = 10f;
    public float ScrollSpeed = 5f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;
    #endregion
    #region Fields
    private bool lockCamera = false;
    #endregion

    #region Unity Methods
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            lockCamera = !lockCamera;

        if (lockCamera)
            return;

        if(transform.position.z <= maxZ && (Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height - ScreenBorder))
        {
            transform.Translate(Vector3.forward * PanSpeed * Time.deltaTime, Space.World);
        }

        if (transform.position.z >= minZ && (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= ScreenBorder))
        {
            transform.Translate(Vector3.back * PanSpeed * Time.deltaTime, Space.World);
        }

        if (transform.position.x <= maxX &&  (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - ScreenBorder))
        {
            transform.Translate(Vector3.right * PanSpeed * Time.deltaTime, Space.World);
        }

        if (transform.position.x >= minX && (Input.GetKey(KeyCode.Q) || Input.mousePosition.x <= ScreenBorder))
        {
            transform.Translate(Vector3.left * PanSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 700 * ScrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
    #endregion
}
