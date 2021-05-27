


# Autószereló munkanyilvántartó

----------



*Egy autószerelő műhelyben működő kliens - szerver alkalmazás implementálása.*




#### Munka felvevő kliens - .NET WPF asztali alkalmazás

*Az ügyintéző irodájában működik.*

**Az érkező ügyfelek adatait tudja felvenni**


- Ügyfél neve
  - Validáció
  - UNIT teszt
- Autó típusa és rendszáma
  - Validáció
  - UNIT teszt
- Az autó hibájának rövid leírásá


**Látja a felvett munkákat**

- Időrendi sorrendben rendezve
- Egy kiválasztott munka adatait
  - Meg tudja nézni
  - Módosítani tudja

#### Autószerelő kliens - .NET WPF asztali alkalmazás

*Az autószerelő műhelyben működik.*


**Látja a felvett munkákat**

- Időrendi sorrendben rendezve

- Ki tud választani egy munkát
  - Aminek az állapotát változtathatja
    - Felvett munka-> Elvégzés alatt-> Befejezett

#### Szerver - .NET WEB API alkalmazás (önálló konzol alkalmazás)

**Tárolja és szolgáltatja a bevitt adatokat**

- Adatok tárolása: JSON, XML vagy adatbázis

- Indításkor betölti a korábbi adatokat

