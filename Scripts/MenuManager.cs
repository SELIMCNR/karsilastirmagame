using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform kafa;
    // Start is called before the first frame update

    [SerializeField]
    private Transform startbtn;
    void Start()
    {
        kafa.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        startbtn.transform.GetComponent<RectTransform>().DOLocalMoveY(-245f, 1f).SetEase(Ease.OutBack);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void basla()
    {
        SceneManager.LoadScene(1);
    }
}
