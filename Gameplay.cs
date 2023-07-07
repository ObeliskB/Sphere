using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay : MonoBehaviour
{
    int score = 0;
    TextMeshProUGUI textScore;
 
    void Start()
    {
        textScore = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                hit.collider.gameObject.SetActive(false);
                if (hit.collider.CompareTag("Red")) score -= 20;
                else if (hit.collider.CompareTag("Green")) score += 20;
                else if (hit.collider.CompareTag("Blue")) score += 10;
            }
        }
        textScore.text = "Score: " + score;
    }
}
