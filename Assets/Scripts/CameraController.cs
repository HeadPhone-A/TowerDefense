using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] float zoomSpeed = 30f;
    [SerializeField] float zoomMax = 25f;
    [SerializeField] float zoomMin = 55f;

    [SerializeField] float maxPosX = 20f;
    [SerializeField] float minPosX = -20f;
    [SerializeField] float maxPosZ = 15f;
    [SerializeField] float minPosZ = -50f;

    private void CameraZoom()
    {
        float zoomDirection = Input.GetAxis("Mouse ScrollWheel");

        if (transform.position.y <= zoomMax && zoomDirection > 0)
        {
            return;
        }

        if (transform.position.y >= zoomMin && zoomDirection < 0)
        {
            return;
        }

        transform.position += Vector3.down * zoomDirection * zoomSpeed;
    }

    private void CameraMove()
    {
        if (Input.GetMouseButton(2))
        {
            float posX = Input.GetAxis("Mouse X");
            float posZ = Input.GetAxis("Mouse Y");

            transform.position += new Vector3(-posX, 0, -posZ);

            if (transform.position.x <= minPosX) transform.position = new Vector3(minPosX, transform.position.y, transform.position.z);
            if (transform.position.x >= maxPosX) transform.position = new Vector3(maxPosX, transform.position.y, transform.position.z);
            if (transform.position.z <= minPosZ) transform.position = new Vector3(transform.position.x, transform.position.y, minPosZ);
            if (transform.position.z >= maxPosZ) transform.position = new Vector3(transform.position.x, transform.position.y, maxPosZ);
        }
    }

    private void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        CameraZoom();
        CameraMove();
    }
}
