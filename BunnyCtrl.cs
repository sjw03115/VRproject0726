using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BunnyCtrl : MonoBehaviour
{
    // Start is called before the first frame update

    //public Transform target; // 따라갈 타겟의 트랜스 폼

    //private float relativeHeigth = -0.5f; // 높이 즉 y값
    //private float zDistance = -1.0f;// z값 나는 사실 필요 없었다.
    //private float xDistance = 1.0f; // x값
    //public float dampSpeed = 0.001f;  // 따라가는 속도 짧으면 타겟과 같이 움직인다.


    //void Start()
    //{

    //    // 타겟의 트랜스 폼을 가져 왔으면.. 변수에 담는 것이 옳으나.. 좀 헤깔려셔 패스

    //}

    //void Update()
    //{

    //    Vector3 newPos = target.position + new Vector3(xDistance, relativeHeigth, -zDistance); // 타겟 포지선에 해당 위치를 더해.. 즉 타겟 주변에 위치할 위치를 담는다.. 일정의 거리를 구하는 방법
    //    transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed); //그 둘 사이의 값을 더해 보정한다. 이렇게 되면 멀어지면 따라간다.
    //}


    //public string _targetName = "Cube";

    public Transform target; 

    private float dampSpeed = 0.4f;  // 따라가는 속도





    // Update is called once per frame

    void Update()
    {
        FollowTarget();

    }

        private void OnCollisionEnter(Collision collision)

        {
            if (collision.transform.tag == "PLAYER")

            {

                SceneManager.LoadScene("End");
            }


        }



    public void FollowTarget()

    {

        // Gets a vector that points from the player's position to the target's.

        var heading = target.position - this.transform.position;



        // 거리가 멀어지면 실행

        if (heading.sqrMagnitude > 0)

        {

            // Target is within range.

            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * dampSpeed);



        }

        // 방향을 봄

        transform.LookAt(target);

    }

}

