using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteManager : MonoBehaviour
{

    public Transform feildPosition;
    public GameObject cameraFeild;
    public GameObject[] prifab;
    public int time;
    public int countMeteorite;
    public float offsetBorder;
    public float k;

    public List<GameObject> meteorite;
    public int countLoadingMeteorite;
    public int timer;



    void Start()
    {
        meteorite = new List<GameObject>();
        countLoadingMeteorite = countMeteorite;
        if (countMeteorite != 0)
        {
            for (int x = 0; x < 1 + countMeteorite / 2; x++)
            {
                createMeteorite();
            }
        }
        timer = time;

    }

    void Update()
    {
        clampedMeteorite();
        createMeteoriteInTime();
    }

    public void clampedMeteorite()
    {
        Vector3 sizeCamera = cameraFeild.GetComponent<SpriteRenderer>().bounds.size;
        Vector3 cameraPos = feildPosition.transform.position + new Vector3(-sizeCamera.x / 2, sizeCamera.y / 2);
        int kPos = 2;
        for (int x = 0; x < meteorite.Count; x++)
        {
            if (meteorite[x] != null)
            {
                Vector2 mPos = meteorite[x].transform.position;
                if (mPos.x < cameraPos.x - offsetBorder - kPos)
                {
                    saveMeteorite(x);
                }
                else if (mPos.x > cameraPos.x + sizeCamera.x + offsetBorder + kPos)
                {
                    saveMeteorite(x);
                }
                else if (mPos.y > offsetBorder + kPos)
                {
                    saveMeteorite(x);
                }
                else if (mPos.y < -sizeCamera.y - offsetBorder - kPos)
                {
                    saveMeteorite(x);
                }
            }
        }
    }

    public void createMeteoriteInTime()
    {
        timer--;
        if(timer < 0)
        {
            if (countLoadingMeteorite > 0)
            {
                createMeteorite();
                timer = time;
            }
        }
    }

    public void saveMeteorite(int id)
    {
        Destroy(meteorite[id]);
        meteorite.Remove(meteorite[id]);
        countLoadingMeteorite++;
    }

    public void createMeteorite()
    {
        Vector3 sizeCamera = cameraFeild.GetComponent<SpriteRenderer>().bounds.size;
        Vector3 cameraPos = feildPosition.transform.position + new Vector3(-sizeCamera.x / 2, sizeCamera.y / 2);

        int side = Random.Range(0, 4);

        float offsetPosX = 0;
        float offsetPosY = 0;

        if(side == 0) //Вверх
        {
            offsetPosX = Random.Range(0, sizeCamera.x);
            offsetPosY = Random.Range(offsetBorder / k, offsetBorder);
        }
        else if(side == 1) //Право
        {
            offsetPosX = Random.Range(sizeCamera.x + offsetBorder / k, sizeCamera.x + offsetBorder);
            offsetPosY = Random.Range(-sizeCamera.y, 0);
        }
        else if (side == 2) //Низ
        {
            offsetPosX = Random.Range(0, sizeCamera.x);
            offsetPosY = Random.Range(-sizeCamera.y - offsetBorder, -sizeCamera.y - (offsetBorder / k));
        }
        else if (side == 3) //Лево
        {
            offsetPosX = Random.Range(-offsetBorder, -offsetBorder / k);
            offsetPosY = Random.Range(-sizeCamera.y, 0);
        }

        Vector3 meteoritePos = cameraPos + new Vector3(offsetPosX, offsetPosY);
        meteoritePos = new Vector3(meteoritePos.x, meteoritePos.y, 0);

        int prifabId = Random.Range(0, prifab.Length);

        GameObject obj = prifab[prifabId];

        meteorite.Add(Instantiate(obj, meteoritePos, new Quaternion(0, 0, Random.Range(0, 360), 0)));
        int countCreatedMeteorite = meteorite.Count - 1;
        Meteorite meteoriteComponent = meteorite[countCreatedMeteorite].GetComponent<Meteorite>();
        float speedMeteorite = Random.Range(meteoriteComponent.minSpeed, meteoriteComponent.maxSpeed);

        Vector3 mPos = new Vector3(meteorite[countCreatedMeteorite].transform.position.x, meteorite[countCreatedMeteorite].transform.position.y, 0);
        Vector3 pointInFeild =  cameraPos + new Vector3(Random.Range(0, sizeCamera.x), -Random.Range(0, sizeCamera.y), 0);
        Vector3 direction = (pointInFeild - mPos).normalized;

        meteorite[countCreatedMeteorite].GetComponent<Rigidbody2D>().velocity = direction * speedMeteorite;
        countCreatedMeteorite++;
        countLoadingMeteorite--;

        if(countCreatedMeteorite >= countMeteorite)
        {
            countCreatedMeteorite = 0;
        }
    }


}
