using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    private GameObject scoreManager;
    public bool isHidden = true;
    public SpriteRenderer sprite;
    public Coroutine ShowMoleCorroutine;
    public static Color[] colorList = new Color[3];

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager");
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        DetectHit();
    }
    void DetectHit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(mousePos.x,mousePos.y,-10f), Vector3.forward);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                StopCoroutine(ShowMole());

                //cambiar posicion directamente

                if (sprite.color == colorList[0])
                {
                    scoreManager.GetComponent<ScoreManager>().score += -10;
                }
                else if (sprite.color == colorList[1])
                {
                    scoreManager.GetComponent<ScoreManager>().score += 10;
                }
                else if (sprite.color == colorList[2])
                {
                    scoreManager.GetComponent<ScoreManager>().score += 20;
                }
            }
        }
    }
    public IEnumerator ShowMole()
    {
        sprite.color = colorList[Random.Range(0, colorList.Length)];
        isHidden = false;

        float TotalTime = 0.5f;
        int interactions = 10;
        for (int i=0; i<interactions; i++)
        {
            yield return new WaitForSeconds(TotalTime/interactions);
            transform.localPosition = (new Vector3(transform.localPosition.x, 0.7f, transform.localPosition.z) - transform.localPosition)/TotalTime * i* TotalTime / interactions + transform.localPosition;
        }
        //transform.localPosition = new Vector3(transform.localPosition.x, 0.7f, transform.localPosition.z);
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < interactions; i++)
        {
            yield return new WaitForSeconds(TotalTime / interactions);
            transform.localPosition = (new Vector3(transform.localPosition.x, -3.5f, transform.localPosition.z) - transform.localPosition) / TotalTime * i *TotalTime / interactions + transform.localPosition;
        }
        //transform.localPosition = new Vector3(transform.localPosition.x, -3.5f, transform.localPosition.z);
        isHidden = true;
    }
}
