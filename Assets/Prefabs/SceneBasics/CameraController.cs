using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public static CameraController Instance;


    public Transform targetLookAt;
    public float startDistance = 40f;
    public float distance = 5f;
    public float distanceMin = 3f;
    public float distanceMax = 10f;
    public float distanceSmooth = 0.05f;
    public float XInputSensitivity = 5f;
    public float YInputSensitivity = 5f;
    public float ZInputSensitivity = 5f;
    public float XSmooth = 0.05f;
    public float YSmooth = 0.1f;
    public float YMinLimit = -40f;
    public float YMaxLimit = 80f;
    public float yOffset = 2;

    public float horizontalX = 0f;
    public float verticalY = 0f;

    private float velX = 0f;
    private float velY = 0f;
    private float velZ = 0f;
    private float velDistance = 0f;
    private Vector3 position = Vector3.zero;
    private Vector3 desiredPosition = Vector3.zero;
    private float desiredDistance = 0f;

    void Awake()
    {
        Instance = this;
        if (targetLookAt == null)
            print("targetLookAt in null on Main Camera");
    }

    void Start()
    {
        distance = Mathf.Clamp(distance, distanceMin, distanceMax);
        Reset();
    }

    void LateUpdate()
    {
        HandlePlayerInput();

        CalculateDesiredPosition();

        UpdatePosition();
    }

    void HandlePlayerInput()
    {
        //Cursor.lockState = CursorLockMode.Locked;

        var deadZone = 0.05f;

        //take input for revolving around target from right analog of controller and from mouse
        horizontalX += (Input.GetAxis("Controller1HorizontalR") + Input.GetAxis("Mouse X")) * XInputSensitivity;

		float x = Camera.main.transform.localEulerAngles.x;

		//cam down
		if(Input.GetAxis ("Controller1VerticalR") > 0 && !(250 < x && x < 280))
			verticalY -= Input.GetAxis ("Controller1VerticalR") * YInputSensitivity;
		//cam up
		if(Input.GetAxis ("Controller1VerticalR") < 0 && !(60 < x && x < 90))
			verticalY -= Input.GetAxis ("Controller1VerticalR") * YInputSensitivity;
        

        if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > deadZone)
        {
            desiredDistance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * ZInputSensitivity, distanceMin, distanceMax);
        }
    }

    void CalculateDesiredPosition()
    {
        distance = Mathf.SmoothDamp(distance, desiredDistance, ref velDistance, distanceSmooth);

        desiredPosition = CalculatePosition(verticalY, horizontalX, distance);
    }

    Vector3 CalculatePosition(float rotationX, float rotationY, float distance)
    {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        return targetLookAt.position + rotation * direction;
    }

    void UpdatePosition()
    {
        var posX = Mathf.SmoothDamp(position.x, desiredPosition.x, ref velX, XSmooth);
        var posY = Mathf.SmoothDamp(position.y, desiredPosition.y, ref velY, YSmooth);
        var posZ = Mathf.SmoothDamp(position.z, desiredPosition.z, ref velZ, XSmooth);
        position = new Vector3(posX, posY, posZ);

        transform.position = position;

        transform.LookAt(targetLookAt.transform.position + new Vector3(0, yOffset, 0));
    }

    public void Reset()
    {
        //for orthographic
        distance = startDistance;
        desiredDistance = distance;
    }

}