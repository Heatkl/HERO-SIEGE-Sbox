using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public Vector3 coordinateDifference;
    public GameObject _player;
    
    void Update()
    {
        CameraMove();
    }

    protected virtual void CameraMove()
    {
        transform.position = new Vector3(_player.transform.position.x + coordinateDifference.x, _player.transform.position.y + coordinateDifference.y, _player.transform.position.z + coordinateDifference.z);
    }
}
