# Projekt Handelsrechner
Konsolenprogramm zur Berechnung der Handelskalkultaion, Rückwärtskalkulation und Differenzkalkulation. Zumdem kann man Angebote berechnen und vergleichen. Realisiert wurde das Projekt in C# und ein Unit-Test zur Kontrolle der Berechnung geschrieben. Bei der Erstellung wurde das MVC Pattern verwendet.

<div style="text-align: center;">
<img src="images/Screenshot_Startmenu.png" alt="Startmenü" title="Handelsrechner" style="width:80%; height:auto;">
</div>

## Verwendete Technologien
- C#
- NET 8.0
- xUnit

## Projektziel:
Demonstration von Programmierkenntnisse in C# und das Sammeln von Erfahrung bei der Verwendung von Unit Test. Die Entscheidung für einen Handelsrechner fiel, da es sich um ein praxisnahes Thema mit überschaubaren Umfang handelt. 

## Funktion
- Auswahl zwischen:
  - Handelskalkulatin
  - Rückwärtskalkultion
  - Differenztialkalkulation
  - Angebotsvergleich  
- Eingabe der für die Kalkulation notwendigen Beträge  
- Berechnung der gewünschten Funktion  
- Ausgabe des Ergebnis

#### UML Klassendiagramm

```plantuml
@startuml
skinparam classFontStyle bold

namespace Handelsrechner.Model {
    class Angebot {
        + Angebotsname : string
        + Listeneinkaufspreis : decimal
        + LieferrabbattProzent : decimal
        + LieferrabattEUR : decimal
        + Zieleinkaufspreis : decimal
        + LieferskontoProzent : decimal
        + LieferskontoEUR : decimal
        + Bareinkaufspreis : decimal
        + Bezugskosten : decimal
        + Bezugspreis : decimal
        + Eingabebogen : Dictionary
        + Ausgabebogen : Dictionary
        + BerechneAngebot() void
        # BerechneLieferrabattEUR() void
        # BerechneZieleinkaufspreis() void <<virtual>>
        # BerechneLieferskontoEUR() void
        # BerechneBareinkaufspreis() void <<virtual>>
        # BerechneBezugspreis() void <<virtual>>
    }

    class Differenzkalkulation {
        # Titel : string <<override>>
        + Differenzkalkulation() void
        + BerechneKalkulation() void <<override>>
        # BerechneGewinn() void
    }

    class Handelskalkulation {
        # Titel : string <<override>>
        + BerechneKalkulation() void <<override>>
    }

    abstract class KalkulationBasis {
        # Titel : string <<abstract>>
        + HandlungskostenProzent : decimal
        + HandelungskostenEUR : decimal
        + Selbstkosten : decimal
        + GewinnzuschlangProzent : decimal
        + GewinnzuschlangEUR : decimal
        + Barverkaufspreis : decimal
        + KundenskontoProzent : decimal
        + KundenskontoEUR : decimal
        + VertreterprovisionProzent : decimal
        + VertreterprovisionEUR : decimal
        + Zielverkaufspreis : decimal
        + KundenrabattProzent : decimal
        + KundenrabattEUR : decimal
        + Listenverkaufspreis : decimal
        + UmsatzsteuerProzent : decimal
        + UmsatzsteuerEUR : decimal
        + ListenverkaufspreisBrutto : decimal
        + KalkulationBasis()
        + BerechneKalkulation() void <<abstract>>
        # BerechneHandlungskostenEUR() void
        # BerechneSelbstkosten() void
        # BerechneGewinnzuschlangEUR() void
        # BerechneBarverkaufspreis() void
        # BerechneKundenskontoEUR() void
        # BerechneVertreterprovisionEUR() void
        # BerechneZielverkaufspreos() void
    }
    class Rueckwaertskalkulation {
        # Titel : string <<override>>
        + BerechneKalkulation(): void <<override>>
        # BerechneBezugspreis(): void <<override>>
        # BerechneBareinkaufspreis() : void <<override>>
        # BerechneZieleinkaufspreis(): void <<override>>
        # BerechneListeneinkaufspreis(): void <<override>>
    }
}
namespace Handelsrechner.Control {
        abstract class BasisControl {
        # Titel : string <<abstract>>
        # MenuListe : List<string> <<abstract>>
        # Fehlermeldung : string <<protected>>
        # AuswahlFehlermeldung : string <<protected>>
        + Ausfuehren(auswahl: string) void <<abstract>>
    }
    class AngebotsvergleichControl {
        # Titel : string <<override>>
        # MenuListe : List<string> <<override>>
        + Ausfuehren(auswahl: string) void <<override>>
    }
    class KalkulationControl {
        # Titel : string <<override>>
        # MenuListe : List<string> <<override>>
        + Ausfuehren(auswahl: string) void <<override>>
        # Kalkulation(auswahl: string) void
    }
    class MainControl {
        # Titel : string <<override>>
        # MenuListe : List<string> <<override>>
        + Ausfuehren(auswahl: string) void <<override>>
    }
}
namespace Handelsrechner.View {
    class Ausgabe {
        - Linie : string
        + Titel(titel: string) void
        + Info(text: string) void
        + Frage(text: string) void
        + Fehlermeldung(text: string) void
        + MenuAuswahl(auswahl: List<string>) void
        + ZeigeTabelle(tabelle: List<string>) void
    }
}
namespace Handelsrechner.Service {
    class Eigenschaften {
        + VersuchSetzen(objekt: object, eigenschaft: string, wert: string) : bool
        + Lese(objekt: object, eigenschaft: string) : object
        }
    class ErzeugeTabelle {
        + DecimalToString(decimal wert) string
        + ErstelleVergleich(list: List<Angebot>) List<string>
        + ErstelleKalkulation(ausgabebogen: Dictionary<string, List<string>>) List<string>
    }
}


Ausgabe <--- AngebotsvergleichControl
Ausgabe <--- MainControl 
Ausgabe <--- KalkulationControl

Angebot <|-- KalkulationBasis
Handelskalkulation --|> KalkulationBasis
Rueckwaertskalkulation --|> KalkulationBasis
Differenzkalkulation --|> KalkulationBasis

BasisControl <|-- AngebotsvergleichControl
BasisControl <|-- MainControl
BasisControl <|-- KalkulationControl

AngebotsvergleichControl --> Angebot
KalkulationControl --> Handelskalkulation
KalkulationControl --> Rueckwaertskalkulation
KalkulationControl --> Differenzkalkulation

ErzeugeTabelle --> Eigenschaften
KalkulationControl --> Eigenschaften

KalkulationBasis --> ErzeugeTabelle
AngebotsvergleichControl --> ErzeugeTabelle
KalkulationControl --> ErzeugeTabelle

class Legende {
    - private
    # protected
    + public
    - private() void
    # protected() void
    + public() void
}

@enduml


<div style="text-align: center;">
<img src="images/Klassendiagramm.png" alt="Startmenü" title="Handelsrechner" style="width:100%; height:auto;">
</div>

## Screenshot
<div style="text-align: center;">
<img src="images/Screenshot_Angebot_A_und_B.png" alt="Eingabe Angebot A und B" title="Handelsrechner" style="width:80%; height:auto;">
<br><br>
<img src="images/Screenshot_Angebotsvergleich.png" alt="Angebotsvergleich" title="Handelsrechner" style="width:80%; height:auto;">
<br><br>
<img src="images/Screenshot_Handelskalkulation.png" alt="Handelskalkulation" title="Handelsrechner" style="width:80%; height:auto;">
</div>