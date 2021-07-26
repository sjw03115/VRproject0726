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
        RaycastHit hit; //레이저가 부딪치는 애가 hit로 들어간다.

        if(Physics.Raycast(ray,out hit,800))
        {
            recticle.fillAmount += Time.deltaTime;

           

            if(recticle.fillAmount == 1)
            {
                if (hit.transform.tag == "START")
                {
                    SceneManager.LoadScene("Main1");
                }
                else if (hit.transform.CompareTag("CREDIT")) // compareTag 태그를 비교한다. 같은 기능이지만 이걸 더 자주씀 훨빠름
                {
                }
               
            }

        }

     

        //               시작점, 방향 * 길이 , 컬러 ,잔존시간
        Debug.DrawRay(ray.origin, ray.direction * 800f, Color.red, 0.5f);
    }
}
