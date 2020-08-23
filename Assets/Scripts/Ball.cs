using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float Yvalue = 2;
    public float zDepth;
    public float moveTime;
    private bool col = false;
    private Vector3 mousePos;
    private Vector3 referent;
    public bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator MoveForward()
    {
        transform.DOMoveZ(transform.position.z + zDepth, moveTime);
        transform.DOMoveY(0, moveTime);
        yield return new WaitForSeconds(moveTime);
        if (col == false)
            GameManager.singleton.Restart();
        transform.DOMoveZ(transform.position.z + zDepth, moveTime);
        transform.DOMoveY(Yvalue, moveTime);
        yield return new WaitForSeconds(moveTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (stop == true)
        {
            DOTween.Clear();
            return;
        }
        if (transform.position.y == Yvalue)
            StartCoroutine(MoveForward());
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = transform.position.z - Camera.main.transform.position.z;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            referent = mousePos;
        }
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = transform.position.z - Camera.main.transform.position.z;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = new Vector3( mousePos.x - referent.x, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        col = true;
        GameManager.singleton.totalScore += GameManager.singleton.scoreValue;
        if (other.tag == "Finish")
            stop = true;
    }
    private void OnTriggerExit(Collider other)
    {
        col = false;
    }
    
}
