using UnityEngine;

public class HandScroll : MonoBehaviour
{

    private Vector3 currPos;
    private void Update()
    {
        //currPos = transform.localEulerAngles.z;

        if(transform.localEulerAngles.x > 70 && transform.localEulerAngles.y < 180)
        {
            transform.localEulerAngles = new Vector3(0, 69, 0 );
        }

        if (transform.localEulerAngles.x < 290 && transform.localEulerAngles.y > 180)
        {
            transform.localEulerAngles = new Vector3(0, -69, 0);
        }
    }
}
