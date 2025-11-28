# 🚀 Projekt - Konsumera Web API

## 📋 Projektbeskrivning

Konsolapplikation som kommunicerar med REST-tjänster för att hämta och visa data i JSON-format. Projektet demonstrerar praktisk användning av HTTP-förfrågningar och JSON-deserialisering i C#.

**API**
* **GitHub API** : Information om .NET Foundation repositories
* **Zippopotam API** : Geografisk information om Montvale, New Jersey

## 🎯 Mål

Lära sig:
* Skicka HTTP-förfrågningar (HTTP requests)
* Deserialisera JSON-svar till C#-objekt
* Konfigurera deserialisering med attribut
* Hantera asynkron programmering med async/await

## 📊 Genomförda övningar

### Del 1: GitHub API (Godkänt)

**✅ HTTP Request till GitHub**  
Anrop till GitHubs API för att hämta .NET Foundation repositories.  
**Kompetenser:** `HttpClient`, `GetAsync()`, HTTP headers

**✅ Deserialisera JSON**  
Konvertering av JSON-data till C#-objekt.  
**Kompetenser:** `JsonSerializer.Deserialize()`, generiska typer

**✅ Konfigurera mappning**  
Mappning mellan JSON-fält (name) och C#-properties (Name).  
**Kompetenser:** `[JsonPropertyName]`, attribut, PascalCase vs camelCase

**✅ Visa data**  
Formaterad utskrift av repository-information.  
**Kompetenser:** String interpolation, datum-formatering, null-hantering

### Del 2: Zippopotam API (Väl Godkänt)

**✅ Hämta geografisk data**  
Anrop till Zippopotam för att hämta information om Montvale, NJ.  
**Kompetenser:** RESTful API:er, URL-parametrar

**✅ Deserialisera komplex JSON**  
Hantering av JSON med nestlade objekt och arrayer.  
**Kompetenser:** Komplexa datastrukturer, `List<T>`

**✅ Felhantering**  
Robust hantering av HTTP-fel och exceptions.  
**Kompetenser:** `try-catch`, `HttpRequestException`, error handling

## 🛠️ Tekniker

* **Språk:** C# / .NET 6+
* **HTTP:** `HttpClient`, `HttpResponseMessage`
* **JSON:** `System.Text.Json`, `JsonSerializer`
* **Asynkron programmering:** `async/await`, `Task`
* **Attribut:** `[JsonPropertyName]`

## 📁 Projektstruktur

```
Laboration4_API/
Projekt konsumera API del G
├── Program.cs          # Huvudprogram med API-anrop
├── Repository.cs       # Modellklass för GitHub repositories
Projekt konsumera API del VG
├── Program.cs          # Huvudprogram med API-anrop
├── Repository.cs       # Modellklass för GitHub repositories
└── ZipLocation.cs       # Modellklasser för Zippopotam API
```

## 🚀 Installation

```bash
# Klona repositoryt
git clone https://github.com/[ditt-användarnamn]/Laboration4_API.git

# Gå till projektmappen
cd Laboration4_API

# Kör programmet
dotnet run


## 📋 Krav

* .NET 6.0 eller senare
* Internetanslutning
* Visual Studio 2022 (eller annan C# IDE)

##  Lärdomar

* Hur man konsumerar externa REST-API:er
* JSON-deserialisering och mappning
* Asynkron programmering i C#
* HTTP-kommunikation med HttpClient
* Felhantering vid nätverksoperationer



---

*Detta projekt är skapat för utbildningsändamål.*
