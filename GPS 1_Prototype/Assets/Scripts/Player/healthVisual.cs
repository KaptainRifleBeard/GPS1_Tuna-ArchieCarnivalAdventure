using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class healthVisual : MonoBehaviour
{
    Player p;

    public static healthSystem HealthSystem;
    [SerializeField] private Sprite heart0Sprite;
    [SerializeField] private Sprite heart1Sprite;
    [SerializeField] private Sprite heart2Sprite;
    private List<HeartImage> heartImageList;
    private healthSystem healthSystem1; //curently not using , for private only

    private void Awake()
    {
        heartImageList = new List<HeartImage>();
    }
    private void Start()
    {
        healthSystem hs = new healthSystem(3); // number of maximum heart 
        SetHealthSystem(hs);

    }

    public void SetHealthSystem(healthSystem hs)
    {
        //this.healthSystem1 = hs;  //a //i think this line no need  (use for private)                  
        HealthSystem = hs; 
        List<healthSystem.Heart> heartList = hs.GetHeartList();
        int row = 0;
        int col = 0;
        int colMax = 10;
        float rowColSize = 30f;
        for (int i = 0; i < heartList.Count; i++)
        {
            healthSystem.Heart heart = heartList[i];
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
    }

    public void healthSystem_OnDead(object sender, System.EventArgs e)
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Dead!");
        Debug.Log(y);

        Destroy(GameObject.FindWithTag("Player"));

        if (y == 3)
        {
            SceneManager.LoadScene(6);
        }
        else if(y == 4)
        {
            SceneManager.LoadScene(7);
        }
    
    }



    private void healthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        RefreshAllHearts();
    }
    private void RefreshAllHearts()   ///// make the health can be decrease
                                      /// if delete this it will always be full health
    {
        List<healthSystem.Heart> heartList = HealthSystem.GetHeartList(); //a
        for (int i = 0; i < heartImageList.Count; i++)
        {
            HeartImage heartImage = heartImageList[i];
            healthSystem.Heart heart = heartList[i];
            heartImage.SetHeartFraments(heart.GetFragmentAmount());
        }
    }

    private HeartImage CreateHeartImage(Vector2 anchoredPosition) ////// create the heart on the screen
    {
        GameObject hgo = new GameObject("Heart", typeof(Image)); // heartGameObject

        hgo.transform.parent = transform;           // Set as child of this transform
        hgo.transform.localPosition = Vector3.zero;
        hgo.transform.localScale = Vector3.one;

        hgo.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;  // Locate and Size heart
        hgo.GetComponent<RectTransform>().sizeDelta = new Vector2(35, 35);

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
        private healthVisual heartsHealthVisual;
        public HeartImage(healthVisual hv, Image hi) ///// to show the number of heart, 
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
