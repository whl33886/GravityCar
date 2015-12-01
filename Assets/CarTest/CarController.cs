using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
    public static CarController instance = null;
    public Transform carBody;
    private float drag = 3f;
    private float maxAngle = 30;
    public float curFSpeed = 0;
    public float curTSpeed = 0;
    private float curASpeed = 0;
    public float curSpeed = 0;
    public Transform mTransform;
    private Vector3 curP = Vector3.zero;
    public Vector3 curR = Vector3.zero;
    public float ratio = 0;

    void Awake()
    {
        if (!instance)
            instance = this;
    }
    void Destroy()
    {
        if (instance)
            Destroy(instance);
    }
    void Start()
    {
        mTransform = transform;
    }




    internal void ProMove(float curRxSpeed)
    {

        curSpeed = curRxSpeed * Mathf.Cos((ratio) / Mathf.Rad2Deg);
        curFSpeed = (curSpeed * Mathf.Cos((/*ratio * 1.8f +*/ curR.y) / Mathf.Rad2Deg) /** Mathf.Cos((ratio) / Mathf.Rad2Deg)*/);
        curP.z += curFSpeed * Time.deltaTime;
        curTSpeed = (curSpeed * Mathf.Sin((/*ratio * 1.8f +*/ curR.y) / Mathf.Rad2Deg)/* * Mathf.Sin((ratio) / Mathf.Rad2Deg)*/);
        curP.x += curTSpeed * Time.deltaTime;
        mTransform.position = curP;

    }
    private Vector3 carBodyR;
    internal void ProTurn(float p)
    {
        curR.y += p * Time.deltaTime;
        //         if (Mathf.Abs(curR.y) > 30)
        //         {
        //             curR.y = Mathf.Sign(curR.y) * 30;
        //         }
        mTransform.eulerAngles = curR;
        carBodyR.x = -Mathf.Abs(ratio * 0.13f);
        carBodyR.z = ratio * 0.13f;
        carBody.localEulerAngles = carBodyR;
    }

    internal void ProRatio(Vector3 vector3)
    {
        ratio = vector3.y;
    }
}