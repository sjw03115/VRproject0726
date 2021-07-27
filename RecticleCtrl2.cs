using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecticleCtrl2 : MonoBehaviour
{
    public Image recticle;
    public Text time;

    public GameObject replay;

    public GameObject bunny;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 20)) //������ �ε�ġ�°� ���� ��
        {


            if (hit.transform.CompareTag("ARROW"))
            {
                recticle.fillAmount += Time.deltaTime;
                if (recticle.fillAmount == 1)
                {
                    Camera.main.transform.position = hit.transform.position
                        + new Vector3(0.1f, 2.9f, 0);
                }
            }

            else if (hit.transform.tag == "TREASURE") //������
            {
                recticle.fillAmount += Time.deltaTime;
                if (recticle.fillAmount == 1)
                {
                    time.text = ((int)Time.time).ToString();
                    hit.transform.GetComponent<BoxCollider>().enabled = false;
                    replay.SetActive(true);
                }
            }

            else if (hit.transform.tag == "HOME")
            {
                recticle.fillAmount += Time.deltaTime;
                if (recticle.fillAmount == 1)
                {
                    SceneManager.LoadScene("Menu2");
                }
            }

            else if (hit.transform.tag == "BUNNY")
            {
                bunny.GetComponent<BunnyCtrl>().enabled = false;
            }

            else
            {
                recticle.fillAmount = 0;
            }


        }

        else //����� ��, �ε�ġ�°� ������
        {
            bunny.GetComponent<BunnyCtrl>().enabled = true;
            recticle.fillAmount = 0;
        }

        //            ������         ����   * ����      �÷�      �����ð�
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 0.5f);
    }
}
