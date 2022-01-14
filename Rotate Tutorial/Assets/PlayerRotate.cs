using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] GameObject playerYAxisLine;
    [SerializeField] GameObject targetYAxisLine;
    [SerializeField] Camera playerCamera;
    public Transform target;
    public Vector3 playerRotation;
    public Vector3 targetRotation;
    public Vector3 quaternionAndEulerAngle;
    public float QuaternionSlerpSpeed;
    public bool onLookRotation { get; private set; }
    private bool onAngle;
    private bool onEluerQuaternion;
    private bool onSlerp;

    float toRotationY;
    private void Start()
    {
    }
    
    void Update()
    {
        GetKeyDown();
        if(onLookRotation)
        {
            LookRotation();
        }else if (onAngle)
        {
            Angle();
        }else if (onEluerQuaternion)
        {
            QuaternionAndEulerAngle();
        }else if (onSlerp)
        {
            Slerp();
        }

    }
    public void GetKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(onLookRotation ? onLookRotation = false : onLookRotation = true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(onAngle ? onAngle = false : onAngle = true) ;
        }if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (onEluerQuaternion ? onEluerQuaternion = false : onEluerQuaternion = true) ;
        }if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (onSlerp ? onSlerp = false : onSlerp = true) ;
        }
    }
    public void LookRotation()
    {
        playerYAxisLine.SetActive(false);
        targetYAxisLine.SetActive(false);
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;
        Debug.Log("OnLookRotation");
    }
    public void Angle()
    {
        playerYAxisLine.SetActive(true);
        targetYAxisLine.SetActive(true);
        Quaternion playerRotationQuaternion = Quaternion.Euler(playerRotation);
        Quaternion targetRotationQuaternion = Quaternion.Euler(targetRotation);
        float angle = Quaternion.Angle(playerRotationQuaternion, targetRotationQuaternion);
        transform.rotation = playerRotationQuaternion;
        target.rotation = targetRotationQuaternion;
        Debug.Log(angle);
    }
    public void QuaternionAndEulerAngle()
    {
        Quaternion rotationQuaternion = Quaternion.Euler(quaternionAndEulerAngle);
        Debug.Log(rotationQuaternion);
        Vector3 rotationVector = QuaternionToEuler.FromQ2(rotationQuaternion);
        Debug.Log(rotationVector);
    }
    public void Slerp()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerPosition = transform.position;
        mousePosition.z = playerPosition.y + playerCamera.transform.position.y;
        Vector3 target = playerCamera.ScreenToWorldPoint(mousePosition);
        Vector3 dir = target - playerPosition;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, QuaternionSlerpSpeed);
    }

}

