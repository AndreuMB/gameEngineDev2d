using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleControllerX : MonoBehaviour
{
    [Range(0,6)][SerializeField] float speed;
    SpriteRenderer sprite;
    float cameraWidth;
    float cameraHeight;
    private Vector3 lastValidPosition;
    private Rigidbody2D rigidbody2d;
    [SerializeField] GameObject bullet;
    [SerializeField] int life;
    Animator animator;
    bool upgrade = false;
    // Start is called before the first frame update
    void Start()
    {     
        // camera size
        Camera cam = Camera.main;

        cameraHeight = cam.orthographicSize;
        cameraWidth = cameraHeight * cam.aspect;

        animator = GetComponent<Animator>();

        // rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // float horizontal = Input.GetAxis("Horizontal");
        float horizontal = Input.GetAxis("Horizontal");

        // spaceship size check???
        if (transform.position.x >= cameraWidth 
        || transform.position.x <= -cameraWidth){
            transform.position = lastValidPosition;
        }else{
            lastValidPosition = transform.position;
            Vector3 direction = new Vector3(horizontal,0,0);
            transform.position += direction * speed;
        }
    }

    void Update()
    {
       if (Input.GetKeyDown("space")){
            FindObjectOfType<AudioManager>().Play("LaserBullet");
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    // void OnCollisionEnter2D(Collision2D other) {
    //     Time.timeScale = 0;
    //     Debug.Log("YOU LOSE :(");
    //     sprite.color=Color.red;
    //     // Destroy(gameObject);
    //     Debug.Log("RESTART WITH SPACE KEY");
    // }

    void OnCollisionEnter2D(Collision2D other) {
        GameObject lifeText =  GameObject.FindWithTag("Life");
        if (other.gameObject.tag=="Enemy")
        {
            GameObject sys =  GameObject.FindWithTag("System");
            upgrade = false;
            life--;
            lifeText.GetComponent<LifeCount>().UpdateLife();
            // lifeText.GetComponent<Text>().text = life.ToString();
            FindObjectOfType<AudioManager>().Play("SpaceshipExplosion");
            if (life <= 0)
            {
                animator.SetBool("destroyedSpaceship",true);
                FindObjectOfType<AudioManager>().Play("GameOver");
                FindObjectOfType<AudioManager>().Stop("MainTheme");
                StartCoroutine(destroySpaceshipCoroutine());
                sys.GetComponent<GameSystem>().setGameOver(true);
            }else{
                StartCoroutine(inmunityCoroutine());
            }
        }else if(other.gameObject.tag=="Upgrade"){
            FindObjectOfType<AudioManager>().Play("GetObject");
            upgrade = true;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag=="LifeUp"){
            FindObjectOfType<AudioManager>().Play("GetObject");
            if (life<3)
            {
                life++;
                lifeText.GetComponent<LifeCount>().UpdateLife();
                // lifeText.GetComponent<Text>().text = life.ToString();
            }
            Destroy(other.gameObject);
        }
    }

    IEnumerator destroySpaceshipCoroutine(){
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime>1)
        {
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }

    IEnumerator inmunityCoroutine(){
        GetComponent<BoxCollider2D>().enabled = false;
        //Fetch the SpriteRenderer from the GameObject
        SpriteRenderer m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        m_SpriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(2);
        GetComponent<BoxCollider2D>().enabled = true;
        m_SpriteRenderer.color = Color.white;
    }

    public int getLife(){
        return life;
    }

    public void setUpgrade(bool upgradeValue){
        upgrade = upgradeValue;
    }
    public bool getUpgrade(){
        return upgrade;
    }


}
