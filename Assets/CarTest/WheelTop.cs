using UnityEngine;
using System.Collections;

public class WheelTop : MonoBehaviour
{
    public Transform mTransform;
    public ForwardWheel mForwardWheel;
    private Vector3 curT = Vector3.zero;
    void Start()
    {
        mTransform = transform;
    }

    void Update()
    {

        curT.y = mForwardWheel.curT.y;
        mTransform.localEulerAngles = curT;
    }

}
