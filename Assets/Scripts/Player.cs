using UnityEngine;
using UnityEngine.Events;

namespace ColorSwitch
{
    public class Player : MonoBehaviour
    {
        public float jumpForce = 10f;

        public Rigidbody2D rigid;
        public SpriteRenderer rend;

        
        public Color[] colors = new Color[4];

        public UnityEvent onGameOver;

        private Color currentColor;
        //Reference
        public GameObject player;
        public GameObject win, lose;
        //Score
        public static int score;
        public int newscore = 1;



        void Start()
        {
            RandomizeColor();
            score = 0;            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            {
                rigid.velocity = Vector2.up * jumpForce;
            }
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            if (screenPosition.y > Screen.height || screenPosition.y < 0)
            {

                Lose();
            }
            if(score == 3)
            {
                Win();
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.name == "ColorChanger")
            {
                RandomizeColor();
                Destroy(col.gameObject);
                return;
            }

            if (col.name == "Star")
            {
                // Add score

                Destroy(col.gameObject);
                score += newscore;
                
                return;
            }

            SpriteRenderer spriteRend = col.GetComponent<SpriteRenderer>();
            if (spriteRend != null &&
               spriteRend.color != rend.color)
            {
                
                
               Lose();
               onGameOver.Invoke();
               
            }
        }

        void RandomizeColor()
        {

            /*
             * Generate random color
             * While randomColor == rend.color
             *      Generate another randomColor
                  
             *
             */
            
            //Generate random color
            int index = Random.Range(0, 4);
            Color randomColor = colors[index];
            //While randomColor == rend.color
            while (randomColor == rend.color)
            {
                // Generate another random color
                index = Random.Range(0, 4);
                randomColor = colors[index];
            }
            // Set renderer color to random color
            rend.color = randomColor;
        }
        public void Win()
        {
            win.SetActive(true);
            lose.SetActive(false);

        }
        public void Lose()
        {
            Destroy(player);
            win.SetActive(false);
            lose.SetActive(true);



        }
    }
}