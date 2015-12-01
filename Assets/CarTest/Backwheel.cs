using UnityEngine;
using System.Collections;

public class Backwheel : MonoBehaviour
{

    private Transform mTransform;
    private CarController mCarControl;
    private Vector3 curR = Vector3.zero;
    private float maxAngle = 30;
    private float curRxSpeed = 0;

    // Use this for initialization
    void Start()
    {
        mTransform = transform;
        mCarControl = this.GetComponentInParent<CarController>();
    }

    void Update()
    {
        curR.x += curRxSpeed * 100 * Time.deltaTime;
        mTransform.localEulerAngles = curR;
        mCarControl.ProMove(curRxSpeed);
    }

    internal void ProRotate(float p)
    {
        curRxSpeed += p;
        if (curRxSpeed > 50)
            curRxSpeed = 50;
        if (curRxSpeed < -10)
            curRxSpeed = -10;

    }
}
