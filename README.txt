Po pobraniu kodu z githuba nale�y wykona� aktualizacj� bazy danych poprzez przeprowadzenie migracji. Utworzy ona tabel�, w kt�rej 
przechowywane s� dane pobrane z API NBP. 

Api jest gotowe do dzia�ania. Po w��czeniu go nale�y skierowa� zapytanie przez nast�puj�c� �cie�k� - currency/{date}/{code}, gdzie 
{date} to data w formacie yyyy-mm-dd, a {code} to kod danej waluty. 
Przyk�ad - https://localhost:7224/currency/2023-06-20/czk
Zapisane dane - 
{
    "id": 1234,
    "currency": "korona czeska",
    "code": "CZK",
    "effectiveDate": "2023-06-20",
    "bid": 0.18520000576972961,
    "ask": 0.1889999955892563
}
Api przy pobraniu danych sprawdza czy na dany dzie� NBP posiada informacje o kursie kupna i sprzeda�y. W przypadku ich braku zwraca kod 404. 
Api przy zapisie danych do bazy sprawdza czy na dany dzie�, dla danej waluty nie ma ju� rekordu w bazie danych. W przypadku istnienia takiego 
pominie zapis by nie tworzy� duplikatu. 