using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] GameObject playerYAxisLine;
    [SerializeField] GameObject targetYAxisLine;

    public Transform target;
    public bool onLookRotation;
    public bool onAngle;
    public Vector3 playerRotation;
    public Vector3 targetRotation;
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
}

