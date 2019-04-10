using System;
using UnityEngine.SceneManagement;
namespace Application
{
    public class LevelComplete: Item
    {
        public override void onPickup()
        {
            SceneManager.LoadScene("VICTORY");
        }
    }
}
