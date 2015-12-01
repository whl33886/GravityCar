using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour
{

    private ForwardWheel[] mForwardWheel;
    private Backwheel[] mBackwheel;
    public float forward = 0.5f;
    public float turn = 0.1f;
    public static bool canTurn = false;
    public static bool canMove = false;
    [Range(-0.5f, 0.5f)]
    public float inputK = 0f;
    //  private WheelTop[] mWheelTop;
    void Start()
    {
        mForwardWheel = GetComponentsInChildren<ForwardWheel>();
        mBackwheel = GetComponentsInChildren<Backwheel>();
        //  mWheelTop = GetComponentsInChildren<WheelTop>();

    }

    void Update()
    {
#if !UNITY_EDITOR
        
        inputK =Mathf.Clamp(Input.acceleration.x*2,-0.5f,0.5f);
#endif
        //Debug.Log("KK");
        canMove = false;
        canTurn = false;
        if (Input.GetKey(KeyCode.W))
        {
            // Debug.Log("Accent:");
            canMove = true;
            mForwardWheel[0].ProRotate(forward);
            mForwardWheel[1].ProRotate(forward);

            mBackwheel[0].ProRotate(forward);
            mBackwheel[1].ProRotate(forward);

        }
        if (Input.GetKey(KeyCode.S))
        {
            canMove = true;
            mForwardWheel[0].ProRotate(-forward);
            mForwardWheel[1].ProRotate(-forward);

            mBackwheel[0].ProRotate(-forward);
            mBackwheel[1].ProRotate(-forward);
        }

        mForwardWheel[0].ProTurnG(inputK);
        mForwardWheel[1].ProTurnG(inputK);
        inputK -= inputK * 0.02f;
        if (Input.GetKey(KeyCode.A))
        {
            canTurn = true;
            mForwardWheel[0].ProTurn(-turn);
            mForwardWheel[1].ProTurn(-turn);

        }
        if (Input.GetKey(KeyCode.D))
        {
            canTurn = true;
            mForwardWheel[0].ProTurn(turn);
            mForwardWheel[1].ProTurn(turn);

        }
    }


    void OnGUI()
    {
        if (GUI.RepeatButton(new Rect(30, Screen.height * 0.8f, 100, 60), "加速"))
        {
            canMove = true;
            mForwardWheel[0].ProRotate(forward);
            mForwardWheel[1].ProRotate(forward);

            mBackwheel[0].ProRotate(forward);
            mBackwheel[1].ProRotate(forward);
        }
        if (GUI.RepeatButton(new Rect(Screen.width - 130, Screen.height * 0.8f, 100, 60), "减速"))
        {
            canMove = true;
            mForwardWheel[0].ProRotate(-forward);
            mForwardWheel[1].ProRotate(-forward);

            mBackwheel[0].ProRotate(-forward);
            mBackwheel[1].ProRotate(-forward);
        }
        GUI.Label(new Rect(Screen.width * 0.5f - 40, 70, 80, 40), CarController.instance.curSpeed + " KM/h");
#if UNITY_EDITOR
        inputK = GUI.HorizontalSlider(new Rect(Screen.width * 0.5f - 100, Screen.height - 30, 200, 20), inputK, -0.5f, 0.5f);
#endif
    }

}