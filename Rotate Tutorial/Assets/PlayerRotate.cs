using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public Transform target;
    public bool onLookRotation;
    public bool onAngle;
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
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;
        Debug.Log("OnLookRotation");
    }
    public void Angle()
    {
        float angle = Quaternion.Angle(transform.rotation, target.rotation);
        Debug.Log(angle);
    }
}

