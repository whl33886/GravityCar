
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public CarController car;
    private Transform mTransform;
    public Vector3 position = new Vector3(0, 15f, -10f);
    public Vector3 rotation = new Vector3(10, 0f, 0f);

    void Start()
    {
        mTransform = transform;
        position = mTransform.position;
        rotation = mTransform.eulerAngles;
        car = CarController.instance;
    }
    void LateUpdate()
    {
        if (car)
        {
            //rotation = car.mTransform.eulerAngles;
            rotation.y = -car.ratio;
            //mTransform.localEulerAngles = rotation;
            // position.x = 3 * Mathf.Sin(car.curR.y / Mathf.Rad2Deg);
            mTransform.localPosition = car.mTransform.position + position;
        }
    }
}
