Plan de lecție
==============

1. Creat controller with read/write actions, implementat Get
2. Văzut răspuns în browser (xml)
3. Fiddler, Composer, Accept: application/json
4. Implement Get(id)
5. Implement Post(), try from Fiddler:
```
    POST http://localhost:56706/api/Books/ HTTP/1.1
    Host: localhost:56706
    Content-Type: application/json
    Accept: application/json

    {"Title": "Renaming of the Birds"}
```
6.
