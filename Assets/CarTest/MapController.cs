using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour
{

    private Transform mTransform;
    public float dis = 0;
    public GameObject itemPrefab;
    private Transform[] itemsInst = new Transform[100];
    private Vector3 itemP = Vector3.zero;
    private Vector3 itemS = Vector3.zero;

    void Start()
    {
        mTransform = transform;
        if (itemPrefab)
            for (int i = 0; i < 100; i++)
            {

                itemS.x = Random.Range(5f, 15f) / 122;
                itemS.y = Random.Range(20, 80);
                itemS.z = Random.Range(4f, 10) / 122;
                itemP.x = Random.Range(-500, 500);
                itemP.z = Random.Range(-500, 500);
                itemP.y = itemS.y * 0.5f;
                itemsInst[i] = Instantiate(itemPrefab).transform;
                itemsInst[i].parent = mTransform;
                itemsInst[i].position = itemP;
                itemsInst[i].localScale = itemS;
            }
    }

    // Update is called once per frame
    void Update()
    {

        if (CarController.instance)
        {
            dis = Vector3.Distance(CarController.instance.mTransform.position, mTransform.position);
            if (dis > 400)
            {
                mTransform.position = CarController.instance.mTransform.position - new Vector3(0, 0.05f, 0);
            }
        }
    }
}
