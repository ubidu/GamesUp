import requests
from bs4 import BeautifulSoup

# Adres URL strony
url = 'https://www.gry-online.pl/S015.asp?KAT=1'

# Wysłanie zapytania HTTP
response = requests.get(url)

# Sprawdzenie, czy udało się pobrać stronę poprawnie
if response.status_code == 200:

    # Analiza zawartości strony za pomocą BeautifulSoup
    soup = BeautifulSoup(response.text, 'html.parser')

    # Znajdź wszystkie divy z klasą, która zawiera dane gier
    game_divs = soup.find_all('div', class_='box')

    for game_div in game_divs:

        # Wyszukaj paragraf z opisem gry
        game_description = game_div.find('p', class_=False).text

        # Wyszukaj tytulu
        game_title = game_div.find('a', class_='pic-c')['title']

        # Wyszukaj link do zdjecia
        game_image = game_div.find('img', class_='pic')

        # Znajdz paragraf o nazwie opis-b
        game_description2 = game_div.find('p', class_='opis-b')

        # Znajdz paragraf o nazwie plat
        game_platform = game_div.find('p', class_='plat')

        if game_description2:

            # Wyodrebnij kategorie elementem b oraz date premiery
            category = game_description2.find('b').text
            release_date = game_description2.get_text(strip=True).replace(category, '').strip()

        else:

            print('blad')

        if game_image:

            # Wyodrebnij link do zdjecia z atrybutu "data-src"
            game_image = game_image['data-src']

        else:
            print('blad')

        if game_platform:

            # Pozyskaj wszystkie linki w paragrafie "plat"
            platform_links = game_platform.find_all('a')

            # Wyodrebnij platformy i polacz je przecinkiem
            platforms = ', '.join(platform.text for platform in platform_links)

        else:

            print('blad')

        # Wyświetlenie lub zapisanie pozyskanych danych
        print("Tytul gry:", game_title)
        print("Opis gry:", game_description)
        print("Link do zdjecia:", game_image)
        print("Kategoria:", category)
        print("Data premiery:", release_date)
        print("Platformy:", platforms)
        print("\n")

else:

    print("Nie udało się pobrać strony.")
