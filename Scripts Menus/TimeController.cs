using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] private TextMeshProUGUI tiempo;
    private float restante;
    private bool enMarcha;
    public GameObject gameover;

    private void Awake ()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        restante = (min * 60) + seg;
        enMarcha = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enMarcha)
        {
            restante -= Time.deltaTime;
            if(restante < 1)
            {
                enMarcha = true;
                gameover.SetActive(true);
            }

            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(min % 60);
            tiempo.text = string.Format("{01:00}:{01:00}", tempMin, tempSeg);
        }
    }
}
