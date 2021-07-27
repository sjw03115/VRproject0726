using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BunnyCtrl : MonoBehaviour
{
    // Start is called before the first frame update

    //public Transform target; // ���� Ÿ���� Ʈ���� ��

    //private float relativeHeigth = -0.5f; // ���� �� y��
    //private float zDistance = -1.0f;// z�� ���� ��� �ʿ� ������.
    //private float xDistance = 1.0f; // x��
    //public float dampSpeed = 0.001f;  // ���󰡴� �ӵ� ª���� Ÿ�ٰ� ���� �����δ�.


    //void Start()
    //{

    //    // Ÿ���� Ʈ���� ���� ���� ������.. ������ ��� ���� ������.. �� ������ �н�

    //}

    //void Update()
    //{

    //    Vector3 newPos = target.position + new Vector3(xDistance, relativeHeigth, -zDistance); // Ÿ�� �������� �ش� ��ġ�� ����.. �� Ÿ�� �ֺ��� ��ġ�� ��ġ�� ��´�.. ������ �Ÿ��� ���ϴ� ���
    //    transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed); //�� �� ������ ���� ���� �����Ѵ�. �̷��� �Ǹ� �־����� ���󰣴�.
    //}


    //public string _targetName = "Cube";

    public Transform target; 

    private float dampSpeed = 0.4f;  // ���󰡴� �ӵ�





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



        // �Ÿ��� �־����� ����

        if (heading.sqrMagnitude > 0)

        {

            // Target is within range.

            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * dampSpeed);



        }

        // ������ ��

        transform.LookAt(target);

    }

}

