using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class healthVisualB : MonoBehaviour
{
    public static healthSystemB HealthSystem;
    [SerializeField] private Sprite heart0Sprite = null;
    [SerializeField] private Sprite heart1Sprite = null;
    [SerializeField] private Sprite heart2Sprite = null;
    private List<HeartImage> heartImageList;
    private healthSystemB healthSystem1; //curently not using , for private only

    healthSystemB hs;
    public bool p2IsDead = false;

    private void Awake()
    {
        heartImageList = new List<HeartImage>();
    }
    private void Start()
    {
        healthSystemB hs = new healthSystemB(3); // number of maximum heart 
        Debug.Log(hs);
        p2IsDead = false;
        SetHealthSystem(hs);
    }
    public void SetHealthSystem(healthSystemB hs)
    {
        //this.healthSystem1 = hs;  //a //i think this line no need  (use for private)                  
        this.hs = hs;
        HealthSystem = hs;

        List<healthSystemB.HeartB> heartList = hs.GetHeartList();
        int row = 0;
        int col = 0;
        int colMax = 10;
        float rowColSize = 30f;
        for (int i = 0; i < heartList.Count; i++)
        {
            healthSystemB.HeartB heart = heartList[i];
            Vector2 hap = new Vector2(col * rowColSize, -row * rowColSize);  //heartAnchoredPosition
            CreateHeartImage(hap).SetHeartFraments(heart.GetFragmentAmount());

            col++;
            if (col >= colMax)
            {
                row++;
                col = 0;
            }
        }
        hs.OnDamaged += healthSystem_OnDamaged;
        hs.OnDead += healthSystem_OnDead;
        hs.OnHeal += healthSystem_OnHeal;

    }

    public void healthSystem_OnDead(object sender, System.EventArgs e)
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Dead!");
        Debug.Log(y);
        p2IsDead = true;

        if (p2IsDead == true)
        {
            Destroy(GameObject.Find("Player"));
            Destroy(GameObject.Find("Player2"));
        }
        if (y == 3)
        {
            SceneManager.LoadScene(6);
        }
        else if (y == 4)
        {
            SceneManager.LoadScene(7);
        }

    }

    private void healthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        RefreshAllHearts();
    }
    private void healthSystem_OnHeal(object sender, System.EventArgs e)
    {
        RefreshAllHearts();
    }


    private void RefreshAllHearts()   ///// make the health can be decrease
    /// if delete this it will always be full health
    {
        List<healthSystemB.HeartB> heartList = HealthSystem.GetHeartList(); //a
        for (int i = 0; i < heartImageList.Count; i++)
        {
            HeartImage heartImage = heartImageList[i];
            healthSystemB.HeartB heart = heartList[i];
            heartImage.SetHeartFraments(heart.GetFragmentAmount());
        }
    }

    private HeartImage CreateHeartImage(Vector2 anchoredPosition) ////// create the heart on the screen
    {
        GameObject hgo = new GameObject("Heart", typeof(Image)); // heartGameObject

        hgo.transform.SetParent(gameObject.transform);          // Set as child of this transform
        hgo.transform.localPosition = Vector3.zero;
        hgo.transform.localScale = Vector3.one;

        hgo.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;  // Locate and Size heart
        hgo.GetComponent<RectTransform>().sizeDelta = new Vector2(32, 32);

        Image heartImageUI = hgo.GetComponent<Image>();   // Set heart sprite
        heartImageUI.sprite = heart2Sprite;

        HeartImage heartImage = new HeartImage(this, heartImageUI);   // heartGameObject.GetComponent<Animation>()
        heartImageList.Add(heartImage);

        return heartImage;
    }

    public class HeartImage // Represents a single Heart
    {
        private int fragments;
        private Image heartImage;
        private healthVisualB heartsHealthVisual;
        public HeartImage(healthVisualB hv, Image hi) ///// to show the number of heart, 
        {
            this.heartsHealthVisual = hv; ///if cancel this line it will show one heart only
            this.heartImage = hi;
        }
        public void SetHeartFraments(int fm) // fragments
        {
            this.fragments = fm;    //*
            switch (fm)
            {
                case 0: heartImage.sprite = heartsHealthVisual.heart0Sprite; break;
                case 1: heartImage.sprite = heartsHealthVisual.heart1Sprite; break;
                case 2: heartImage.sprite = heartsHealthVisual.heart2Sprite; break;
            }
        }
    }


}


