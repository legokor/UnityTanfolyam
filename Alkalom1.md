 ## 1. Alkalom
 # C++ és C# legfőbb különbségek:
- C#-ban nincs pointer, nincs memóriakezelés, nincs free, nincs delete, nincs malloc
- Helyette: new és Garbage Collector
- Osztályok: class A : B, csak egy ős lehet, de lehet több interfész
- Unity: MonoBehaviour-ból öröklünk: ennek vannak az életciklus függvényei
- GameObject: a pályán elhelyezhető objektumok, ezekhez lehet a MonoBehaviour-t hozzáadni -> ezek a szkriptek komponensek
 # UI Részek:
- Hierarchy: Mutatja a pályán lévő elemeket (fa struktúra)
- Scene: A pályát mutatja 3D-ben, lehet módosítani különböző eszközökkel (mozgatás, forgatás, skálázás, stb.)
- Game: Azt mutatja, amit a játékos lát, itt lehet tesztelni
- Inspector: Az aktuálisan kiválasztott elem (GameObject) tulajdonságait mutatja
- Project: A projektben lévő, pályán nem biztosan elhelyezett elemek (pl. szkriptek, pályák, Elmentett GameObject-ek=prefabok, textúrák, hangok, stb.)
- Console: Játék során keletkező (hiba)üzeneteket mutatja, szkriptből lehet írni (infó, figyelmeztetés, hiba)
 # LifeCycle, Debug:
- Lifecycle részek: Awake, OnEnable, OnDisable, **Start**, **Update**, **FixedUpdate**, LateUpdate, OnDestroy
    - Start: Egyszer hívódik meg, a szkript életciklusának elején, a szkript létrejöttekor
    - Update: Minden képkockában meghívódik, a szkript életciklusának elején
    - FixedUpdate: Minden fizikai szimulációs lépésben meghívódik, a szkript életciklusának elején
    - Mindegyik private void Függvény()!
- Debug: Debug.Log() -> Információ, Debug.LogWarning() -> Figyelmeztetés, Debug.LogError() -> Hiba