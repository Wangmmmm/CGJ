using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneUI : MonoBehaviour {

    GameData gameData;
    GameObject matrix;

    public Text timer;
    public Slider energySlider;
    public Text energyText;
    public Slider MatrixSlider;


    private void Start()
    {
        gameData = GameObject.Find("SceneLoader").GetComponent<GameData>();
        matrix = GameObject.Find("Matrix");
        MatrixSlider = matrix.transform.GetComponentInChildren<Slider>();

    }

    void RayEnergyUI()
    {
        float ratio = gameData.rayCurrentEnergy / gameData.rayMaxEnergy;
        energySlider.value = ratio;
        energyText.text = ((int)(ratio * 100)) + "%";
    }

    void MatrixUI()
    {
        MatrixSlider.value = gameData.matrixCurrentLife / gameData.matrixMaxLife;
    }

    void TimerUI()
    {
        int min = (int)gameData.timer / 60;
        int sec = (int)gameData.timer % 60;
        timer.text = min + " : " + sec;
    }

    // Update is called once per frame
    void Update () {
        RayEnergyUI();
        TimerUI();
        MatrixUI();
	}



}
