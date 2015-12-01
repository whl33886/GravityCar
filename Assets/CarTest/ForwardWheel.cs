using UnityEngine;
using System.Collections;

public class ForwardWheel : MonoBehaviour
{
    private Vector3 curR = Vector3.zero;
    private Transform mTransform;
    public Vector3 curT = Vector3.zero;
    private float maxAngle = 35;
    private float curTySpeed = 0;
    private float curTxSpeed = 0;
    private CarController mCarControl;

    // Use this for initialization
    void Start()
    {
        mTransform = transform;
        mCarControl = this.GetComponentInParent<CarController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(curT.y) <= maxAngle || curTySpeed * curT.y < 0)
        {
            curT.y += curTySpeed * Time.deltaTime;
        }
        else
        {
            curT.y = Mathf.Sign(curT.y) * maxAngle;
            curTySpeed = 0;
        }
        if (!UserInput.canTurn && curT.y != 0)
        {
            curTySpeed = 0;
            curT.y -= (curT.y) * curTxSpeed * 0.05f * Time.deltaTime;
            if (Mathf.Abs(curT.y) < 0.5f)
            {
                curT.y = 0;
            }
        }
        curT.x += curTxSpeed * 100 * Time.deltaTime;
        mTransform.localEulerAngles = curT;
        mCarControl.ProTurn(curT.y * curTxSpeed * 0.1f *Mathf.Abs( Mathf.Sin((curT.y) / Mathf.Rad2Deg)));
        mCarControl.ProRatio(curT);
    }

    internal void ProRotate(float p)
    {

        curTxSpeed += p;
        if (curTxSpeed > 50)
            curTxSpeed = 50;
        if (curTxSpeed < -10)
            curTxSpeed = -10;

    }

    internal void ProTurn(float p)
    {
        curTySpeed += p;

    }

    internal void ProTurnG(float p)
    {
        curT.y = p * Mathf.Rad2Deg;
    }
}
