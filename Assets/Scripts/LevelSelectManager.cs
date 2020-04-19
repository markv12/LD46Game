﻿using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour {

    public Button level1Button;
    public Button level2Button;

    void Awake() {
        level1Button.onClick.AddListener(delegate { LoadScene(Scenes.LEVEL_1); });
        level2Button.onClick.AddListener(delegate { LoadScene(Scenes.LEVEL_2); });
    }

    private void LoadScene(Scenes scene) {
        LoadingScreen.LoadScene(scene);
    }
}
