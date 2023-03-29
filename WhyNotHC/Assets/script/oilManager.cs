using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OilManager : MonoBehaviour
{
    public Image bar;//���� ��
    bool landing = false;//���� �ߴ��� ���ߴ���
    public Height he;
    public int score = 0;//���� ����
    public Text sc;//���� ���� �ؽ�Ʈ
    void Update()
    {
        if(landing == false)//���ִٸ� ���� ��´�
            bar.fillAmount -= he.y*0.0003f;
        sc.text = score.ToString("0");
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "building")
        {
            landing = true;
            bar.fillAmount += 0.3f;//�����ϸ� ����ä��
            if (collision.transform.position.z >= -0.4)//���� �󸶳� �߾ӿ� ��������� ���� ���� ��
            {
                if (Vector3.Distance(transform.position, collision.transform.position) <= 1.6f)
                {
                    score += 3;
                }
                else if (Vector3.Distance(transform.position, collision.transform.position) <= 2.5f)
                {
                    score += 2;
                }
                else
                {
                    score += 1;
                }
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
                collision.gameObject.tag = "null building";//�Ȱ��� �������� �ѹ��� ���� ���� �� �ֵ���
            }
        }
    }
}
