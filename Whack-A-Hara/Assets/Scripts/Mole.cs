using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    private AudioSource hitMole;
    private GameObject gameManager;
    private GameObject scoreManager;
    public bool isHidden = true;
    public SpriteRenderer sprite;
    public Coroutine ShowMoleCorroutine;
    public static Color[] colorList = new Color[3];
    [SerializeField] private ParticleSystem hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        scoreManager = GameObject.Find("ScoreManager");
        sprite = GetComponent<SpriteRenderer>();
        hitMole = GetComponent<AudioSource>();
        hitEffect = GetComponentInChildren<ParticleSystem>();
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
                //audio
                hitMole.Play();
                StopCoroutine(ShowMole());

                transform.localPosition = new Vector3(transform.localPosition.x, -3.5f, transform.localPosition.z);
                isHidden = true;

                if (sprite.color == colorList[0])
                {
                    hitEffect.Play();
                    scoreManager.GetComponent<ScoreManager>().scores[gameManager.GetComponent<GameManager>().round] += 30;
                }
                else if (sprite.color == colorList[1])
                {
                    if (scoreManager.GetComponent<ScoreManager>().scores[gameManager.GetComponent<GameManager>().round] - 10 < 0)
                    {
                        scoreManager.GetComponent<ScoreManager>().scores[gameManager.GetComponent<GameManager>().round] = 0;
                    }
                    else
                    {
                        scoreManager.GetComponent<ScoreManager>().scores[gameManager.GetComponent<GameManager>().round] += -10;
                    }
                }
                else if (sprite.color == colorList[2])
                {
                    if (scoreManager.GetComponent<ScoreManager>().scores[gameManager.GetComponent<GameManager>().round] - 20 < 0)
                    {
                        scoreManager.GetComponent<ScoreManager>().scores[gameManager.GetComponent<GameManager>().round] = 0;
                    }
                    else
                    {
                        scoreManager.GetComponent<ScoreManager>().scores[gameManager.GetComponent<GameManager>().round] += -20;
                    }
                }
                scoreManager.GetComponent<ScoreManager>().UpdateScoreUI(gameManager.GetComponent<GameManager>().round);
            }
        }
    }
    public IEnumerator ShowMole()
    {
        ChooseMoleColor();
        isHidden = false;

        float TotalTime = 0.3f;
        int interactions = 15;
        for (int i=0; i<interactions; i++)
        {
            yield return new WaitForSeconds(TotalTime/interactions);
            transform.localPosition = (new Vector3(transform.localPosition.x, 0.7f, transform.localPosition.z) - transform.localPosition)/TotalTime * i* TotalTime / interactions + transform.localPosition;
        }
        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < interactions; i++)
        {
            yield return new WaitForSeconds(TotalTime / interactions);
            transform.localPosition = (new Vector3(transform.localPosition.x, -3.5f, transform.localPosition.z) - transform.localPosition) / TotalTime * i *TotalTime / interactions + transform.localPosition;
        }
        isHidden = true;
    }
    private void ChooseMoleColor()
    {
        if (gameManager.GetComponent<GameManager>().correctMoles < 15)
        {
            int random = Random.Range(0, 10);
            if (random < 4)
            {
                sprite.color = colorList[0];
            }
            else if (random >= 4 && random < 7)
            {
                sprite.color = colorList[1];
            }
            else
            {
                sprite.color = colorList[2];
            }
        }
        else
        {
            int random = Random.Range(0, 5);
            if (random < 1)
            {
                sprite.color = colorList[0];
            }
            else if (random >= 1 && random < 3)
            {
                sprite.color = colorList[1];
            }
            else
            {
                sprite.color = colorList[2];
            }
        }
    }
    public void HideMole()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, -3.5f, transform.localPosition.z);
        isHidden = true;
    }
}
