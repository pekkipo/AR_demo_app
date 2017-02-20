using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FurnitureBehaviour : MonoBehaviour {

    private Vector3 startposition;
    private Vector3 startscale;
    private Quaternion startrotation;

    void Start()
    {
        // transform.position = new Vector3(0, 0, -0.1f);
        startposition = transform.position;
        startscale = transform.localScale;
        startrotation = transform.rotation;

    }

    void Adjust_Size(float[] values)
    {
        transform.localScale = new Vector3(1f * values[0], 1f * values[1], 1f * values[2]);
    }

    public void Restore_Defaults()
    {
        transform.position = startposition;
        transform.localScale = startscale;
        transform.rotation = startrotation;

    }
}
