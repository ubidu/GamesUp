import json
import requests
from bs4 import BeautifulSoup
import html

categories = {
    'akcji': '1',
    'zrecznosciowe': '4',
    'rpg': '6',
    'strategiczne': '9',
    'przygodowe': '10',
    'sportowe': '12',
    'wyscigi': '14',
    'symulacje': '15',
    'logiczne': '16'
}

# Słownik do mapowania nazw miesięcy na liczby
month_map = {
    "stycznia": "01",
    "lutego": "02",
    "marca": "03",
    "kwietnia": "04",
    "maja": "05",
    "czerwca": "06",
    "lipca": "07",
    "sierpnia": "08",
    "września": "09",
    "października": "10",
    "listopada": "11",
    "grudnia": "12"
}


for category_name, category_id in categories.items():
    url = f"https://www.gry-online.pl/S015.asp?KAT={category_id}"
    response = requests.get(url)

    if response.status_code == 200:
        soup = BeautifulSoup(response.text, 'html.parser')
        game_divs = soup.find_all('div', class_='box')
        games_data = []  # Lista, do której dodamy informacje o grach

        for game_div in game_divs:
            game_info = {}
            link = "https://www.gry-online.pl" + game_div.find('a', class_='pic-c')['href']
            game_description = html.unescape(game_div.find('p', class_=False).text)
            game_title = game_div.find('a', class_='pic-c')['title']
            game_image = game_div.find('img', class_='pic')
            game_description2 = game_div.find('p', class_='opis-b')
            game_platform = game_div.find('p', class_='plat')

            if game_description2:
                category = game_description2.find('b').text

                # Znalezienie daty i zamiana nazwy miesiąca na liczbę
                release_date_text = game_description2.get_text(strip=True)

                for month_name, month_number in month_map.items():
                    if month_name in release_date_text:
                        release_date_text = release_date_text.replace(month_name, f"/{month_number}/")
                        break

                # Usunięcie zbędnych znaków oraz formatowanie daty na RRRR/MM/DD
                release_date_text = release_date_text.replace(category, '').strip()
                release_date_parts = release_date_text.split()

                if len(release_date_parts) >= 3:
                    day = release_date_parts[0].zfill(2)  # Dodanie wiodącego zera, jeśli dzień jest jednocyfrowy
                    year = release_date_parts[-1]
                    formatted_date = f"{year}/{release_date_parts[1]}/{day}"

                # Zastąp dwa ukośniki jednym
                release_date = formatted_date.replace("//", "-")
                response_game = requests.get(link)

                if response_game.status_code == 200:
                    soup_game = BeautifulSoup(response_game.text, 'html.parser')

                    # Pobranie dwóch dodatkowych danych ze strony gry (o konkretnych ID)
                    developer_span = soup_game.find('span', id='game-developer-cnt').text
                    publisher_span = soup_game.find('span', id='game-publisher-cnt').text

                    # Usunięcie słów "Producent" i "Wydawca" z pobranych stringów
                    developer_span = developer_span.replace('producent: ', '')
                    publisher_span = publisher_span.replace('wydawca: ', '')
                else:
                    print(f"Nie udało się pobrać danych z podstrony dla gry: {game_title}")
            else:
                print('Brak opisu gry - brak danych')
                continue

            platforms = None

            if game_platform:
                platform_links = game_platform.find_all('a')
                platforms = ', '.join(platform.text for platform in platform_links)
            else:
                print('Brak informacji o platformach')
                continue

            game_info = {
                "Name": game_title,
                "Description": game_description,
                "CoverPath": game_image['data-src'] if game_image else None,
                "Category": category,
                "ReleaseDate": release_date,
                "Platform": platforms,  # Używamy zmiennej platforms
                "Developer": developer_span,
                "Publisher": publisher_span,

            }

            games_data.append(game_info)  # Dodaj informacje o grze do listy

        with open(f'{category_name}.json', 'w', encoding='utf-8') as file:
            json.dump(games_data, file, indent=4)  # Zapisz dane w formacie JSON

    else:
        print("Nie udało się pobrać strony.")


