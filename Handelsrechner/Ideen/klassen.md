````mermaid
---
title: Angebote vergleichen
---
classDiagram

    class Angebot{
        + Angebotsname: string
        + Nettoeinkaufspreis: decimal
        + LieferrabattProzent: decimal
        + LieferrabattEUR: decimal
        + LieferskontoProzent: decimal
        + LieferskontoEUR: decimal
        + Bezugskosten: decimal
        + Zieleinkaufspreis: decimal
        + Bareinkaufspreis: decimal
        + Bezugspreis: decimal
        + Angebotsvorlage: dict
        + berZieleinkaufspreis()
        + berLieferrabbatEUR()
        + berBareinkaufspreis()
        + berLieferskontoEUR()
        + berBezugspreis()
    }


    class MainControl{

    }
    class AngebotVergleich {
        Angebotliste: Angebot

    }