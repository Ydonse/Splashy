using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public GameObject ball;
    public GameObject scoreMesh;
    public  int totalScore = 0;
    public int scoreValue = 1;
    private void Awake()
    {
        if (singleton != null && singleton != this)
            Destroy(gameObject);
        else
            singleton = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void DisplayScore ()
    {
        GameObject txt = Instantiate(scoreMesh, new Vector3(ball.transform.position.x + 5, ball.transform.position.y, ball.transform.position.z - 5), Quaternion.identity);
        txt.GetComponent<TextMeshProUGUI>().text = "+ " + scoreValue.ToString();
    }
    public void Restart()
    {
        DOTween.Clear();
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
