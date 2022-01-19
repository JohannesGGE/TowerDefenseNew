using System;

/// <summary>
/// Abgeaenderte Version der Folgenden Loesung
/// https://github.com/MichelleFuchs/StoringDataJsonUnity
/// </summary>
[Serializable]
public class Settings {
    public float volumeBackground;
    public float volumeSounds;
    
    public Settings (float volumeBackground, float volumeSounds) {
        this.volumeBackground = volumeBackground;
        this.volumeSounds = volumeSounds;
    }
}