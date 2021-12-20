using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{
    // SetUp für die Tests (wird anscheinend vor jedem Tests aufgerufen)
    [SetUp]
    public void Setup()
    {
        // SetUp
    }
    
    
    // TearDown für die Tests (wird anscheinend nach jedem Test aufgerufen)
    [TearDown]
    public void Teardown()
    {
        // TearDown
    }

    
    // Definition eines UnityTestes
    [UnityTest]
    public IEnumerator TestMethode()
    {
        // Mit Assert. lassen sich die Ergebnisse überprüfen
        Assert.False(false);
        Assert.Equals(11, 11);
        
        // Yield muss immer im UnityTest vorkommen. Entweder als return null oder z.B. als WaitforSeconds(f)
        yield return null;
        yield return new WaitForSeconds(0.1f);
    }
    
    
    // Anscheinend ein simpler Test, ohne yield
    [Test]
    public void TestSuiteSimplePasses()
    {
        // Code wahrscheinlich quivalent zu UnityTest
    }
}
