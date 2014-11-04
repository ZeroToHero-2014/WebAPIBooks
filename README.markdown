Plan de lecție
==============

1. Ce e HTTP?

2. Exemplu pe http://www.youtypeitwepostit.com/

3. Ce sunt Web APIs?

4. Exemplu pe http://www.youtypeitwepostit.com/api/

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

6. Implement Put(), try from Fiddler:

    ```
    
        PUT http://localhost:56706/api/Books/9103c9dc-45b6-483e-bece-421565e74108 HTTP/1.1
        Host: localhost:56706
        Content-Type: application/json
        Accept: application/json
    
        {
            "Id": "9103c9dc-45b6-483e-bece-421565e74108",
            "Title": "Habibi",
            "Subtitle": "A graphic novel",
            "Publisher" : {
                "Id": "79d2a6a2-341a-44b0-991a-2a5bc8060e28",
                "Name": "Pantheon Books"
            },
            "Authors": ["Craig Thompson"]
        }
    ```
