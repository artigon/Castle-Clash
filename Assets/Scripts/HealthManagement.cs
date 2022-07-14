using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HealthManagement : MonoBehaviour
{
  

    public Image healthBarImage;
    public Fort fort;
    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(fort.health / fort.maxHealth, 0, 1f);
    }
}

