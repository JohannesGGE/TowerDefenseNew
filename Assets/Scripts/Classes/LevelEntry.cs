using System;

/// <summary>
/// Abgeaenderte Version der Folgenden Loesung
/// https://github.com/MichelleFuchs/StoringDataJsonUnity
/// </summary>
[Serializable]
public class LevelEntry {
    public bool unlocked;
    public int stars;

    public LevelEntry (bool unlocked, int stars) {
        this.unlocked = unlocked;
        this.stars = stars;
    }
}