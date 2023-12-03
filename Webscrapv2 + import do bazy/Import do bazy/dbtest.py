import psycopg2

conn = psycopg2.connect(
    host="localhost",
    database="GamesUp",
    user="postgres",
    password="admin"
)

name = "Games"

cur = conn.cursor()
cur.execute("SELECT * FROM \"" + name+ "\";")
