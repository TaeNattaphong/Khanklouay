using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPlayer : MonoBehaviour
{

    public GameObject bullet, bulletPrefub;
    public Animator ani;
    public Rigidbody2D myRigit;
    public BoxCollider2D myForm;
    public bool Paused;
    public static float hpplayer;
    public float max = 100;
    public Image img;

    private int distance = 1;

    private float widthImg;

    //bool jump = false;

    // Use this for initialization
    void Start()
    {
        // gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(10f,0f);
        ani = GetComponent<Animator>();
        myRigit = GetComponent<Rigidbody2D>();
        myForm = GetComponent<BoxCollider2D>();
        Paused = false;
        widthImg =  img.GetComponent<RectTransform>().sizeDelta.x;
        hpplayer = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (hpplayer <= 0) {
            if (GameContorler.numLife == 0) {
				new seen().ChangeScene("GameOver");
			}
			else {
				gameObject.transform.position = new Vector3(-8f,10f,-5f);
				Text tt;
				tt = GameObject.Find("/Canvas showVeiw/Life").GetComponent<Text>();
				GameContorler.numLife--;
				tt.text = "Life = " + GameContorler.numLife;
                hpplayer = 100;
			}
        }
        else if (hpplayer > max) {
            hpplayer = max;
        }
        img.GetComponent<RectTransform>().sizeDelta = new Vector2( (hpplayer / max) * widthImg,img.GetComponent<RectTransform>().sizeDelta.y );
        // Debug.Log((hp / max) * widthImg);
        // Debug.Log(hp / max + " " + widthImg);
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            distance = 1;
            //.rigidbody2D.velocity = new Vector2(3f, 0f);
            ani.SetBool("isLeft", false);
            ani.SetBool("walk", true);
            myRigit.transform.Translate(new Vector3(15f * Time.deltaTime, 0));
        }
        else
        {
            ani.SetBool("walk", false);
        }

        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            distance = -1;
            ani.SetBool("isLeft", true);
            ani.SetBool("walkBack", true);
            myRigit.transform.Translate(new Vector3(-15f * Time.deltaTime, 0));
        }
        else
        {
            ani.SetBool("walkBack", false);
        }

        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)) && (myRigit.velocity.y == 0) && !(ani.GetBool("isLeft")))
        {
            ani.SetBool("jumpRight", true);
            myRigit.velocity = new Vector2(0,18f);
        }
        else if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)) && (myRigit.velocity.y == 0) && (ani.GetBool("isLeft")))
        {
            ani.SetBool("jumpLeft", true);
            myRigit.velocity = new Vector2(0,18f);
        }
        else
        {
            ani.SetBool("jumpRight", false);
            ani.SetBool("jumpLeft", false);
        }

        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)) && !ani.GetBool("isLeft"))
        {
            ani.SetBool("coverRight", true);
            // myForm.offset = new Vector2(0, -0.2008744f);
            // myForm.size = new Vector2(0.5f, 0.0001f);
            // myRigit.velocity = new Vector2(0, 0);
        }
        else if (Input.GetKey(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)) && ani.GetBool("isLeft"))
        {
            ani.SetBool("coverLeft", true);
            myForm.offset = new Vector2(0, -0.2008744f);
            myForm.size = new Vector2(0.5f, 0.0001f);
            myRigit.velocity = new Vector2(0, 0);
        }
        else
        {
            ani.SetBool("coverRight", false);
            ani.SetBool("coverLeft", false);
            myForm.offset = new Vector2(0, -0.002696544f);
            myForm.size = new Vector2(0.5f, 0.3964556f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("shootRight", true);
            bulletPrefub = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            bulletPrefub.GetComponent<Bullet>().player = gameObject;
            bulletPrefub.GetComponent<Bullet>().setDamage(30f);
            bulletPrefub.GetComponent<Rigidbody2D>().velocity = new Vector2(50f*distance, 0f);
            bulletPrefub.GetComponent<SpriteRenderer>().flipX = distance < 0;
            Destroy(bulletPrefub, 7);
        }
        // else if (Input.GetKeyDown(KeyCode.Space) && ani.GetBool("isLeft"))
        // {
        //     ani.SetBool("shootLeft", true);
        //     bulletPrefub = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        //     bullet.GetComponent<Bullet>().player = gameObject;
        //     bulletPrefub.GetComponent<Rigidbody2D>().velocity = new Vector2(-50f, 0f);
        //     Destroy(bulletPrefub, 7);

            /* void CmdFire(Vector2 a) {
        GameObject bulletOb = Instantiate(bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet> ().player = gameObject;
        bulletOb.GetComponent<Rigidbody2D> ().velocity = a;
        NetworkServer.Spawn(bulletOb);
        Destroy(bulletOb, 2);
    } */
        // }
        else
        {
            ani.SetBool("shootRight", false);
            ani.SetBool("shootLeft", false);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)){
            myRigit.velocity = new Vector2(0, 0);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)){
            myRigit.velocity = new Vector2(0, 0);
        }
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
     //booster
        if (coll.gameObject.CompareTag("Booster")) {
			myRigit.velocity = new Vector2(0f, 30f);
		}
        else if (coll.gameObject.CompareTag("Death")) {
			if (GameContorler.numLife == 0) {
				new seen().ChangeScene("GameOver");
			}
			else {
				gameObject.transform.position = new Vector3(-8f,10f,-5f);
				Text tt;
				tt = GameObject.Find("/Canvas showVeiw/Life").GetComponent<Text>();
				GameContorler.numLife--;
				tt.text = "Life = " + GameContorler.numLife;
				
			}
		}
		else if (coll.gameObject.CompareTag("ChangeSceneTummy")) {
			new seen().ChangeScene("Tum");
		}
		else if (coll.gameObject.CompareTag("ChangeSceneBosso")) {
			new seen().ChangeScene("Bosso");
		}
    }
}
