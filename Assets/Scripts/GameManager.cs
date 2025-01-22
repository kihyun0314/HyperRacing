using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] GameObject gasItemPrefab;
    [SerializeField] TMP_Text gasText;

    public int Gas = 100;
    public int gasItemUp = 30;
    float moveSpeed = 1.0f;
    float spawnRangeX = 2f;

    void Start()
    {
        UpdateGasText();
        StartCoroutine(DecreaseGas());
        StartCoroutine(SpawnGasItem());
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            car.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.RightArrow)){
            car.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.UpArrow)){
            car.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.DownArrow)){
            car.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
    }

    IEnumerator DecreaseGas(){
        while(Gas > 0){
            yield return new WaitForSeconds(1f);
            Gas -= 10;
            UpdateGasText();
        }
        SceneManager.LoadScene(2);
    }

    public void UpdateGasText(){
        gasText.text = "Gas : " + Gas.ToString();
    }

    IEnumerator SpawnGasItem()
    {
        while (true)
        {
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPosition = new Vector3(randomX, 2, 0);

            Instantiate(gasItemPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(8f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GasItem"))
        {
            Gas += gasItemUp;
            UpdateGasText();

            Destroy(collision.gameObject);
        }
    }

    public void LoadIngamescene(){
        SceneManager.LoadScene(1);
    }

    public void LoadIntroscene(){
        SceneManager.LoadScene(0);
    }
}
