using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public Transform target;
    public bool onLookRotation;
    public bool angle;
    void Update()
    {
        GetKeyDown();
        if (onLookRotation)
        {
            LookRotation();
        }

    }
    public void GetKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !onLookRotation)
        {
            onLookRotation = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && onLookRotation)
        {
            onLookRotation = false;
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
    }
}

