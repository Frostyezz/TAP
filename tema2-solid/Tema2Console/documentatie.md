## Single Responsibility Principle;

- Descrierea implementării efectuate: Am creat clase (RoomOrderProcessor, ProductOrderProcessor, BreakfastOrderProcessor) pentru getionarea fiecarui tip de comanda. 
- De ce s-a ales implementarea respectiva: Fiecare tip de comanda este procesata de o clasa individuala. Astfel, codul este mai modular si mai usor de urmarit.
- Ce și Cum încalcă implementarea curentă definitia principiului: Clasa HotelReception se ocupa de procesarea tuturor tipurilor de comenzi, creand o logica convulsionata si predispusa la modificari pe viitor.

## Open/Closed Principle;

- Descrierea implementării efectuate: Am adaugat interfata IOrderProcessor pe baza careia am creat 3 clase care se ocupa de procesarea comenzilor.
- De ce s-a ales implementarea respectiva: Codul poate fi modificat cu usurinta in cazul unui nou tip de comanda, prin adaugarea unui nou procesor care respecta interfata stabilita.
- Ce și Cum încalcă implementarea curentă definitia principiului: Metoda ProcessOrder din clasa HotelReception foloseste un switch pentru a procesa fiecare tip de comanda. Daca un nou tip de comanda ar fi adaugata, va fi nevoie de un caz aditional in cadrul acelui switch. Pentru a respecta acest principiu, ar trebui sa evitam acest comportament.

## Liskov Substitution Principle;

- Descrierea implementării efectuate: Am creat IOrderProcessor pentru a avea o interfata comuna pentru toate clasele ce proceseaza comenzi. 
- De ce s-a ales implementarea respectiva: Flexibilitatea de a inlocui intre ele clasele de tip IOrderProcessor, fara a creea type errors.
- Ce și Cum încalcă implementarea curentă definitia principiului: Nu cred ca exista un loc in cod care sa incalce acest principiu in sine.

## Interface Segregation Principle;

- Descrierea implementării efectuate: Am definit interfata IOrderProcessor care contine o singura metoda numita ProcessOrder, necesara pentru procesarra comenzilor.
- De ce s-a ales implementarea respectiva: Fiecare clasa ce proceseaza tipuri de comenzi contine implementari corespunzatoare cu propria functionalitatea.
- Ce și Cum încalcă implementarea curentă definitia principiului: Nu cred ca exista un loc in cod care sa incalce acest principiu in sine.

## Dependency Inversion Principle;

- Descrierea implementării efectuate: Am adaugat _orderProcessor in HotelReception. Astfel, HotelReception depinde de o abstractie, si nu de implementari concrete.
- De ce s-a ales implementarea respectiva: Flexibilitate si lizibilitate a codului
- Ce și Cum încalcă implementarea curentă definitia principiului: HotelReception contine implementari concrete ceea ce impiedica abilitatea de a scrie logica de procesare intr un mod abstract.