using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[ExecuteInEditMode]
public class Healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public float maxhealth;
    public Image visualcolor;
    public TextMeshProUGUI mytext;
    //public GameObject explosioneffect2;
    //public Gradient gradiant;
    float lerpSpeed=10f;
    float curhealth=0f;
    public void setmaxhealth()
    {
        slider.maxValue = maxhealth;
        slider.value = maxhealth;
        curhealth = maxhealth;
    }

    /*public void Takedamage(int amount)
    {
        curhealth -= amount;
        sethealth(curhealth);
        
        if(curhealth < 0)
        {
            GameObject effect = Instantiate(explosioneffect2, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(effect, 2f);

            FindObjectOfType<AudioManager>().Play("Destroyenemy");
        }
    }*/
    public void sethealth(float health)
    {
         slider.value = health;
        
        mytext.text = "Health: " + (int)((health / maxhealth) * 100f) +"%";
        visualcolor.fillAmount  = Mathf.Lerp(visualcolor.fillAmount, health / maxhealth, lerpSpeed);
        Color healthcolor = Color.Lerp(Color.red, Color.green, health / maxhealth);
        visualcolor.color = healthcolor;
    }

    
}
