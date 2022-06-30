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
    public float enemyhealth;
    public Image visualcolor;
    public TextMeshProUGUI mytext;
    //public Gradient gradiant;
    float lerpSpeed=10f;
    public void setmaxhealth()
    {
        slider.maxValue = enemyhealth;
        slider.value = enemyhealth;
       

    }
    public void sethealth(float health)
    {
         slider.value = health;
        
        mytext.text = "Health: " + (float)((health / enemyhealth) * 100f) +"%";
        visualcolor.fillAmount  = Mathf.Lerp(visualcolor.fillAmount, health / enemyhealth, lerpSpeed);
        Color healthcolor = Color.Lerp(Color.red, Color.green, health / enemyhealth);
        visualcolor.color = healthcolor;
    }

    
}
