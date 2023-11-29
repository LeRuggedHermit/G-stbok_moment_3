# G-stbok_moment_3
Lösning för moment 3 - DT071G Datateknik GR (A), Programmering i C#.NET
Detta är min lösning till moment 3 i ovan nämnda kurs. Det är en "gästboks-applikation" för konsoll gjord i C#. 
Den är gjort med objekt-orienterad C# och innehåller utöver program.cs filen två klasser: Posts och Guestbook.
Den tar emot användar input för att navigera meny systemet och ger användaren 4 val: Lägg till inlägg, radera inlägg (med index-nummer), visa inlägg eller spara och stänga av appen. 
Om 1: Så måste användare skriva namn och meddelande - dessa måste vara längre än ett tecken. 

Lyckad tillläggning leder till sparat inlägg i JSON-filen.

Om 2: så måste användaren skriva ett index-nummer för att radera valt inlägg.

om 3: så visas samtliga meddelanden i gästboken.

om 4: så sparas de inläggen som skapats igen och förs in i JSON-filen.
