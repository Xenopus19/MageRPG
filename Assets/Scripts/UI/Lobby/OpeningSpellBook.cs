using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSpellBook : MonoBehaviour
{
    public void LoadSpellBook()
    {
        SceneManager.LoadScene("SpellBook");
    }
}
