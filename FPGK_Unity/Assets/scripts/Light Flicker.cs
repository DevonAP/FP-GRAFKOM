using UnityEngine;
using System.Collections.Generic;

public class LightFlicker : MonoBehaviour
{
    public Light candleLight;
    public float minIntensity = 0.7f;
    public float maxIntensity = 1.2f;

    [Range(1, 50)]
    public int smoothing = 5;

    Queue<float> smoothQueue;
    float lastSum = 0;

    void Start()
    {
        smoothQueue = new Queue<float>(smoothing);
        if (candleLight == null) candleLight = GetComponent<Light>();
    }

    void Update()
    {
        // Menghapus nilai lama dari antrean
        while (smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }

        // Menambahkan nilai random baru
        float newVal = Random.Range(minIntensity, maxIntensity);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;

        // Menghitung rata-rata agar transisi mulus
        candleLight.intensity = lastSum / (float)smoothQueue.Count;
    }
}
