import psycopg2
import json

# Lista nazw plików JSON
json_files = ['akcji.json', 'przygodowe.json', 'rpg.json', 'sportowe.json', 'strategiczne.json', 'symulacje.json', 'wyscigi.json', 'zrecznosciowe.json']

# Połącz się z bazą danych
conn = psycopg2.connect(
    host="localhost",
    database="GamesUp",
    user="postgres",
    password="admin"
)

# Utwórz kursor do wykonania zapytań
cur = conn.cursor()

# Iteruj przez nazwy plików JSON
for json_file in json_files:
    # Otwórz plik JSON
    with open(json_file, 'r', encoding='UTF-8') as file:
        data = json.load(file)

        # Iteruj przez dane i wstaw do tabeli
        for entry in data:
            cur.execute("""
                INSERT INTO Games (Name, Description, CoverPath, Category, ReleaseDate, Platform, Developer, Publisher)
                VALUES (%s, %s, %s, %s, %s, %s, %s, %s);
            """, (
                entry['Name'],
                entry['Description'],
                entry['CoverPath'],
                entry['Category'],
                entry['ReleaseDate'],
                entry['Platform'],
                entry['Developer'],
                entry['Publisher']
            ))

# Zatwierdź zmiany i zamknij połączenie
conn.commit()
cur.close()
conn.close()
