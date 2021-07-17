using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    [SerializeField]
    private float Min_X, Max_X;

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x < Min_X)
            tempPos.x = Min_X;

        if (tempPos.x > Max_X)
            tempPos.x = Max_X;



        transform.position = tempPos;
    }
}
