using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TicTacToe3D : MonoBehaviour
{
    public string filepath;

    private float timeTillUpdate;
    public float timeBetweenUpdates;

    public GameObject player1;
    public GameObject player2;

    public GameObject numberIdentifier;

    public List<int> state;

    public List<Vector3> positions;

    public Text output;

    private void Awake()
    {
        if (state.Count < 27)
        {
            for (int i = 27 - state.Count; i >= 0; i--)
            {
                state.Add(0);
            }
        }

        for (int i = 0; i < 27; i++)
        {
            GameObject go = Instantiate(numberIdentifier);
            Text idText = go.GetComponentInChildren<Text>();
            idText.text = i.ToString();
            go.transform.position = positions[i] + new Vector3(0.75f, 0.75f, 0.75f);
        }
    }

    public void SetPath(string path)
    {
        filepath = path;
    }

    

    void ConvertToList(string str)
    {
        foreach(Transform go in transform)
        {
            Destroy(go.gameObject);
        }
        string[] tokens = str.Split(',');
        for (int i = 0; i < 27; i++)
        {
            state[i] = int.Parse(tokens[i]);
            if (state[i] == -1)
            {
                GameObject newPos = Instantiate(player1);
                newPos.transform.position = positions[i];
                newPos.transform.SetParent(transform);
            } else if (state[i] == 1)
            {
                GameObject newPos = Instantiate(player2);
                newPos.transform.position = positions[i];
                newPos.transform.SetParent(transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeTillUpdate < 0)
        {
            timeTillUpdate = timeBetweenUpdates;
            if (File.Exists(filepath))
            {
                StreamReader reader;
                reader = new StreamReader(filepath);
                ConvertToList(reader.ReadLine());
                reader.Close();
                output.text = "Read file board.txt found!\nUpdating every " + timeBetweenUpdates.ToString() + "s";
            }
            else
            {
                
                output.text = "File path: " + Path.GetFullPath(filepath) + " does not exist.\n\nGenerate a csv file with 27 values.\nplayer1 = -1\nplayer2 = 1\nempty = 0\n\nex:\n0,-1,0,0,0,1,-1,...";
            }
        }
        timeTillUpdate -= Time.deltaTime;
    }
}
