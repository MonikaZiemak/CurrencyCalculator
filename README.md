# CurrencyCalculator

**CurrencyCalculator** to prosta konsolowa aplikacja napisana w języku C#, która przelicza podaną kwotę w euro (EUR) na bitcoiny (BTC) na podstawie aktualnego kursu wymiany pobranego z API **Alpha Vantage**.


## Funkcjonalność

- Pobiera kurs wymiany BTC/EUR z serwisu [Alpha Vantage](https://www.alphavantage.co/).
- Umożliwia użytkownikowi wpisanie kwoty w euro.
- Przelicza EUR na BTC i wyświetla wynik z dokładnością do 8 miejsc po przecinku.
- Obsługuje błędne dane wejściowe i nieudane odpowiedzi z API.


## Przykładowe użycie

Podaj kwotę w EUR: 100
Podaj swój klucz API: ************
Odpowiedź API:
{...}
100 EUR = 0.00123456 BTC
Naciśnij dowolny klawisz, aby zakończyć...


## Technologie

- C# / .NET
- Konsola (CLI)
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)
- API: [Alpha Vantage - Currency Exchange Rate](https://www.alphavantage.co/documentation/#currency-exchange)


## Jak uruchomić

1. **Uzyskaj darmowy klucz API**:
   - Zarejestruj się na stronie [Alpha Vantage](https://www.alphavantage.co/support/#api-key)
   - Otrzymasz klucz API, skopiuj go.

2. **Sklonuj repozytorium lub pobierz kod**:
   ```bash
   git clone https://github.com/MonikaZiemak/CurrencyCalculator
   

3. **Otwórz projekt w Visual Studio 2022**

4. **Przywróć pakiety NuGet**:
   - Kliknij prawym przyciskiem myszy projekt > **Restore NuGet Packages**
   - Upewnij się, że zainstalowany jest pakiet `Newtonsoft.Json`

5. **Uruchom aplikację (`F5`)**


## Struktura API (przykład odpowiedzi)

Alpha Vantage zwraca dane w formacie JSON. Aplikacja automatycznie przetwarza odpowiedź i oblicza kurs EUR → BTC.


## Uwagi

- Kurs BTC do EUR jest pobierany, ale następnie przeliczany na EUR → BTC (1 / rate).
- Alpha Vantage może mieć ograniczenie liczby zapytań na minutę/dzień (FREE tier).
- Wymagana jest poprawna obsługa separatora dziesiętnego w zależności od kultury systemu.


## Licencja

Ten projekt jest dostępny na licencji MIT – możesz go dowolnie używać i modyfikować.


## Autor

Projekt stworzony w celach edukacyjnych, jako ćwiczenie nauki C# oraz pracy z API.
