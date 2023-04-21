# Rapport Jumper Assigmnent MLAgent

## Inleiding

Het doel van deze opdracht is om een zelflerende agent te maken dat een obstakel kan ontwijken. Het obstakel zal steeds een willekeurige snelheid krijgen. Deze opdracht dient als leermiddel om te oefenen op het maken van een eigen agent, in plaats van een op voorhand geschreven agent te gebruiken (en mogelijk aan te passen).

## Methode

Eerst werd er een basis opstelling gemaakt voor dit experiment, bestaande uit een platform, een kubus die zal dienen als agent en nog een balk die de rol van obstakel krijgt.

![De basis opstelling](/images/jumperagentsetup.PNG "De basis opstelling")

Daarna werd er een script geschreven dat het obstakel met een willekeurige snelheid laat bewegen en terug op zijn originele plaats zet als het obstakel een bepaald punt bereikt heeft. Ten slotte werd er een agent geschreven die de kubus laat springen en een reward geeft als het obstakel voorbij hem is gegaan. Als er een botsing is word het obstakel ook op zijn originele plaats gezet (en de episode word beëindigt). Ook zorgt de agent dat er een negatieve beloning is als er een botsing is en als de kubus springt, dit is om te voorkomen dat de kubus continu blijft springen. Uiteindelijk werd er zelfs een timer gezet op het springen, maar da heeft ook niet het gewenste effect.

## Resultaten

Het trainingsproces duurde enorm lang met zeer weinig vooruitgang. Dit is waarschijnlijk door fout ingestelde hyperparameter en/of een foute ratio negatieve/positieve belonging. Het geven van een negatieve beloning bij elke sprong leek geen effect te hebben op de agent, het onnodig springen werd niet tegengehouden. Er werd nooit een positief gemiddeld reward bereikt.

Het trainingsproces duurde waarschijnlijk ook langer dan normaal omdat er maar één training area werd gebruikt. Voor volgende iteraties zullen er meerdere training areas gebruikt moeten worden om dit te versnellen.

![Grafiek van de resultaten](/images/jumperagentchart.PNG "Grafiek van de resultaten")

## Conclusie

De opdracht had niet het gewenste resultaat, er werd nooit een positief resultaat bereikt maar uiteindelijk was er wel een "werkende" agent. Voor volgende iteraties zal er meer geëxperimenteert moeten worden met de ratio positieve/negatieve beloningen en de hyperparameters. Het negatieve gemiddelde kwam hoogstwaarschijnlijk doordat de agent bleef springen (zelfs met de cooldown). De lange duur van het trainingsproces werd waarschijnlijk beïnvloed door de fout opgestelde hyperparameters.
