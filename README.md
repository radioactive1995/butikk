## Demo webApi som håndterer handlekurv forespørsel.
### Benytt swagger til å teste endepunkt: 
https://localhost:7145/swagger/index.html

typeVare: 0 --> PLU A
typeVare: 1 --> PLU B
typeVare: 2 --> PLU C

Eksempel JSON payload foresporsel:
```json
{
  "varer": [
    {
      "typeVare": 0,
      "antall": 14
    },

    {
      "typeVare": 1,
      "antall": 13
    },

    {
      "typeVare": 2,
      "antall": 7.47
    }
  ]
}
```

Forventet **200 OK** respons:
```json
{
  "beregnetSum": 5140
}
```
