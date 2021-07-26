using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecticleCtrl : MonoBehaviour
{
    public Image recticle;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit; //�������� �ε�ġ�� �ְ� hit�� ����.

        if(Physics.Raycast(ray,out hit,800))
        {
            recticle.fillAmount += Time.deltaTime;

           

            if(recticle.fillAmount == 1)
            {
                if (hit.transform.tag == "START")
                {
                    SceneManager.LoadScene("Main1");
                }
                else if (hit.transform.CompareTag("CREDIT")) // compareTag �±׸� ���Ѵ�. ���� ��������� �̰� �� ���־� �κ���
                {
                }
               
            }

        }

     

        //               ������, ���� * ���� , �÷� ,�����ð�
        Debug.DrawRay(ray.origin, ray.direction * 800f, Color.red, 0.5f);
    }
}
