// Oz
using UnityEngine;

public class NameGen : MonoBehaviour
{
    static string[] names = {
        "Bucket", "Blue", "Ice", "Hurricane", "Pyro",
        "Mugs", "Cyclone", "Black Widow", "Babe",
        "Lightning", "Bad Boy", "Wiggles", "Pops",
        "Artsy", "Sage", "Silence", "Rouge", "Dino",
        "Handsome", "Daring",};

    public static string GetName() => names[Random.Range(0, names.Length)];
}
