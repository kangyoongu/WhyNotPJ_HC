using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OilManager : MonoBehaviour
{
    public Image bar;//���� ��
    bool landing = false;//���� �ߴ��� ���ߴ���
    public Height he;
    public int score = 0;//���� ����
    public Text sc;//���� ���� �ؽ�Ʈ
    public int combo = 0;
    public TextMeshProUGUI combo_text;
    ItemSpawn[] item;
    private void Start()
    {
        item = FindObjectsOfType<ItemSpawn>();
    }
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
            
            int rand = Random.Range(0, item.Length);
            item[rand].StartCoroutine("itemSpawning");
            if (collision.transform.position.z >= -0.4)//���� �󸶳� �߾ӿ� ��������� ���� ���� ��
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
                bar.fillAmount += 0.3f * 1 + (combo * 0.1f); //�޺��� ���� ���� ��
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
                collision.gameObject.tag = "null building";//�Ȱ��� �������� �ѹ��� ���� ���� �� �ֵ���
            }
        }
    }
}
