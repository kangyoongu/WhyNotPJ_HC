using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OilManager : MonoBehaviour//게임 충돌, 점수, 오일 관리
{
    public Image bar;//오일 바
    bool landing = false;//착륙 했는지 안했는지
    public Height he;
    public int score = 0;//게임 점수
    public Text sc;//게임 점수 텍스트
    public int combo = 0;
    public TextMeshProUGUI combo_text;
    void Update()
    {
        if(landing == false)//떠있다면 오일 깎는다
            bar.fillAmount -= he.y*0.0003f;
        sc.text = score.ToString("0");
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "building")
        {
            landing = true;
            if (collision.transform.position.z >= -0.4)//착륙 얼마나 중앙에 가까운지에 따라 점수 줌
            {
                if (Vector3.Distance(transform.position, collision.transform.position) <= 1.6f)
                {
                    score += 3;
                    combo += 1;
                    if (combo % 5 == 0)
                    {
                        score += 1;
                    }
                    combo_text.text = combo.ToString() + " combo";
                }
                else if (Vector3.Distance(transform.position, collision.transform.position) <= 2.5f)
                {
                    score += 2;
                    combo = 0;
                    combo_text.text = "";
                }
                else
                {
                    score += 1;
                    combo = 0;
                    combo_text.text = "";
                }
            }
            if (combo <= 7)
            {
                bar.fillAmount += 0.3f * 1 + (combo * 0.1f); //콤보에 따라 연료 줌
            }
            else
            {
                bar.fillAmount += 0.54f;
            }
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "building")
        {
            landing = false;
            if (collision.transform.position.z >= -0.4)
            {
                collision.gameObject.tag = "null building";//똑같은 빌딩에선 한번만 연료 넣을 수 있도록
            }
        }
    }
}
