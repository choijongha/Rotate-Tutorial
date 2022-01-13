using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] GameObject playerYAxisLine;
    [SerializeField] GameObject targetYAxisLine;
    public Transform target;
    public Vector3 playerRotation;
    public Vector3 targetRotation;
    public Vector3 quaternionAndEulerAngle;

    public bool onLookRotation { get; private set; }
    private bool onAngle;
    private bool onEluerQuaternion;
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
}

