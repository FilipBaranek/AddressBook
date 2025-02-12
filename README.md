# Address Book
Je WPF aplikácia zameraná na manažovanie zamestnancov, v zmysle ich hľadania, pridávania, mazania z JSON súborov a úpravou (aktualizáciou) ich osobných údajov. Upravené alebo na novo vytvorené súbory je možné uložiť alebo exportovať ako CSV súbory.

## Knižnica
Logika za načítaním, vytváraním a mazaním zamestnancov z JSON súborov podľa presného formátu uvedeného nižšie, filtrovanie, upráva údajov, export a ukladanie zamestnancov do súborov

## Konzolová aplikácia
Pracovanie s uvedenými funkciami z knižnice pomocou CLI prostredia
Príkazy (každý sa začína charaktermi --):
- input nazovsuboru.pripona
- name meno (časť alebo celé vyhľadávané meno)
- main-workplace "Názov pracoviska" (Celý názov v uvodzovkách s diagritikou)
- position pracovna pozicia
- output nazovoutputsuboru.csv

## Aplikácia vyhľadávania
Umožňuje vyhľadávanie a filtrovanie zamestnancov zo súborov

## Aplikácia upravovania a vyhľadávania
Umožňuje vytváranie a úpravu súborov zamestnancov s možnosťou rovnakého vyhľadávania ako v aplikácii vyhľadávania

## Formát JSON súboru
![json_example](https://github.com/user-attachments/assets/4ddce0dd-a10f-41c6-857e-3acad7d8c4e6)

(súbor musí byť transkódovaný pre správne čítanie slovenských charakterov)


## Ukážka CLI
![cli](https://github.com/user-attachments/assets/40d8e474-1258-4c8d-80ed-521691db0ea0)


## Ukážka GUI
![main_window](https://github.com/user-attachments/assets/ec76895a-3f81-4f4d-99e0-e659e36051c7)

![search_window](https://github.com/user-attachments/assets/6d22e0f5-7cc6-4ea0-8750-9c7473f15d0a)

![edit_button](https://github.com/user-attachments/assets/f0e6549e-50a5-45bc-b1b7-3606a2beaad2)
