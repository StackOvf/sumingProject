using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector2 Margin;
    public Vector2 smoothing;
    public BoxCollider2D Bounds;

    private Vector3 _min;
    private Vector3 _max;

    public  bool IsFollowing { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _min = Bounds.bounds.min;
        _max = Bounds.bounds.max;
        IsFollowing = true;

    }

    // Update is called once per frame
    void Update()
    {
        var x = transform.position.x;
        //var y = transform.position.y;
        if (IsFollowing)
        {
            if(Mathf.Abs(x - player.position.x)> Margin.x)
            {
                x = Mathf.Lerp(x, player.position.x, smoothing.x * Time.deltaTime);
            }
            /*if (Mathf.Abs(y - player.position.y) > Margin.y)
            {
                y = Mathf.Lerp(y, player.position.y, smoothing.y * Time.deltaTime);
            }*/
        }
        float orthographicSize = GetComponent<Camera>().orthographicSize;

        var cameraHalfWidth = orthographicSize * ((float)Screen.width / Screen.height);

        x = Mathf.Clamp(x, _min.x + cameraHalfWidth, x - cameraHalfWidth);

        //y = Mathf.Clamp(y, _min.y + orthographicSize, y - orthographicSize);

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
